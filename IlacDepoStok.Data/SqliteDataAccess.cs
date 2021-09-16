using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlacDepoStok.Data
{
    public class SqliteDataAccess
    {
        [SQLiteFunction(FuncType = FunctionType.Collation, Name = "UTF8CI")]
        public class SQLiteCaseInsensitiveCollation : SQLiteFunction
        {
            private static readonly System.Globalization.CultureInfo _cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("tr-TR");
            public override int Compare(string x, string y)
            {
                return string.Compare(x, y, _cultureInfo, System.Globalization.CompareOptions.IgnoreCase);
            }
        }

        public static List<IlacModel> LoadIlaclar()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<IlacModel>("select * from ilac", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveDepo(DepoModel depo)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into depo(adi) values (@adi)", depo);
            }
        }
        public static Cari_Kategori_Model getCariWithKategoribyCariId(int? cariId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Cari_Kategori_Model>("select * from cari inner join cari_kategori on cari_kategori.cari_kategori_id==cari.cari_kategori_id where cari_id = @cari_id", new { cari_id = cariId });
                return output.FirstOrDefault();
            }
        }
        public static CariModel getCaribyCariId(int? cariId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CariModel>("select * from cari where cari_id = @cari_id", new { cari_id = cariId });
                return output.FirstOrDefault();
            }
        }
        public static DepoModel getDepobyDepoId(int? depoId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DepoModel>("select * from depo where id = @id", new { id = depoId });
                return output.FirstOrDefault();
            }
        }
        public static void UpdateCari(CariModel cariModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update cari SET cari_ad_soyad=@cari_ad_soyad,cari_kategori_id=@cari_kategori_id,cari_telefon=@cari_telefon,cari_adres=@cari_adres,cari_not=@cari_not WHERE cari_id=@cari_id", cariModel);
            }
        }


        public static List<DepoModel> LoadDepolar()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DepoModel>("select * from depo order by adi", new DynamicParameters());
                return output.ToList();
            }
        }

        public static KategoriModel GetCariKategoribyId(int cariKategoriId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KategoriModel>("select * from cari_kategori where cari_kategori_id = @cari_kategori_id order by cari_kategori_adi", new { cari_kategori_id = cariKategoriId });
                return output.FirstOrDefault();
            }
        }

        public static List<HareketModel> findHareketbyCariId(int? cariId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HareketModel>("select   CAST(hareket.fiyat AS FLOAT)/100 as fiyat, cast(hareket.tutar as float)/100 as tutar, hareket.id, date(hareket.tarih) as tarih, hareket.yon, hareket.adet, hareket.ilac_id, hareket.depo_id,ilac.adi as ilac_adi, depo.adi AS depo_adi from hareket inner join ilac on ilac.id=hareket.ilac_id inner join depo on depo.id=hareket.depo_id inner join cari on cari.cari_id=hareket.cari_id where cari.cari_id=@cari_id order by date(tarih) desc, hareket.id desc", new { cari_id = cariId });
                return output.ToList();
            }
        }

        public static void SaveCari(CariModel cariModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into cari(cari_ad_soyad,cari_kategori_id,cari_telefon,cari_adres,cari_not) values (@cari_ad_soyad,@cari_kategori_id,@cari_telefon,@cari_adres,@cari_not)", cariModel);
            }
        }

        public static void SaveHareket(HareketModel hModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into hareket(yon, adet, ilac_id, depo_id, tarih, cari_id, tutar, fiyat, ilac_adi, cariadsoyad, depo_adi) values (@yon, @adet, @ilac_id, @depo_id, @tarih, @cari_id, @tutar, @fiyat, @ilac_adi, @cariadsoyad, @depo_adi)", hModel);
            }
        }

        public static void updateHareket(HareketModel hareket)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update hareket SET yon=@yon, adet=@adet, ilac_id=@ilac_id, depo_id=@depo_id, tarih=@tarih, cari_id=@cari_id, tutar=@tutar, fiyat=@fiyat, ilac_adi=@ilac_adi, cariadsoyad=@cariadsoyad, depo_adi=@depo_adi WHERE id=@id", hareket);
            }
        }

        public static void SaveIlac(IlacModel ilac)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into ilac(adi, barcode, notu,dusukStok,fiyat) values (@adi, @barcode, @notu, @dusukStok,@fiyat)", ilac);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            SQLiteFunction.RegisterFunction(typeof(SQLiteCaseInsensitiveCollation));
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static List<HareketModel> findHareketbyIlacId(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HareketModel>("select * from hareket where ilac_id=@ilac_id order by tarih desc", new { ilac_id = id });
                return output.ToList();
            }
        }

        public static void updateIlac(IlacModel ilac)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update ilac SET adi=@adi, barcode=@barcode, notu=@notu, dusukStok=@dusukStok, fiyat=@fiyat WHERE id=@id", ilac);
            }
        }

        public static IlacModel findIlacbyBarkod(string barkod)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<IlacModel>("select * from ilac where barcode=@barcode", new { barcode = barkod });
                return output;
            }
        }

        public static IlacModel findIlacbyId(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<IlacModel>("select * from ilac where id=@id", new { id = id });
                return output;
            }
        }

        public static HareketModel getHareketbyId(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<HareketModel>("select * from hareket where id=@id", new { id = id });
                return output;
            }
        }
        public static void hareketSilbyId(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from hareket where id=@id", new { id = id });
            }
        }
        public static void hareketYonDegistirbyId(int id, string yon)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update hareket SET yon=@yon where id=@id", new { id = id, yon = yon });
            }
        }
        public static void updateDepo(DepoModel depo)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update depo SET adi=@adi WHERE id=@id", depo);
            }
        }

        public static int findIlacStokbyBarkod(string barkod)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("select (IFNULL(i2.giren,0)-IFNULL(i3.cikan,0)) as Stok from ilac as i1 left join (select ilac.id, IFNULL(sum(adet),0)as giren from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'G' GROUP by ilac_id) as i2 on i2.id = i1.id left join (select ilac.id, IFNULL(sum(adet),0) as cikan from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'C' GROUP by ilac_id) as i3 on i3.id = i1.id Where barcode=@barcode", new { barcode = barkod });
                return output.FirstOrDefault();
            }
        }
        public static int findIlacStokbyid(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("select (IFNULL(i2.giren,0)-IFNULL(i3.cikan,0)) as Stok from ilac as i1 left join (select ilac.id, IFNULL(sum(adet),0)as giren from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'G' GROUP by ilac_id) as i2 on i2.id = i1.id left join (select ilac.id, IFNULL(sum(adet),0) as cikan from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'C' GROUP by ilac_id) as i3 on i3.id = i1.id Where i1.id=@id", new { id = id });
                return output.FirstOrDefault();
            }
        }


        public static void cariSil(int cariId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from cari WHERE cari_id=@cari_id", new { cari_id = cariId });
            }
        }

        public static void DeleteDepo(int depoId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from depo WHERE id=@id", new { id = depoId });
            }
        }

        public static void DeleteHareketbyIlacId(int ilacId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from hareket WHERE ilac_id=@id", new { id = ilacId });
            }
        }

        public static void DeleteIlac(int ilacId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from ilac WHERE id=@id", new { id = ilacId });
            }
        }
        
        public static List<HareketModel> findHareketbyTarih(string htarih)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HareketModel>("select cari.cari_ad_soyad as cariadsoyad, hareket.id, date(hareket.tarih) as tarih, hareket.yon, hareket.adet, hareket.ilac_id, hareket.depo_id,ilac.adi as ilac_adi, depo.adi AS depo_adi from hareket inner join ilac on ilac.id=hareket.ilac_id inner join depo on depo.id=hareket.depo_id inner join cari on cari.cari_id=hareket.cari_id where tarih=@tarih order by date(tarih) desc, hareket.id desc", new { tarih = htarih });
                return output.ToList();
            }
        }

        public static List<StokModel> stokUyari()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StokModel>("select i1.*, IFNULL(i2.giren,0)as gireni, IFNULL(i3.cikan,0) as cikani, (IFNULL(i2.giren,0)-IFNULL(i3.cikan,0)) as Stok from ilac as i1 left join (select ilac.id, IFNULL(sum(adet),0) as giren from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'G' GROUP by ilac_id) as i2 on i2.id = i1.id left join (select ilac.id, IFNULL(sum(adet),0) as cikan from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'C' GROUP by ilac_id) as i3 on i3.id = i1.id where dusukStok >= kalan");
                return output.ToList();
            }
        }

        public static CariModel findCaribyCariId(int? cariId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<CariModel>("select * from cari where cari_id=@cari_id", new { cari_id = cariId });
                return output;
            }
        }

        public static List<StokModel> stokDurumu(int depoid)
        {
            if (depoid == 0)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<StokModel>("select i1.*, IFNULL(i2.giren,0)as gireni, IFNULL(i3.cikan,0) as cikani, (IFNULL(i2.giren,0)-IFNULL(i3.cikan,0)) as Stok from ilac as i1 left join (select ilac.id, IFNULL(sum(adet),0)as giren from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'G' GROUP by ilac_id) as i2 on i2.id = i1.id left join (select ilac.id, IFNULL(sum(adet),0) as cikan from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'C' GROUP by ilac_id) as i3 on i3.id = i1.id order by adi");
                    return output.ToList();
                }
            }
            else
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<StokModel>("select i1.*, IFNULL(i2.giren,0)as gireni, IFNULL(i3.cikan,0) as cikani, (IFNULL(i2.giren,0)-IFNULL(i3.cikan,0)) as Stok from ilac as i1 left join (select ilac.id, IFNULL(sum(adet),0)as giren from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'G' and hareket.depo_id=@depoid GROUP by ilac_id) as i2 on i2.id = i1.id left join (select ilac.id, IFNULL(sum(adet),0) as cikan from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'C' and hareket.depo_id=@depoid GROUP by ilac_id) as i3 on i3.id = i1.id order by adi", new { depoid = depoid });
                    return output.ToList();
                }
            }
        }

        public static List<StokHareketModel> stokDurumubyIlacId(int ilac_id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StokHareketModel>("select hareket.id, ilac.adi as ilac_adi, ilac.barcode, cari.cari_ad_soyad, depo.adi as depo_adi, hareket.yon, hareket.tarih,  CAST(hareket.fiyat AS FLOAT)/100 as fiyat, hareket.adet, CAST(hareket.tutar AS FLOAT)/100 as tutar from hareket inner join ilac on ilac.id == hareket.ilac_id inner join depo on depo.id == hareket.depo_id inner join cari on cari.cari_id == hareket.cari_id where ilac.id==@ilac_id order by hareket.id desc;", new { ilac_id = ilac_id });
                return output.ToList();
            }
        }

        public static void SaveCariKategori(KategoriModel kategori)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into cari_kategori(cari_kategori_adi) values (@cari_kategori_adi)", kategori);
            }
        }
        public static void UpdateCariKategori(KategoriModel kategori)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update cari_kategori SET cari_kategori_adi=@cari_kategori_adi WHERE cari_kategori_id=@cari_kategori_id", kategori);
            }
        }

        public static List<KategoriModel> LoadCariKategoriler()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KategoriModel>("select * from cari_kategori order by cari_kategori_adi", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<CariModel> LoadCariler(int KategoriID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CariModel>("select * from cari where cari_kategori_id=@cari_kategori_id order by cari_ad_soyad", new { cari_kategori_id = KategoriID });
                return output.ToList();
            }
        }

        public static List<CariModel> LoadCarilerbyCariAdi(string cariAdi)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CariModel>("select * from cari where cari_ad_soyad like @cari_ad_soyad order by cari_ad_soyad", new { cari_ad_soyad = "%" + cariAdi + "%" });
                return output.ToList();
            }
        }
        public static List<CariModel> LoadCarilerKategoriilebyCariAdi(int kategoriId, string cariAdi)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CariModel>("select * from cari where  cari_kategori_id=@cari_kategori_id and cari_ad_soyad like @cari_ad_soyad order by cari_ad_soyad", new { cari_kategori_id = kategoriId, cari_ad_soyad = "%" + cariAdi + "%" });
                return output.ToList();
            }
        }
        public static void cariKategoriSil(int kategoriId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from cari_kategori WHERE cari_kategori_id=@cari_kategori_id", new { cari_kategori_id = kategoriId });
            }
        }

        public static List<KategoriModel> LoadCariKategorilerbyKategoriAdi(string kategoriAdi)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KategoriModel>("select * from cari_kategori where cari_kategori_adi like @cari_kategori_adi order by cari_kategori_adi", new { cari_kategori_adi = "%" + kategoriAdi + "%" });
                return output.ToList();
            }
        }

        private string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }
    }
}
