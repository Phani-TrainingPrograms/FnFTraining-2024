﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                lblUser.Text ="Welcome " + Page.User.Identity.Name;
            }
            else
            {
                lblUser.Text = "Anonymous User! Please register for more user Experience";
            }
            lblTime.Text = DateTime.Now.Year.ToString();
        }
    }
}