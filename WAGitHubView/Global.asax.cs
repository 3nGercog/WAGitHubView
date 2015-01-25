using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace WAGitHubView
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.8.2.min.js"
            });
            //IPStatus status;
            //Ping p = new Ping();
            //PingReply pr = p.Send(@"github.com");
            //status = pr.Status;
            Debug.WriteLine("Application_ Start()");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Exception lastException = Server.GetLastError();
                if (lastException != null)
                {
                    Session["ErrorException"] = lastException.InnerException;
                }
                //Server.ClearError();

                Response.Redirect("Error.aspx");

                
            }
            catch (Exception)
            {
                Response.Write("К сожалению произошла критическая ошибка." +
                "Нажмите кнопку 'Назад' в браузере и попробуйте ещё раз. ");
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}