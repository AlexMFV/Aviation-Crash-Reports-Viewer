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

namespace ACIR
{
    public partial class YearSearch : Form
    {
        string selectedYear = "";

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
            string pageContents;
            this.Text = "Occurrences reported in " + selectedYear;

            WebClient web = new WebClient();
            Stream stream;

            stream = web.OpenRead("https://aviation-safety.net/database/dblist.php?Year=" + selectedYear);
            using (StreamReader reader = new StreamReader(stream))
            {
                label1.Text = reader.ReadToEnd();
            }
            stream.Close();

            this.Show();
            SplashScreen.CloseSplashScreen();
            this.Activate();

            //buildList(pageContents);
        }

        //void buildList(string content)
        //{

        //}
    }
}
