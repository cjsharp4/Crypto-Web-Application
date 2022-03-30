using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Presentation
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //get different captcha
            ServiceReference1.ServiceClient myProxy = new ServiceReference1.ServiceClient();

            string myString = myProxy.GetVerifierString("4");
            Session["generatedString"] = myString;
        

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Register Account
            string userName = TextBox1.Text;
            string password = TextBox2.Text;

            string fLocation = HttpContext.Current.Server.MapPath("~/App_Data/Members.xml");
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(fLocation);  // open file
            XmlElement rootElement = myDoc.DocumentElement;

            //check if username already exists
            bool newName = true;
            XmlElement root = myDoc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node["UserName"].InnerText.Equals(userName))
                {
                    Label1.Text = "Error! Account with user name: " + userName + " already exists";
                    newName = false;
                }
            }

            if (!TextBox3.Text.Equals(Session["generatedString"]))
            {
                newName = false;
                Label2.Text = "The string you have entered does not match the image";
            }

            //register new account in xml database if the username isn't already taken
            if (newName && TextBox3.Text.Equals(Session["generatedString"]))
            {
                XmlElement myMember = myDoc.CreateElement("Users",
                rootElement.NamespaceURI);
                rootElement.AppendChild(myMember);
                XmlElement myUser = myDoc.CreateElement("UserName",
                rootElement.NamespaceURI);
                myMember.AppendChild(myUser);
                myUser.InnerText = userName;
                XmlElement myPwd = myDoc.CreateElement("Password",
                rootElement.NamespaceURI);
                myMember.AppendChild(myPwd);
                myPwd.InnerText = password;
                myDoc.Save(fLocation);

                FormsAuthentication.RedirectFromLoginPage((userName + "|" + "2"), true);
            }
            

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Go back to homepage
            Server.Transfer("~/Default.aspx");

        }
    }
}