using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation.Members
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get UserId (1 = admin) (2 = Member)
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            //string id = ticket.Name.Split('|')[1];
            Label1.Text = "Hello " + ticket.Name.Split('|')[0];
            Label2.Text = ticket.Name.Split('|')[0];

            string role = "(no role given)";
            if (ticket.Name.Split('|')[1].Equals("1"))
            {
                role = "(admin)";
            }
            else if (ticket.Name.Split('|')[1].Equals("2"))
            {
                role = "(member)";
            }

            Label3.Text = ticket.Name.Split('|')[1] + " " + role;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //sign out button
            FormsAuthentication.SignOut();
            Server.Transfer("~/Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //home button
            Server.Transfer("~/Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ServiceReference2.Service1Client myProxy = new ServiceReference2.Service1Client();
            string usdAmount = TextBox1.Text; //assign user inputted string from textbox
            string[] temps = myProxy.ExchangeRates(usdAmount); //store weather service array locally for display purposes
            Label4.Text = String.Join(" | ", temps); //turn array into a string to display on the TryIt page
            myProxy.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Obtain the runtime value of the Text input argument
            string text = TextBox2.Text;

            text = text.ToLower();

            string apiUrl = "https://api.coingecko.com/api/v3/simple/price?ids=";
            apiUrl += text;
            apiUrl += "&vs_currencies=usd";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            WebResponse response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();


            JsonDocument jdoc = JsonDocument.Parse(responseText);

            JsonElement root = jdoc.RootElement;

            string finalPrice = "-1";

            //catch error if invalid crypto is entered, which would invalidate the api call address
            try
            {
                JsonElement price = root.GetProperty(text);
                finalPrice = price.GetProperty("usd").ToString();
                Label5.Text = "The cost of " + text + " is currently: $" + finalPrice;
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                Label5.Text = "ERROR"; 
            }

            if(Label5.Text != "ERROR")
            {

                //set values to be double so that you can get a rate conversion using division
                double getConversionRate = Convert.ToDouble(finalPrice);
                double toInvest = Convert.ToDouble(TextBox3.Text);
                double getCryptoRate = toInvest / getConversionRate; 

                //truncate answer to get clean value with 2 decimal places
                double rateTruncated = Math.Truncate(getCryptoRate * 100) / 100;

                Label6.Text = "You could buy " + string.Format("{0:N2}", rateTruncated) + " " + text + "!";

            }

        }
    }
}