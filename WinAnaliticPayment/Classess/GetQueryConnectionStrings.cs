using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class GetQueryConnectionStrings : IQuery
    {
        /// <summary>
        /// Запрос на получение строк подключения к БД ЭСРН.
        /// </summary>
        /// <returns></returns>
        public string Query()
        {
            return @"SELECT [id]
                  ,[ip]
                  ,[имя БД]
                  ,[логин]
                  ,[пароль]
                  ,[район]
                        FROM[View1]";
        }
    }
}
