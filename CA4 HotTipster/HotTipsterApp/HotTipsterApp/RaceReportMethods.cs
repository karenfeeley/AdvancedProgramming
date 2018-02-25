using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipsterApp
{
    public class RaceReportMethods
    {
        public RaceResultsModel GetHighestLoss(List<RaceResultsModel> raceResults)
        {
            //Highest lost
            var racesLoss = raceResults.Where(w => w.Result == "Loss");
            var highestLoss = racesLoss.Aggregate((w1, w2) => w1.Amount > w2.Amount ? w1 : w2);

            return highestLoss;

        }
        public RaceResultsModel GetHighestWon(List<RaceResultsModel> raceResults)
        {
            //Highest won 
            var racesWon = raceResults.Where(w => w.Result == "Win");
            var highestWon = racesWon.Aggregate((w1, w2) => w1.Amount > w2.Amount ? w1 : w2);

            return highestWon;
        }

        public List<dynamic> GetMostPopular(List<RaceResultsModel> raceResults)
        {
            //Most popular - Top 5 RaceCourses
            var mostFrequent = raceResults.GroupBy(w => w.RaceCourse)
                                            .OrderByDescending(gp => gp.Count())
                                            .Take(5)
                                            .Select(g => new { Total = g.Count(), RaceCourse = g.Key });

            return mostFrequent.ToList<dynamic>();

        }
        public List<RaceResultsModel> GetRacesPendingUpdates(List<RaceResultsModel> raceResults)
        {
            //Race records showing NoResult in data records
            var pendingUpdates = from result in raceResults
                                 where result.Result.Contains("NoResult")
                                 select result;

            return pendingUpdates.ToList();
        }

        public List<RaceResultsModel> GetSortedByDate(List<RaceResultsModel> raceResults)
        {
            var sortedBydate = raceResults.OrderBy(r => r.RaceDate);

            return sortedBydate.ToList();
        }

        public List<dynamic> GetTotalByYear(List<RaceResultsModel> raceResults)
        {
            //Total bets per year, Total Won, Total Lost
            var totalBetsByYear = from r in raceResults
                                  group r by new { r.RaceDate.Year, r.Result } into g
                                  select new { g.Key.Year, Results = g.Key.Result, Total = g.Sum(r => r.Amount) };

            var sortedByYear = totalBetsByYear.OrderByDescending(r => r.Year);

            return sortedByYear.ToList<dynamic>();
        }

        public int GetTotalNumRaces(List<RaceResultsModel> raceResults)
        {
            //Total number of races with a bet placed and either a Win or Loss set
            var totalRaces = raceResults.Where(w => w.Result != "NoResult").Count();
           
            return totalRaces;
        }

        public int GetTotalRacesWon(List<RaceResultsModel> raceResults)
        {   
            //Total number of races won
            var totalRacesWon = raceResults.Where(w => w.Result == "Win").Count();
            
            return totalRacesWon;
        }      
    }
}
