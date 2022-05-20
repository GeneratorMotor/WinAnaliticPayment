using System.Data;
using WinAnaliticPayment.Classess;
using WinAnaliticPayment.Reports;

namespace WinAnaliticPayment.Factory
{
    public class FactoryPrintReport
    {
        public IReport PrintReportPersonRegion(DataTable dataTable, string nameRegion)
        {
            return new ReportPersonRegion(dataTable, nameRegion);
        }
    }
}
