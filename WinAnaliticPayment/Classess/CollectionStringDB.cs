using System;
using System.Collections.Generic;
using System.Linq;
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
            ТаблицаБД.GetDataTable(StringConnectionDB.StringConnection(), queryConnectionString, "СтрокиПодключенияЭСРН");

            return null;
        }

        private void SqlGetTable()
        {


        }
    }
}
