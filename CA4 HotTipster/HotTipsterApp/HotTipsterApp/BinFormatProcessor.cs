using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace HotTipsterApp
{
    public static class BinFormatProcessor
    {
        private const string file_dirname = @"C:\Users\Admin\Documents";

        //extension method for combining filename & file Directory
        public static string FullFilePath(this string filename)
        {
           
            return $"{ file_dirname }\\{ filename }";
        }

        //extension method for reading the data
        public static List<string> ImportOrigFile(this string file)
        {

            if (!File.Exists(file))
            {
                return new List<string>();
            }
            List<string> lines = File.ReadAllLines(file).ToList();
            //ensuring first line in imported file matches the expected pattern
            string pattern = @"^\s+\w+[,]\s[(]\d{4}[,]\s\d{1,2}[,]\s\d{1,2}[)][,]\s\d+[.]\d{2}m[,]\s(true|false)$";
            Regex reEngine = new Regex(pattern);
            Match match = reEngine.Match(lines[0]);

            if (match.Success)
            {
                return lines.ToList();
            }
            return new List<string>();
        }

        //extension method for coverting data into RaceResultsModel format
        public static List<RaceResultsModel> ConvertOrigData(this List<string> lines)
        {
            List<RaceResultsModel> output = new List<RaceResultsModel>();


            int lineId = 1;
            foreach (string line in lines)
            {
                string chg1 = line.Replace("(", "");
                string chg2 = chg1.Replace(")", "");
                string chg3 = chg2.Replace(" ", "");
                string[] words = chg3.Split(',');
                string date = string.Format(words[3] + "/" + words[2] + "/" + words[1]);
                string amt = words[4].Replace("m", "");
                string res;
                if (words[5] == "true")
                        res = "Win";
                    else
                        res = "Loss";
                RaceResultsModel resultsModel = new RaceResultsModel(lineId, words[0], date, amt, res)
                {
                    ID = lineId,
                    RaceCourse = words[0],
                    RaceDate = Convert.ToDateTime(date),
                    Amount = decimal.Parse(amt),
                    Result = res
                };
                lineId = lineId + 1;//incrementing the uniqueId for each line of data.
                output.Add(resultsModel);   
            }
            return output;
        }

        public static bool IsFirstTimeUse(this string filename)
        {
            bool firstTimeUse = true;

            if (!File.Exists(filename.FullFilePath()))
            {
                return firstTimeUse;
            }
            return firstTimeUse = false;
        }

        public static List<RaceResultsModel> OpenSerialisedFile(this string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    var racemodel = (List<RaceResultsModel>)bf.Deserialize(fs);
                    return racemodel;

                }
                catch (SerializationException)
                {
                    fs?.Close();
                    return new List<RaceResultsModel>();
                }
            }
        }

        public static void SaveSerialisedFile(this List<RaceResultsModel> model, string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.Open(filename.FullFilePath(), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                try
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    bf.Serialize(fs, model);
                }
                catch (SerializationException)
                {
                    fs?.Close();
                }
            }
        }
    }
}
