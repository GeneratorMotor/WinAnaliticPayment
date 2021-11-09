using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using WinAnaliticPayment.Classess;
using WinAnaliticPayment.Reports;


namespace UnitTestProject
{
    public class UnitTest1
    {
        // Закоментировал тест потому что я сделел глупость и провел тест через конструктор
        // Что не соответсвует действительности.
        //[Fact]
        //public void Test1()
        //{

        //}

        //[Fact]
        //public void TestTimeDateAgeDeadthStart()
        //{
        //    // Arrange.
        //    DateTime date = new DateTime(2022, 1, 20);

        //    DateTimeSelect dateTime = new DateTimeSelect(date);

        //    // Act
        //    var dDead = dateTime.DateAgeDeadthStart();


        //    // Assert
        //    Assert.Equal("20211201", dDead);
        //}

        //[Fact]
        //public void TestTimeDateAgeDeadthStart_20211018()
        //{
        //    // Arrange.
        //    DateTime date = new DateTime(2021, 10, 18);

        //    DateTimeSelect dateTime = new DateTimeSelect(date);

        //    // Act
        //    var dDead = dateTime.DateAgeDeadthStart();


        //    // Assert
        //    Assert.Equal("20211001", dDead);
        //}

        //[Fact]
        //public void TestDateAgeDeadthEnd()
        //{
        //    // Arrange.
        //    DateTime date = new DateTime(2022, 1, 20);

        //    DateTimeSelect dateTime = new DateTimeSelect(date);

        //    // Act
        //    var dDead = dateTime.DateAgeDeadthEnd();

        //    // Assert
        //    Assert.Equal("20211225", dDead);
        //}

        ///// <summary>
        ///// Поиск с даты рождения женщин при уходе на пенсию в 55 лет.
        ///// </summary>
        //[Fact]
        //public void TestDateAgeFemal()
        //{
        //    // Arrange.
        //    DateTime date = new DateTime(2021, 10, 18);

        //    DateTimeSelect dateTime = new DateTimeSelect(date);

        //    // Act
        //    var dDead = dateTime.DateAgeFemal();

        //    // Assert
        //    Assert.Equal("19661001", dDead);
        //}

        ///// <summary>
        ///// Проверка дня рождения мужчин уходящих на пенсию с 60 лет.
        ///// </summary>
        //[Fact]
        //public void TestDateAgeMen()
        //{
        //    // Arrage.
        //    DateTime date = new DateTime(2021, 10, 18);

        //    DateTimeSelect dateTime = new DateTimeSelect(date);

        //    // Act
        //    var dDead = dateTime.DateAgeMen();

        //    // Assert
        //    Assert.Equal("19611001", dDead);
        //}

        //[Fact]
        //public void TestDateAgeHeadMen()
        //{
        //    // Arrage.
        //    DateTime date = new DateTime(2021, 10, 18);

        //    DateTimeSelect dateTime = new DateTimeSelect(date);

        //    // Act.
        //    var dDead = dateTime.DateAgeStartMen();

        //    Assert.Equal("19610901", dDead);

        //}

        //[Fact]
        //public void TestDateAgeEndMen()
        //{
        //    // Arrage.
        //    DateTime date = new DateTime(2021, 10, 18);

        //    DateTimeSelect dateTime = new DateTimeSelect(date);

        //    // Act.
        //    var dDead = dateTime.DateAgeEndMen();

        //    Assert.Equal("19611025", dDead);

        //}

        [Fact]
        public void ReportPrintTest()
        {

            // Пролучим ссылку на документ.
            ReportCopyPattern reportCopyPattern = new ReportCopyPattern();

            // Получим имя файла.
            string fileNameReport = reportCopyPattern.GetFileName();

            // string fName = "РайоныОбласти";

            ////try
            ////{

            ////var test = fName;

            ////Скопируем шаблон в папку Документы
            //FileInfo fn = new FileInfo(System.Windows.Forms.Application.StartupPath + @"\Шаблон\РайоныОбласти.docx");
            //fn.CopyTo(@"F:\VS 2019 проекты\WinAnaliticPayment\WinAnaliticPayment" + @"\Документы\" + fName + ".docx", true);

            ////idProcessWord = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".doc").Id;
            ////}
            ////catch
            ////{

            ////    //idProcessWord = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\Документы\" + fName + ".doc").Id;

            ////    System.Windows.Forms.MessageBox.Show("Возможно у вас уже открыт договор с этим льготником. Закройте этот договор.");
            ////    return;
            ////}

            //string fileNameReport = @"F:\VS 2019 проекты\WinAnaliticPayment\WinAnaliticPayment" + @"\Документы\" + fName + ".docx";


            // Arrage.
            //List<string> listRegions = new List<string>();
            //listRegions.Add("Вольский");
            //listRegions.Add("Балаковский");

            //// Act.
            //PrintErrorRegions printErrorRegions = new PrintErrorRegions(listRegions);
            //printErrorRegions.Print();

        }
    }
}
