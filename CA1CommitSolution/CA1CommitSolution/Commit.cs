using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1CommitSolution
{
    class Commit
    {
        //Properties
        public string RevisionNo { get; set; }
        public string Name { get; set; }
        public string DateLog { get; set; }
        public int Line { get; set; }
        public string Changes { get; set; }
        public string Comment { get; set; }


        //6 Parameter required Constructor
        public Commit(string revisionNo, string name, string dateLog, int lineNbr, string changes, string comment)
        {
            RevisionNo = revisionNo;
            Name = name;
            DateLog = dateLog;
            Line = lineNbr;
            Changes = changes;
            Comment = comment;
        }


        //Method - stringbuilder object in csv format.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(RevisionNo + ",");
            sb.Append(Name + ",");
            sb.Append(DateLog + ",");
            sb.Append(Line + ",");
            sb.Append(Comment + ",");
            sb.Append(Changes + ",");

            return sb.ToString();

        }


    }
}
