using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACIR.Properties;

namespace ACIR
{
    public partial class Main : Form
    {
        bool isOn = false;
        bool isLocked = true;
        BackgroundWorker SyncFullThread = new BackgroundWorker();

        public Main()
        {
            InitializeComponent();
            SyncFullThread.DoWork += FullDBSync;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "Developed by: Alex Valente (2018 - " + DateTime.Now.Year + ")\nData gathered from" +
                " 'Aviation Safety Network' official website.";

            lblDataAge.Text = "The database is updated daily, contains descriptions\n" +
                " of military transport category aircraft and corporate\n" +
                " jet aircraft safety occurrences since 1919.";

            nupYear.Minimum = 1919;
            nupYear.Maximum = DateTime.Now.Year;
            nupYear.Value = nupYear.Maximum;
            lblOcc.Text = "Incidents: " + Settings.Default.OccurrencesSync.ToString();
            lblIndividual.Text = "Individual: " + Settings.Default.IndividualSync.ToString();
            switchDB.Value = Settings.Default.UseDB;
        }

        /// <summary>
        /// Fully create all the years of occurrences in the DB
        /// </summary>
        /// <returns></returns>
        public void FullDBSync(object sender, DoWorkEventArgs e)
        {
            btnLock.Enabled = false;
            btnSync.Enabled = false;

            int date = 2018;
            int count = 0;

            while (date <= Convert.ToInt32(DateTime.Now.Year))
            {
                List<CrashInfo> values = CrashInfo.GetCrashes(date.ToString());

                foreach (CrashInfo cr in values)
                {
                    int id = DBSync.GetOccurrenceIDByLink(cr.Link);
                    int img_ID;
                    int countryID = 0;

                    if (id == 0)
                    {
                        countryID = DBSync.GetFlagByFlagName(cr.Flag_Name);

                        if (countryID <= 0)
                            countryID = DBSync.CreateFlagImage(cr.Flag_Name, DBSync.ImageToByteArray(cr.Img));

                        //Creates the occurrence, if it doesn't exist
                        id = DBSync.CreateOccurence(cr, countryID);

                        if (id != 0)
                            count++;

                        //Creates the page for the occurrence
                        img_ID = DBSync.GetPlaneImageIDByPlaneModel(cr.Plane);

                        if (img_ID <= 0)
                            img_ID = DBSync.CreatePlaneImage(cr.Plane, DBSync.ImageToByteArray(cr.Img));

                        DBSync.CreateOccurrenceInfo(CrashDetails.RetrieveInfoFromWebsite(Resources.MainPage + cr.Link), id, img_ID);
                    }
                    else
                    {
                        if (DBSync.GetOccurrenceInfoByID(id) <= 0) //If it does not exist
                        {
                            img_ID = DBSync.GetPlaneImageIDByPlaneModel(cr.Plane);

                            if (img_ID <= 0)
                                img_ID = DBSync.CreatePlaneImage(cr.Plane, DBSync.ImageToByteArray(cr.Img));

                            DBSync.CreateOccurrenceInfo(CrashDetails.RetrieveInfoFromWebsite(Resources.MainPage + cr.Link), id, img_ID);
                        }
                    }
                }

                CrashInfo.AllCrashes.Clear();
                date++;
            }

            Settings.Default.OccurrencesSync = DateTime.Now;
            Settings.Default.IndividualSync = DateTime.Now;
            Settings.Default.Save();
            lblOcc.Text = "Incidents: " + Settings.Default.OccurrencesSync.ToString();
            lblIndividual.Text = "Individual: " + Settings.Default.IndividualSync.ToString();
            btnLock.Enabled = true;
            isLocked = true;
        }

        //public int UpdateDB()
        //{

        //}

        private void btnSearchYear_Click(object sender, EventArgs e)
        {
            YearSearch ys = new YearSearch(nupYear.Value.ToString());
            this.Hide();
            ys.ShowDialog();
            this.Show();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            SyncFullThread.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isOn)
            {
                this.Size = new Size(390, this.Height);
                isOn = false;
            }
            else
            {
                this.Size = new Size(600, this.Height);
                isOn = true;
            }
        }

        private void btnLock_MouseClick(object sender, MouseEventArgs e)
        {
            if (isLocked)
            {
                this.btnSync.Enabled = true;
                isLocked = false;
            }
            else
            {
                this.btnSync.Enabled = false;
                isLocked = true;
            }
        }

        private void switchDB_OnValueChange(object sender, EventArgs e)
        {
            if (switchDB.Value == true)
                Settings.Default.UseDB = true;
            else
                Settings.Default.UseDB = false;

            Settings.Default.Save();
        }

        private void btnSyncInc_Click(object sender, EventArgs e)
        {
            //Main crashes
            //Create new values on DB and or Update them from the last 10 years
        }

        private void btnSyncInd_Click(object sender, EventArgs e)
        {
            //Individual Pages
            //Create new values on DB and or Update them from the last 10 years
        }
    }
}
