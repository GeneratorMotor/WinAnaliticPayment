using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAnaliticPayment.Classess;
using CarlosAg.ExcelXmlWriter;
using System.IO;

namespace WinAnaliticPayment.Reports
{
    public class ReportPersonRegion : IReport
    {
        private DataTable dataTable;

        private string nameRegion = string.Empty;

        public ReportPersonRegion(DataTable dataTable, string nameRegion)
        {
            this.dataTable = dataTable ?? throw new ArgumentNullException(nameof(dataTable));
            this.nameRegion = nameRegion ?? throw new ArgumentNullException(nameof(nameRegion));
        }

        public void Print()
        {
            // Сформируем документ.
            string filename = "Список "+ this.nameRegion +".xls";
            string filePath = System.Windows.Forms.Application.StartupPath + @"\Документы\" + filename;

            // Проверим есть ли такой файл в папке.
            if (File.Exists(filePath) == true)
            {
                // Если файл есть тогда удаляем его.
                File.Delete(filePath);
            }

            Workbook book = new Workbook();

            // Сформируем стиль для ячеек.
            WorksheetStyle style1 = book.Styles.Add("HeaderStyle1");
            style1.Font.FontName = "Times New Roman";
            style1.Font.Size = 12;
            style1.Font.Bold = true;
            style1.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            //style2.Font.Color = "White";
            //style2.Interior.Color = "Blue";
            //style2.Interior.Pattern = StyleInteriorPattern.DiagCross;
            style1.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            style1.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            style1.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            style1.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            style1.Alignment.WrapText = true;


            // Сформируем стиль для ячеек.
            WorksheetStyle style2 = book.Styles.Add("HeaderStyle2");
            style2.Font.FontName = "Times New Roman";
            style2.Font.Size = 8;
            style2.Font.Bold = true;
            style2.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            //style2.Font.Color = "White";
            //style2.Interior.Color = "Blue";
            //style2.Interior.Pattern = StyleInteriorPattern.DiagCross;
            style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            style2.Alignment.WrapText = true;
            //style2.Interior.Pattern = StyleInteriorPattern.Gray75;

            // Сформируем стиль для ячеек.
            WorksheetStyle style3 = book.Styles.Add("HeaderStyle3");
            style3.Font.FontName = "Times New Roman";
            style3.Font.Size = 8;
            style3.Font.Bold = true;
            style3.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            style3.Alignment.Vertical = StyleVerticalAlignment.Top;
            //style2.Font.Color = "White";
            //style2.Interior.Color = "Blue";
            //style2.Interior.Pattern = StyleInteriorPattern.DiagCross;
            style3.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            style3.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            style3.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            style3.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            style3.Alignment.WrapText = true;
            //style2.Interior.Pattern = StyleInteriorPattern.Gray75;

            // Добавить Лист с некоторым данных
            Worksheet sheet = book.Worksheets.Add("Лист1");

            sheet.Table.Columns.Add(new WorksheetColumn(30));
            sheet.Table.Columns.Add(new WorksheetColumn(100));
            sheet.Table.Columns.Add(new WorksheetColumn(100));
            sheet.Table.Columns.Add(new WorksheetColumn(100));
            sheet.Table.Columns.Add(new WorksheetColumn(100));
            sheet.Table.Columns.Add(new WorksheetColumn(400));
            sheet.Table.Columns.Add(new WorksheetColumn(100));

            // Заголовок.
            WorksheetRow rowT01 = sheet.Table.Rows.Add();

            WorksheetCell myCella01 = rowT01.Cells.Add("Список льготников по " + nameRegion);
            myCella01.Index = 1;
            myCella01.MergeAcross = 10;
            myCella01.StyleID = "HeaderStyle1";

            WorksheetRow rowT1 = sheet.Table.Rows.Add();
            ItemReport.WorkCell(rowT1, "№ п.п", 1, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Фамилия", 2, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Имя", 3, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Отчество", 4, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Дата рождения", 5, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Адрес", 6, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "СНИЛС ", 7, "HeaderStyle2");

            int iCount = 1;
           
            // Заполним талицу данными.
            foreach(DataRow row in this.dataTable.Rows)
            {
                WorksheetRow rowT = sheet.Table.Rows.Add();
                ItemReport.WorkCell(rowT,  iCount.ToString().Trim(), 1, "HeaderStyle2");
                ItemReport.WorkCell(rowT, row["Фамилия"].ToString().Trim(), 2, "HeaderStyle2");
                ItemReport.WorkCell(rowT, row["Имя"].ToString().Trim(), 3, "HeaderStyle2");
                ItemReport.WorkCell(rowT, row["Отчество"]?.ToString().Trim(), 4, "HeaderStyle2");
                ItemReport.WorkCell(rowT, row["ДатаРождения"].ToString().Trim(), 5, "HeaderStyle2");
                ItemReport.WorkCell(rowT, row["Адрес"].ToString().Trim(), 6, "HeaderStyle2");
                ItemReport.WorkCell(rowT, row["A_SNILS"].ToString().Trim(), 7, "HeaderStyle2"); //A_SNILS

                iCount++;
            }

            book.Save(filePath);

        }
    }
}
