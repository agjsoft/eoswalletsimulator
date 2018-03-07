using System;
using System.Data.SQLite;

namespace EOSWallet
{
    public static class DB
    {
        public static string SqliteFileName = "eos.db";
        private static SQLiteConnection SqlCon = new SQLiteConnection("Data Source=eos.db");

        public static void Open()
        {
            SqlCon.Open();
        }

        public static void Close()
        {
            SqlCon.Close();
        }

        public static void RunQuery(string qry)
        {
            new SQLiteCommand(qry, SqlCon).ExecuteNonQuery();
        }

        public static void RunReadQuery(string qry, Action<SQLiteDataReader> func)
        {
            var rdr = new SQLiteCommand(qry, SqlCon).ExecuteReader();
            while (rdr.Read())
            {
                func(rdr);
            }
            rdr.Close();
        }
    }
}