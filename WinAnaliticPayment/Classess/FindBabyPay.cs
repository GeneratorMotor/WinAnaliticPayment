using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class FindBabyPay : IQuery
    {
        // Пример проверка 25 октября 2021 года dateStartBirth - 01.09.2021 г., dateEndBirth - 25.10.2021 г.
        // Дата смерти на 1о еч ичисло предыдущего месяца.
        private string dateStartPay = string.Empty;

        // Дата смерти на 25 число текущего месяца
        private string dateEndPay = string.Empty;

        private int idLk = 0;

        public FindBabyPay(string dateStartPay, string dateEndPay, int idLk)
        {
            this.dateStartPay = dateStartPay ?? throw new ArgumentNullException(nameof(dateStartPay));
            this.dateEndPay = dateEndPay ?? throw new ArgumentNullException(nameof(dateEndPay));

            this.idLk = idLk;
        }

        public string Query()
        {
            return null;
        }
    }
}
