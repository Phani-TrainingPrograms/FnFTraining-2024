using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Ex01BasicControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This function gets called everytime the page is refreshed in the browser. 
        }
        //All events are instances of a .NET Delegate called EventHandler. 
        protected void btnClick_Click(object sender, EventArgs e)
        {
            //sender is the object on which the event called click was raised. Any args that an event can have is placed under EventArgs. If no args are available, it shall remain as an object variable
            //var btn = (Button)sender;
            //btn.BackColor = System.Drawing.Color.Brown;
            Trace.Write("Now processing the Button click"); 
            //extract the value from the textbox
            var textEntered = txtItem.Text;
            lstItems.Items.Add(textEntered);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Add the edited item into the listbox. 
            lstItems.Items.Add(txtItem.Text);   
            txtItem.Text = string.Empty;
        }

        protected void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Extract the selected Item from the listbox.
            var selectedItem = lstItems.SelectedItem.Text;
            lblSelected.Text = $"The selected Item is {selectedItem}";
        }
        //Page life cycle:
        //PreInit,Init, InitComplete
        //PreLoad,Load, LoadComplete,
        //PreRender, PreRenderComplete, Render
        //Unload ->All the objects that are created during this Request will be destroyed. The page does not remember anything. 

        //Create a Page called CalcPage that has 2 Text boxes and a Listbox. The List box has the operations of the calc. User enters the inputs in the textboxes, selects the operation from the listbox and the result of the operration should be displayed on the page.
        //It should be server side scripting. 

    }
}