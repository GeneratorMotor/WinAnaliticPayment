using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WinAnaliticPayment.Classess
{
    public class ReportCopyPattern
    {

        // Переменная для хранения имени файла.
        private string fName = string.Empty;


        public ReportCopyPattern()
        {
            this.fName = "РайоныОбласти"; 
        }

        private void CopyFile()
        {
            //try
            //{

            var test = fName;

                //Скопируем шаблон в папку Документы
                FileInfo fn = new FileInfo(System.Windows.Forms.Application.StartupPath + @"\Шаблон\РайоныОбласти.docx");
                fn.CopyTo(System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".docx", true);

                //idProcessWord = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".doc").Id;
            //}
            //catch
            //{

            //    //idProcessWord = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".doc").Id;

            //    MessageBox.Show("Возможно у вас уже открыт договор с этим льготником. Закройте этот договор.");
            //    return;
            //}
        }

        //private bool ExistsFile()
        //{
        //    if(File.Exists(filePath))
        //}

        public string GetFileName()
        {
            // Скопируем файл из папки Шаблон, в папку Документы.
            CopyFile();

            // Получим путь к файлу.
            string filName = System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".docx";

            return filName;

        }
    }
}
