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

namespace ACIR
{
    public partial class YearSearch : Form
    {
        struct CrashInfo
        {
            public string PageLink; //Page with the full info of the crash
            public string Date; //Date of the crash
            public string Plane; //Model of the plane
            public string Registration; //Matrícula in Portuguese
            public string AirlineCompany; //Company responsible for the plane
            public int Fatalities; //Number of fatalities in the crash
            public string Location; //Location of the crash
            public Image CountryFlag; //Link to the Country Image where the crash happened
            public string Category; //Category of the incident
        };

        /*  Struct "Category" explanation:
         * 
         *  A = Accident
         *  I = Incident
         *  H = Hijacking
         *  C = Criminal Occurrence (Sabotage, ShootDown)
         *  O = Other Occurrence (Ground Fire)
         * 
         *  1 = Hull-Loss
         *  2 = Repairable Damage
         * 
         * Struct category explanation  */

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
            //Variables
            List<string> values = new List<string>();
            List<CrashInfo> crashes = new List<CrashInfo>();
            string pageContent;
            //Variables

            this.Text = "Occurrences reported in " + selectedYear;

            WebClient web = new WebClient();
            Stream stream;

            stream = web.OpenRead("https://aviation-safety.net/database/dblist.php?Year=" + selectedYear);
            using (StreamReader reader = new StreamReader(stream))
            {
                //label1.Text = reader.ReadToEnd();
                pageContent = reader.ReadToEnd();
            }
            stream.Close();

            this.Show();
            SplashScreen.CloseSplashScreen();
            this.Activate();

            //Limits the page to the table tags (What we want to show)
            pageContent = getStringBetweenTags(pageContent, "<table>", "</table>");
            //Grabs each individual set of data into a list
            values = getListFromString(pageContent, "<tr>", "</tr>");
            values.RemoveAt(1);
            //Distributes the concatenated string into the actual data
            crashes = getCrashInfoFromList(values);

            //Only gets the top 100 need to fix for other pages TODOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

            //Just testin
            label1.Text = "";
            foreach (CrashInfo i in crashes)
            {
                label1.Text += i.Date;
                label1.Text += i.AirlineCompany;
                label1.Text += i.Category;
                //label1.Text = i.CountryFlag;
                label1.Text += i.Fatalities.ToString();
                label1.Text += i.Location;
                label1.Text += i.PageLink;
                label1.Text += i.Plane;
                label1.Text += i.Registration;
                label1.Text += "\n";
            }
            //buildLists(values);
        }

        string getStringBetweenTags(string value, string startTag, string endTag)
        {
            if (value.Contains(startTag) && value.Contains(endTag))
            {
                int index = value.IndexOf(startTag) + startTag.Length;
                return value.Substring(index, value.IndexOf(endTag) - index);
            }
            else
                return null;
        }

        string getStringBetweenTags(string value, string startTag, string endTag, int idx)
        {
            Regex rx = new Regex(startTag + "(.*?)" + endTag); //change to "(.*?)>(.*?)"
            MatchCollection col = rx.Matches(value);

            if (idx < 4 || idx == 7)
                return col[idx].ToString();
            else
                if(idx >= 5)
                    return col[idx-1].ToString();
            else
                return col[0].ToString();
        }

        List<string> getListFromString(string value, string startTag, string endTag)
        {
            List<string> values = new List<string>();
            return value.Split(new string[] { startTag, endTag }, StringSplitOptions.None).ToList();
        }

        List<CrashInfo> getCrashInfoFromList(List<string> values)
        {
            List<CrashInfo> crashes = new List<CrashInfo>();

            CrashInfo crash;

            foreach (string item in values)
            {
                if(item != "\n" && item != "") {
                    crash = splitCrashInfo(item);
                    crashes.Add(crash);
                }
            }

            return crashes;
        }

        CrashInfo splitCrashInfo(string item)
        {
            CrashInfo crash = new CrashInfo();
            List<string> vals = new List<string>();
            string aux;

            for (int i = 0; i < 8; i++)
            {
                if (i == 0) //Link and date
                {
                    aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                    aux = getStringBetweenTags(item, "<nobr>", "</nobr>");
                    aux = getStringBetweenTags(aux, "<a href=\"", "</a>");
                    string[] val = aux.Split(new string[] { "\">" }, StringSplitOptions.None);
                    crash.PageLink = val[0];
                    crash.Date = val[1];
                }
                else
                    if (i == 1) //Plane
                {
                    aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                    crash.Plane = getStringBetweenTags(aux, "<td class=\"list\"><NOBR>", "</NOBR></td>");
                }
                else
                        if (i == 4) //Fatalities
                    crash.Fatalities = getFatalities(item, i);
                else
                        if (i == 6) //CountryFlag (returns URL) TO FIX
                {
                    aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i); //Maybe add the Title of the country later
                    aux = getStringBetweenTags(aux, "<img src=\"", "\" title=");
                    vals.Add(aux);
                }
                else
                    if (i == 7)
                {
                    aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                    vals.Add(getStringBetweenTags(aux, "<td class=\"list\">", "</td>"));
                }
                else
                {
                    aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                    vals.Add(getStringBetweenTags(aux, "<td class=\"list\">", "</td>"));
                }
            }

            crash.Registration = vals[0];
            crash.AirlineCompany = vals[1];
            crash.Location = vals[2];
            crash.CountryFlag = getImageFromURL(vals[3]);
            crash.Category = vals[4];

            return crash;
        }

        Image getImageFromURL(string url)
        {
            Image img = null;

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();

                img = Image.FromStream(stream);
                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return img;
        }

        int getFatalities(string item, int i)
        {
            string aux = getStringBetweenTags(item, "<td class=\"listdata\">", "</td>", i);
            aux = getStringBetweenTags(aux, "<td class=\"listdata\">", "</td>");
            string[] vals = new string[2];

            if (aux.Contains('+'))
            {
                vals = aux.Split('+');
                return Convert.ToInt32(vals[0]) + Convert.ToInt32(vals[1]);
            }
            else
                return Convert.ToInt32(aux);
        }

        void buildLists(List<CrashInfo> Crashes)
        {

        }
    }
}
