using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace RequiredServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] ExchangeRates(string cryptoInUSD)
        {
            string apiUrl = "https://api.exchangerate.host/latest?base=USD&places=2";

            if (Double.TryParse(cryptoInUSD, out Double value))
            {
                apiUrl += "&amount=";
                apiUrl += value.ToString();
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            WebResponse response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();
            JsonDocument jdoc = JsonDocument.Parse(responseText);

            JsonElement root = jdoc.RootElement;
            string[] allCurrencies = new string[15];
            string[] top15Currencies = {"EUR" , "JPY" , "GBP" , "AUD" , "CAD" , "CNY" , "INR" , "KRW" ,
                "RUB" , "MXN" , "HKD" , "TWD" , "BRL" , "CHF" , "NZD"};

            int count = 0;
            foreach (var item in root.EnumerateObject())
            {
                if (item.Name.ToString().Equals("rates"))
                {
                    var temp = item.Value;
                    foreach (var currency in temp.EnumerateObject())
                    {
                        if (top15Currencies.Contains(currency.Name.ToString()))
                        {
                            //Console.WriteLine(currency.ToString());
                            allCurrencies[count] = currency.ToString();
                            count = count + 1;
                        }
                    }
                }

            }


            return allCurrencies;

        }

        public string[] Weather5day(string zipcode)
        {

            WeatherServiceReference.ndfdXML weatherService = new WeatherServiceReference.ndfdXML();

            string coordsXml = weatherService.LatLonListZipCode(zipcode); //get xml output for latitude and longitude method from the national weather service based on the given zip code

            XmlDocument docRef = new XmlDocument();
            docRef.LoadXml(coordsXml); //load latitudelongitude xml into XmlDocument

            //begin navigating through the given xml to get latitude and longitude information
            XmlNode root = docRef.FirstChild;

            string latLon = root.NextSibling.InnerText; //Gets latitude and longitude values
            string[] words = latLon.Split(',');
            decimal lat = Convert.ToDecimal(words[0]);
            decimal lon = Convert.ToDecimal(words[1]);

            //format all variables to be the correct type when giving the weather service method its parameters
            DateTime date = DateTime.Now;
            ((DateTime)date).ToString("yyyy-MM-dd");
            string weatherXML = weatherService.NDFDgenByDay(lat, lon, date , "6", "e", "24 hourly"); //get weather forecast for a specific zip code

            docRef.LoadXml(weatherXML); //load in 5 day weather forecast service xml output
            root = docRef.FirstChild; //dvml section
            var child = root.NextSibling; //head section
            var data = child.ChildNodes[1]; //data section

            var temps = data.ChildNodes[5]; //parameters
            var max = temps.ChildNodes[0]; //5 max temps
            var min = temps.ChildNodes[1]; //5 min temps

            var weatherType = temps.ChildNodes[3]; //contains the weather type for the next 5 days example: "mostly sunny"

            string[] dailyForecast = new string[5]; //array containing the weather forecast for the next 5 days
            DateTime time = DateTime.Now;

            //Concatenate information for each day and store the string in the dailyForecast array
            int j = 1;
            for (int i = 1; i < 6; i++)
            {

                string forecast = (time.DayOfWeek + (j)).ToString();
                if ((time.DayOfWeek + j) == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Saturday && j == 1)
                {
                    j = -6;
                }
                j++;

                if(i == 1)
                {
                    forecast = "Tomorrow";
                }
                forecast += " Hi/Low: ";
                forecast += min.ChildNodes[i].InnerText;
                forecast += "/";
                forecast += max.ChildNodes[i].InnerText;
                forecast += " ";
                forecast += weatherType.ChildNodes[i].Attributes["weather-summary"].Value;
                dailyForecast[i - 1] = forecast;
              
            }


            return dailyForecast;
        }

        public string WordFilter(string str)
        {

            //compiled list of stop words in the English language
            string[] stopWords =
            {
                "a","but","during","hows","it's","said","about","by","each","however","it’s","says","above","can","either","i","its","see","across","can't",
                "for","i'd","let's","she","after","can’t","from","i’d","let’s","she'd","all","cant","given","i'll","lets","she’d","along","cannot","had","i’ll",
                "may","shed","also","could","has","i'm","me","she'll","am","couldn't","have","i’m","more","she’ll","an","couldn’t","having","im","most","shell",
                "and","couldnt","he","i've","much","should","any","did","he'd","i’ve","must","since","are","didn't","he’d","ive","my","so","aren't","didn’t","hed",
                "if","no","some","aren’t","didnt","he'll","in","not","such","arent","do","he’ll","instead","now","than","as","does","her","into","of","that","at",
                "doesn't","here","is","on","the","be","doesn’t","hers","isn't","one","their","because","doesnt","him","isn’t","only","them","been","doing","himself",
                "isnt","or","then","before","done","his","it","other","there","being","don't","how","it'll","our","therefore","between","don’t","how's","it’ll","out",
                "these","both","dont","how’s","itll","over","they","this","we’re","who’ve","those","we've","whove","through","we’ve","will","to","weve","with","too",
                "were","within","towards","what","without","under","what's","won't","until","what’s","won’t","us","whats","would","use","when","wouldn't","used",
                "when's","wouldn’t","uses","when’s","you","using","whens","you'd","very","where","you’d","want","whether","youd","was","which","you'll","wasn't",
                "while","you’ll","wasn’t","who","youll","wasnt","who'll","you're","we","who’ll","you’re","we'd","wholl","youre","we’d","who's","you've","we'll",
                "who’s","you’ve","we’ll","whos","youve","we're","who've","your"
            };

            //put each word from the given string/sentence to be compared with the stop words
            string[] strArray = str.Split(' ');

            //iterate through each stop word and each word from the given sentence
            //compare stop words with words from the sentence and remove a word if it is a stop word
            foreach (string stopWord in stopWords)
            {
                for(int i = 0; i < strArray.Length; i++)
                {
                    //compare stop words with words in the sentence (case insensitive)
                    if(String.Equals(stopWord, strArray[i], StringComparison.OrdinalIgnoreCase))
                    {
                        strArray[i] = "";
                    }
                }
            }

            //join remaining words from the original sentence that were not stop words
            str = string.Join(" ", strArray);
            str = String.Join(" ", str.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)); //removes any extra whitespaces that were created in the sentence

            
            return str; //return the new, filtered sentence

        }


    }
}
