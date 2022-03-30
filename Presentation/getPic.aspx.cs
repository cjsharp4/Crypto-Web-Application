using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class getPic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get new image for verifier
            Response.Clear();
            ServiceReference1.ServiceClient myProxy = new ServiceReference1.ServiceClient();

            string myString = myProxy.GetVerifierString("4");
            Session["generatedString"] = myString;
            Stream myStream = myProxy.GetImage(myString);
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
            Response.ContentType = "image/jpeg";
            myImage.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}