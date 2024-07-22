using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class ApplicationState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["AllItems"] == null)
                {
                    Application.Add("AllItems", new List<string>());
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Application["AllItems"] != null) 
            {
                //unbox the data
                var data = Application["AllItems"] as List<string>;//unboxing
                data.Add(txtItem.Text);
                Application["AllItems"] = data;//boxing
                lstItems.DataSource = data;
                lstItems.DataBind();
            }
        }
    }
}