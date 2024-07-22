using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Ex04Validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        //dblClk on the Custom Validator in the Designer to generate the Event Handler.
        //Custom Validator will the last to validate. Custom Validator validates at the server side and this will happen only after all the regular validators are validated. 
        protected void Unnamed7_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Custom validation is usually used for server side validation for which U wish to validate on a server side resource(File, DB...)
            if (args.Value == "Trainer" || args.Value == "Trainee")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            //QuerystringExample();
            CookiesExample();
            //Hidden Fields are input elements of HTML that has attribute hidden which is not visible to the users and can be accessed using the Forms Collection of the Request. However, the Hidden fields are html elements used to store static text
        }

        private void CookiesExample()
        {
            if (Page.IsValid)
            {
                HttpCookie cookie = new HttpCookie("RegisterInfo");
                //cookie.Expires = DateTime.Now.AddMinutes(1);//Persistaance cookie..
                cookie.Values.Add("name", txtName.Text);
                cookie.Values.Add("email", txtEmail.Text);
                cookie.Values.Add("age", txtAge.Text);
                cookie.Values.Add("pwd", txtPwd.Text);

                Response.Cookies.Add(cookie);//Add the cookie to the response.
                Response.Redirect("StateManagement.aspx");
            }
            //Cookies are Text based files that are stored in the browsers. They are harmless and plain text. Apps can store text based info in the browsers for a default period of upto 1 year. Cookies with no expiry date are called as NON Persistant cookies.  
        }

        private void QuerystringExample()
        {
            //if all the validations of the page is done....
            if (Page.IsValid)
            {
                string url = $"StateManagement.aspx?name={txtName.Text}&email={txtEmail.Text}&age={txtAge.Text}&pwd={txtPwd.Text}";
                //Redirect is like Hyperlink of server side(HTTP-GET) where we request for the page that is passed as arg....
                Response.Redirect(url);
                //It is a new request after processing the Click event of the Button
            }
          //QueryString: Is text based information that shared thru the URL of the page. Querystring is a key-value pairs of text seperated by an & for each pair. 
        }
    }
}