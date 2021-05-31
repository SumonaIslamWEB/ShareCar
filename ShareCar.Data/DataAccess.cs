using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ShareCar.Data
{
    public class DataAccess
    {
        private static SqlConnection sqlCon;

        public static SqlConnection SqlCon
        {
            get
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(@"Data Source=HP_PROBOOK\SQLEXPRESS;Initial Catalog=ShareCar2DB;Integrated Security=True");
                }
                else if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                }
                return sqlCon;
            }
        }

        public static DataSet GetDataSet(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, SqlCon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }



        public static DataTable GetDataTable(string query)
        {
            var ds = GetDataSet(query);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        public static int ExecuteUpdateQuery(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, SqlCon);
            return sqlCommand.ExecuteNonQuery();

        }

        public static SqlDataReader ExecuteQuery(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, SqlCon);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            return dataReader;
        }
    }
}
