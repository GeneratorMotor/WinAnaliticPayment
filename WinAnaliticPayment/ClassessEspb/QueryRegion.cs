using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAnaliticPayment.Classess;

namespace WinAnaliticPayment.ClassessEspb
{
    public class QueryRegion : IQuery
    {
        private string createTable = string.Empty;

        public QueryRegion(string createTable)
        {
            this.createTable = createTable ?? throw new ArgumentNullException(nameof(createTable));
        }

        public string Query()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(this.createTable);

            string query = @" select distinct [GUID], OUID,Tab1.Фамилия,Tab1.Имя,Tab1.Отчество,A_ADRTITLE as 'Адрес',BIRTHDATE as 'ДатаРождения',A_SNILS,A_REGREGIONCODE
                            --, ЛьготнаКатегория 
                            from (
							   select WM_PERSONAL_CARD.GUID, WM_PERSONAL_CARD.OUID, SPR_FIO_SURNAME.A_NAME as Фамилия,dbo.SPR_FIO_NAME.A_NAME as 'Имя',SPR_FIO_SECONDNAME.A_NAME as 'Отчество',WM_ACTDOCUMENTS.DOCUMENTSTYPE, 
                                 WM_ACTDOCUMENTS.DOCUMENTSERIES ,WM_ACTDOCUMENTS.DOCUMENTSNUMBER ,WM_ACTDOCUMENTS.ISSUEEXTENSIONSDATE --, PPR_DOC.A_NAME
								 ,WM_ADDRESS.A_ADRTITLE, 
                                 WM_PERSONAL_CARD.BIRTHDATE ,dbo.WM_PERSONAL_CARD.A_SNILS,dbo.REGISTER_CONFIG.A_REGREGIONCODE--, PPR_CAT.A_NAME as 'ЛьготнаКатегория' 
								  from dbo.WM_PERSONAL_CARD
                                 join SPR_FIO_SURNAME
                                 on WM_PERSONAL_CARD.SURNAME = SPR_FIO_SURNAME.OUID
                                  join SPR_FIO_NAME
                                  on SPR_FIO_NAME.OUID = WM_PERSONAL_CARD.A_NAME
                                  join SPR_FIO_SECONDNAME
                                  on SPR_FIO_SECONDNAME.OUID = WM_PERSONAL_CARD.A_SECONDNAME
                                  join dbo.WM_ACTDOCUMENTS
                                  on WM_PERSONAL_CARD.OUID = dbo.WM_ACTDOCUMENTS.PERSONOUID
                                   join PPR_DOC
                                  on WM_ACTDOCUMENTS.DOCUMENTSTYPE = PPR_DOC.A_ID
                                   join WM_ADDRESS
                                  on WM_ADDRESS.OUID = WM_PERSONAL_CARD.A_REGFLAT
                                   CROSS JOIN dbo.REGISTER_CONFIG
                                  -- inner join WM_CATEGORY
                                  -- ON WM_CATEGORY.PERSONOUID = WM_PERSONAL_CARD.OUID
                                  -- inner join PPR_REL_NPD_CAT
                                  -- ON PPR_REL_NPD_CAT.A_ID = WM_CATEGORY.A_NAME
                                  -- inner join PPR_CAT
                                  -- ON PPR_REL_NPD_CAT.A_CAT = PPR_CAT.A_ID
                                   where WM_PERSONAL_CARD.A_PCSTATUS = 1
								) as Tab1  inner join #t2_temp  on LTRIM(RTRIM(LOWER(Tab1.GUID))) = LTRIM(RTRIM(LOWER(#t2_temp.PC_GUID)))  ";

        //    string query = @" select [GUID], OUID,Tab1.Фамилия,Tab1.Имя,Tab1.Отчество,A_ADRTITLE as 'Адрес',BIRTHDATE as 'ДатаРождения',A_SNILS,A_REGREGIONCODE, ЛьготнаКатегория from (
        //                       select WM_PERSONAL_CARD.GUID, WM_PERSONAL_CARD.OUID, SPR_FIO_SURNAME.A_NAME as Фамилия,dbo.SPR_FIO_NAME.A_NAME as 'Имя',SPR_FIO_SECONDNAME.A_NAME as 'Отчество',WM_ACTDOCUMENTS.DOCUMENTSTYPE, 
        //                         WM_ACTDOCUMENTS.DOCUMENTSERIES ,WM_ACTDOCUMENTS.DOCUMENTSNUMBER ,WM_ACTDOCUMENTS.ISSUEEXTENSIONSDATE ,PPR_DOC.A_NAME,WM_ADDRESS.A_ADRTITLE, 
        //                         WM_PERSONAL_CARD.BIRTHDATE ,dbo.WM_PERSONAL_CARD.A_SNILS, dbo.REGISTER_CONFIG.A_REGREGIONCODE, PPR_CAT.A_NAME as 'ЛьготнаКатегория' from dbo.WM_PERSONAL_CARD
        //                         join SPR_FIO_SURNAME
        //                         on WM_PERSONAL_CARD.SURNAME = SPR_FIO_SURNAME.OUID
        //                          join SPR_FIO_NAME
        //                          on SPR_FIO_NAME.OUID = WM_PERSONAL_CARD.A_NAME
        //                          join SPR_FIO_SECONDNAME
        //                          on SPR_FIO_SECONDNAME.OUID = WM_PERSONAL_CARD.A_SECONDNAME
        //                          join dbo.WM_ACTDOCUMENTS
        //                          on WM_PERSONAL_CARD.OUID = dbo.WM_ACTDOCUMENTS.PERSONOUID
        //                           join PPR_DOC
        //                          on WM_ACTDOCUMENTS.DOCUMENTSTYPE = PPR_DOC.A_ID
        //                           join WM_ADDRESS
        //                          on WM_ADDRESS.OUID = WM_PERSONAL_CARD.A_REGFLAT
        //                           CROSS JOIN dbo.REGISTER_CONFIG
        //                           inner join WM_CATEGORY
        //                           ON WM_CATEGORY.PERSONOUID = WM_PERSONAL_CARD.OUID
        //                           inner join PPR_REL_NPD_CAT
        //                           ON PPR_REL_NPD_CAT.A_ID = WM_CATEGORY.A_NAME
        //                           inner join PPR_CAT
        //                           ON PPR_REL_NPD_CAT.A_CAT = PPR_CAT.A_ID
        //                           where WM_PERSONAL_CARD.A_PCSTATUS = 1
        //) as Tab1   " +
        //                        " inner join #t2_temp " +
        //                        " on Tab1.GUID = #t2_temp.PC_GUID ";

            stringBuilder.Append(query);

            return stringBuilder.ToString();

        }
    }
}
