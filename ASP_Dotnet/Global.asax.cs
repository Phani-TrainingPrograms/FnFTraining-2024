using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
//Right place to create app and session state objects as they have events that can be used to create those kinds of objects
namespace SampleWebApp
{
    public class Global : System.Web.HttpApplication
    {
        //Event handler for Application Start
        protected void Application_Start(object sender, EventArgs e)
        {
            //Use Server.MapPath function to extract the folder path from the Web server to get the physical path of the directory where the images are stored. 
            var path = Server.MapPath("~//Images");
            var data = ApplicationData.CreateProducts(path);
            Application["data"] = data;
        }

        //Event handler when a Session Starts. 
        protected void Session_Start(object sender, EventArgs e)
        {

        }
    }
}