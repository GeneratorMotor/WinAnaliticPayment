using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class QueryFactory : AbstractFactoryQuery
    {

        

        /// <summary>
        /// Поиск женщин чей возраст больше или равно 55 лет.
        /// </summary>
        /// <returns></returns>
        public override IQuery SqlPersonAge55Femali(string dateBirth)
        {
            return new FindPersonAge55Femal(dateBirth);
        }

        /// <summary>
        /// Поиск мужчин которым на время проверки исполнилось 60 и более лет.
        /// </summary>
        /// <param name="dateBirth"></param>
        /// <returns></returns>
        public override IQuery SqlPersonAge60Men(string dateBirth)
        {
            return new FindPersonAge60Men(dateBirth); 
        }

        /// <summary>
        /// Поиск льготников которым в предыдущем месяце исполнилось 55 или 60 лет соответственно для женщин и мужчин.
        /// </summary>
        /// <returns></returns>
        public override IQuery SqlPersonWillBeFemile(string dateBirthStart, string dateBirthEnd)
        {
            return new FindPersonWillBeFemali(dateBirthStart, dateBirthEnd);
        }

        public override IQuery SqlPersonWillBeMen(string dateBirthStart, string dateBirthEnd)
        {
            return new FindPersonWillBeMen(dateBirthStart, dateBirthEnd);
        }

        /// <summary>
        /// Поиск льготников которые умерли в прошлый месяц.
        /// </summary>
        /// <returns></returns>
        public override IQuery SqlPersonHead(string dateBirthStart, string dateBirthEnd)
        {
            return new FindPersonHead(dateBirthStart, dateBirthEnd);
        }
    }
}
