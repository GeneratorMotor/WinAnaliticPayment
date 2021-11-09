using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class DataTableAsync
    {
        private string query = string.Empty;
        private string connectionString = string.Empty;
        private string nameTable = string.Empty;

        // Количество льготников.
        private int countPerson = 0;

        // Строка содержит ошибку.
        private string error = string.Empty;

        // Флаг указывает на наличие ошибки.
        // True - ошибка, False - ошибки нет.
        private bool flagError = false;

        public DataTableAsync(string query, string connectionString, string nameTable)
        {
            this.query = query ?? throw new ArgumentNullException(nameof(query));
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this.nameTable = nameTable ?? throw new ArgumentNullException(nameof(nameTable));
        }

        /// <summary>
        ///// Возвращает количество льготников.
        ///// </summary>
        ///// <param name="tableResult"></param>
        ///// <returns></returns>
        //public async Task<int> GetDataPersonAsync(int tableResult)
        //{
        //    try
        //    {
        //        return await Task.FromResult<int>(tableResult);
        //    }
        //    catch(Exception ex)
        //    {
        //        return await Task.FromException<int>(ex);
        //    }
        //}

        //public int GetCountPerson()
        //{
        //    GetDataTableAsync();
        //    return countPerson;
        //}

        /// <summary>
        /// Возвращает флаг указывающий о наличии ошибки.
        /// </summary>
        /// <returns></returns>
        public bool ValidError()
        {
            return flagError;
        }

        public string MessageError()
        {
            return error;
        }

        //public async Task<int> GetDataTableAsync()
        //public async void GetDataTableAsync()
        //private async void GetDataTableAsync()
        //private async void GetDataTableAsync()
        //{

        //    try
        //    {
        //        ////return await ТаблицаБД.GetDataTableAsync(this.connetionString, this.query, this.nameTable);

        //        //return await Task.Run<int>(() =>
        //        //{
        //        countPerson = await Task.Run<int>(() =>
        //        {

        //            int count = ТаблицаБД.GetDateCountPerson(this.connectionString, this.query, this.nameTable);

        //            return count;

        //            //return Convert.ToInt32(tab.Rows[0]["CountRows"]);
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        flagError = true;
        //        error = await Task.FromException<string>(ex);
        //    }
        //}

    }
}
