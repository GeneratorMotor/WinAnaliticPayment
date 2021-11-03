using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class FindPerson
    {
        private List<CountPersonResultLK> list;

        public FindPerson()
        {
            this.list = new List<CountPersonResultLK>();
        }

        private async Task<CountPersonResultLK[]> GetList()
        {
            // Выполним выборку из БД.
            Task<CountPersonResultLK> item = GetPeronForRegion();

            Task<CountPersonResultLK> item2 = GetPeronForRegion2();

            // Ожидаем выполнение всех задач.
            return await Task.WhenAll(item, item2);
        }

        public List<CountPersonResultLK> GetAll()
        {
            Task<CountPersonResultLK[]> array = GetList();

            var asd = array.Result;

            return this.list;
        }


        private async Task<CountPersonResultLK> GetPeronForRegion()
        {
            Task t = Task.Delay(TimeSpan.FromSeconds(100));

            CountPersonResultLK regionPerson = new CountPersonResultLK();

            // Моделируем считывание из БД.
            if (t.Status == TaskStatus.RanToCompletion)
            {
                // Считываем из БД.
                regionPerson.CountVtso = 100;
            }

            return await Task.FromResult<CountPersonResultLK>(regionPerson);
        }


        private async Task<CountPersonResultLK> GetPeronForRegion2()
        {
            Task t = Task.Delay(TimeSpan.FromSeconds(100));

            CountPersonResultLK regionPerson = new CountPersonResultLK();

            if (t.Status == TaskStatus.RanToCompletion)
            {
                // Считываем из БД.
                regionPerson.CountTT = 1000;
            }

            return await Task.FromResult<CountPersonResultLK>(regionPerson);
        }
    }
}
