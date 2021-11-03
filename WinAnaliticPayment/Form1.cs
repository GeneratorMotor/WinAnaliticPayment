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


        private async Task Validate()
        {

        }
        

        private void btnFindStart_ClickAsync(object sender, EventArgs e)
        {
            
            // Строки подключения к БД ЭСРН по области.
            CollectionStringDB collectionStringDB = new CollectionStringDB();

            // Список ошибок.
            List<LogError> listError = new List<LogError>();

            // Список для хранения количества льготников в результате поиска в ЭСРН.
            List<CountPersonResultLK> listPerson = new List<CountPersonResultLK>();

            // Пройдемся по строкам подключения.
            foreach (KeyValuePair<string, string> dStringConnect in collectionStringDB.StringConnectionsEsrn())
            {
                //if (dStringConnect.Key.Trim().ToLower() != "балаковский".Trim())
                //{
                //    continue;
                //}

                Validate(dStringConnect, listError, listPerson);
            }

            var testItems = listPerson;

            MessageBox.Show("Проверка прошла");

            // Сгруппирукем все по id льготных категорий.
            var groups = listPerson.GroupBy(w => w.idLK);

            CountPersonResultLK itemTotal = new CountPersonResultLK();

            // Сложем все в один класс.
            foreach (var gr in groups)
            {
                if (itemTotal.CountVt == 0)
                    itemTotal.CountVt = gr.Select(w => w.CountVt).Sum();

                if (itemTotal.CountStalin == 0)
                    itemTotal.CountStalin = gr.Select(w => w.CountStalin).Sum();

                if (itemTotal.CountTT == 0)
                    itemTotal.CountTT = gr.Select(w => w.CountTT).Sum();

                if (itemTotal.CountVtso == 0)
                    itemTotal.CountVtso = gr.Select(w => w.CountVtso).Sum();

                if (itemTotal.CountVvs == 0)
                    itemTotal.CountVvs = gr.Select(w => w.CountVvs).Sum();
            }

            List<CountPersonResultLK> list = new List<CountPersonResultLK>();

            list.Add(itemTotal);

            this.dataGridView1.DataSource = list;
            this.dataGridView1.Columns["idLK"].Visible = false;

            this.dataGridView1.Columns["CountVtso"].HeaderText = "ВТСО";
            this.dataGridView1.Columns["CountVvs"].HeaderText = "ВВС";
            this.dataGridView1.Columns["CountVt"].HeaderText = "ВТ";
            this.dataGridView1.Columns["CountTT"].HeaderText = "ТТ";
            this.dataGridView1.Columns["CountStalin"].HeaderText = "Реабелитированные";
            this.dataGridView1.Columns["CountBeby"].Visible = false;

        }

        private void Validate(KeyValuePair<string, string> dStringConnect, List<LogError> listError, List<CountPersonResultLK> listPerson)//, List<string> listPerson)
        {

            // Получим дату отчета со дня рождения льготников.
            DateTimeSelect dts = new DateTimeSelect();

            //// Класс для хранения количества льготников.
            //CountPersonResultLK countPerson = new CountPersonResultLK();

            // Класс для записи логов.
            LogError logError = new LogError();

            // Получим строки подключения к БД.
            QueryFactory queryFactory = new QueryFactory();

            var items = LoadLK.GetLK();

            foreach (var lk in LoadLK.GetLK())
            {
                //if(lk.Id == 2181)
                //{
                //    var stop = "";
                //}

                // Получим строку запроса к БД для женщин достигших 55 лет и старше.
                IQuery query55Femali = queryFactory.SqlPersonAge55Femali(dts.DateAgeFemal(), lk.Id);

                // SQL запрос поиск женщин 55 лет и старше на текущую дату.
                string queryString55Femaly = query55Femali.Query();

                // Количество женщин которым на данный момент есть 55.
                int count55Femali = ТаблицаБД.GetDateCountPerson(dStringConnect.Value, queryString55Femaly, "Женщины55");

                // Получим строку запроса к БД для мужиков достигших 60 лет и старше.
                IQuery query60Men = queryFactory.SqlPersonAge60Men(dts.DateAgeMen(), lk.Id);

                // SQL запрос поиск мужчин 60 лет и старше на текущую дату.
                string queryString60Men = query60Men.Query();

                // Количество мужчин которым на данный момент 60 лет.
                int count60Men = ТаблицаБД.GetDateCountPerson(dStringConnect.Value, queryString60Men, "Мужики60");

                // Получим строку запроса к БД получение льготников женщин которым испольнилось 
                // за текущий месяц 55 лет.
                IQuery queryWillBeFemali = queryFactory.SqlPersonWillBeFemile(dts.DateAgeStartFemal(), dts.DateAgeEndFemal(), lk.Id);

                // SQL запрос к БД для женщин которым исполниться в текущем месяце 55 лет. 
                string queryStringWillBeFemali = queryWillBeFemali.Query();

                // Количество женщин которым в текущем месяце исполнилось 55.
                int countFemali55DR = ТаблицаБД.GetDateCountPerson(dStringConnect.Value, queryStringWillBeFemali, "Женщины55ДР");

                // Получим строку запроса к БД получение льготников мужиков которым испольнилось 
                // за текущий месяц 60 лет.
                IQuery queryWillBeMen = queryFactory.SqlPersonWillBeMen(dts.DateAgeStartMen(), dts.DateAgeEndMen(), lk.Id);

                // Получим строку запроса к БД получение льготников мужчин которым испольнилось 
                // за текущий месяц 60 лет.
                string queryStringWillBeMen = queryWillBeMen.Query();

                // Количество мужиков которым в текущем месяце исполнилось 60.
                int countMen60DR = ТаблицаБД.GetDateCountPerson(dStringConnect.Value, queryStringWillBeMen, "Мужики60ДР");

                // Получим строку запроса к БД получение умерших льготников в текущем месяце.
                IQuery queryPersonHead = queryFactory.SqlPersonHead(dts.DateStartMonthDead(), dts.DateEndMonthDead(), lk.Id);

                // SQl ззапрос к БД на поиск умерших в текущем месяце.
                string queryStringPersonHead = queryPersonHead.Query();

                // Количество умерших.
                int countPersonHead = ТаблицаБД.GetDateCountPerson(dStringConnect.Value, queryStringPersonHead, "Умершие");

                // Подсчитаем количество.
                int countPersonForReport = (count55Femali + count60Men + countFemali55DR + countMen60DR) - countPersonHead;

                // Если ВВС.
                if (lk.Id == 42)
                {
                    // Класс для хранения количества льготников.
                    CountPersonResultLK countPerson = new CountPersonResultLK();
                    //countPerson.NameLK = "Ветеран военной службы";
                    countPerson.idLK = lk.Id;
                    countPerson.CountVvs = countPersonForReport;

                    listPerson.Add(countPerson);
                }

                // Если ВТ.
                if (lk.Id == 46)
                {
                    // Класс для хранения количества льготников.
                    CountPersonResultLK countPerson = new CountPersonResultLK();
                    //countPerson.NameLK = "Ветеран труда";
                    countPerson.idLK = lk.Id;
                    countPerson.CountVt = countPersonForReport;

                    listPerson.Add(countPerson);
                }

                // Если ВТ.
                if (lk.Id == 260)
                {
                    // Класс для хранения количества льготников.
                    CountPersonResultLK countPerson = new CountPersonResultLK();
                    //countPerson.NameLK = "Реабилитированные лица";
                    countPerson.idLK = lk.Id;
                    countPerson.CountStalin = countPersonForReport;

                    listPerson.Add(countPerson);
                }

                // Если ВТ.
                if (lk.Id == 2297)
                {
                    // Класс для хранения количества льготников.
                    CountPersonResultLK countPerson = new CountPersonResultLK();
                    //countPerson.NameLK = "Ветеран труда Саратовской области";
                    countPerson.idLK = lk.Id;
                    countPerson.CountVtso = countPersonForReport;

                    listPerson.Add(countPerson);
                }

                // Если ВТ.
                if (lk.Id == 2181)
                {
                    // Класс для хранения количества льготников.
                    CountPersonResultLK countPerson = new CountPersonResultLK();
                    //countPerson.NameLK = "Ветеран труда Саратовской области";
                    countPerson.idLK = lk.Id;
                    countPerson.CountTT = countPersonForReport;

                    listPerson.Add(countPerson);
                }
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обработка парраллелно");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Для теста.
            FindPerson fp = new FindPerson();
            List<CountPersonResultLK> result = fp.GetAll();

            this.dataGridView1.DataSource = result;

            //Task<RegionPersonResult> item = FindPerson.GetPeronForRegion();

            //if(item.Result.CountVtso == 100)
            //{
            //    MessageBox.Show("Задача решена");
            //}

        }
    }
}
