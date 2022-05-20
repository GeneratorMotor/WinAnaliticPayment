using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.ClassessEspb
{
    /// <summary>
    /// Получим билет 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITravelTcketEspb<T>
    {
        IEnumerable<T> GetTicket();
    }
}
