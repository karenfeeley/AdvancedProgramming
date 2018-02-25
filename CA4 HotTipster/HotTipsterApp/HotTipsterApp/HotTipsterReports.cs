using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTipsterApp
{
    public partial class HotTipsterReports : Form
    {
        public static List<RaceResultsModel> _savedData = new List<RaceResultsModel>();
        RaceReportMethods rrm = new RaceReportMethods();

        public HotTipsterReports(List<RaceResultsModel> savedData)
        {
            _savedData = savedData;
            InitializeComponent();
            //RaceReportMethods rrm = new RaceReportMethods();
            lstReportsData.Items.Add("Race Records to date:");
            lstReportsData.Items.Add("====================================");
            foreach (var record in _savedData)
            {
                lstReportsData.Items.Add(record);
            }
        }

        private void btnBettingStats_Click(object sender, EventArgs e)
        {
            lstReportsData.Items.Clear();

            int totalRaces = rrm.GetTotalNumRaces(_savedData);
            int totalRacesWon = rrm.GetTotalRacesWon(_savedData);
            double winPercentage = ((double)totalRacesWon / totalRaces * 100);

            lstReportsData.Items.Add($"Total Races recorded to date: {totalRaces}");
            lstReportsData.Items.Add("====================================");
            lstReportsData.Items.Add($"Total Races won recorded to date: {totalRacesWon}");
            lstReportsData.Items.Add("====================================");
            lstReportsData.Items.Add($"Winning percentage : {winPercentage: 0'%'}");

        }

        private void btnHigh_Low_Click(object sender, EventArgs e)
        {
            lstReportsData.Items.Clear();
            RaceResultsModel highestWon = rrm.GetHighestWon(_savedData);
            RaceResultsModel highestLoss = rrm.GetHighestLoss(_savedData);

            lstReportsData.Items.Add("The good and the bad...");
            lstReportsData.Items.Add($"Best result todate: {highestWon}");
            lstReportsData.Items.Add("===========================================");
            lstReportsData.Items.Add($"Worst result to date: {highestLoss}");
            lstReportsData.Items.Add("===========================================");
        }

        private void btnMostPopular_Click(object sender, EventArgs e)
        {
            lstReportsData.Items.Clear();
            var mostFrequent = rrm.GetMostPopular(_savedData);
            lstReportsData.Items.Add("Top 5, Most Frequent RaceCourses visited: ");
            lstReportsData.Items.Add("=====================================");
            foreach (var item in mostFrequent)
            {
                string report = item.ToString();
                string chg1 = report.Replace("{", "");
                string chg2 = chg1.Replace("}", "");
                lstReportsData.Items.Add(chg2);
            }
        }

        private void btnResultsByYear_Click(object sender, EventArgs e)
        {
            lstReportsData.Items.Clear();
            var totalsByYear = rrm.GetTotalByYear(_savedData);
            lstReportsData.Items.Add("Totals by Year: ");
            lstReportsData.Items.Add("====================");
           // var sortedList = totalsByYear.Sort();
            foreach (var item in totalsByYear)
            {               
                string report = item.ToString();
                string chg1 = report.Replace("{", "");
                string chg2 = chg1.Replace("}", "");
                lstReportsData.Items.Add(chg2);
            }
        }

       

        private void btnSortedByDate_Click(object sender, EventArgs e)
        {
            lstReportsData.Items.Clear();

            var sortedByDate = rrm.GetSortedByDate(_savedData);
            lstReportsData.Items.Add("Race records sorted by date:");
            lstReportsData.Items.Add("============================");
            foreach (var item in sortedByDate)
            {
                lstReportsData.Items.Add(item);
            }
        }

        private void btnUpdatesPending_Click(object sender, EventArgs e)
        {
            lstUpdatesDue.Items.Clear();
            var pendingUpdates = rrm.GetRacesPendingUpdates(_savedData);
            if (pendingUpdates.Count == 0)
            {
                lstUpdatesDue.Items.Add("No records pending updates");
            }
            else
            {
                lstUpdatesDue.Items.Add("Records pending updates:");
                lstUpdatesDue.Items.Add("=======================");
                foreach (var item in pendingUpdates)
                {
                    lstUpdatesDue.Items.Add(item);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
