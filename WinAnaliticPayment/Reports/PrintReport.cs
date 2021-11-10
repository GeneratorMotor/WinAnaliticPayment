using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WinAnaliticPayment.Classess;
using CarlosAg.ExcelXmlWriter;

namespace WinAnaliticPayment.Reports
{
    public class PrintReport : IReport
    {

        private List<CountPersonResultLK> list;

        public PrintReport(List<CountPersonResultLK> list)
        {
            this.list = list ?? throw new ArgumentNullException(nameof(list));
        }

        public void Print()
        {
            // Получим 
            //string filename = fileName;// @"D:\test.xls";
            string filePath = System.Windows.Forms.Application.StartupPath + @"\Документы\Отчет.xls";

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
            sheet.Table.Columns.Add(new WorksheetColumn(200));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            sheet.Table.Columns.Add(new WorksheetColumn(80));
            //sheet.Table.Columns.Add(new WorksheetColumn(80));
            //sheet.Table.Columns.Add(new WorksheetColumn(80));
            //sheet.Table.Columns.Add(new WorksheetColumn(80));

            // Заполним таблицу данными.
            CountPersonResultLK personItem = this.list.First();

            WorksheetRow rowT01 = sheet.Table.Rows.Add();

            WorksheetCell myCella01 = rowT01.Cells.Add("Информация по численности и кол-ве выплат мер социальной поддержки отдельных категорий граждан за ГОД МЕСЯЦ");
            myCella01.Index = 1;
            myCella01.MergeAcross = 10;
            myCella01.StyleID = "HeaderStyle1";

            WorksheetRow rowT1 = sheet.Table.Rows.Add();
            ItemReport.WorkCell(rowT1, "№ п.п", 1, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Наименование нормативно-правового акта", 2, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Наименование публичных нормативных обязательств и публичных обязательств", 3, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Раздел", 4, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Подраздел", 5, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Целевая статья", 6, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, " ", 7, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "Вид расходов", 8, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "КОСГУ", 9, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "направление", 10, "HeaderStyle2");
            ItemReport.WorkCell(rowT1, "месяц отчета", 11, "HeaderStyle2");

          
            ItemExcelReport i1 = new ItemExcelReport();
            i1.НомерПП = "19";
            i1.НаименваниеПравовогоАкта = "ЗСО \"Омерах социальной поддержки отдельных категорий граждан в Саратовской области\" от 26.12.2008 г. №372-ЗСО ";

            string nameVT = "ежемесячная денежная выплата";

            // Строка ВТСО.
            WorksheetRow rowT2 = sheet.Table.Rows.Add();
            ItemReport.WorkCell(rowT2, "19", 1, "HeaderStyle2");
            ItemReport.WorkCellDown(rowT2, 3, i1.НаименваниеПравовогоАкта, 2, "HeaderStyle3");
            ItemReport.WorkCell(rowT2, nameVT + "ветеранам труда Саратовской области", 3, "HeaderStyle2");
            ItemReport.WorkCell(rowT2, "10", 4, "HeaderStyle2");
            ItemReport.WorkCell(rowT2, "03", 5, "HeaderStyle2");
            ItemReport.WorkCell(rowT2, "5210520310", 6, "HeaderStyle2");
            ItemReport.WorkCell(rowT2, "504", 7, "HeaderStyle2");
            ItemReport.WorkCell(rowT2, "313", 8, "HeaderStyle2");
            ItemReport.WorkCell(rowT2, "262", 9, "HeaderStyle2");
            ItemReport.WorkCell(rowT2, "003", 10, "HeaderStyle2");
            ItemReport.WorkCell(rowT2, personItem.CountVtso.ToString(), 11, "HeaderStyle2");

            // Строка ВТ и ВВС.
            WorksheetRow rowT3 = sheet.Table.Rows.Add();
            ItemReport.WorkCell(rowT3, "19", 1, "HeaderStyle2");
            //ItemReport.WorkCell(rowT3, i1.НаименваниеПравовогоАкта, 2, "HeaderStyle2");
            ItemReport.WorkCell(rowT3, nameVT + "ветеранам труда,ветеранам труда, ветеранам воееной службы", 3, "HeaderStyle2");
            ItemReport.WorkCell(rowT3, "10", 4, "HeaderStyle2");
            ItemReport.WorkCell(rowT3, "03", 5, "HeaderStyle2");
            ItemReport.WorkCell(rowT3, "52105203H0", 6, "HeaderStyle2");
            ItemReport.WorkCell(rowT3, "504", 7, "HeaderStyle2");
            ItemReport.WorkCell(rowT3, "313", 8, "HeaderStyle2");
            ItemReport.WorkCell(rowT3, "262", 9, "HeaderStyle2");
            ItemReport.WorkCell(rowT3, "003", 10, "HeaderStyle2");

            int countSum = personItem.CountVt + personItem.CountVvs;

            ItemReport.WorkCell(rowT3, countSum.ToString(), 11, "HeaderStyle2");


            // Строка Труженники тыла.
            WorksheetRow rowT4 = sheet.Table.Rows.Add();
            ItemReport.WorkCell(rowT4, "19", 1, "HeaderStyle2");
            //ItemReport.WorkCell(rowT4, i1.НаименваниеПравовогоАкта, 2, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, nameVT + "труженникам тыла", 3, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, "10", 4, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, "03", 5, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, "5210520330", 6, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, "504", 7, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, "313", 8, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, "262", 9, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, "003", 10, "HeaderStyle2");
            ItemReport.WorkCell(rowT4, personItem.CountTT.ToString(), 11, "HeaderStyle2");

            // Строка Реабелитированным.
            WorksheetRow rowT5 = sheet.Table.Rows.Add();
            ItemReport.WorkCell(rowT5, "19", 1, "HeaderStyle2");
            //ItemReport.WorkCell(rowT5, i1.НаименваниеПравовогоАкта, 2, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, nameVT + "труженникам тыла", 3, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, "10", 4, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, "03", 5, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, "5210520340", 6, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, "504", 7, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, "313", 8, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, "262", 9, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, "003", 10, "HeaderStyle2");
            ItemReport.WorkCell(rowT5, personItem.CountStalin.ToString(), 11, "HeaderStyle2");

            ///-------------------------

            book.Save(filePath);

            // Проверим если файл есть тогда запустим процесс.
            if (File.Exists(filePath) == true)
            {
                // Запустим процесс.
                System.Diagnostics.Process.Start(filePath);
            }

            

        }

        private string GetDate()
        {
            //// Текущая дата.
            DateTime dt = DateTime.Today;

            //// Переменная для хранения наименования месяца.
            //string month = string.Empty;

            //if(dt.Month < 12)
            //{
            //    month = dt.Month.ToString();
            //}
            //else if(dt.Month == 12)
            //{
            //    month = 
            //}

            return dt.Year.ToString() + " " + (dt.Month + 1).ToString();
        }
    }
}
