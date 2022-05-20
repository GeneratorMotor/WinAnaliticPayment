using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAnaliticPayment.Classess;

namespace WinAnaliticPayment.ClassessEspb
{
    public class CreateTempTable : IQuery
    {
        private IEnumerable<string> listTest;

        private string nameTable = string.Empty;

        public CreateTempTable(IEnumerable<string> listTest)
        {
            this.listTest = listTest ?? throw new ArgumentNullException(nameof(listTest));
        }

        public string Query()
        {
            // Переменная для хранения SQL запроса.
            StringBuilder stringBuilder = new StringBuilder();

            // Создадим временную таблицу.
            stringBuilder.Append(CreateTable("#t2_temp"));

            // Заполним данными временную таблицу.
            stringBuilder.Append(InsertData(listTest));

            return stringBuilder.ToString();
        }

        private string CreateTable(string nameTempTable)
        {
            this.nameTable = nameTempTable;

            string createTable = "create table " + nameTempTable + " ([id_карточки] [int] IDENTITY(1,1) NOT NULL, " +
                                "[PC_GUID] [nvarchar](300) NULL ) ";

            return createTable;
        }

        private string InsertData(IEnumerable<string> listTest)
        {
            StringBuilder insertBuilder = new StringBuilder();

            foreach (string pcGoid in listTest)
            {
                string insert = "insert into " + this.nameTable + " (PC_GUID) values('"+ pcGoid + "') ";

                insertBuilder.Append(insert);
            }

            return insertBuilder.ToString();
        }
    }
}
