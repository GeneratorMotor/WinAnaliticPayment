using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public abstract class AbstractFactoryQuery
    {
       
        /// <summary>
        /// Класс реализующий запрос на посик женщин которым на момент проверки исполнилось 55 лет.
        /// </summary>
        /// <param name="dateBirth"></param>
        /// <returns></returns>
        public abstract IQuery SqlPersonAge55Femali(string dateBirth);

        /// <summary>
        /// Класс реализующий запрос на посик мужчин которым на момент проверки исполнилось 60 лет.
        /// </summary>
        /// <param name="dateBirth"></param>
        /// <returns></returns>
        public abstract IQuery SqlPersonAge60Men(string dateBirth);

        /// <summary>
        /// Класс реализующий запрос на посик льготников которым исполнилось в прошлом месяце 55 и 60 лет.
        /// </summary>
        /// <returns></returns>
        public abstract IQuery SqlPersonWillBeFemile(string dateBirthStart, string dateBirthEnd);

        public abstract IQuery SqlPersonWillBeMen(string dateBirthStart, string dateBirthEnd);

        /// <summary>
        /// Поиск льготников которые умерли в прошлый месяц.
        /// </summary>
        /// <returns></returns>
        public abstract IQuery SqlPersonHead(string dateBirthStart, string dateBirthEnd);


    }
}
