using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipsterApp
{

    [Serializable]
    public class RaceResultsModel
    {
        public int ID { get; set; }

        public string RaceCourse { get; set; }

        public DateTime RaceDate { get; set; }

        public decimal Amount { get; set; }

        public string Result { get; set; }

        //constructor for initial import file, assigning unique Ids.
        public RaceResultsModel(int id, string raceCourse, string raceDate, string amt, string result)
        {
            ID = id;
            RaceCourse = raceCourse;
            RaceDate = Convert.ToDateTime(raceDate);
            decimal amount = 0.0M;
            decimal.TryParse(amt, out amount);
            Amount = amount;
            Result = result;
        }

        //constructor for adding new records without the ID being known.
        public RaceResultsModel(string raceCourse, string raceDate, string amt, string result)
        {

            RaceCourse = raceCourse;
            RaceDate = Convert.ToDateTime(raceDate);
            decimal amount = 0.0M;
            decimal.TryParse(amt, out amount);
            Amount = amount;
            Result = result;
        }

        public RaceResultsModel()
        {

        }

        public override string ToString()
        {
            return string.Format(ID + " " + RaceCourse + " " + RaceDate.ToShortDateString()
                            + " " + Amount + " " + Result);
        }

    }
}
