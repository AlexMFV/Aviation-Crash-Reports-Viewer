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
        Size mapDefaultSize;
        Point mapDefaultPos;

        public CrashSelection(CrashInfo info)
        {
            InitializeComponent();
            link = Properties.Resources.MainPage + info._link;
            mapDefaultPos = this.webBrowser1.Location;
            mapDefaultSize = this.webBrowser1.Size;
        }

        private void CrashSelection_Load(object sender, EventArgs e)
        {
            CrashDetails cs = CrashDetails.RetrieveInfoFromWebsite(link);
            pctPlane.Image = cs._Image;
            this.Text = "Current Status: " + cs._Status;
            this.lblDate.Text = "Date: " + cs._Date;
            this.lblTime.Text = "Time: " + cs._Time;

            if (cs._planeModel == null)
                this.lblType.Visible = false;
            else
                this.lblType.Text = "Type: " + cs._planeModel;

            if (cs._operator == null)
                this.lblOperator.Visible = false;
            else
                this.lblOperator.Text = "Operator: " + cs._operator;

            if (cs._registration == null)
                this.lblRegistration.Visible = false;
            else
                this.lblRegistration.Text = "Registration: " + cs._registration;

            if (cs._firstFlight == null)
                this.lblFirstFlight.Visible = false;
            else
                this.lblFirstFlight.Text = "First Flight: " + cs._firstFlight;

            if (cs._crew == null)
                this.lblCrew.Visible = false;
            else
                this.lblCrew.Text = "Crew: " + cs._crew;

            if (cs._passengers == null)
                this.lblPassengers.Visible = false;
            else
                this.lblPassengers.Text = "Pass: " + cs._passengers; //Passengers

            if (cs._total == null)
                this.lblTotal.Visible = false;
            else
                this.lblTotal.Text = "Total:  " + cs._total;

            if (cs._aircraftDamage == null)
                this.lblDamage.Visible = false;
            else
                this.lblDamage.Text = "Aircraft Damage: " + cs._aircraftDamage;

            if (cs._location == null)
                this.lblLocation.Visible = false;
            else
                this.lblLocation.Text = "Location: " + cs._location + ")";

            if (cs._phase == null)
                this.lblPhase.Visible = false;
            else
                this.lblPhase.Text = "Phase: " + cs._phase;

            if (cs._nature == null)
                this.lblNature.Visible = false;
            else
                this.lblNature.Text = "Nature: " + cs._nature;

            if (cs._departureAirport == null)
                this.lblDeparture.Visible = false;
            else
                this.lblDeparture.Text = "Departure Airport: " + cs._departureAirport;

            if (cs._destinationAirport == null)
                this.lblDestination.Visible = false;
            else
                this.lblDestination.Text = "Destination Airport: " + cs._destinationAirport;

            if (cs._flightNumber == null)
                this.lblFlightNumber.Visible = false;
            else
                this.lblFlightNumber.Text = "Flight Number: " + cs._flightNumber;

            if (cs._crashSummary == null)
                this.textBox1.Visible = false;
            else
                this.textBox1.Text = cs._crashSummary; this.textBox1.SelectionStart = 0; this.textBox1.SelectionLength = 0;

            if (cs._cycles == null)
                this.lblCycles.Visible = false;
            else
                this.lblCycles.Text = "Cycles: " + cs._cycles;

            if (cs._engines == null)
                this.lblEngines.Visible = false;
            else
                this.lblEngines.Text = "Engines: " + cs._engines;

            if (cs._airframeHours == null)
                this.lblAirframeHours.Visible = false;
            else
                this.lblAirframeHours.Text = "Total Airframe Hrs: " + cs._airframeHours;

            if (cs._aircraftFate == null)
                this.lblAircraftFate.Visible = false;
            else
                this.lblAircraftFate.Text = "Aircraft Fate: " + cs._aircraftFate;

            if (cs._mapUrl == null)
                DisableMap();
            else
                this.webBrowser1.Url = new Uri(Properties.Resources.MainPage + cs._MapURL);

            //if (cs._imgList == null)
            //    DisableImgList();

            int x = 12;
            int y = 230;
            int idx = 0;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                for (int i2 = this.Controls.Count - 1; i2 >= 0; i2--)
                {
                    if (this.Controls[i2] is Label && this.Controls[i2].TabIndex == i && this.Controls[i2].Visible == true)
                    {
                        if (idx >= 17)
                        {
                            idx = 0;
                            x = 270;
                            y = 40;
                        }
                        this.Controls[i2].Location = new Point(x, y + (25 * idx));
                        //item.Text = idx.ToString();
                        idx++;
                    }
                }
            }
        }

        void DisableMap()
        {
            this.webBrowser1.Visible = false;
            this.btnExitFS.Visible = false;
            this.btnFS.Visible = false;
        }

        //void DisableImgList()
        //{

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            mapDefaultSize = this.webBrowser1.Size;
            mapDefaultPos = this.webBrowser1.Location;
            this.webBrowser1.Size = new Size(this.Width, this.Height);
            this.webBrowser1.Location = new Point(0, 0);
            this.btnFS.Enabled = false;
            this.btnFS.Visible = false;
            this.btnExitFS.Enabled = true;
            this.btnExitFS.Visible = true;
            this.webBrowser1.BringToFront();
            this.btnExitFS.BringToFront();
        }

        private void btnExitFS_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Size = mapDefaultSize;
            this.webBrowser1.Location = mapDefaultPos;
            this.btnFS.Enabled = true;
            this.btnFS.Visible = true;
            this.btnExitFS.Enabled = false;
            this.btnExitFS.Visible = false;
            this.webBrowser1.SendToBack();
        }
    }
}
