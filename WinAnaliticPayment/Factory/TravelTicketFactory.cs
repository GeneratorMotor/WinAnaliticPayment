using WinAnaliticPayment.ClassessEspb;
using WinAnaliticPayment.ConnectionStringEspb;
using WinAnaliticPayment.Classess;
using System.Collections.Generic;

namespace WinAnaliticPayment.Factory
{
    public class TravelTicketFactory
    {
        public ITravelTcketEspb<string> GetTicketEspbRegion(IConnectionString conStr, IQuery query)
        {
            return new TravelTicketEspb(conStr, query);
        }

        /// <summary>
        /// Воззвращает SQL запрос на получение льготников купивших билет за два месяца в текущем районе.
        /// </summary>
        /// <param name="oszn"></param>
        /// <returns></returns>
        public IQuery QueryGetPersonEspb(string район)
        {
            return new QueryDataPersonInEspb(район);
        }

        public IQuery QueryCreateTempTable(IEnumerable<string> listPC)
        {
            return new CreateTempTable(listPC);
        }

        /// <summary>
        /// Возвращает SQl запрос на поиск льготников в районе.
        /// </summary>
        /// <param name="queryCreateTable"></param>
        /// <returns></returns>
        public IQuery GetPersonRegion(string queryCreateTable)
        {
            return new QueryRegion(queryCreateTable);
        }
    }
}
