using System;
using HotTipsterApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace UnitTestHotTipsterApp
{
    [TestClass]
    public class TestDataUpdates
    {
        List<RaceResultsModel> testRaceModel;
        RaceResultsModel model;
        DataUpdateMethods myDataMethods;
        List<RaceResultsModel> mylist;
        RaceReportMethods rrm;
        private const string srcOrig_file_name = "HotTipsterTestOrig.txt";
        private const string doesntexistfile = "Doesntexist.txt";
        private const string wrongfile = "WrongFile.txt";
        private const string raceResultsfile = "HotTipsterTestDataSer.txt";
        private const string raceUpdatesfile = "HotTipsterTestDataSer1.txt";
        private const string raceUpdatesfile1 = "HotTipsterTestDataSer2.txt";
        private const string file_dirname = @"C:\Users\Admin\Documents";
        private string fullpath = $"{file_dirname}\\{raceResultsfile}";
        

        [TestInitialize]
        public void TestInitialize()
        {
            model = new RaceResultsModel();
            myDataMethods = new DataUpdateMethods();
            testRaceModel = new List<RaceResultsModel>();
            mylist = new List<RaceResultsModel>();
            rrm = new RaceReportMethods();

            ////Sample testdata
            mylist.Add(new RaceResultsModel { ID = 1, RaceCourse = "Aintree", RaceDate = Convert.ToDateTime("12/05/2017"), Amount = 11.58M, Result = "Win" });
            mylist.Add(new RaceResultsModel { ID = 2, RaceCourse = "Punchestown", RaceDate = Convert.ToDateTime("22/02/2016"), Amount = 122.52M, Result = "Win" });
            mylist.Add(new RaceResultsModel { ID = 3, RaceCourse = "Sandown", RaceDate = Convert.ToDateTime("17/11/2016"), Amount = 20.00M, Result = "Loss" });
            mylist.Add(new RaceResultsModel { ID = 4, RaceCourse = "Ayr", RaceDate = Convert.ToDateTime("03/11/2016"), Amount = 25.00M, Result = "Loss" });
            mylist.Add(new RaceResultsModel { ID = 5, RaceCourse = "Fairyhouse", RaceDate = Convert.ToDateTime("02/12/2016"), Amount = 65.75M, Result = "Win" });
            mylist.Add(new RaceResultsModel { ID = 6, RaceCourse = "Ayr", RaceDate = Convert.ToDateTime("11/03/2017"), Amount = 12.05M, Result = "Win" });
            mylist.Add(new RaceResultsModel { ID = 7, RaceCourse = "Doncaster", RaceDate = Convert.ToDateTime("02/12/2017"), Amount = 10.00M, Result = "Loss" });
            mylist.Add(new RaceResultsModel { ID = 8, RaceCourse = "Towcester", RaceDate = Convert.ToDateTime("12/03/2016"), Amount = 50.00M, Result = "Loss" });
            mylist.Add(new RaceResultsModel { ID = 9, RaceCourse = "Goodwood", RaceDate = Convert.ToDateTime("07/10/2017"), Amount = 525.74M, Result = "Win" });
            mylist.Add(new RaceResultsModel { ID = 10, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 43.21M, Result = "Win" });
        }      

        [TestMethod]
        public void ImportOrigAndSaveTestData()
        {           
            testRaceModel = srcOrig_file_name.FullFilePath().ImportOrigFile().ConvertOrigData();
            testRaceModel.SaveSerialisedFile(raceResultsfile);
            Assert.IsTrue(File.Exists(fullpath));
        }

        [TestMethod]
        public void ImportFileNotFound()
        {
            string error = doesntexistfile.FullFilePath();
            Assert.IsFalse(File.Exists(error));
        }

        [TestMethod]
        public void ImportWrongFile()
        {
            testRaceModel = wrongfile.FullFilePath().ImportOrigFile().ConvertOrigData();
            int checkmodel = testRaceModel.Count;
            Assert.AreEqual(0, checkmodel);
        }

        [TestMethod]
        public void OpenFileCountItems()
        {
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            int checkmodel = testRaceModel.Count;
            Assert.AreEqual(10, checkmodel);

        }

        [TestMethod]
        public void CompareLists()
        {
            testRaceModel = srcOrig_file_name.FullFilePath().ImportOrigFile().ConvertOrigData();
            testRaceModel.SaveSerialisedFile(raceResultsfile);           
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            Assert.AreEqual(10, testRaceModel.Count());
            CollectionAssert.Equals(mylist, testRaceModel);
        }

        //Data update tests
        [TestMethod]
        public void AddNewItem()
        {
            testRaceModel = srcOrig_file_name.FullFilePath().ImportOrigFile().ConvertOrigData();
            testRaceModel.SaveSerialisedFile(raceResultsfile);
            model = new RaceResultsModel { ID = 11, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 43.21M, Result = "Win" };
            testRaceModel = myDataMethods.AddNewRecord(model, raceResultsfile);
            model = new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 00.00M, Result = "NoResult" };
            testRaceModel = myDataMethods.AddNewRecord(model, raceResultsfile);
            //my comparison data
            mylist.Add(new RaceResultsModel { ID = 11, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 43.21M, Result = "Win" });
            mylist.Add(new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 00.00M, Result = "NoResult" });
            Assert.AreEqual(mylist.Count(), testRaceModel.Count());
            CollectionAssert.Equals(mylist.ToList(), testRaceModel.ToList());   
        }

        [TestMethod]
        public void DeleteRecord()
        {
            //Initial data
            testRaceModel = srcOrig_file_name.FullFilePath().ImportOrigFile().ConvertOrigData();
            testRaceModel.SaveSerialisedFile(raceResultsfile);
            model = new RaceResultsModel { ID = 11, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 43.21M, Result = "Win" };
            testRaceModel = myDataMethods.AddNewRecord(model, raceResultsfile);
            model = new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 00.00M, Result = "NoResult" };
            testRaceModel = myDataMethods.AddNewRecord(model, raceResultsfile);
            mylist.Add(new RaceResultsModel { ID = 11, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 43.21M, Result = "Win" });
            mylist.Add(new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 00.00M, Result = "NoResult" });

            //Delete comparison data
            mylist.RemoveAll(x => x.ID == 12);
            //Item to delete
            model = new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 00.00M, Result = "NoResult" };

            //Delete methods
            testRaceModel = myDataMethods.DeleteRecord(model, raceUpdatesfile);
            Assert.AreEqual(mylist.Count(), testRaceModel.Count());

        }

        [TestMethod]
        public void UpdateRecord()
        {
            //Initial data
            testRaceModel = srcOrig_file_name.FullFilePath().ImportOrigFile().ConvertOrigData();
            testRaceModel.SaveSerialisedFile(raceResultsfile);
            model = new RaceResultsModel { ID = 11, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 43.21M, Result = "Win" };
            testRaceModel = myDataMethods.AddNewRecord(model, raceResultsfile);
            model = new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 00.00M, Result = "NoResult" };
            testRaceModel = myDataMethods.AddNewRecord(model, raceResultsfile);
            mylist.Add(new RaceResultsModel { ID = 11, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 43.21M, Result = "Win" });
            mylist.Add(new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 00.00M, Result = "NoResult" });

            //Update comparison data
            mylist.RemoveAll(x => x.ID == 12);
            mylist.Add(new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 100.00M, Result = "Win" });
            mylist.OrderBy(r => r.ID);
         
            //Item to update
            model = new RaceResultsModel { ID = 12, RaceCourse = "Kelso", RaceDate = Convert.ToDateTime("13/09/2016"), Amount = 100.00M, Result = "Win" };

            //update methods
            testRaceModel = myDataMethods.UpdateRecord(model, raceUpdatesfile1);
            Assert.AreEqual(mylist.Count(), testRaceModel.Count());

            //Expected
            string myExpectedupdate = "12 Kelso 13/09/2016 100.00 Win";
            string updateTestItem = string.Format(testRaceModel[11].ToString());          
            Assert.AreEqual(myExpectedupdate, updateTestItem);

        }



        //Reporting Methods tests
        [TestMethod]
        public void TotalRaces()
        {
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            //testing the GetTotalNumRaces method
            int totalRaces = rrm.GetTotalNumRaces(testRaceModel);
            Assert.AreEqual(11, totalRaces);  
        }

        [TestMethod]
        public void TotalNumberOfRacesWon()
        {
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            //testing the GetTotalRacesWon method
            int totalRacesWon = rrm.GetTotalRacesWon(testRaceModel);
            Assert.AreEqual(7,totalRacesWon);
        }

        [TestMethod]
        public void HighestLoss()
        {
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            //Expected answer
            var expectedHighLoss = new RaceResultsModel { ID = 8, RaceCourse = "Towcester", RaceDate = Convert.ToDateTime("12/03/2016"), Amount = 50.00M, Result = "Loss" }.ToString();
            //testing the GetHighestLoss method
            var testHighestLoss = rrm.GetHighestLoss(testRaceModel).ToString();
            Assert.AreEqual(expectedHighLoss, testHighestLoss);          
        }

        [TestMethod]
        public void HighestWin()
        {
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            //Expected answer
            var expectedHighWin = new RaceResultsModel { ID = 9, RaceCourse = "Goodwood", RaceDate = Convert.ToDateTime("07/10/2017"), Amount = 525.74M, Result = "Win" }.ToString();
            //testing the GetHighestWin method
            var testHighestWin = rrm.GetHighestWon(testRaceModel).ToString();
            Assert.AreEqual(expectedHighWin, testHighestWin);
        }

        [TestMethod]
        public void TotalBetsByYear()
        {
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            List<string> myresultsList = new List<string>();
            //Expected
            myresultsList.Add("{ Year = 2017, Results = Win, Total = 549.37 }");
            myresultsList.Add("{ Year = 2017, Results = Loss, Total = 10.00 }");
            myresultsList.Add("{ Year = 2016, Results = Win, Total = 274.69 }");
            myresultsList.Add("{ Year = 2016, Results = Loss, Total = 95.00 }");
            myresultsList.Add("{ Year = 2016, Results = NoResult, Total = 0.00 }");

            var testTotalBets = rrm.GetTotalByYear(testRaceModel);
            List<string> actualList = new List<string>();
            foreach (var item in testTotalBets)
            {              
                string convert = item.ToString();
                actualList.Add(convert);
            }
            CollectionAssert.AreEqual(myresultsList, actualList);
        }

        [TestMethod]
        public void MostPopular()
        {
            //Most popular - Top 5 RaceCourses
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            List<string> myresultsList = new List<string>();
            //Expected
            myresultsList.Add("{ Total = 3, RaceCourse = Kelso }");
            myresultsList.Add("{ Total = 2, RaceCourse = Ayr }");
            myresultsList.Add("{ Total = 1, RaceCourse = Aintree }");
            myresultsList.Add("{ Total = 1, RaceCourse = Punchestown }");
            myresultsList.Add("{ Total = 1, RaceCourse = Sandown }");

            var mostFrequent = rrm.GetMostPopular(testRaceModel);
            List<string> actualList = new List<string>();
            foreach (var item in mostFrequent)
            {
                string convert = item.ToString();
                actualList.Add(convert);
            }
            CollectionAssert.AreEqual(myresultsList, actualList);
        }  

        [TestMethod]
        public void RacesPendingUpdates()
        {
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            List<string> myresultsList = new List<string>();
            //Expected
            myresultsList.Add("12 Kelso 13/09/2016 0.00 NoResult");

            var updates = rrm.GetRacesPendingUpdates(testRaceModel);
            List<string> actualList = new List<string>();
            foreach (var item in updates)
            {
                string convert = item.ToString();
                actualList.Add(convert);
            }
            CollectionAssert.AreEqual(myresultsList, actualList);
        }

        [TestMethod]
        public void SortedByDate()
        {
            testRaceModel = raceResultsfile.FullFilePath().OpenSerialisedFile();
            List<string> myresultsList = new List<string>();
            //Expected
            myresultsList.Add("8 Towcester 12/03/2016 50.00 Loss");
            myresultsList.Add("10 Kelso 13/09/2016 43.21 Win");
            myresultsList.Add("11 Kelso 13/09/2016 43.21 Win");
            myresultsList.Add("12 Kelso 13/09/2016 0.00 NoResult");
            myresultsList.Add("4 Ayr 03/11/2016 25.00 Loss");
            myresultsList.Add("3 Sandown 17/11/2016 20.00 Loss");
            myresultsList.Add("5 Fairyhouse 02/12/2016 65.75 Win");
            myresultsList.Add("2 Punchestown 22/12/2016 122.52 Win");
            myresultsList.Add("6 Ayr 11/03/2017 12.05 Win");
            myresultsList.Add("1 Aintree 12/05/2017 11.58 Win");
            myresultsList.Add("9 Goodwood 07/10/2017 525.74 Win");
            myresultsList.Add("7 Doncaster 02/12/2017 10.00 Loss");

            var sorted = rrm.GetSortedByDate(testRaceModel);
            List<string> actualList = new List<string>();
            foreach (var item in sorted)
            {
                string convert = item.ToString();
                actualList.Add(convert);
            }
            CollectionAssert.AreEqual(myresultsList, actualList);
        }
        [TestCleanup]
        public void TestCleanUp()
        {

        }
    }
}
