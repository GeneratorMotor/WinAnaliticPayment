using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class TestAsync
    {
        public async Task<int> MyTestAsync()
        {
            return await Task.Run(() =>
            {

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));

                return Task.FromResult(10).Result;
            });
        }
    }
}
