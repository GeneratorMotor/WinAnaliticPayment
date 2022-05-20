using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace WinAnaliticPayment.Classess
{
    public static class DataTableBD
    {
        
        public static DataTable GetTable(string query, string connectionString, string nameTable)
        {
            DataSet ds = new DataSet();
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand com = new SqlCommand(query, con);
                    com.CommandTimeout = 0;

                    SqlDataAdapter da = new SqlDataAdapter(com);

                    da.Fill(ds, nameTable);
                }
                catch (Exception ex)
                {
                    DataTable dataTable = new DataTable();

                    ds.Tables.Add(dataTable);
                }
                //con.Close();
            }

            return ds?.Tables[0]??null ;
        }

        public static DataTable GetTable(string query, string connectionString, string nameTable, List<LogError> listError, string region)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand com = new SqlCommand(query, con);
                    com.CommandTimeout = 0;

                    SqlDataAdapter da = new SqlDataAdapter(com);

                    da.Fill(ds, nameTable);
                }
                catch (Exception ex)
                {
                    DataTable dataTable = new DataTable();

                    ds.Tables.Add(dataTable);

                    LogError logError = new LogError();
                    logError.MessageError = ex.Message.Trim();
                    logError.Region = region;

                    listError.Add(logError);
                }
                //con.Close();
            }

            return ds?.Tables[0] ?? null;
        }

        //public static async Task<DataTable> GatTableAsync(string query, string connectionString, string nameTable)
        //{
        //    DataSet ds = new DataSet();

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();

        //        SqlCommand com = new SqlCommand(query, con);
        //        com.CommandTimeout = 0;

        //        SqlDataAdapter da = new SqlDataAdapter(com);

        //        da.Fill(ds, nameTable);
        //        //con.Close();
        //    }

        //    return ds.Tables[0];
        //}
    }
}
