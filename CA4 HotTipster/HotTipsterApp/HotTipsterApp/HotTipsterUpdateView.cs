using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTipsterApp
{
    public partial class HotTipsterUpDateView : Form
    {
        DataUpdateMethods dataUpdates = new DataUpdateMethods();
        private const string srcOrig_file_name = "HotTipsterOrig.txt";
        private const string raceResultsfile = "HotTipsterDataSer.txt";
        private const string file_dirname = @"C\Admin\users";
        public static List<RaceResultsModel> savedData;

        public HotTipsterUpDateView()
        {
            savedData = new List<RaceResultsModel>();
            InitializeComponent();

            //assign the enum values when the page loads.
            cboRaceCourse.DataSource = Enum.GetValues(typeof(RaceCourses_Results_Enums));
            cboResult.DataSource = Enum.GetValues(typeof(Results));
            cboRaceCourse.SelectedIndex = -1;
            cboResult.SelectedIndex = -1;
            btnRaceReports.Enabled = false;
            btnUpdateRaceResult.Enabled = false;
            btnDelete.Enabled = false;

            bool firstTimeUse = raceResultsfile.IsFirstTimeUse();
            if (firstTimeUse)
            {
                btnImportOrig.Enabled = true;
                btnOpen.Enabled = false;
            }
            else
            {
                btnImportOrig.Enabled = false;
                btnOpen.Enabled = true;
            }
        }

        private void btnImportOrig_Click(object sender, EventArgs e)
        {
            //Step 1:loading original data file using BinFormatProcessor Extension methods
            savedData = srcOrig_file_name.FullFilePath().ImportOrigFile().ConvertOrigData();
            if (savedData == null)
            {
                lblDisplay.Text = "File importing error";
                lblDisplay.BackColor = Color.OrangeRed;
            }
            else
            {
                //Step2: Display the Racing results in windows form Listbox
                foreach (RaceResultsModel result in savedData)
                {
                    lstDisplayUpdateView.Items.Add(result);
                }
                lblDisplay.Text = "Original data imported, converted and saved";
                btnImportOrig.Enabled = false;

                //step3: Saving imported converted data to serialised file
                savedData.SaveSerialisedFile(raceResultsfile);
                lblDisplay.Text = "HotTipsterDataSer.txt file created";
                btnRaceReports.Enabled = true;
            }
        }

        //loading a saved serialised file version
        private void btnOpen_Click(object sender, EventArgs e)
        {
            lstDisplayUpdateView.Items.Clear();
            savedData = raceResultsfile.FullFilePath().OpenSerialisedFile();

            if (savedData == null)
            {
                lblDisplay.Text = "File opening error";
                lblDisplay.BackColor = Color.OrangeRed;
            }
            else
            {
                
                foreach (RaceResultsModel result in savedData)
                {
                    lstDisplayUpdateView.Items.Add(result);
                }
                lblDisplay.Text = "Data loaded";
                btnOpen.Enabled = false;
                btnRaceReports.Enabled = true;
            }
        }

        private void btnAddNewRace_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            /*ensuring that the files data has either been imported
             * or opened before a new entry can be added*/

            if (lstDisplayUpdateView.Items.Count != 0)
            {
                if (InputValidation())
                {
                    RaceResultsModel model = new RaceResultsModel(
                        cboRaceCourse.SelectedItem.ToString(),
                        dtpRaceDate.Text,
                        txtAmount.Text,
                        cboResult.SelectedItem.ToString());

                    savedData = dataUpdates.AddNewRecord(model, raceResultsfile);

                    string message = "Race details added";
                    lblDisplay.Visible = true;
                    lblDisplay.Text = message;
                    ResetInputBoxes();

                    //display data in listbox
                    lstDisplayUpdateView.Items.Clear();
                    foreach (RaceResultsModel race in savedData)
                    {
                        lstDisplayUpdateView.Items.Add(race);
                    }
                    ResetInputBoxes();
                }
                else
                { 
                    string message = "Invalid input, please try again";
                    lblDisplay.Text = message;
                    ResetInputBoxes();
                }
            }
            else
            {
                lblDisplay.Text = "Missing saved data, import or open file";
            }
        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            if (lstDisplayUpdateView.SelectedIndex >= 0)
            {
                RaceResultsModel updateRecord = (RaceResultsModel)lstDisplayUpdateView.SelectedItem;
                int selectedIndex = lstDisplayUpdateView.Items.IndexOf(updateRecord);

                cboRaceCourse.Text = updateRecord.RaceCourse;
                dtpRaceDate.Value = updateRecord.RaceDate;
                txtAmount.Text = updateRecord.Amount.ToString();
                cboResult.Text = updateRecord.Result;
                lblDisplay.Text = "";
                btnAddNewRace.Enabled = false;
                btnUpdateRaceResult.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                lblDisplay.Text = "Nothing selected";
            }
        }

        private void btnUpdateRaceResult_Click(object sender, EventArgs e)
        {
            if (lstDisplayUpdateView.SelectedIndex >= 0)
            {
                if (InputValidation())
                {
                    RaceResultsModel updateRecord = (RaceResultsModel)lstDisplayUpdateView.SelectedItem;
                    updateRecord.RaceCourse = cboRaceCourse.Text;
                    updateRecord.RaceDate = DateTime.Parse(dtpRaceDate.Text);
                    updateRecord.Amount = decimal.Parse(txtAmount.Text);
                    updateRecord.Result = cboResult.Text;

                    savedData = dataUpdates.UpdateRecord(updateRecord, raceResultsfile);
                    lstDisplayUpdateView.Items.Clear();
                    
                    foreach (var item in savedData)
                    {
                        lstDisplayUpdateView.Items.Add(item);
                    }
                    btnAddNewRace.Enabled = true;
                    ResetInputBoxes();
                    lblDisplay.Text = "record updated";
                }
                else
                {
                    string message = "Invalid input, please try again";
                    lblDisplay.Text = message;
                    ResetInputBoxes();
                }
            }
            else
            {
                lblDisplay.Text = "Please select an item to update";
            }
        }

       public void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstDisplayUpdateView.SelectedIndex >= 0)
            {
                RaceResultsModel deleteRecord = (RaceResultsModel)lstDisplayUpdateView.SelectedItem;
                savedData = dataUpdates.DeleteRecord(deleteRecord, raceResultsfile);
                lstDisplayUpdateView.Items.Clear();
                foreach (RaceResultsModel result in savedData)
                {
                    lstDisplayUpdateView.Items.Add(result);
                }
                lblDisplay.Text = "Record deleted";
                ResetInputBoxes();
                btnAddNewRace.Enabled = true;
            }
            else
            {
                lblDisplay.Text = "Please select an item to delete";
            }
        }

        private void btnRaceReports_Click(object sender, EventArgs e)
        {
            using (HotTipsterReports reports = new HotTipsterReports(savedData))
            {
                reports.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Validation Method
        public bool InputValidation()
        {
            bool output = true;
            if (cboRaceCourse.SelectedIndex == -1) return output = false;
            if (cboResult.SelectedIndex == -1) return output = false;
            decimal number = 0.0M;
            bool txtAmountValidNumber = decimal.TryParse(txtAmount.Text, out number);
            if (!txtAmountValidNumber) return output = false;
            if (number < 0) return output = false;

            return output;
        }

        //Clearing textboxes
        private void ResetInputBoxes()
        {
            cboRaceCourse.SelectedIndex = -1;
            dtpRaceDate.ResetText();
            txtAmount.Text = "0";
            cboResult.SelectedIndex = -1;
        }

    }
}
