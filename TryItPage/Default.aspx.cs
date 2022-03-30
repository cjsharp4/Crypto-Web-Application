using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client myProxy = new ServiceReference1.Service1Client(); //create new proxy to call service methods
            string zip = TextBox1.Text; //assign user inputted string from textbox
            string[] temps = myProxy.Weather5day(zip); //store weather service array locally for display purposes
            Label1.Text = String.Join(" | " , temps); //turn array into a string to display on the TryIt page
            myProxy.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client myProxy = new ServiceReference1.Service1Client(); //create new proxy to call service methods
            string sentence = TextBox2.Text; //get user inputted string to be processed for stop words
            Label2.Text = myProxy.WordFilter(sentence); //use proxy to access WordFilter service and assign output to a label on the TryIt page
            myProxy.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client myProxy = new ServiceReference1.Service1Client();
            string usdAmount = TextBox3.Text; //assign user inputted string from textbox
            string[] temps = myProxy.ExchangeRates(usdAmount); //store weather service array locally for display purposes
            Label3.Text = String.Join(" | ", temps); //turn array into a string to display on the TryIt page
            myProxy.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Uri completeUri = new Uri("http://localhost:57756/Service2.svc/CryptoRank");
            WebClient channel = new WebClient();
            byte[] abc = channel.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string[]));
            string[] randStringArray = (string[])obj.ReadObject(strm);
            Label4.Text = String.Join(" |||| " , randStringArray);

        }
    }
}