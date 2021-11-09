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


        /// <summary>
        /// Возвращает количество льготников.
        /// </summary>
        /// <param name="stringConnection">Строка подключения к БД</param>
        /// <param name="query">SQL запрос к БД</param>
        /// <param name="nameTable">Название таблицы в DataSet</param>
        /// <returns></returns>
        public static int GetDateCountPerson(string stringConnection, string query, string nameTable, List<LogError> listError, string region)
        {
            DataSet ds = new DataSet();

            int result = 0;

            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                try
                {
                    con.Open();

                    SqlCommand com = new SqlCommand(query, con);
                    com.CommandTimeout = 0;

                    SqlDataAdapter da = new SqlDataAdapter(com);

                    da.Fill(ds, nameTable);

                    if(ds.Tables[0] != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
                    {
                        result = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    }
                }
                catch (Exception ex)
                {
                    
                    // Создадим лог.
                    LogError logError = new LogError();

                    // Описание ошибки.
                    logError.MessageError = "Ошибка при выполнении запроса - " + ex.Message;

                    // Район области, где произошла ошибка.
                    logError.Region = region;

                    // Добавим ошибку в список ошибок.
                    listError.Add(logError);

                    result = 0;
                }
            }

            return result;
        }

        /// <summary>
        /// Асинхронное заполнение таблицы 
        /// </summary>
        /// <param name="stringConnection"></param>
        /// <param name="query"></param>
        /// <param name="nameTable"></param>
        /// <returns></returns>
        public static async Task<int> GetDataTableAsync(SqlConnection con, SqlCommand com)
        {
            await con.OpenAsync();
            await com.ExecuteNonQueryAsync();
            return 1;
        }
    }
}
