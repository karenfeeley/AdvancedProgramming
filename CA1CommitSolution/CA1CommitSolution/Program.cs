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
                //Instantiating listclass
                ListClass cl = new ListClass();

                //Reading the file and creating an array of lines.
                string[] lines = File.ReadAllLines(filePathSrc);

                //Adding file headings
                cl.AddItemsToList("Revision_No", "Author_Name", "Date_Time", 0, "Changed_Paths", "Comments");

                while (linecount < lines.Length)
                {
                    if ((lines[linecount].LastIndexOf("-") == 71) && (linecount + 1 < lines.Length))
                    {
                        linecount++; //moving to the next line
                        string[] commitprop = ConvertLine1(lines[linecount]);
                        int noOfComms = GetNumber(commitprop[3]);

                        linecount++; //moving to the next line

                        //Instantiating stringbuilder objects to hold the data
                        StringBuilder cp = new StringBuilder();//1st changepaths object
                        StringBuilder cp1 = new StringBuilder();//2nd changepaths object - limited cell capacity in excel
                        StringBuilder comms = new StringBuilder();//comments object

                        if (lines[linecount].IndexOf(':') == 13)//validating linecount is @ changedPaths:
                        {
                            linecount = ConvertBlock1(linecount, cl, lines, commitprop, noOfComms, cp, cp1);
                        }
                        else
                        {
                            cp.Append($"File format has changed_review file source: {filePathSrc}");
                            while (lines[linecount] != string.Empty && noOfComms > 0)
                            {
                                linecount++;
                            }
                        }
                        linecount++;//moving to the next line

                        //creating the comments datablock
                        ConvertBlock2(linecount, lines, noOfComms, comms);

                        //adding data to the commitList
                        cl.AddItemsToList(commitprop[0], commitprop[1], commitprop[2], noOfComms, cp.ToString(), comms.ToString());
                    }
                    else
                    {
                        linecount++;
                    }
                }
                //Write the list out to a new file "Commit-Output_datatime.csv"
                CreateCommitFile(cl.commitList);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found error: {filePathSrc}");
            }
        }


        //Methods - Convert 1stline
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

        //Get number of comments in each block of code
        static int GetNumber(string commsNbr)
        {
            int loc = commsNbr.IndexOf("line");
            int nmbr = int.Parse(commsNbr = commsNbr.Substring(0, loc - 1));

            return nmbr;
        }

        //Convert first block of code - starting at "ChangedPaths:"
        private static int ConvertBlock1(int linecount, ListClass cl, string[] lines, string[] commitprop,
                                        int noOfComms, StringBuilder cp, StringBuilder cp1)
        {
            linecount++;
            while (lines[linecount] != "" && cp.Length < 30000)
            {
                lines[linecount] = lines[linecount].Trim();
                lines[linecount] = lines[linecount].Replace(",", "");//removing any commas for csv output
                //adding " between lines to allow for multiline separation in the future
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
                cl.AddItemsToList(string.Format($"{commitprop[0]}a"), commitprop[1], commitprop[2], noOfComms, cp1.ToString(),
                                string.Format($"{commitprop[0]}:Additional record - ChangedPaths cellsize_OverCapacity"));
            }
            return linecount;
        }

        //Creating Comments block of code
        private static void ConvertBlock2(int linecount, string[] lines, int noOfComms, StringBuilder comms)
        {
            for (int i = linecount; i < (linecount + noOfComms); i++)
            {
                lines[i] = lines[i].Trim();
                lines[i] = lines[i].Replace(",", "");//removing any commas for csv output
                //adding " between lines to allow for multiline separation in the future
                comms.Append(string.Format($"\"{lines[i]}\""));
            }
        }

        //Creating the CsvOutput file
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
