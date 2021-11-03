
DECLARE @MSP VARCHAR(255)
--SET @MSP = 'Ежемесячная компенсация расходов на оплату жилого помещения и коммунальных услуг (федеральный бюджет)' 
SET @MSP = 'Пособие на ребенка' 
 
SELECT     TOP (100) PERCENT derivedtbl_1.OUID, 
                             derivedtbl_1.A_PCSTATUS,
                             derivedtbl_1.f, 
                             derivedtbl_1.i, 
                             derivedtbl_1.o, 
                             derivedtbl_1.dr, 
                             PPR_SERV.A_NAME AS МСП, 
                             PPR_CAT.A_NAME AS Категория,
                             SPR_STATUS_PROCESS.A_NAME AS [Статус МСП], 
                             derivedtbl_2.OUID AS OUID_reb,
                             derivedtbl_2.A_SNILS AS SNILS, 
                             derivedtbl_2.fam AS fam_reb, 
                             derivedtbl_2.im AS im_reb,
                             derivedtbl_2.otches AS otchest_reb, 
                             derivedtbl_2.dat AS dr_reb, 
                             SPR_MAIL_PHONE.A_INDEX AS Индекс, 
                             WM_ADDRESS.A_ADRTITLE AS Адрес, 
                             CONVERT(char(10),  SPR_SERV_PERIOD.STARTDATE, 104) AS [Дата начала МСП], 
                             CONVERT(char(10), SPR_SERV_PERIOD.A_LASTDATE, 104) AS [Дата окончания МСП],
                             WM_PAYMENT_BOOK.A_NUMPB AS [№ выплатного дела], 
                             CONVERT(char(10), ESRN_SERV_SERV.A_SERVDATE, 104) AS [Дата принятия решения о назначении], 
                             SPR_LABEL.A_NAME AS Метка
