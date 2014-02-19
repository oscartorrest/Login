using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Login
{
    public class SQLHelper
    {
        public static DataTable runStoredProcedure(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection("data source=localhost;user id=publico;password=12345678");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(reader);
            reader.Close();
            con.Close();
            return tabla;
        }
    }
}