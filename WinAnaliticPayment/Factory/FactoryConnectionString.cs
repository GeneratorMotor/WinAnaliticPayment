using WinAnaliticPayment.ClassessEspb;
using WinAnaliticPayment.Classess;
using WinAnaliticPayment.ConnectionStringEspb;

namespace WinAnaliticPayment.Factory
{
    public class FactoryConnectionString
    {
        /// <summary>
        /// Фабрика для получения строк подключения к БД ЭСРН с привязкой к ЕСПБ.
        /// </summary>
        /// <returns></returns>
        public IQuery FactoryConnectionStringEspb()
        {
            return new GetConnectionString();
        }

        /// <summary>
        ///  Экземпляр со строками подключения к ЭСРН с привязкой к ЕСПБ.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public CollectionStringEspb GetCollectionStringEspb(IQuery query)
        {
            return new CollectionStringEspb(query);
        }

        

        /// <summary>
        /// Инкапсулирует строку запроса к ЕСПБ.
        /// </summary>
        /// <returns></returns>
        public IConnectionString GetConnectionStringEspb()
        {
            return new ConnectStringEspb();
        }
    }
}
