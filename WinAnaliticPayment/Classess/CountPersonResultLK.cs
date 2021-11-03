using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    /// <summary>
    /// Результат количества льготников по льготным категориям.
    /// </summary>
    public class CountPersonResultLK
    {

        //public string NameLK { get; set; }

        /// <summary>
        /// ID Льготнгой категории по ЭСРН.
        /// </summary>
        public int idLK { get; set; }

        /// <summary>
        /// Количество Ветеранов Труда Саратовской Области.
        /// </summary>
        public int CountVtso { get; set; }

        /// <summary>
        /// Количество Ветеранов военной службы.
        /// </summary>
        public int CountVvs { get; set; }

        /// <summary>
        /// Количество Ветеранов Труда.
        /// </summary>
        public int CountVt { get; set; }

        /// <summary>
        /// Количество труженников тыла.
        /// </summary>
        public int CountTT { get; set; }

        /// <summary>
        /// Количество реабелитированных лиц.
        /// </summary>
        public int CountStalin { get; set; }

        /// <summary>
        /// Пособие на ребенка.
        /// </summary>
        public int CountBeby { get; set; }
    }
}
