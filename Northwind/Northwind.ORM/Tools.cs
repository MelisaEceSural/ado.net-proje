using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;// Appconfig dosyasından veri okuyacağım
using System.Data;

namespace Northwind.ORM
{
    class Tools
    {

        private static SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["MyNorthwind"].ConnectionString);

        public static SqlConnection Baglanti
        {
            get { return baglanti; }
            set { baglanti = value; }
        }

        public static DataTable Listele(string storedProcedure)
        {
            SqlDataAdapter adp = new SqlDataAdapter(storedProcedure, Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();// bağlantı açık değilse aç

                return command.ExecuteNonQuery() > 0;// geriye bool döndürür
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed)
                    command.Connection.Close();// bağlantı kapalı değilse kapat
            }
        }

    }
}
