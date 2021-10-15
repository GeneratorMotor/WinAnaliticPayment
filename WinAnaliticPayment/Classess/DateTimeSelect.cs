using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class DateTimeSelect
    {
        // Получим текущую дату.
        private DateTime date = DateTime.Now;
        private string dateDeath = string.Empty;

        /// <summary>
        /// Дата поиска женщин которым испольнилось 55 лет и старше.
        /// </summary>
        /// <returns></returns>
        public string DateAgeFemal()
        {
            string date = GetYearForFemal().ToString().Trim() + GetMonth().ToString().Trim() + "01";

            return date;
        }

        /// <summary>
        /// Дата поиска мужчин которым исполнилось 60 лет.
        /// </summary>
        /// <returns></returns>
        public string DateAgeMen()
        {
            string date = GetYearForMean().ToString().Trim() + GetMonth().ToString().Trim() + "01";

            return date;
        }

        /// <summary>
        /// Дата начала поиска умерших льготников.
        /// </summary>
        /// <returns></returns>
        public string DateAgeDeadthStart()
        {
            return GetYearMonth(GetMonth()) + "01";
        }

        public string DateAgeDeadthEnd()
        {
            return date.Year.ToString().Trim().Trim() + date.Month.ToString().Trim() + "25";
        }

        private string GetYearMonth(int month)
        {

            if (month == 1)
            {
                dateDeath = (date.Year - 1).ToString().Trim();
            }
            else
            {
                dateDeath = (date.Year).ToString().Trim();
            }

            return dateDeath;

        }

        /// <summary>
        /// Год рождения Женщины.
        /// </summary>
        /// <returns></returns>
        private int GetYearForFemal()
        {
            return date.Year - 55;
        }

        private int GetYearForMean()
        {
            return date.Year - 60;
        }

        private int GetMonth()
        {
            return date.Month;
        }
    }
}
