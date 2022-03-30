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

namespace ElectiveService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService3
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
    }
}
