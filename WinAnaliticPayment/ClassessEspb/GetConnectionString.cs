using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinAnaliticPayment.Classess;

namespace WinAnaliticPayment.ClassessEspb
{
    public class GetConnectionString : IQuery
    {
        public string Query()
        {
            return @" select ip, [имя БД],логин,пароль,район, OUID,AREA_NAME from [dbo].[View1]
                        inner join espb.dbo.ESPB_OSZN
                        on espb.dbo.ESPB_OSZN.AREA_CODE = [dbo].[View1].id "; // where AREA_NAME = 'Волжский' ";
        }
    }
}
