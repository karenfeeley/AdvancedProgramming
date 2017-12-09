using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CA1CommitSolution
{
    class Program
    {
       


        static readonly string filePathSrc = Environment.GetFolderPath
                                (Environment.SpecialFolder.MyDocuments)
                                + Path.DirectorySeparatorChar + "commit_changes.txt";

        static string filePathDes
        {
            get
            {
                return string.Format("{0}{1}commit_Updates{2:_yyyyMMdd_hh-mm-ss}.csv",
                                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                    Path.DirectorySeparatorChar, DateTime.Now);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //Variables
                int linecount = 0;
                //Instantiating
                ListClass cl = new ListClass();
                //Reading the file and creating an array of lines.
                string[] lines = File.ReadAllLines(filePathSrc);

                while (linecount < lines.Length)
                {
                    if ((lines[linecount].LastIndexOf("-") == 71) && (linecount + 1 < lines.Length))
                    {
                        linecount++; //moving to the next line
                        string[] commitprop = ConvertLine1(lines[linecount]);
                        int noOfComms = GetNumber(commitprop[3]);

                        linecount++; //moving to the next line
                        StringBuilder cp = new StringBuilder();//changepaths object
                        StringBuilder cp1 = new StringBuilder();//2nd changepaths object - limited cell capacity in excel
                        StringBuilder comms = new StringBuilder();//comments object

                        if (lines[linecount].IndexOf(':') == 13)//validating linecount is @ changedPaths:
                        {
                            linecount++;
                            while (lines[linecount] != "" && cp.Length < 30000)
                            {
                                lines[linecount] = lines[linecount].Trim();
                                cp.Append(string.Format($"\"{lines[linecount]}\""));
                                linecount++;
                            }
                            if (cp.Length >= 30000)
                            {
                                while (lines[linecount] != "")
                                {

                                    lines[linecount] = lines[linecount].Trim();
                                    cp1.Append(string.Format($"\"{lines[linecount]}\""));
                                    linecount++;
                                }
                                cl.AddItemsToList(commitprop[0], commitprop[1], "", noOfComms, cp1.ToString(), "\"**Duplicate record - ChangedPaths cellOverCapacity**\"");
                            }
                        }
                        else
                        {
                            cp.Append($"File format has changed_review file source: {filePathSrc}");
                            while (lines[linecount] != string.Empty && noOfComms > 0)
                            {
                                linecount++;
                            }
                        }
                        linecount++;
                        for (int i = linecount; i < (linecount + noOfComms); i++)
                        {
                            lines[i] = lines[i].Trim();
                            comms.Append(string.Format($"\"{lines[i]}\""));
                        }

                        //adding commit properties to the commitList
                        cl.AddItemsToList(commitprop[0], commitprop[1], commitprop[2], noOfComms, cp.ToString(), comms.ToString());
                    }
                    else
                    {
                        linecount++;
                    }
                }

            //toDo: Console writeline in final version
            foreach (Commit c in cl.commitList)
            {
                Console.WriteLine(c.ToString()); //override ToString Method
            }
            Console.ReadLine();
            //Write the list out to a new file "Commit-Output.csv"
            CreateCommitFile(cl.commitList);

            }
            catch (FileNotFoundException)
            {

                Console.WriteLine("File not found error");
            }

        }

        //Methods
        static string[] ConvertLine1(string ln)
        {
            //defining the delimiter
            char[] delimiter = { '|' };

            //removing any commas
            string noComma = ln.Replace(",", "");

            //splitting based on |
            string[] commitProp = noComma.Split(delimiter);

            //Trimming and cleaning up the data
            for (int j = 0; j < commitProp.Length; j++)
            {
                commitProp[j] = commitProp[j].Trim();
            }

            return commitProp;
        }

        static int GetNumber(string commsNbr)
        {
            int loc = commsNbr.IndexOf("line");
            int nmbr = int.Parse(commsNbr = commsNbr.Substring(0, loc - 1));

            return nmbr;
        }

        private static void CreateCommitFile(List<Commit> outPutlist)
        {

            if (File.Exists(filePathDes))
            {
                File.Delete(filePathDes);
            }

            else if (!File.Exists(filePathDes))
            {
                using (FileStream fstream = File.Create(filePathDes))
                {
                    using (TextWriter txtWriter = new StreamWriter(fstream, Encoding.UTF8))
                    {
                        foreach (var item in outPutlist)
                        {
                            txtWriter.WriteLine(item);
                        }
                    }
                }
                Console.WriteLine($"File created :{filePathDes}");
                Console.ReadLine();
            }
        }
    }
}
