using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WinAnaliticPayment.Classess
{
    public static class ТаблицаБД
    {
        /// <summary>
        /// Возвращает таблицу БД из SQL запроса.
        /// </summary>
        /// <param name="stringConnection">SQL звапрос</param>
        /// <param name="nameTable">Название таблицы</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string stringConnection, string query, string nameTable)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                try
                {
                    con.Open();

                    SqlCommand com = new SqlCommand(query, con);
                    com.CommandTimeout = 0;

                    SqlDataAdapter da = new SqlDataAdapter(com);

                    da.Fill(ds, nameTable);
                }
                catch(Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка при выполнении запроса - " + query + " описание ошибки  - " + ex.Message);
                }
            }

            return ds.Tables[0];
        }
    }
}
