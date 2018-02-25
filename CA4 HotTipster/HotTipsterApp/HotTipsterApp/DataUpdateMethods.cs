using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipsterApp
{
    public class DataUpdateMethods
    {

        public List<RaceResultsModel> AddNewRecord(RaceResultsModel model,string filename)
        {
            //Open the saved file
            List<RaceResultsModel> results = filename.FullFilePath().OpenSerialisedFile();
            //find the maxId
            int maxId = results.OrderByDescending(x => x.ID).First().ID + 1;
            model.ID = maxId;
            results.Add(model);
            //Save Serialised file
            results.SaveSerialisedFile(filename);
            return results;
        }

        public List<RaceResultsModel> DeleteRecord(RaceResultsModel model, string filename)
        {
            //Open the saved file
            List<RaceResultsModel> results = filename.FullFilePath().OpenSerialisedFile();
            results.RemoveAll(x => x.ID == model.ID);
            results.SaveSerialisedFile(filename);
            return results;
        }

        public List<RaceResultsModel> UpdateRecord(RaceResultsModel model, string filename)
        {
            //Open the saved file
            List<RaceResultsModel> results = filename.FullFilePath().OpenSerialisedFile();
            results.RemoveAll(x => x.ID == model.ID);
            results.Add(model);
            results.OrderBy(r => r.ID);
            results.SaveSerialisedFile(filename);
            return results;
        }
    }
}
