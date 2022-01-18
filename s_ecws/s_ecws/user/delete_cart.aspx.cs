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
    public partial class delete_cart : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shakil\source\repos\s_ecws\s_ecws\App_Data\shopping.mdf;Integrated Security=True");
        string[] a = new string[6];
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            // page এর url থেকে current product cookies-এর কততম index-এ আছে তার id-টা নিব
                // এইটা টেবিলে product-র id না, cookie-এ এই order-র position
             id = Convert.ToInt32(Request.QueryString["id"].ToString());



            // cookies-কে যে Table-এ save করবো
                // table-টা database type table
                // eg. sql database table
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            dt.Columns.AddRange(new DataColumn[7] {
                new DataColumn("productName"),
                new DataColumn("productDesc"),
                new DataColumn("productPrice"),
                new DataColumn("productQty"),
                new DataColumn("productImage"),
                new DataColumn("id"),

                new DataColumn("product_id")
            });



            // check করবো cart-এ কিছু আছে কিনা?
            if(Request.Cookies["Order"] != null)
            {

                // saved cookies কে split করে sql database table-এ save করবো
                    // এইভাবে access করা easy
                    // string দিয়ে করা যাবে(maybe), কিন্তু পারি না
                
                string oldCookies = Convert.ToString(Request.Cookies["Order"].Value);
                string[] splitOldCookies = oldCookies.Split('$');

                string[] itemsList = new string[7];
                for (int i = 0; i < splitOldCookies.Length - 1; i++)
                {
                    string individualItemDetails = splitOldCookies[i];
                    string[] splitIndividualItemDetails = individualItemDetails.Split(',');
                    for (int j = 0; j < splitIndividualItemDetails.Length; ++j)
                    {
                        itemsList[j] = splitIndividualItemDetails[j].ToString();
                    }
                    dt.Rows.Add(itemsList[0].ToString(), itemsList[1].ToString(), itemsList[2].ToString(), itemsList[3].ToString(), itemsList[4].ToString(), i.ToString(), itemsList[5].ToString());
                }
            }

            // cart থেকে কোনো product remove করলে, database quantity বাড়াবো
                // id   =   cookies-এ এর position
                // product_id   =   MAIN DATABASE TABLE-এ এর ID
                // count    =   দিয়ে বুঝতেছি, আমি যেটা খুঝতেছি তার কাছে আসছি কিনা?
            int count = 0, product_id = 0, qty = 0;
            foreach (DataRow dr in dt.Rows) {
                if (count == id) {
                    // MAIN DATABASE TABLE থেকে current quantity নিচ্ছি
                    product_id = Convert.ToInt32(dr["product_id"].ToString());
                    qty = Convert.ToInt32(dr["productQty"].ToString());
                }
                count++;
            }
            count = 0;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update product set product_qty = product_qty + " + qty + "where id = " + product_id;
            cmd.ExecuteNonQuery();
            con.Close();






            // যে product delete করা হইসে, ওইটা remove করবো
                // next steps:
                    // আগের saved cookie delete করবো
                    // এই update করা table দিয়ে নতুন cookie create করবো, then এইটা save করবো
            dt.Rows.RemoveAt(id);

            //delete the cookies
            // same line ekbaer beshi ow dekhe
            // onek somoy ekbar dile delete hy na, jodi ow shona kotha
            Response.Cookies["Order"].Expires = DateTime.Now.AddDays(-1);


            // recreateing the cookies
            string currentProduct = "";
            foreach (DataRow dr in dt.Rows)
            {
                currentProduct += dr["productName"].ToString() + "," +
                          dr["productDesc"].ToString() + "," +
                          dr["productPrice"].ToString() + "," +
                          dr["productQty"].ToString() + "," +
                          dr["productImage"].ToString() + "," +
                          //dr["id"].ToString() + "," +
                          dr["product_id"].ToString() + "$";
            }

            Response.Cookies["Order"].Value = currentProduct;
            Response.Cookies["Order"].Expires = DateTime.Now.AddDays(1);
            Response.Redirect("view_cart.aspx");
        }
    }
}