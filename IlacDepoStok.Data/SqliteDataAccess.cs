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

        public static void SaveIlac(IlacModel ilac)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into ilac(adi, barcode, notu) values (@adi, @barcode, @notu)", ilac);
            }
        }

        private static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
