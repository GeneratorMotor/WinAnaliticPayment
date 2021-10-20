using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class DataTableAsync
    {
        private string query = string.Empty;
        private string connectionString = string.Empty;
        private string nameTable = string.Empty;

        public DataTableAsync(string query, string connectionString, string nameTable)
        {
            this.query = query ?? throw new ArgumentNullException(nameof(query));
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this.nameTable = nameTable ?? throw new ArgumentNullException(nameof(nameTable));
        }

        public async Task<DataTable> GetDataTableAsync()
        {
            try
            {
                return await Task.FromResult(GetTable());
            }
            catch(Exception ex)
            {
                return await Task.FromException<DataTable>(ex);
            }
        }

      

        private DataTable GetTable()
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                 con.Open();
                SqlCommand com = new SqlCommand(this.query, con);
                com.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(com);

                da.Fill(ds, this.nameTable);
                //con.Close();
            }

            return ds.Tables[0];
        }
    }
}
