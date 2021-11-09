using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class MessageValidate
    {
        /// <summary>
        /// Указывает что валидация закончилась.
        /// </summary>
        public bool EndValidate { get; set; }

        /// <summary>
        /// Флаг указывающий на наличие ошибок.
        /// </summary>
        public bool FlagExecError { get; set; }
    }
}
