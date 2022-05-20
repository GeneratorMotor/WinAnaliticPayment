using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAnaliticPayment.Classess;

namespace WinAnaliticPayment.ClassessEspb
{
    /// <summary>
    /// SQL Запрос на получение GUID льготников купивших билеты за два месяца.
    /// </summary>
    public class QueryDataPersonInEspb : IQuery
    {
        private string район = string.Empty;

        public QueryDataPersonInEspb(string район)
        {
            this.район = район ?? throw new ArgumentNullException(nameof(район));
        }

        /// <summary>
        /// SQL Запрос на получение GUID льготников купивших билеты за два месяца в текущем районе области.
        /// </summary>
        /// <returns></returns>
        public string Query()
        {
            return @" select Tab1.PC_GUID, Tab2.PC_GUID from(
                        select PC_GUID from ESPB_IMPLEMENTED
                        inner join ESPB_PERSONAL_CARD
                        on ESPB_IMPLEMENTED.PERSONAL_CARD = ESPB_PERSONAL_CARD.OUID
                        inner
                                       join ESPB_OSZN
                                 on ESPB_PERSONAL_CARD.OSZN = ESPB_OSZN.OUID
                                 inner
                                       join ESPB_VALIDITY
                                 ON ESPB_IMPLEMENTED.VALIDITY = ESPB_VALIDITY.OUID
                        where ESPB_OSZN.AREA_NAME = '"+ район + "' and PERIOD_YEAR = 2022 and VALIDITY = 79) as Tab1 " +
                        @" inner join(
                        select PC_GUID from ESPB_IMPLEMENTED
                        inner join ESPB_PERSONAL_CARD
                        on ESPB_IMPLEMENTED.PERSONAL_CARD = ESPB_PERSONAL_CARD.OUID
                        inner join ESPB_OSZN
                        on ESPB_PERSONAL_CARD.OSZN = ESPB_OSZN.OUID
                        inner join ESPB_VALIDITY
                        ON ESPB_IMPLEMENTED.VALIDITY = ESPB_VALIDITY.OUID
                        where ESPB_OSZN.AREA_NAME = '"+ район + "' and PERIOD_YEAR = 2022 and VALIDITY = 80) as Tab2 " +
                        " ON Tab1.PC_GUID = Tab2.PC_GUID ";

            //return @" select TabFevral.PC_GUID, TabMart.OSZN from(
            //            select Tab1.PC_GUID,OSZN from(
            //            select ESPB_IMPLEMENTED.BAR_CODE, ESPB_PERSONAL_CARD.PC_GUID, ESPB_PERSONAL_CARD.OSZN from ESPB_IMPLEMENTED
            //            inner join ESPB_EXT_USER
            //            on ESPB_IMPLEMENTED.[USER] = ESPB_EXT_USER.OUID
            //            inner join ESPB_PERSONAL_CARD
            //            on ESPB_IMPLEMENTED.PERSONAL_CARD = ESPB_PERSONAL_CARD.OUID
            //            where VALIDITY = 80 and OSZN = '"+ this.oszn +"') as Tab1 " +
            //            @" GROUP BY PC_GUID,OSZN ) as TabMart
            //            inner join(
            //            select Tab1.PC_GUID, OSZN from(
            //            select ESPB_IMPLEMENTED.BAR_CODE, ESPB_PERSONAL_CARD.PC_GUID, ESPB_PERSONAL_CARD.OSZN from ESPB_IMPLEMENTED
            //            inner join ESPB_EXT_USER
            //            on ESPB_IMPLEMENTED.[USER] = ESPB_EXT_USER.OUID
            //            inner join ESPB_PERSONAL_CARD
            //            on ESPB_IMPLEMENTED.PERSONAL_CARD = ESPB_PERSONAL_CARD.OUID
            //            where VALIDITY = 79 and OSZN = '"+ this.oszn +"') as Tab1 " +
            //            @"GROUP BY PC_GUID,OSZN ) as TabFevral
            //            on TabFevral.PC_GUID = TabMart.PC_GUID ";
        }
    }
}
