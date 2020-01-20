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

        public static List<DepoModel> LoadDepolar()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DepoModel>("select * from depo order by adi", new DynamicParameters());
                return output.ToList();
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

        private string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }
    }
}
