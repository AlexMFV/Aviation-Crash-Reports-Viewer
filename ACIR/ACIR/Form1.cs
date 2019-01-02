﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACIR
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
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
        }

        public int SyncDB()
        {
            List<CrashInfo> values = CrashInfo.GetCrashes("2018");
            int count = 0;

            foreach(CrashInfo cr in values)
            {
                int value = DBSync.CreateOccurence(cr);

                if (value != 0)
                    count++;
            }

            return count;
        }

        private void btnSearchYear_Click(object sender, EventArgs e)
        {
            YearSearch ys = new YearSearch(nupYear.Value.ToString());
            this.Hide();
            ys.ShowDialog();
            this.Show();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Text = SyncDB().ToString();
        }
    }
}
