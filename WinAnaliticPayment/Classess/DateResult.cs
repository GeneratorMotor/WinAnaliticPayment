using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace WinAnaliticPayment.Classess
{
    public class DateResult
    {
        private Task<DataTable> dataTableAsyncdta60M = null;
        private string region = string.Empty;

        public DateResult(Task<DataTable> dataTableAsyncdta60M, string nameRegion)
        {
            this.dataTableAsyncdta60M = dataTableAsyncdta60M ?? throw new ArgumentNullException(nameof(dataTableAsyncdta60M));

            this.region = nameRegion;
        }

        public bool FlagError()
        {
            bool flagError = false;

            if (dataTableAsyncdta60M.Exception != null)
            {
                flagError = true;
            }

            return flagError;
        }

        public string MessageError()
        {
            return this.region + " " + dataTableAsyncdta60M.Exception.InnerException.Message;
        }

        public DataTable getData()
        {
            return this.dataTableAsyncdta60M.Result;
        }
    }
}
