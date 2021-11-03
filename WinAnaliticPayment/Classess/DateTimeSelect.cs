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

        public DateTimeSelect()
        {

        }

        public DateTimeSelect(DateTime dt)
        {
            this.date = dt;
        }

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
        /// Дата поиска женщин которым исполниться 55 лет.
        /// </summary>
        /// <returns></returns>
        public string DateAgeStartFemal()
        {
            string date = GetYearForFemal().ToString().Trim() + GetMinusMonth().ToString().Trim() + "01";

            return date;
        }

        public string DateAgeEndFemal()
        {
            string date = GetYearForFemal().ToString().Trim() + GetMonth().ToString().Trim() + "25";

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

        public string DateAgeStartMen()
        {
            string date = GetYearForMean().ToString().Trim() + GetMinusMonth().ToString().Trim() + "01";

            return date;
        }

        public string DateAgeEndMen()
        {
            string date = GetYearForMean().ToString().Trim() + GetMonth().ToString().Trim() + "25";

            return date;
        }

        /// <summary>
        /// Дата начала поиска умерших льготников.
        /// </summary>
        /// <returns></returns>
        public string DateStartMonthDead()
        {
            string date = GetYearDead().ToString().Trim() + GetMinusMonth().ToString().Trim() + "01";

            return date;
        }

        /// <summary>
        /// Дата окончания поиска умерших льготников.
        /// </summary>
        /// <returns></returns>
        public string DateEndMonthDead()
        {
            string date = GetYearDead().ToString().Trim() + GetMinusMonth().ToString().Trim() + "25";

            return date;
        }

        /// <summary>
        /// Дата начала поиска умерших льготников.
        /// </summary>
        /// <returns></returns>
        public string DateAgeStart()
        {
            return GetYearMonth(GetMonth()) + "01";
        }

        public string DateAgeEnd()
        {
            //return date.Year.ToString().Trim().Trim() + date.Month.ToString().Trim() + "25";
            return GetYearMonth(GetMonth()) + "25";
        }

        private string GetYearMonth(int month)
        {

            if (month == 1)
            {
                dateDeath = (date.Year - 1).ToString().Trim() + "12";
            }
            else
            {
                if (month == 10 || month == 11 || month == 12)
                {
                    dateDeath = (date.Year).ToString().Trim() + month.ToString().Trim();
                }
                else
                {
                    dateDeath = (date.Year).ToString().Trim() + "0" + month.ToString().Trim();
                }
            }

            return dateDeath;

        }

        private int GetYearDead()
        {
            string month = GetMinusMonth();

            int year = date.Year;

            if(month.ToLower().Trim() == "01".ToLower().Trim())
            {
                year--;
            }

            return year;
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

        private string GetMinusMonth()
        {
            string monthResult = string.Empty;

            int month = date.Month;

            if(month == 11 || month == 12)
            {
                monthResult = (month - 1).ToString();
            }
            else
            {
                monthResult = "0" + (month -1).ToString();
            }

            return monthResult;
        }
    }
}
