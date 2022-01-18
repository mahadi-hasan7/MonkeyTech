using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;

namespace s_ecws.user
{
    public partial class view_cart : System.Web.UI.Page
    {

        int totalCost = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] {
                new DataColumn("productName"),
                new DataColumn("productDesc"),
                new DataColumn("productPrice"),
                new DataColumn("productQty"),
                new DataColumn("productImage"),
                new DataColumn("id"),

                new DataColumn("product_id") // will use to increase the total amount when something is remove from cart
            });

            
            if(Request.Cookies["Order"] != null && Request.Cookies["Order"].Value.Length > 1)
            {
                string oldCookies = Convert.ToString(Request.Cookies["Order"].Value);
                string[] splitOldCookies = oldCookies.Split('$');

                //System.Diagnostics.Debug.Write("oldCookies : " + oldCookies + "\n");

                string[] itemsList = new string[6];
                for (int i = 0; i < splitOldCookies.Length - 1; i++)
                {
                    string individualItemDetails = splitOldCookies[i];
                    string[] splitIndividualItemDetails = individualItemDetails.Split(',');
                    for (int j=0;j<splitIndividualItemDetails.Length; ++j)
                    {
                        itemsList[j] = splitIndividualItemDetails[j].ToString();
                    }
                    //System.Diagnostics.Debug.Write("single product : " + individualItemDetails + " " + itemsList[5].ToString());


                    dt.Rows.Add(itemsList[0].ToString(), itemsList[1].ToString(), itemsList[2].ToString(), itemsList[3].ToString(), itemsList[4].ToString(), i.ToString(), itemsList[5].ToString());
                    totalCost += Convert.ToInt32(itemsList[2].ToString()) * Convert.ToInt32(itemsList[3].ToString());
                }
                d1.DataSource = dt;
                d1.DataBind();


                totalPrice.Text = totalCost.ToString();
                //Response.Cookies["Order"].Value = oldCookies;
                //Response.Cookies["Order"].Expires.AddDays(10);
            }
            else
            {
                //... do nothing
            }
        }

        protected void confirmBuying(object sender, EventArgs e)
        {
            Session["checkoutButton"] = "yes";
            //Response.Redirect("checkout.aspx");
            //Response.Redirect("confirmOrder.aspx");
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                //Cookies.Expires = DateTime.Now.AddDays(-1);
                //if (Request.Cookies["Order"] != null)
                //{



                //    Response.Cookies["Order"].Expires = DateTime.Now.AddDays(-1);
                //}
                Response.Redirect("confirmOrder.aspx");
            }
        }
    }
}