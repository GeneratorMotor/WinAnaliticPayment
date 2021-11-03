using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public class FindPersonWillBeMen : IQuery
    {
        private string dateStartBirth = string.Empty;
        private string dateEndBirth = string.Empty;
        private int idLk = 0;

        public FindPersonWillBeMen(string dateStartBirth, string dateEndBirth, int idLk)
        {
            this.dateStartBirth = dateStartBirth ?? throw new ArgumentNullException(nameof(dateStartBirth));
            this.dateEndBirth = dateEndBirth ?? throw new ArgumentNullException(nameof(dateEndBirth));
            this.idLk = idLk;
        }

        public string Query()
        {
            return @" select COUNT(OUID) from (
SELECT     TOP (100) PERCENT WM_PERSONAL_CARD.OUID, SPR_FIO_SURNAME.A_NAME AS f, SPR_FIO_NAME.A_NAME AS i, SPR_FIO_SECONDNAME.A_NAME AS o, 
                      CONVERT(char(10), WM_PERSONAL_CARD.BIRTHDATE, 104) AS Dr, WM_PERSONAL_CARD.A_SEX,
                      PPR_CAT.A_NAME AS kat,WM_CATEGORY.A_DATELAST, Convert(char(10),WM_PERSONAL_CARD.A_DEATHDATE) as 'ДатаСмерти'
FROM         SPR_FIO_SURNAME INNER JOIN
                      WM_PERSONAL_CARD ON SPR_FIO_SURNAME.OUID = WM_PERSONAL_CARD.SURNAME INNER JOIN
                      SPR_FIO_NAME ON WM_PERSONAL_CARD.A_NAME = SPR_FIO_NAME.OUID INNER JOIN
                      SPR_FIO_SECONDNAME ON WM_PERSONAL_CARD.A_SECONDNAME = SPR_FIO_SECONDNAME.OUID LEFT OUTER JOIN
                      WM_CATEGORY ON WM_PERSONAL_CARD.OUID = WM_CATEGORY.PERSONOUID LEFT OUTER JOIN
                      PPR_REL_NPD_CAT ON WM_CATEGORY.A_NAME = PPR_REL_NPD_CAT.A_ID LEFT OUTER JOIN
                      PPR_CAT ON PPR_REL_NPD_CAT.A_CAT = PPR_CAT.A_ID " +
//WHERE    (PPR_CAT.A_ID in (42,2297,46,260)) 
" WHERE    (PPR_CAT.A_ID in ("+ this.idLk +"))  " +
@"AND (WM_PERSONAL_CARD.A_DEATHDATE IS NULL) 
AND (WM_PERSONAL_CARD.A_STATUS = 10) AND 
                      (WM_PERSONAL_CARD.A_PCSTATUS = 1) AND (WM_PERSONAL_CARD.A_NOT_LOAD_ESPB = 0 OR
                      WM_PERSONAL_CARD.A_NOT_LOAD_ESPB IS NULL)
					  and WM_PERSONAL_CARD.A_SEX = 1 and (WM_PERSONAL_CARD.BIRTHDATE >= '" + this.dateStartBirth + "' and WM_PERSONAL_CARD.BIRTHDATE <= '" + this.dateEndBirth + "') " +
@" GROUP BY WM_PERSONAL_CARD.OUID, PPR_CAT.A_ID, WM_PERSONAL_CARD.OUID, SPR_FIO_SURNAME.A_NAME, SPR_FIO_NAME.A_NAME, 
                      SPR_FIO_SECONDNAME.A_NAME, 
                      PPR_CAT.A_NAME, WM_PERSONAL_CARD.A_SEX,
                      WM_PERSONAL_CARD.BIRTHDATE, WM_CATEGORY.A_DATELAST,WM_PERSONAL_CARD.A_DEATHDATE
                      order by WM_PERSONAL_CARD.OUID ) as Tab1";
        }
    }
}
