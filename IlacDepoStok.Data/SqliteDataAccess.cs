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

        public static void UpdateCari(CariModel cariModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update cari SET cari_ad_soyad=@cari_ad_soyad,cari_kategori_id=@cari_kategori_id WHERE cari_id=@cari_id", cariModel);
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

        public static void SaveCari(CariModel cariModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into cari(cari_ad_soyad,cari_kategori_id) values (@cari_ad_soyad,@cari_kategori_id)", cariModel);
            }
        }

        public static void SaveHareket(HareketModel hModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into hareket(yon, adet, ilac_id, depo_id, tarih) values (@yon, @adet, @ilac_id, @depo_id, @tarih)", hModel);
            }
        }
        
        public static void SaveIlac(IlacModel ilac)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into ilac(adi, barcode, notu,dusukStok) values (@adi, @barcode, @notu, @dusukStok)", ilac);
            }
        }

        private static string LoadConnectionString(string id="Default")
        {
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
                cnn.Execute("update ilac SET adi=@adi, barcode=@barcode, notu=@notu,dusukStok=@dusukStok WHERE id=@id", ilac);
            }
        }

        public static IlacModel findIlacbyBarkod(string barkod)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<IlacModel>("select * from ilac where barcode=@barcode", new {barcode= barkod });
                return output;
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

        public static List<HareketModel> findHareketbyTarih(string htarih)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HareketModel>("select hareket.id, date(hareket.tarih) as tarih, hareket.yon, hareket.adet, hareket.ilac_id, hareket.depo_id,ilac.adi as ilac_adi, depo.adi AS depo_adi from hareket inner join ilac on ilac.id=hareket.ilac_id inner join depo on depo.id=hareket.depo_id where tarih=@tarih order by date(tarih) desc, hareket.id desc", new { tarih = htarih });
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

        public static List<StokModel> stokDurumu(int depoid)
        {
            if(depoid==0)
            { 
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<StokModel>("select i1.*, IFNULL(i2.giren,0)as gireni, IFNULL(i3.cikan,0) as cikani, (IFNULL(i2.giren,0)-IFNULL(i3.cikan,0)) as Stok from ilac as i1 left join (select ilac.id, IFNULL(sum(adet),0)as giren from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'G' GROUP by ilac_id) as i2 on i2.id = i1.id left join (select ilac.id, IFNULL(sum(adet),0) as cikan from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'C' GROUP by ilac_id) as i3 on i3.id = i1.id");
                    return output.ToList();
                }
            }
            else
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<StokModel>("select i1.*, IFNULL(i2.giren,0)as gireni, IFNULL(i3.cikan,0) as cikani, (IFNULL(i2.giren,0)-IFNULL(i3.cikan,0)) as Stok from ilac as i1 left join (select ilac.id, IFNULL(sum(adet),0)as giren from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'G' and hareket.depo_id="+depoid+ " GROUP by ilac_id) as i2 on i2.id = i1.id left join (select ilac.id, IFNULL(sum(adet),0) as cikan from hareket left join ilac on ilac.id = hareket.ilac_id where hareket.yon = 'C' and hareket.depo_id=" + depoid + " GROUP by ilac_id) as i3 on i3.id = i1.id");
                    return output.ToList();
                }
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
        public static void cariKategoriSil(int kategoriId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from cari_kategori WHERE cari_kategori_id=@cari_kategori_id", new { cari_kategori_id = kategoriId });
            }
        }
        
        private string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }
    }
}
