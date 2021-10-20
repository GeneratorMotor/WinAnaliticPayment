using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public static class DataTableBD
    {
        
        public static DataTable GetTable(string query, string connectionString, string nameTable)
        {
            DataSet ds = new DataSet();
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(query, con);
                com.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(com);

                da.Fill(ds, nameTable);
                //con.Close();
            }

            return ds.Tables[0];
        }

        public static async Task<DataTable> GatTableAsync(string query, string connectionString, string nameTable)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(query, con);
                com.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(com);

                da.Fill(ds, nameTable);
                //con.Close();
            }

            return ds.Tables[0];
        }
    }
}
