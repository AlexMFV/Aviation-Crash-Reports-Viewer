using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using BrightIdeasSoftware;

namespace ACIR
{
    public partial class YearSearch : Form
    {
        public string selectedYear = "";

        public YearSearch(string year)
        {
            this.Hide();
            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            splashthread.IsBackground = true;
            splashthread.Start();
            InitializeComponent();
            selectedYear = year;
        }

        private void YearSearch_Load(object sender, EventArgs e)
        {
            this.Text = "Occurrences reported in " + selectedYear;

            olvFlag.AspectToStringConverter = delegate (object x) {
                return String.Empty;
            };

            olvFlag.ImageGetter = delegate (object rowObject) {
                CrashInfo s = (CrashInfo)rowObject;
                return s.Img;
            };
            
            olvCrashes.SetObjects(CrashInfo.GetCrashes(selectedYear));

            //Deletes the Crashes List
            CrashInfo.AllCrashes.Clear();

            lblResults.Text = "Showing " + olvCrashes.Items.Count + " results";

            this.Show();
            SplashScreen.CloseSplashScreen();
            this.Activate();

            lblResults.Visible = true;
        }

        private void YearSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            olvCrashes.SetObjects(null);
            olvCrashes.BuildList();
        }

        private void olvCrashes_DoubleClick(object sender, EventArgs e)
        {
            if(olvCrashes.SelectedIndex != -1)
            {
                CrashSelection cs = new CrashSelection((CrashInfo)olvCrashes.SelectedItem.RowObject);
                this.Hide();
                cs.ShowDialog();
                this.Show();
            }
        }
    }
}
