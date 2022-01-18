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
    public partial class user : System.Web.UI.MasterPage
    {

        int totalPrice = 0, numberOfItem=0;

        //protected void seachButtonTest_Click(object sender, EventArgs e)
        //{
        //    //String searchPage = "display_item.aspx?search=" + searchItem.Text;
        //    //Response.Redirect(searchPage);
        //}

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


            if (Request.Cookies["Order"] != null && Request.Cookies["Order"].Value.Length > 1)
            {
                string oldCookies = Convert.ToString(Request.Cookies["Order"].Value);
                string[] splitOldCookies = oldCookies.Split('$');

                //System.Diagnostics.Debug.Write("oldCookies : " + oldCookies + "\n");

                string[] itemsList = new string[7];
                for (int i = 0; i < splitOldCookies.Length - 1; i++)
                {
                    string individualItemDetails = splitOldCookies[i];
                    string[] splitIndividualItemDetails = individualItemDetails.Split(',');
                    for (int j = 0; j < splitIndividualItemDetails.Length; ++j)
                    {
                        //System.Diagnostics.Debug.Write("ij = " + i + " : "+ j);
                        //itemsList[j] = splitIndividualItemDetails[j].ToString();
                        //System.Diagnostics.Debug.Write(itemsList[j]);
                    }
                    //System.Diagnostics.Debug.Write("shakil\n\n");


                    //dt.Rows.Add(itemsList[0].ToString(), itemsList[1].ToString(), itemsList[2].ToString(), itemsList[3].ToString(), itemsList[4].ToString(), i.ToString(), itemsList[5].ToString());


                    //totalCost = sum of(price * quantity);
                    //totalPrice += Convert.ToInt32(itemsList[2].ToString()) * Convert.ToInt32(itemsList[3].ToString());

                    //numberOfItem += Convert.ToInt32(itemsList[3].ToString());
                    //numberOfItem++;
                }


                //totalCost.Text = totalPrice.ToString();
                //typeOfItem.Text = numberOfItem.ToString();
            }
            else
            {
                //... do nothing
            }

        }
    }
}