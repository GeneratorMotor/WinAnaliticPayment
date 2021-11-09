using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    /// <summary>
    /// Класс содержащий результаты поиска.
    /// </summary>
    public  class DataResult
    {
        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<LogError> ListLogError { get; set; }

        /// <summary>
        /// Список льготников найденных в ЭСРН.
        /// </summary>
        public List<CountPersonResultLK> ListCountPerson { get; set; }
    }
}
