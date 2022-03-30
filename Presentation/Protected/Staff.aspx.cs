using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation.Protected
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
            FormsAuthentication.SignOut();
            Server.Transfer("~/Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Default.aspx");
        }
    }
}