using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAGitHubView
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception except = (Exception)(Session["ErrorException"]);
            if (except != null)
            {
                message.Text = except.Message;
                Server.ClearError();
                //Session["ErrorException"] = null;
            }
        }
    }
}