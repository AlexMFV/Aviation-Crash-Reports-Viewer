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
    public class CrashDetails
    {
        public Image _planeImage;
        public string _planeModel;
        public string _crashDate;
        public string _crashTime;
        public string _currentStatus;

        public CrashDetails() { }

        //Just for testing
        public CrashDetails(Image planeImage, string planeModel, string crashDate, string crashTime, string currentStatus)
        {
            this._Image = planeImage;
            this._Model = planeModel;
            this._Date = crashDate;
            this._Time = crashTime;
            this._Status = currentStatus;
        }

        //static internal CrashDetails GetCrashInfo(string link)
        //{
        //    Crash = RetrieveInfoFromWebsite(link);
        //    return CrashDetails.Crash;
        //}
        //static public CrashDetails Crash = new CrashDetails();

        static internal CrashDetails RetrieveInfoFromWebsite(string link)
        {
            string pageContent = "";
            List<string> values = new List<string>();
            CrashDetails details;

            WebClient web = new WebClient();
            Stream stream;

            stream = web.OpenRead(link);
            using (StreamReader reader = new StreamReader(stream))
            {
                pageContent = reader.ReadToEnd();
            }
            stream.Close();

            //Limits the page to the table tags (What we want to show)
            pageContent = CrashInfo.getStringBetweenTags(pageContent, "<table>", "</table>");
            //Grabs each individual set of data into a list
            values = CrashInfo.getListFromString(pageContent, "<tr>", "</tr>");
            //Distributes the concatenated string into the actual data
            details = getCrashDetailsFromList(values);

            return details;
        }

        static internal CrashDetails getCrashDetailsFromList(List<string> values)
        {
            CrashDetails crash = new CrashDetails();
            Image _planeImage = null;
            string _planeModel = "";
            string _crashDate = "";
            string _crashTime = "";
            string _currentStatus = "";

            foreach (string item in values)
            {
                if (!item.Contains("\r\n") && item != "\n" && item != "")
                {
                    if (item.Contains("Type:")) //Plane Model
                    {
                        string auxItem = getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0);
                        _planeModel = GetPlaneModel(auxItem);
                        if (item.Contains("<img src=")) //Plane Image
                            _planeImage = GetPlaneImage(auxItem);
                    }

                    if (item.Contains("Status:")) //Current Inspection Status
                        _currentStatus = GetStringValue(getStringBetweenTags(item, "\"desc\">", "</td>", 0)); //Site tag is wrong

                    if (item.Contains("Date:")) //Date of the Accident
                        _crashDate = GetStringValue(getStringBetweenTags(item, "<td class=\"caption\">", "</td>", 1));

                    if (item.Contains("Time:")) //Time of the Accident
                            _crashTime = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));
                }
            }

            if (_crashTime == "")
                _crashTime = "Unknown";

            if (_crashDate == "")
                _crashTime = "Unknown";

            if (_planeImage == null)
                _planeImage = Properties.Resources.stock_plane;

            return new CrashDetails(_planeImage, _planeModel, _crashDate, _crashTime, _currentStatus);
        }

        static internal string getStringBetweenTags(string value, string startTag, string endTag, int idx)
        {
            Regex rx = new Regex(startTag + "(.*?)" + endTag); //change to "(.*?)>(.*?)"
            MatchCollection col = rx.Matches(value);
            
            return col[idx].ToString();
        }

        static internal string getStringBetweenTags(string value, string startTag, string endTag)
        {
            Regex rx = new Regex(startTag + "(.*?)" + endTag); //change to "(.*?)>(.*?)"
            MatchCollection col = rx.Matches(value);

            int idx = 0;
            for(int i = 0; i < col.Count; i++)
            {
                if (col[i].Length > (startTag.Length + endTag.Length))
                {
                    idx = i;
                    break;
                }
            }

            string toReturn = col[idx].ToString();
            toReturn = toReturn.Remove(toReturn.IndexOf(startTag), startTag.Length);
            toReturn = toReturn.Remove(toReturn.IndexOf(endTag), endTag.Length);
            //toReturn = toReturn.Substring(toReturn.IndexOf(startTag) + startTag.Length, toReturn.Length-1 - endTag.Length);

            return toReturn;
        }

        public static string GetPlaneModel(string item)
        {
            return getStringBetweenTags(item, ">", "<");
        }

        public static Image GetPlaneImage(string item)
        {
            Image img = getImageFromURL(getStringBetweenTags(item, "<img src=\"", "\""));
            return img;
        }
        
        public static string GetStringValue(string item)
        {
            string aux = getStringBetweenTags(item, ">", "<");

            if (aux == "" || aux == " ")
                return "Unknown";
            else
                return aux;
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

            if (img.Width > 245)
                img = resizeImage(img, new Size(240, (int)img.VerticalResolution));

            return img;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public Image _Image
        {
            get { return _planeImage; }
            set { _planeImage = value; }
        }

        public string _Model
        {
            get { return _planeModel; }
            set { _planeModel = value; }
        }

        public string _Date
        {
            get { return _crashDate; }
            set { _crashDate = value; }
        }

        public string _Time
        {
            get { return _crashTime; }
            set { _crashTime = value; }
        }

        public string _Status
        {
            get { return _currentStatus; }
            set { _currentStatus = value; }
        }
    }
}
