using System.Data;
using Npgsql;

namespace Arkanoid
{
    public static class DataBaseController
    {
        private static string Conection = 
            "Server=127.0.0.1;Port=5432;User Id=postgres;Password=admin;Database=Arkanoid";
        
        public static DataTable ExecuteQuery(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(Conection);
            DataSet ds = new DataSet();
            
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
             
            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(Conection);
            
            conn.Open();
            NpgsqlCommand nc = new NpgsqlCommand(sql, conn);
            nc.ExecuteNonQuery();
            conn.Close();
        }
        
    }
}