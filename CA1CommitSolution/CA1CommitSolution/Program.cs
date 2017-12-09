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
        //ToDo:FilePath to be updated to be: Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "CommitUpdates.csv";
        
        static readonly string filePathSrc = @"C:\Users\Admin\OneDrive - Dublin Business School (DBS)\07. Advanced Programming\CA 20171210\commit_changestst1.txt";
        static readonly string filePathDes = @"C:\Users\Admin\OneDrive - Dublin Business School (DBS)\07. Advanced Programming\CA 20171210\commit_Output.csv";

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

                        linecount++; //moving to the next line
                        StringBuilder cp = new StringBuilder();
                        while (lines[linecount] != "")
                        {
                            linecount++;
                            lines[linecount] = lines[linecount].Trim();
                            cp.AppendLine(lines[linecount]);
                        }
                        //ToDo: review CP  - extra line being added...not due to appendline
                        linecount++;

                        StringBuilder comms = new StringBuilder();
                        int noOfComms = GetNumber(commitprop[3]);
                        for (int i = linecount; i < (linecount + noOfComms); i++)
                        {
                            lines[i] = lines[i].Trim();
                            comms.Append(string.Format($"\"{lines[i]}\""));
                            i++;
                        }


                        //adding commit properties to the commitList
                        cl.AddItemsToList(commitprop[0], commitprop[1], commitprop[2], noOfComms, cp.ToString(), comms.ToString());
                    }

                    else
                    {
                        linecount++;
                    }

                }
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
            }
        }
    }
}
