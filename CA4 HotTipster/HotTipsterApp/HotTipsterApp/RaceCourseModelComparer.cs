using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipsterApp
{
    public class RaceCourseModelComparer:IEqualityComparer<RaceResultsModel>
    {

        public bool Equals(RaceResultsModel x, RaceResultsModel y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            return x != null && y != null &&
                x.ID.Equals(y.ID)
                && x.RaceCourse.Equals(y.RaceCourse)
                && x.RaceDate.Equals(y.RaceDate)
                && x.Amount.Equals(y.Amount)
                && x.Result.Equals(y.Result);
  
        }

        public int GetHashCode(RaceResultsModel obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
