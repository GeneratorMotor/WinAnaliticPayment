using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinAnaliticPayment.Classess;
using System.Collections.Generic;
using System.Data;

namespace WinAnaliticPayment.ClassessEspb
{
    public class CollectionStringEspb
    {
        private IQuery query;

        public CollectionStringEspb(IQuery query)
        {
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public Dictionary<string, string> StringConnectionsEsrn()
        {
            // Запрос к БД.
            IQuery query = new GetConnectionString();
            string queryConnectionString = query.Query();

            // Получим таблицу сос троками подключения
            DataTable tab = ТаблицаБД.GetDataTable(StringConnectionDB.StringConnection(), queryConnectionString, "СтрокиПодключенияЭСРН");

            var dic = SqlGetTable(tab);

            return dic;
        }

        public Dictionary<string, IpAddressOszn> StringConnectionsEsrnOuid()
        {
            // Запрос к БД.
            IQuery query = new GetConnectionString();
            string queryConnectionString = query.Query();

            // Получим таблицу сос троками подключения
            DataTable tab = ТаблицаБД.GetDataTable(StringConnectionDB.StringConnection(), queryConnectionString, "СтрокиПодключенияЭСРН");

            var dic = SqlGetTableOuid(tab);

            return dic;
        }

        private Dictionary<string, string> SqlGetTable(DataTable dataTable)
        {
            // Словарь для хранения строк подключения к БД ЭСРН по Саратовской области.
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string config = "";
            string key = "";

            // Сформируем строки подключения к БД ЭСРН.
            foreach (DataRow row in dataTable.Rows)
            {
                // Район.
                key = row["AREA_NAME"].ToString();


                config = @"Data Source=" + row["ip"].ToString().Trim() + ";Initial Catalog=" + row["имя БД"].ToString() + ";User ID=" + row["Логин"].ToString() + ";Password=" + row["пароль"].ToString() + "";
                //config = @"Data Source=" +"10.159.70.28" + ";Initial Catalog=" + row["имя БД"].ToString() + ";User ID=" + row["Логин"].ToString() + ";Password=" + row["пароль"].ToString() + "";

                //config = row["OUID"].ToString();

                dic.Add(key, config);
            }

            return dic;
        }

        private Dictionary<string, IpAddressOszn> SqlGetTableOuid(DataTable dataTable)
        {
            // Словарь для хранения строк подключения к БД ЭСРН по Саратовской области.
            Dictionary<string, IpAddressOszn> dic = new Dictionary<string, IpAddressOszn>();
            string config = "";
            string key = "";

            // Сформируем строки подключения к БД ЭСРН.
            foreach (DataRow row in dataTable.Rows)
            {
                // Район.
                key = row["район"].ToString();

                IpAddressOszn ipAddress = new IpAddressOszn();
                ipAddress.Ip = row["ip"].ToString().Trim();
                ipAddress.AREA_NAME = row["район"].ToString();
                ipAddress.OSZN = row["OUID"].ToString();
                ipAddress.DataSource = @"Data Source=" + row["ip"].ToString().Trim() + ";Initial Catalog=" + row["имя БД"].ToString() + ";User ID=" + row["Логин"].ToString() + ";Password=" + row["пароль"].ToString() + "";

                dic.Add(key, ipAddress);
            }

            return dic;
        }
    }
}
