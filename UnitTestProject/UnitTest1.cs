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
        // �������������� ���� ������ ��� � ������ �������� � ������ ���� ����� �����������
        // ��� �� ������������ ����������������.
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
        ///// ����� � ���� �������� ������ ��� ����� �� ������ � 55 ���.
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
        ///// �������� ��� �������� ������ �������� �� ������ � 60 ���.
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

            // �������� ������ �� ��������.
            ReportCopyPattern reportCopyPattern = new ReportCopyPattern();

            // ������� ��� �����.
            string fileNameReport = reportCopyPattern.GetFileName();

            // string fName = "�������������";

            ////try
            ////{

            ////var test = fName;

            ////��������� ������ � ����� ���������
            //FileInfo fn = new FileInfo(System.Windows.Forms.Application.StartupPath + @"\������\�������������.docx");
            //fn.CopyTo(@"F:\VS 2019 �������\WinAnaliticPayment\WinAnaliticPayment" + @"\���������\" + fName + ".docx", true);

            ////idProcessWord = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\���������\" + fName + ".doc").Id;
            ////}
            ////catch
            ////{

            ////    //idProcessWord = System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\���������\" + fName + ".doc").Id;

            ////    System.Windows.Forms.MessageBox.Show("�������� � ��� ��� ������ ������� � ���� ����������. �������� ���� �������.");
            ////    return;
            ////}

            //string fileNameReport = @"F:\VS 2019 �������\WinAnaliticPayment\WinAnaliticPayment" + @"\���������\" + fName + ".docx";


            // Arrage.
            //List<string> listRegions = new List<string>();
            //listRegions.Add("��������");
            //listRegions.Add("�����������");

            //// Act.
            //PrintErrorRegions printErrorRegions = new PrintErrorRegions(listRegions);
            //printErrorRegions.Print();

        }
    }
}
