using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class StateManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ExtractUsingQueryString();
                var value = Request.Form["counter"];
                lblDetails.Text = value + "<br/>";
                ExtractUsingCookies();
            }
        }

        private void ExtractUsingCookies()
        {
            var cookie = Request.Cookies["RegisterInfo"];
            if (cookie == null)
            {
                lblDetails.Text = "This Page is requested directly, so no input details are available";
            }
            else
            {
                var name = cookie.Values["name"];
                var email = cookie.Values["email"];
                var age = cookie.Values["age"];
                var pwd = cookie.Values["pwd"];
                var stringInput = $"Name: {name}<br/>Email: {email}<br/>Age: {age}<br/>Password: {pwd}<br/>Please click on Register if the inputs are correct!!!";
                lblDetails.Text += stringInput;
            }
        }

        private void ExtractUsingQueryString()
        {
            //extract the Querystring values:
            if (Request.QueryString.Count == 0)
            {
                lblDetails.Text = "This Page is requested directly, so no input details are available";
            }
            else
            {
                var name = Request.QueryString["name"];
                var email = Request.QueryString["email"];
                var age = Request.QueryString["age"];
                var pwd = Request.QueryString["pwd"];
                var stringInput = $"Name: {name}<br/>Email: {email}<br/>Age: {age}<br/>Password: {pwd}<br/>Please click on REgister if the inputs are correct!!!";
                lblDetails.Text = stringInput;

            }
        }
    }
}
/*
 * Notes:
 * QueryString is not secured. It can be modified by the user. 
 * QueryString is text based, no objects or any other kind of data can be used. 
 * Some Browsers restrict the length to be upto 255 charecters. 
 * Querystring is fine for simple text transfer from one page to another. 
 * 
 * 
 * Cookies:
 * The data is stored in the client's browser
 * The Clients can disable/delete the cookies when ever they want. 
 * It is recommended to ask for Client's permissions before setting the cookies. 
 */