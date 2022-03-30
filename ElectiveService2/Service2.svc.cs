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

namespace ElectiveService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService2
    {
        public string[] CryptoRank()
        {
            string apiUrl = "https://api.coingecko.com/api/v3/search/trending";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            WebResponse response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();
            JsonDocument jdoc = JsonDocument.Parse(responseText);

            JsonElement root = jdoc.RootElement;
            string[] trendingCryptos = new string[7];


            int count = 0;
            foreach (var item in root.EnumerateObject())
            {
                if (item.Name.ToString().Equals("coins"))
                {
                    var temp = item.Value;
                    foreach (var cryptoList in temp.EnumerateArray())
                    {
                        string combineData = "";
                        var coin = cryptoList.GetProperty("item"); //element containing each coin's total data
                        combineData += coin.GetProperty("name").ToString();
                        combineData += ": Trending Rank: ";
                        //combineData += coin.GetProperty("score").ToString();
                        combineData += (count + 1).ToString();
                        combineData += " , Market Cap Rank: ";
                        combineData += coin.GetProperty("market_cap_rank").ToString();
                        Console.Write(combineData);
                        Console.Write("\n");
                        trendingCryptos[count] = combineData;
                        count = count + 1;

                    }
                }

            }

           
            return trendingCryptos;

        }
    }
}
