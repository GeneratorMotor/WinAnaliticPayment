using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinAnaliticPayment.Classess;
using WinAnaliticPayment.ConnectionStringEspb;

namespace WinAnaliticPayment.ClassessEspb
{
    public class TravelTicketEspb : ITravelTcketEspb<string>
    {
        // Строка подключения к БД ЕСПБ.
        IConnectionString conStr;

        // SQL запрос на получение GUID льготниклов купивших билет в текущем районе за два месяца;
        IQuery query;

        public TravelTicketEspb(IConnectionString conStr, IQuery query)
        {
            this.conStr = conStr ?? throw new ArgumentNullException(nameof(conStr));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public IEnumerable<string> GetTicket()
        {
            List<string> listPerson = new List<string>();

            DataTable tabPerson = DataTableBD.GetTable(this.query.Query(), this.conStr.ConnectionString(), "ЛьготникиРайона");

            if(tabPerson != null && tabPerson.Rows != null && tabPerson.Rows.Count > 0)
            {
                listPerson = new List<string>();

                foreach(DataRow row in tabPerson.Rows)
                {
                    listPerson.Add(row["PC_GUID"].ToString().Trim());
                }
            }

            return listPerson;
        }
    }
}