FROM         WM_PCPHONE RIGHT OUTER JOIN
                          (SELECT     TOP (100) PERCENT SPR_FIO_SURNAME.A_NAME AS f, SPR_FIO_NAME.A_NAME AS i, SPR_FIO_SECONDNAME.A_NAME AS o, 
                                                   WM_PERSONAL_CARD_1.OUID, CONVERT(char(10), WM_PERSONAL_CARD_1.BIRTHDATE, 104) AS dr
                                                   ,WM_PERSONAL_CARD_1.A_PCSTATUS
                            FROM          SPR_FIO_SURNAME RIGHT OUTER JOIN
                                                   SPR_FIO_SECONDNAME RIGHT OUTER JOIN
                                                   WM_PERSONAL_CARD AS WM_PERSONAL_CARD_1 ON SPR_FIO_SECONDNAME.OUID = WM_PERSONAL_CARD_1.A_SECONDNAME LEFT OUTER JOIN
                                                   SPR_FIO_NAME ON WM_PERSONAL_CARD_1.A_NAME = SPR_FIO_NAME.OUID ON SPR_FIO_SURNAME.OUID = WM_PERSONAL_CARD_1.SURNAME)
                      AS derivedtbl_1 INNER JOIN
                      WM_PERSONAL_CARD ON derivedtbl_1.OUID = WM_PERSONAL_CARD.OUID ON WM_PCPHONE.A_PERSCARD = WM_PERSONAL_CARD.OUID LEFT OUTER JOIN
                      WM_PAYMENT_BOOK INNER JOIN
                          (SELECT     TOP (100) PERCENT SPR_FIO_SURNAME_1.A_NAME AS fam, SPR_FIO_NAME_1.A_NAME AS im, SPR_FIO_SECONDNAME_1.A_NAME AS otches, 
                                                   CONVERT(char(10), WM_PERSONAL_CARD_1.BIRTHDATE, 104) AS dat, WM_PERSONAL_CARD_1.OUID
                                                   ,WM_PERSONAL_CARD_1.A_SNILS
                            FROM          SPR_FIO_SURNAME AS SPR_FIO_SURNAME_1 RIGHT OUTER JOIN
                                                   SPR_FIO_SECONDNAME AS SPR_FIO_SECONDNAME_1 RIGHT OUTER JOIN
                                                   WM_PERSONAL_CARD AS WM_PERSONAL_CARD_1 ON 
                                                   SPR_FIO_SECONDNAME_1.OUID = WM_PERSONAL_CARD_1.A_SECONDNAME LEFT OUTER JOIN
                                                   SPR_FIO_NAME AS SPR_FIO_NAME_1 ON WM_PERSONAL_CARD_1.A_NAME = SPR_FIO_NAME_1.OUID ON 
                                                   SPR_FIO_SURNAME_1.OUID = WM_PERSONAL_CARD_1.SURNAME) AS derivedtbl_2 INNER JOIN
                      SPR_STATUS_PROCESS INNER JOIN
                      SPR_NPD_MSP_CAT INNER JOIN
                      ESRN_SERV_SERV ON SPR_NPD_MSP_CAT.A_ID = ESRN_SERV_SERV.A_SERV 
					  INNER JOIN PPR_SERV ON 
					  SPR_NPD_MSP_CAT.A_MSP = PPR_SERV.A_ID 
					  ON SPR_STATUS_PROCESS.A_ID = ESRN_SERV_SERV.A_STATUSPRIVELEGE ON 
                      derivedtbl_2.OUID = ESRN_SERV_SERV.A_CHILD INNER JOIN
                      PPR_CAT ON SPR_NPD_MSP_CAT.A_CATEGORY = PPR_CAT.A_ID ON WM_PAYMENT_BOOK.OUID = ESRN_SERV_SERV.A_PAYMENTBOOK LEFT OUTER JOIN
 
                      SPR_LABEL ON ESRN_SERV_SERV.A_LABEL = SPR_LABEL.A_ID LEFT OUTER JOIN
                      SPR_SERV_PERIOD ON ESRN_SERV_SERV.OUID = SPR_SERV_PERIOD.A_SERV ON 
                      WM_PERSONAL_CARD.OUID = ESRN_SERV_SERV.A_PERSONOUID LEFT OUTER JOIN
                      SPR_MAIL_PHONE RIGHT OUTER JOIN
                      WM_ADDRESS ON SPR_MAIL_PHONE.OUID = WM_ADDRESS.A_MAIL_PHONE ON WM_PERSONAL_CARD.A_REGFLAT = WM_ADDRESS.OUID
WHERE    -- (ESRN_SERV_SERV.A_STATUSPRIVELEGE = 13) AND
             
            (ESRN_SERV_SERV.A_STATUS = 10) 
            AND (PPR_SERV.A_NAME = @MSP)
                         
            AND (SPR_SERV_PERIOD.A_STATUS = 10) 

            --AND (SPR_LABEL.A_NAME = 'Был размер 4854 руб.') 
        --    AND (PPR_CAT.A_NAME = 'Реабилитированные лица' --OR PPR_CAT.A_NAME = 'Семьи, имеющие детей-инвалидов' 
        --    OR PPR_CAT.A_NAME = 'Инвалид')
        
    GROUP BY derivedtbl_1.OUID, derivedtbl_2.OUID, derivedtbl_1.f, derivedtbl_1.i, derivedtbl_1.o, derivedtbl_1.dr, PPR_SERV.A_NAME, SPR_STATUS_PROCESS.A_NAME, 
                      derivedtbl_2.fam, derivedtbl_2.im, derivedtbl_2.otches, derivedtbl_2.dat, WM_ADDRESS.A_ADRTITLE, SPR_SERV_PERIOD.STARTDATE, 
                      SPR_SERV_PERIOD.A_LASTDATE, PPR_CAT.A_NAME, WM_PAYMENT_BOOK.A_NUMPB, ESRN_SERV_SERV.A_SERVDATE, SPR_MAIL_PHONE.A_INDEX, 
                      SPR_LABEL.A_NAME,derivedtbl_2.A_SNILS, derivedtbl_1.A_PCSTATUS
					  --having SPR_SERV_PERIOD.A_LASTDATE >= '20211125'
ORDER BY derivedtbl_1.f

 