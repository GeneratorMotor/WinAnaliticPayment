using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.ConnectionStringEspb
{
    public interface IConnectionString
    {
        /// <summary>
        /// Строка подключения к БД ESPB.
        /// </summary>
        /// <returns></returns>
        string ConnectionString();
    }
}
