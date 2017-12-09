using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1CommitSolution
{
    class ListClass
    {
        internal List<Commit> commitList = new List<Commit>();

        public void AddItemsToList(string revNo, string nme, string date, int ln, string chg, string cmt)
        {
            //Instantiating the commit object with required paramters
            Commit commit = new Commit(revNo, nme, date, ln, chg, cmt);

            commitList.Add(commit);
        }




    }
}
