using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.ConnectionStringEspb
{
    public class ConnectStringEspb : IConnectionString
    {
        public string ConnectionString()
        {
            return "Data Source=10.159.102.21;Initial Catalog=espb;User ID=sa;Password=sitex";
        }
    }
}
