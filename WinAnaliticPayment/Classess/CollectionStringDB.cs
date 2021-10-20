using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    /// <summary>
    /// Строки подключения к БД ЭСРН.
    /// </summary>
    public class CollectionStringDB
    {
        public Dictionary<string,string> StringConnectionsEsrn()
        {
            // Запрос к БД.
            IQuery query = new GetQueryConnectionStrings();
            string queryConnectionString = query.Query();

            // Получим таблицу сос троками подключения
            DataTable tab = ТаблицаБД.GetDataTable(StringConnectionDB.StringConnection(), queryConnectionString, "СтрокиПодключенияЭСРН");

            var dic = SqlGetTable(tab);

            return dic;
        }

        private Dictionary<string, string> SqlGetTable(DataTable dataTable)
        {
            // Словарь для хранения строк подключения к БД ЭСРН по Саратовской области.
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string config = "";
            string key = "";

            // Сформируем строки подключения к БД ЭСРН.
            foreach(DataRow row in dataTable.Rows)
            {
                // Район.
                key = row["район"].ToString();


                config = @"Data Source=" + row["ip"].ToString().Trim() + ";Initial Catalog=" + row["имя БД"].ToString() + ";User ID=" + row["Логин"].ToString() + ";Password=" + row["пароль"].ToString() + "";
                //config = @"Data Source=" +"10.159.70.28" + ";Initial Catalog=" + row["имя БД"].ToString() + ";User ID=" + row["Логин"].ToString() + ";Password=" + row["пароль"].ToString() + "";

                dic.Add(key, config);
            }

            return dic;
        }
    }
}
