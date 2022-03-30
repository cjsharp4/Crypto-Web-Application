using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Presentation
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {

        string myAuthenticate(string username, string password)
        {

            string fLocation = HttpContext.Current.Server.MapPath("~/App_Data/Staff.xml");
            if (File.Exists(fLocation))
            {
                FileStream FS = new FileStream(fLocation, FileMode.Open);
                XmlDocument xd = new XmlDocument();
                xd.Load(FS);
                FS.Close();
                XmlNode node = xd;
                XmlNodeList children = node.ChildNodes;
                var users = children[1];
                foreach (XmlNode user in users)
                {
                    string name = user["UserName"].InnerText;
                    string pass = user["Password"].InnerText;

                    if(username.Equals(name) && password.Equals(pass))
                    {
                        return "1";
                    }
                }
            }
            fLocation = HttpContext.Current.Server.MapPath("~/App_Data/Members.xml");
            if (File.Exists(fLocation))
            {
                FileStream mFS = new FileStream(fLocation, FileMode.Open);
                XmlDocument mxd = new XmlDocument();
                mxd.Load(mFS);
                mFS.Close();
                XmlNode anode = mxd;
                XmlNodeList achildren = anode.ChildNodes;
                var ausers = achildren[1];
                foreach (XmlNode user in ausers)
                {
                    string name = user["UserName"].InnerText;
                    string pass = user["Password"].InnerText;

                    if (username.Equals(name) && password.Equals(pass))
                    {
                        return "2";
                    }
                }
            }
            return "0";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserId = "0";
            UserId = myAuthenticate(TextBox1.Text, TextBox2.Text);

            if (UserId.Equals("1"))
            {
                //Response.Redirect("Protected/Staff.aspx");
                FormsAuthentication.RedirectFromLoginPage((TextBox1.Text+"|"+UserId), CheckBox1.Checked);
                //FormsAuthentication.SetAuthCookie(TextBox1.Text, true);
            }
            else if(UserId.Equals("2"))
            {
                FormsAuthentication.RedirectFromLoginPage((TextBox1.Text + "|" + UserId), CheckBox1.Checked);
            }
            else
            {
                Label1.Text = "Invalid Login";
                //Label1.Text = HttpContext.Current.Server.MapPath("~/App_Data/Staff.xml");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Go to sign-up page
            Response.Redirect("Register.aspx");
        }
    }
}