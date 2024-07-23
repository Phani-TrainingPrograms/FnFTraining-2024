using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                lstProducts.DataSource = Application["data"] as HashSet<Product>;
                lstProducts.DataTextField = "Name";
                lstProducts.DataValueField = "Id";
                lstProducts.DataBind();
            }
        }

        private Product findProduct(int id)
        {
            var data = Application["data"] as HashSet<Product>;
            return data.FirstOrDefault((p)=>p.Id == id);
        }
        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fetch the record from the Application data based on the selected Item
            var product = findProduct(Convert.ToInt32(lstProducts.SelectedItem.Value));
            if(product == null)
            {
                lblError.Text = "No product found to display";
                return;  
            }
            txtId.Text = product.Id.ToString();
            txtName.Text = product.Name;
            imgProduct.ImageUrl = product.Image;

            ///Filling the recent list...
            var recentList = Session["recentList"] as Queue<Product>;
            if(recentList.Count == 5)
            {
                recentList.Dequeue();//Remove the first item in the queue.
            }
            recentList.Enqueue(product);
            HashSet<Product> tempList = new HashSet<Product>();
            foreach (var item in recentList)
            {
                if (tempList.Contains(item))
                {
                    tempList.Remove(item);
                }
            }
            //tempList.Add(product);
            //recentList = new Queue<Product>(tempList);
            var list = recentList.Reverse();
            dtRecentList.DataSource = list;
            dtRecentList.DataBind();
        }
    }
}