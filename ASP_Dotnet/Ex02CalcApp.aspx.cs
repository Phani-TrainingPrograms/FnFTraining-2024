using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Ex02CalcApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double first, second;
            if (!double.TryParse(txtFirstValue.Text, out first))
            {
                lblError.Text = "Value cannot be blank";
                return;
            }
            if (!double.TryParse(txtSecondValue.Text, out second))
            {
                lblError.Text = "Value cannot be blank";
                return;
            }
            var option = dpList.Text;
            var result = 0.0;
            switch (option)
            {
                case "Add": result = first +second; break;
                case "Subtract": result = first - second; break;
                case "Multiply": result = first * second; break;
                case "Divide": result = first / second; break;
                default:
                    lblError.Text="Invalid Option";
                    break;
            }
            lblDisplay.Text = $"The Result: {result}";
        }
    }
}