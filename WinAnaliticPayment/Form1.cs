using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAnaliticPayment.Classess;


namespace WinAnaliticPayment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFindStart_Click(object sender, EventArgs e)
        {
            DateTimeSelect timeSelect = new DateTimeSelect();

            var femal = timeSelect.DateAgeFemal();

            var men = timeSelect.DateAgeMen();

            // Строки подключения к БД АИС ЭСРН.
            ConfigLibrary.Config config = new ConfigLibrary.Config();

            //Получаем словарь со строками подключения к АИС ЭСРН.
            Dictionary<string, string> pullConnect = config.Select();

            // Пройдемся по строкам подключения.
            foreach (KeyValuePair<string, string> dStringConnect in pullConnect)
            {
                var test = dStringConnect;
            }



                var test2 = "";
        }
    }
}
