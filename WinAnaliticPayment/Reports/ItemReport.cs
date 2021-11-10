using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarlosAg.ExcelXmlWriter;

namespace WinAnaliticPayment.Reports
{
    public static class ItemReport
    {
        //public static void WorkCell(WorksheetCell cellDate, int index, string style)
        public static void WorkCell(WorksheetRow row, string text, int index, string style)
        {
            //WorksheetCell myCella = rowT1.Cells.Add("№ п.п");

            WorksheetCell cell = row.Cells.Add(text);
            cell.Index = index;
            //cellFG.MergeAcross = 1;
            cell.StyleID = style;
        }

        public static void WorkCellDown(WorksheetRow row, int mergeDown, string text, int index, string style)
        {
            //WorksheetCell myCella = rowT1.Cells.Add("№ п.п");

            WorksheetCell cell = row.Cells.Add(text);
            cell.Index = index;
            cell.MergeDown = mergeDown;
            //cellFG.MergeAcross = 1;
            cell.StyleID = style;
        }

        //public static void WorkCellDown(WorksheetRow row, int mergeDown, string text, int index, string style)
        //{
        //    //WorksheetCell myCella = rowT1.Cells.Add("№ п.п");

        //    WorksheetCell cell = row.Cells.Add(text);
        //    cell.Index = index;
        //    cell.MergeDown = mergeDown;
        //    //cellFG.MergeAcross = 1;
        //    cell.StyleID = style;
        //}
    }
}
