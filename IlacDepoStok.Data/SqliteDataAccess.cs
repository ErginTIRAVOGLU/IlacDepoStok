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
    }
}
