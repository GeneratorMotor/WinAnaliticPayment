using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            // Получим коллекцию строк подключения к БД.
            CollectionStringDB collectionStringDB = new CollectionStringDB();

            // Пройдемся по строкам подключения.
            foreach (KeyValuePair<string, string> dStringConnect in collectionStringDB.StringConnectionsEsrn())
            {
                //var test = dStringConnect;

                //if(dStringConnect.Key.Trim().ToLower() != "балаковский".Trim())
                //{
                //    continue;
                //}

                // Получим стрку подключения.
                var stringConnect = dStringConnect.Value;

                // Получим дату отчета со дня рождения льготников.
                DateTimeSelect dts = new DateTimeSelect();

                // Получим строки подключения к БД.
                QueryFactory queryFactory = new QueryFactory();

                // Получим строку запроса к БД для женщин достигших 55 лет и старше.
                IQuery query55Femali = queryFactory.SqlPersonAge55Femali(dts.DateAgeFemal());

                // SQL запрос поиск женщин 55 лет и старше на текущую дату.
                string queryString55Femaly = query55Femali.Query();

                // Получим таблицу с данными.
                DataTableAsync dta55F = new DataTableAsync(queryString55Femaly, dStringConnect.Value, "Женщины55");
                Task<DataTable> dataTableAsyncDta55 = dta55F.GetDataTableAsync();

                if(dataTableAsyncDta55.Exception != null)
                {
                    MessageBox.Show("Район - " + dataTableAsyncDta55.Exception.InnerException.Message);
                }
                else
                {
                    var result = dataTableAsyncDta55.Result;
                }

                // Получим таблицу с данными.
                //DataTable dataTable = DataTableBD.GetTable(queryString55Femaly, dStringConnect.Value, "Женщины55");

                // Получим строку запроса к БД для мужиков достигших 60 лет и старше.
                IQuery query60Men = queryFactory.SqlPersonAge60Men(dts.DateAgeMen());

                // SQL запрос поиск мужчин 60 лет и старше на текущую дату.
                string queryString60Men = query60Men.Query();

                DataTableAsync dta60M = new DataTableAsync(queryString60Men, dStringConnect.Value, "Мужики60");
                Task<DataTable> dataTableAsyncdta60M = dta60M.GetDataTableAsync();

                DateResult dr = new DateResult(dataTableAsyncdta60M, dStringConnect.Key);

                // Проверим на наличие ошибки.
                if (dataTableAsyncdta60M.Exception != null)
                {
                    MessageBox.Show("Район - " + dStringConnect.Key + " ошибка - " + dataTableAsyncdta60M.Exception.InnerException.Message);
                }
                else
                {
                    // Выведим результат.
                    var result = dataTableAsyncdta60M.Result;
                }

                // Получим строку запроса к БД получение льготников женщин которым испольнилось 
                // за текущий месяц 55 лет.
                IQuery queryWillBeFemali = queryFactory.SqlPersonWillBeFemile(dts.DateAgeStartFemal(), dts.DateAgeEndFemal());

                // SQL запрос к БД для женщин которым исполниться в текущем месяце 55 лет. 
                string queryStringWillBeFemali = queryWillBeFemali.Query();

                // Получим данные о женщинах у которых наступил день рождения.
                DataTableAsync dtaWillBeFemali = new DataTableAsync(queryStringWillBeFemali, dStringConnect.Value, "ЖенщиныДР");
                Task<DataTable> dataTableWillBeFemali = dtaWillBeFemali.GetDataTableAsync();

                // Проверим на наличие ошибки.
                if(dataTableWillBeFemali.Exception != null)
                {
                    MessageBox.Show("Район - " + dStringConnect.Key + " ошибка - " + dataTableWillBeFemali.Exception.InnerException.Message);
                }
                else
                {
                    // Выведим результат.
                    var result = dataTableWillBeFemali.Result;
                }

                // Получим строку запроса к БД получение льготников мужиков которым испольнилось 
                // за текущий месяц 60 лет.
                IQuery queryWillBeMen = queryFactory.SqlPersonWillBeMen(dts.DateAgeStartMen(), dts.DateAgeEndMen());

                // Получим строку запроса к БД получение льготников мужчин которым испольнилось 
                // за текущий месяц 60 лет.
                string queryStringWillBeMen = queryWillBeMen.Query();

                // Получим данные о женщинах у которых наступил день рождения.
                DataTableAsync dtaWillBeMen = new DataTableAsync(queryStringWillBeMen, dStringConnect.Value, "МужикиДР");
                Task<DataTable> dataTableWillBeMen = dtaWillBeMen.GetDataTableAsync();

                // Проверим на наличие ошибки.
                if (dataTableWillBeMen.Exception != null)
                {
                    MessageBox.Show("Район - " + dStringConnect.Key + " ошибка - " + dataTableWillBeMen.Exception.InnerException.Message);
                }
                else
                {
                    // Выведим результат.
                    var result = dataTableWillBeMen.Result;
                }

                // Получим строку запроса к БД получение умерших льготников в текущем месяце.
                IQuery queryPersonHead = queryFactory.SqlPersonWillBeMen(dts.DateAgeStartMen(), dts.DateAgeEndMen());

                // SQl ззапрос к БД на поиск умерших в текущем месяце.
                string queryStringPersonHead = queryPersonHead.Query();

                // Получим данные о женщинах у которых наступил день рождения.
                DataTableAsync dtaPersonHead = new DataTableAsync(queryStringPersonHead, dStringConnect.Value, "МужикиДР");
                Task<DataTable> dataTabledtaPersonHead = dtaPersonHead.GetDataTableAsync();

                // Проверим на наличие ошибки.
                if (dataTabledtaPersonHead.Exception != null)
                {
                    MessageBox.Show("Район - " + dStringConnect.Key + " ошибка - " + dataTabledtaPersonHead.Exception.InnerException.Message);
                }
                else
                {
                    // Выведим результат.
                    var result = dataTabledtaPersonHead.Result;
                }


            }



            var test2 = "";
        }
    }
}
