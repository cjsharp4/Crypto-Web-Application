using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}