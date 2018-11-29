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
            public string Fatalities; //Number of fatalities in the crash
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
            string pageContent = "";
            this.Text = "Occurrences reported in " + selectedYear;
            int page = 1;

            while (true)
            {
                List<string> values = new List<string>();
                List<CrashInfo> crashes = new List<CrashInfo>();

                WebClient web = new WebClient();
                Stream stream;

                stream = web.OpenRead("https://aviation-safety.net/database/dblist.php?Year=" + selectedYear + "&lang=&page=" + page);
                using (StreamReader reader = new StreamReader(stream))
                {
                    pageContent = reader.ReadToEnd();
                }
                stream.Close();

                if (pageContent.Contains("no occurrences in the database"))
                    break;

                //Limits the page to the table tags (What we want to show)
                pageContent = getStringBetweenTags(pageContent, "<table>", "</table>");
                //Grabs each individual set of data into a list
                values = getListFromString(pageContent, "<tr>", "</tr>");
                values.RemoveAt(1);
                //Distributes the concatenated string into the actual data
                crashes = getCrashInfoFromList(values);

                //Only gets the top 100 need to fix for other pages TODOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

                addToListView(crashes);
                page++;
            }

            lblResults.Text = "Showing " + lvwCrashes.Items.Count + " results";

            this.Show();
            SplashScreen.CloseSplashScreen();
            this.Activate();

            lvwCrashes.Visible = true;
            lblResults.Visible = true;
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
                    string[] dateL = new string[2];
                    dateL = fillDateLink(item, i);
                    crash.PageLink = dateL[0];
                    crash.Date = dateL[1];
                }
                else
                    if (i == 1) //Plane
                {
                    crash.Plane = getPlane(item, i);
                }
                else
                        if (i == 4) //Fatalities
                    crash.Fatalities = getFatalities(item, i);
                else
                        if (i == 6) //CountryFlag (returns URL) TO FIX
                {
                    vals.Add(getCountryFlag(item, i));
                }
                else
                    if (i == 7) //Category
                {
                    vals.Add(getCategory(item, i));
                }
                else
                {                    
                    vals.Add(getAnyOther(item, i));
                }
            }

            crash.Registration = vals[0];
            crash.AirlineCompany = vals[1];
            crash.Location = vals[2];
            crash.CountryFlag = getImageFromURL(vals[3]);
            crash.Category = vals[4];

            return crash;
        }

        string[] fillDateLink(string item, int i) //Returns the array with the strings for the date and the Link of the page
        {
            try
            {
                string aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                aux = getStringBetweenTags(item, "<nobr>", "</nobr>");
                aux = getStringBetweenTags(aux, "<a href=\"", "</a>");
                return aux.Split(new string[] { "\">" }, StringSplitOptions.None);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        string getPlane(string item, int i)
        {
            try
            {
                string aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                return getStringBetweenTags(aux, "<td class=\"list\"><NOBR>", "</NOBR></td>");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        string getCountryFlag(string item, int i)
        {
            try
            {
                string aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i); //Maybe add the Title of the country later
                return getStringBetweenTags(aux, "<img src=\"", "\" title=");
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        
        string getCategory(string item, int i)
        {
            try
            {
                string aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                return getStringBetweenTags(aux, "<td class=\"list\">", "</td>");
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        string getAnyOther(string item, int i)
        {
            try
            {
                string aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                return getStringBetweenTags(aux, "<td class=\"list\">", "</td>");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        Image getImageFromURL(string url)
        {
            Image img = null;

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("https:" + url);
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

        string getFatalities(string item, int i)
        {
            try
            {
                string aux = getStringBetweenTags(item, "<td class=\"listdata\">", "</td>", i);
                aux = getStringBetweenTags(aux, "<td class=\"listdata\">", "</td>");
                string[] vals = new string[2];

                if (aux.Contains('+'))
                {
                    vals = aux.Split('+');
                    return (Convert.ToInt32(vals[0]) + Convert.ToInt32(vals[1])).ToString();
                }
                else
                    return Convert.ToInt32(aux).ToString();
            }
            catch(Exception ex)
            {
                return " ";
            }
        }

        void addToListView(List<CrashInfo> crashes)
        {
            foreach (CrashInfo i in crashes)
            {
                ListViewItem lvwItem = new ListViewItem();
                lvwItem.Text = i.Date;
                lvwItem.SubItems.Add(i.Plane);
                lvwItem.SubItems.Add(i.Registration);
                lvwItem.SubItems.Add(i.AirlineCompany);
                lvwItem.SubItems.Add(i.Fatalities);
                lvwItem.SubItems.Add(i.Location);
                lvwItem.SubItems.Add(" "); //Add Country Flag atm is just a space
                lvwItem.SubItems.Add(i.Category);
                lvwCrashes.Items.Add(lvwItem);
            }
        }
    }
}
