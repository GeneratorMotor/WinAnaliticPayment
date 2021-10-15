using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    /// <summary>
    /// Запрос к БД поиск льготников которомы есть женщины 55 лет, мужики 60 лет.
    /// </summary>
    public abstract class PersonAge60and55
    {
        public abstract string Query();
        
    }
}
