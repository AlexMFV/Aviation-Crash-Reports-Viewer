using System;
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
    public partial class CrashSelection : Form
    {
        public string link = "";

        public CrashSelection(CrashInfo info)
        {
            InitializeComponent();
            link = Properties.Resources.MainPage + info._link;
        }

        private void CrashSelection_Load(object sender, EventArgs e)
        {
            CrashDetails cs = CrashDetails.RetrieveInfoFromWebsite(link);
            pctPlane.Image = cs._Image;
            this.Text = "Current Status: " + cs._Status;
            this.lblDate.Text = "Date: " + cs._Date;
            this.lblTime.Text = "Time: " + cs._Time;
        }
    }
}
