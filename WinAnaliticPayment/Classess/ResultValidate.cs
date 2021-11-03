using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class ResultValidate
    {
        private DataTableAsync dta;
        private LogError logError;

        private string nameRegion = string.Empty;

        public ResultValidate(DataTableAsync dta, LogError logError, string nameRegion)
        {
            this.dta = dta ?? throw new ArgumentNullException(nameof(dta));

            this.logError = logError ?? throw new ArgumentNullException(nameof(logError));

            this.nameRegion = nameRegion ?? throw new ArgumentNullException(nameof(nameRegion));
        }

        public int GetValue()
        {
            int countPerson = 0;

            if (this.dta.ValidError() == false)
            {
                // Получаем результат.
                countPerson = this.dta.GetCountPerson();
            }
            else
            {
                this.logError.MessageError.Add(this.nameRegion,this.dta.MessageError());
            }

            return countPerson;
        }


    }
}
