using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ACIR
{
    public class CrashInfo
    {
        /*  Column "Category" explanation:
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
         * Column "Category" explanation  */

        public string _link;
        public string _date;
        public string _plane;
        public string _reg;
        public string _operator;
        public int _fat;
        public string _loc;
        public Image _img;
        public string _cat;

        public CrashInfo() { }

        public CrashInfo(string PageLink, string Date, string Plane, string Registration,
            string AirlineCompany, int Fatalities, string Location, Image CountryFlag,
            string Category)
        {
            this.Link = PageLink; //Page with the full info of the crash
            this.Date = Date; //Date of the crash
            this.Plane = Plane; //Model of the plane
            this.Reg = Registration; //Matrícula in Portuguese
            this.Operator = AirlineCompany; //Company responsible for the plane
            this.Fat = Fatalities; //Number of fatalities in the crash
            this.Loc = Location; //Location of the crash
            this.Img = CountryFlag; //Link to the Country Image where the crash happened
            this.Cat =  Category; //Category of the incident
        }

        static internal List<CrashInfo> GetCrashes(string year)
        {
            if (CrashInfo.AllSongs.Count == 0)
                CrashInfo.AllSongs = FillWithCrashes(year);
            return CrashInfo.AllSongs;
        }
        static private List<CrashInfo> AllSongs = new List<CrashInfo>();

        static internal List<CrashInfo> FillWithCrashes(string year)
        {
            List<CrashInfo> crashesFull = new List<CrashInfo>();
            string pageContent = "";
            int page = 1;

            while (true)
            {
                List<string> values = new List<string>();
                List<CrashInfo> crashes = new List<CrashInfo>();

                WebClient web = new WebClient();
                Stream stream;

                stream = web.OpenRead("https://aviation-safety.net/database/dblist.php?Year=" + year + "&lang=&page=" + page);
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

                foreach (CrashInfo crash in crashes)
                    crashesFull.Add(crash);

                //addToListView(crashes);
                page++;
            }

            return crashesFull;
        }

        static internal string getStringBetweenTags(string value, string startTag, string endTag)
        {
            if (value.Contains(startTag) && value.Contains(endTag))
            {
                int index = value.IndexOf(startTag) + startTag.Length;
                return value.Substring(index, value.IndexOf(endTag) - index);
            }
            else
                return null;
        }

        static internal string getStringBetweenTags(string value, string startTag, string endTag, int idx)
        {
            Regex rx = new Regex(startTag + "(.*?)" + endTag); //change to "(.*?)>(.*?)"
            MatchCollection col = rx.Matches(value);

            if (idx < 4 || idx == 7)
                return col[idx].ToString();
            else
                if (idx >= 5)
                return col[idx - 1].ToString();
            else
                return col[0].ToString();
        }

        static internal List<string> getListFromString(string value, string startTag, string endTag)
        {
            List<string> values = new List<string>();
            return value.Split(new string[] { startTag, endTag }, StringSplitOptions.None).ToList();
        }

        static internal List<CrashInfo> getCrashInfoFromList(List<string> values)
        {
            List<CrashInfo> crashes = new List<CrashInfo>();

            CrashInfo crash;

            foreach (string item in values)
            {
                if (item != "\n" && item != "")
                {
                    crash = splitCrashInfo(item);
                    crashes.Add(crash);
                }
            }

            return crashes;
        }

        static internal CrashInfo splitCrashInfo(string item)
        {
            CrashInfo crash;
            List<string> vals = new List<string>();
            string aux;

            string link = null;
            string date = null;
            string plane = null;
            string reg = null;
            string company = null;
            string fat = null;
            string loc = null;
            Image flag = null;
            string cat = null;

            for (int i = 0; i < 8; i++)
            {
                if (i == 0) //Link and date
                {
                    string[] dateL = new string[2];
                    dateL = fillDateLink(item, i);
                    link = dateL[0];
                    date = dateL[1];
                }
                else
                    if (i == 1) //Plane
                {
                    plane = getPlane(item, i);
                }
                else
                        if (i == 4) //Fatalities
                    fat = getFatalities(item, i);
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

            //Remove the "blank" Registration to a '-'
            if (vals[0].Contains("&nbsp"))
                reg = "-";
            else
                reg = vals[0];

            //Remove "Banned in the EU" Tag/Symbol
            if (!vals[1].Contains("<img src"))
                company = vals[1];
            else
                company = vals[1].Substring(vals[1].IndexOf('>') + 1, vals[1].Length - (vals[1].IndexOf('>') + 1)).Trim();

            loc = vals[2];
            flag = getImageFromURL(vals[3]);
            cat = vals[4];

            return new CrashInfo(link, date, plane, reg, company, Convert.ToInt32(fat), loc, flag, cat);
        }

        static internal string[] fillDateLink(string item, int i) //Returns the array with the strings for the date and the Link of the page
        {
            try
            {
                string aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i);
                aux = getStringBetweenTags(item, "<nobr>", "</nobr>");
                aux = getStringBetweenTags(aux, "<a href=\"", "</a>");
                return aux.Split(new string[] { "\">" }, StringSplitOptions.None);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static internal string getPlane(string item, int i)
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

        static internal string getCountryFlag(string item, int i)
        {
            try
            {
                string aux = getStringBetweenTags(item, "<td class=\"list\">", "</td>", i); //Maybe add the Title of the country later
                return getStringBetweenTags(aux, "<img src=\"", "\" title=");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static internal string getCategory(string item, int i)
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

        static internal string getAnyOther(string item, int i)
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

        static internal Image getImageFromURL(string url)
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

        static internal string getFatalities(string item, int i)
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
            catch (Exception ex)
            {
                return " ";
            }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Plane
        {
            get { return _plane; }
            set { _plane = value; }
        }

        public string Reg
        {
            get { return _reg; }
            set { _reg = value; }
        }

        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public int Fat
        {
            get { return _fat; }
            set { _fat = value; }
        }

        public string Loc
        {
            get { return _loc; }
            set { _loc = value; }
        }

        public Image Img
        {
            get { return _img; }
            set { _img = value; }
        }

        public string Cat
        {
            get { return _cat; }
            set { _cat = value; }
        }
    }
}
