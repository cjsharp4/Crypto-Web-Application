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
    public partial class capImage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            //string path = HttpContext.Current.Server.MapPath("~/getPic.ascx");
            Image1.ImageUrl = "~/getPic.aspx";
            Image1.Visible = true;
        }
    }
}