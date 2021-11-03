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
        private Task<DataTable> dataTable = null;
        private string region = string.Empty;

        public DateResult(Task<DataTable> dataTable, string nameRegion)
        {
            this.dataTable = dataTable ?? throw new ArgumentNullException(nameof(dataTable));

            this.region = nameRegion;
        }

        public bool FlagError()
        {
            bool flagError = false;

            if (dataTable.Exception != null)
            {
                flagError = true;
            }

            return flagError;
        }

        public string MessageError()
        {
            return this.region + " " + dataTable.Exception.InnerException.Message;
        }

        public DataTable getData()
        {
            return this.dataTable.Result;
        }
    }
}
