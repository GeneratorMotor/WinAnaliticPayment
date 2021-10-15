using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace WinAnaliticPayment.Classess
{
    public static class StringConnectionDB
    {
        public static string StringConnection()
        {
            return ConfigurationSettings.AppSettings["connect"].ToString();
        }
    }
}
