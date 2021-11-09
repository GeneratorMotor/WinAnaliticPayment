using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using WinAnaliticPayment.Classess;

namespace WinAnaliticPayment.Reports
{
    public class PrintErrorRegions : IReport
    {
        private List<string> regions;

        public PrintErrorRegions(List<string> regions)
        {
            this.regions = regions ?? throw new ArgumentNullException(nameof(regions));
        }

        public void Print()
        {
            //// Пролучим ссылку на документ.
            //ReportCopyPattern reportCopyPattern = new ReportCopyPattern();

            //// Получим имя файла.
            //string fileNameReport = reportCopyPattern.GetFileName();

            string fName = "РайоныОбласти";

            //try
            //{

            var test = System.Windows.Forms.Application.StartupPath + @"\Шаблон\РайоныОбласти.docx";

            //Скопируем шаблон в папку Документы
            FileInfo fn = new FileInfo(System.Windows.Forms.Application.StartupPath + @"\Шаблон\РайоныОбласти.docx");
            fn.CopyTo(System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".docx", true);

                //idProcessWord = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".doc").Id;
            //}
            //catch
            //{

            //    //idProcessWord = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".doc").Id;

            //    System.Windows.Forms.MessageBox.Show("Возможно у вас уже открыт договор с этим льготником. Закройте этот договор.");
            //    return;
            //}

            string fileNameReport = System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".docx";

            //Создаём новый Word.Application
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            //Загружаем документ
            Microsoft.Office.Interop.Word.Document doc = null;

            object fileName = fileNameReport;
            object falseValue = false;
            object trueValue = true;
            object missing = Type.Missing;
            object writePasswordDocument = "12A86Asd";

            //1

            //старая рабочая реализация 
            //doc = app.Documents.Open(ref fileName, ref missing, ref trueValue,
            //ref missing, ref missing, ref missing, ref missing, ref missing,
            //ref missing, ref missing, ref missing, ref missing, ref missing,
            //ref missing, ref missing, ref missing);

            doc = app.Documents.Open(ref fileName, ref missing, ref trueValue,
            ref missing, ref missing, ref missing, ref missing, ref writePasswordDocument,
            ref missing, ref missing, ref missing, ref missing, ref trueValue,
            ref missing, ref missing, ref missing);

            //Вставить таблицу
            object bookNaziv = "таблица";
            Range wrdRng = doc.Bookmarks.get_Item(ref bookNaziv).Range;

            object behavior = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord8TableBehavior;
            object autobehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow;


            Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(wrdRng, 1, 1, ref behavior, ref autobehavior);
            table.Range.ParagraphFormat.SpaceAfter = 1;

            table.Columns[1].Width = 200;
            //table.Columns[2].Width = 50;
            //table.Columns[3].Width = 250;
            //table.Columns[4].Width = 60;
            //table.Columns[5].Width = 30;
            //table.Columns[6].Width = 60;
            table.Borders.Enable = 1; // Рамка - сплошная линия
            table.Range.Font.Name = "Times New Roman";
            table.Range.Font.Size = 12;

            // Список для хранения информации выводимой в таблицу.
            List<string> listItems = new List<string>();

            listItems.Add("Наименование районов области");

            listItems.AddRange(this.regions);

            // Заполним таблицу данными.

            //счётчик строк
            int i = 1;

            //запишем данные в таблицу
            foreach (string item in listItems)
            {
                //table.Cell(i, 1).Column.Width = 10f;
                table.Cell(i, 1).Range.Text = item;

                //doc.Words.Count.ToString();
                Object beforeRow1 = Type.Missing;
                table.Rows.Add(ref beforeRow1);

                i++;
            }

            //удалим последную строку
            table.Rows[i].Delete();

            //откроем получившейся документ
            app.Visible = true;

        }
    }
}
