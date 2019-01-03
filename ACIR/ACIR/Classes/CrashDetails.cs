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
        public string _operator;
        public string _registration;
        public string _firstFlight;
        public string _crew;
        public string _passengers;
        public string _total;
        public string _aircraftDamage;
        public string _location;
        public string _phase;
        public string _nature;
        public string _departureAirport;
        public string _destinationAirport;
        public string _flightNumber;
        public string _crashSummary;
        public string _cycles;
        public string _engines;
        public string _airframeHours;
        public string _aircraftFate;
        public string _mapUrl;
        public List<Image> _imgList;

        public CrashDetails() { }

        //Just for testing
        public CrashDetails(Image planeImage, string planeModel, string crashDate, string crashTime, string currentStatus, string Operator, string reg, string firstFlight,
            string crew, string passengers, string total, string aircraftDamage, string location, string phase, string nature, string departure, string destination,
            string flightNumber, string crashSummary, string cycles, string engines, string airframeHours, string aircraftFate, string mapUrl, List<Image> imgList)
        {
            this._Image = planeImage;
            this._Model = planeModel;
            this._Date = crashDate;
            this._Time = crashTime;
            this._Status = currentStatus;
            this._Operator = Operator;
            this._Registration = reg;
            this._FirstFlight = firstFlight;
            this._Crew = crew;
            this._Passengers = passengers;
            this._Total = total;
            this._Damage = aircraftDamage;
            this._Location = location;
            this._Phase = phase;
            this._Nature = nature;
            this._Departure = departure;
            this._Destination = destination;
            this._FlightNumber = flightNumber;
            this._Summary = crashSummary;
            this._Cycles = cycles;
            this._Engines = engines;
            this._AirframeHours = airframeHours;
            this._AircraftFate = aircraftFate;
            this._MapURL = mapUrl;
            this._ImageList = imgList;
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

            pageContent = DeleteComments(pageContent);

            //Limits the page to the table tags (What we want to show)
            pageContent = CrashInfo.getStringBetweenTags(pageContent, "<body>", "</body>");
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
            string _planeModel = null;
            string _crashDate = null;
            string _crashTime = null;
            string _currentStatus = null;
            string _operator = null;
            string _registration = null;
            string _firstFlight = null;
            string _crew = null;
            string _passengers = null;
            string _total = null;
            string _aircraftDamage = null;
            string _location = null;
            string _phase = null;
            string _nature = null;
            string _departureAirport = null;
            string _destinationAirport = null;
            string _flightNumber = null;
            string _crashSummary = null;
            string _cycles = null;
            string _engines = null;
            string _airframeHours = null;
            string _aircraftFate = null;
            string _mapUrl = null;
            List<Image> _imgList = null;

            foreach (string item in values)
            {
                if (item.Contains("\r\n") && item.Length < 20 || item == "\n" || item == "")
                {
                    continue; //Do nothing
                }
                else
                {
                    if (item.Contains("Type:")) //Plane Model
                    {
                        string auxItem = getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0);
                        _planeModel = GetPlaneModel(auxItem);
                        if (item.Contains("<img src=")) //Plane Image
                            _planeImage = GetPlaneImage(auxItem);
                    }

                    if (item.Contains("Status:") && item.Contains("\"desc\">")) //Current Inspection Status
                        _currentStatus = GetStringValue(getStringBetweenTags(item, "\"desc\">", "</td>", 0)); //Site tag is wrong

                    if (item.Contains("Date:")) //Date of the Accident
                        _crashDate = GetStringValue(getStringBetweenTags(item, "<td class=\"caption\">", "</td>", 1));

                    if (item.Contains("Time:")) //Time of the Accident
                        _crashTime = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Operator:"))
                        _operator = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Registration:"))
                        _registration = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0).Trim());

                    if (item.Contains("First flight:"))
                        _firstFlight = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Total airframe:"))
                        _airframeHours = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Cycles:"))
                        _cycles = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Engines:"))
                    {
                        _engines = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));
                        _engines += GetStringValue(getStringBetweenTags(item, ">", "<", 3));
                    }

                    if (item.Contains("Crew:") && item.Contains("Occupants:"))
                        _crew = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Passengers:") && item.Contains("Occupants:"))
                        _passengers = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Total:") && item.Contains("Occupants:"))
                        _total = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Aircraft damage:"))
                        _aircraftDamage = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Aircraft fate:"))
                        _aircraftFate = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Location:"))
                    {
                        _location = GetStringValue(getStringBetweenTags(item, ">", "<", 2));
                        _location += GetStringValue(getStringBetweenTags(item, ">", "<", 4));

                        if (_location.Contains("United States of America"))
                            _location = _location.Replace("United States of America", "USA");
                    }

                    if (item.Contains("Phase:"))
                        _phase = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Nature:"))
                        _nature = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Departure airport:"))
                    {
                        if (item.Contains(">-<"))
                        {
                            _departureAirport = null;
                        }
                        else
                        {
                            if (item.Contains(">?<"))
                            {
                                _departureAirport = "Unknown";
                            }
                            else
                            {
                                _departureAirport = GetStringValue(getStringBetweenTags(item, ">", "<", 3));
                                _departureAirport += GetStringValue(getStringBetweenTags(item, ">", "<", 4));
                            }
                        }
                    }

                    if (item.Contains("Destination airport:"))
                    {
                        if (item.Contains(">-<"))
                        {
                            _destinationAirport = null;
                        }
                        else
                        {
                            if (item.Contains(">?<"))
                            {
                                _destinationAirport = "Unknown";
                            }
                            else
                            {
                                _destinationAirport = GetStringValue(getStringBetweenTags(item, ">", "<", 5));
                                _destinationAirport += GetStringValue(getStringBetweenTags(item, ">", "<", 6));
                            }
                        }
                    }

                    if (item.Contains("Flightnumber:"))
                        _flightNumber = GetStringValue(getStringBetweenTags(item, "<td class=\"desc\">", "</td>", 0));

                    if (item.Contains("Narrative:"))
                    {
                        _crashSummary = GetStringValue(getStringBetweenTags(item, "<span lang=\"en-US\">", "</span>", 0).Replace("<br />", "ççç"));
                        _crashSummary = _crashSummary.Replace("ççç", "\r\n");
                    }

                    if (item.Contains("Map") && item.Contains("infoboxtitle"))
                        _mapUrl = getMapUrlBetweenTags(item, "<iframe src=\"", "\" height");
                }
            }

            if (_currentStatus == null)
                _currentStatus = "Unknown";

            if (_crashTime == null)
                _crashTime = "Unknown";

            if (_crashDate == null)
                _crashTime = "Unknown";

            if (_planeImage == null)
                _planeImage = Properties.Resources.stock_plane;

            return new CrashDetails(_planeImage, _planeModel, _crashDate, _crashTime, _currentStatus, _operator, _registration, _firstFlight, _crew, _passengers,
                _total, _aircraftDamage, _location, _phase, _nature, _departureAirport, _destinationAirport, _flightNumber, _crashSummary, _cycles, _engines,
                _airframeHours, _aircraftFate, _mapUrl, _imgList);
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

        public static string getMapUrlBetweenTags(string value, string startTag, string endTag)
        {
            Regex rx = new Regex(startTag + "(.*?)" + endTag); //change to "(.*?)>(.*?)"
            MatchCollection col = rx.Matches(value);

            int idx = 0;
            for (int i = 0; i < col.Count; i++)
            {
                if(col[i].ToString().Contains("map_iframe.php"))
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

        public static string DeleteComments(string text)
        {
            Regex rx = new Regex("<!--" + "(.*?)" + "-->"); //change to "(.*?)>(.*?)"
            MatchCollection col = rx.Matches(text);

            foreach(Match c in col)
            {
                text = text.Replace(c.ToString(), " ");
            }

            return text;
        }

        public Image _Image
        {
            get { return _planeImage; }
            set { _planeImage = value; }
        }

        public string _Model
        {
            get { return _planeModel.Trim(); }
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

        public string _Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public string _Registration
        {
            get { return _registration; }
            set { _registration = value; }
        }

        public string _FirstFlight
        {
            get { return _firstFlight; }
            set { _firstFlight = value; }
        }

        public string _Crew
        {
            get { return _crew; }
            set { _crew = value; }
        }

        public string _Passengers
        {
            get { return _passengers; }
            set { _passengers = value; }
        }

        public string _Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public string _Damage
        {
            get { return _aircraftDamage; }
            set { _aircraftDamage = value; }
        }

        public string _Location
        {
            get { return _location; }
            set { _location  = value; }
        }

        public string _Phase
        {
            get { return _phase; }
            set { _phase = value; }
        }

        public string _Nature
        {
            get { return _nature; }
            set { _nature = value; }
        }

        public string _Departure
        {
            get { return _departureAirport; }
            set { _departureAirport = value; }
        }

        public string _Destination
        {
            get { return _destinationAirport; }
            set { _destinationAirport = value; }
        }

        public string _FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        public string _Summary
        {
            get { return _crashSummary; }
            set { _crashSummary = value; }
        }

        public string _Cycles
        {
            get { return _cycles; }
            set { _cycles = value; }
        }

        public string _Engines
        {
            get { return _engines; }
            set { _engines = value; }
        }

        public string _AirframeHours
        {
            get { return _airframeHours; }
            set { _airframeHours = value; }
        }

        public string _AircraftFate
        {
            get { return _aircraftFate; }
            set { _aircraftFate = value; }
        }

        public string _MapURL
        {
            get { return _mapUrl; }
            set { _mapUrl = value; }
        }

        public List<Image> _ImageList
        {
            get { return _imgList; }
            set { _imgList = value; }
        }
    }
}
