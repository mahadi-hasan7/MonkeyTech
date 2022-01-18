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
    public partial class product_description : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shakil\source\repos\s_ecws\s_ecws\App_Data\shopping.mdf;Integrated Security=True");


        // যে product-র discription দেখাবো তার id(MAIN DATABASE TABLE-এ, projectDatabase)
        int id_jetaDekhbo;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            // যদি কোনো user নিচের মত কিছু click করলে, error না দেই
              // http://localhost:32481/user/product_description.aspx?icchaMoto
              // কোনো value নাই, এই link-এ
            if (Request.QueryString["icchaMoto"] == null)
            {
                Response.Redirect("display_item.aspx");
            }
            else
            {

                // URL থেকে current product-এর id retrive করবো
                id_jetaDekhbo = Convert.ToInt32(Request.QueryString["icchaMoto"].ToString());


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from product where id='"+id_jetaDekhbo+"'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                d1.DataSource = dt;
                d1.DataBind();

                con.Close();
            }


            // check করবো stock-এ product টা আছে কিনা
                // না থাকলে বলব OUT OF STOCK

                //currentlyAvailableInStore(যার quantity দেখতে চাচ্ছি তার id(MAIN DATABASE TABLE))
            int amountAvaliable = currentlyAvailableInStore(id_jetaDekhbo);
            if(amountAvaliable == 0)
            {
                //enterQuantity_OutofStock.Visible = false;
                enterQuantity.Visible = false;
                b1.Visible = false;

                enterQuantity_OutofStock.Text= "OUT OF STOCK";
            }
        }




        // add to cart button-এ click করলে
        protected void addToCart(object sender, EventArgs e)
        {

            // open থাকলে close করে then আবার open করবো
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product where id='" + id_jetaDekhbo + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            string currentProduct = "";
            string storeQuantity = "";
            foreach (DataRow dr in dt.Rows)
            {
                currentProduct = dr["product_name"].ToString() + "," +
                          dr["product_desc"].ToString() + "," +
                          dr["product_price"].ToString() + "," +
                          //dr["product_qty"].ToString() + "," +

                          enterQuantity.Text + "," + // user koto input dise oita
                          dr["product_images"].ToString() + "," +

                          id_jetaDekhbo.ToString(); // so that we can use to to increase the total time then some item is removed from cart
                          ;


                storeQuantity = dr["product_qty"].ToString();
            }

            // user যে quantity কিনতে চাই
            int requestedItem = Convert.ToInt32(enterQuantity.Text);
            // যা আছে
            int inStore = Convert.ToInt32(storeQuantity);

            if(requestedItem <= 0)
            {
                overflowQuantityLabel.Text = "please enter a positive amount";
            }
            else if (requestedItem > inStore)
            {
                //overflowQuantityLabel.Visible = true;
                overflowQuantityLabel.Text = "we only have " + storeQuantity + " many available"; 
            }
            else
            {
                //overflowQuantityLabel.Visible = false;

                overflowQuantityLabel.Text = "";
                if (Response.Cookies["Order"] != null)
                {
                    string oldCookies = Convert.ToString(Request.Cookies["Order"].Value);
                    string cookiesNew = oldCookies + currentProduct + "$";
                    Response.Cookies["Order"].Value = cookiesNew;
                }
                else
                {
                    Response.Cookies["Order"].Value = Request.Cookies["Order"].Value + currentProduct + "$";
                }

                Response.Cookies["Order"].Expires = DateTime.Now.AddDays(10);



                // কিনলে যে database থেকে quantity reduce হবে
                 // updating the database
                 // reduce the quntity the of that particular item
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update product set product_qty = product_qty - " + enterQuantity.Text + "where id = " + id_jetaDekhbo;
                cmd1.ExecuteNonQuery();


                // calculation করে আবার same product এর page-এ redirect করবো
                Response.Redirect("product_description.aspx?icchaMoto=" + id_jetaDekhbo.ToString());

            }


















            // string দিয়ে করার try করছিলাম,
                // cookie থেকে product information retrive



            //spliting the stored cookes
            //eikhane eita dorkar nai
            //string[] strArr = Response.Cookies["Order"].Value.Split(' ');
            //System.Diagnostics.Debug.Write("array of cookies\n");
            //for (int i = 0; i < strArr.Length; i++)
            //{
            //    System.Diagnostics.Debug.Write(strArr[i].ToString());
            //    System.Diagnostics.Debug.Write("\n");
            //}
            //System.Diagnostics.Debug.Write("\n\n\n");




            //note:
            //another way to reading the cookies



            //string currentProduct = "";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    currentProduct = dr["product_name"].ToString() + "," +
            //              dr["product_desc"].ToString() + "," +
            //              dr["product_price"].ToString() + "," +
            //              dr["product_qty"].ToString() + "," +
            //              dr["product_images"].ToString();
            //}


            //HttpCookie currentCookie = new HttpCookie("Order");
            //if (Response.Cookies["Order"] != null)
            //{
            //    string oldCookies = Convert.ToString(Request.Cookies["Order"].Value);
            //    string cookiesNew = oldCookies + currentProduct + " - ";
            //    currentCookie.Value = cookiesNew;
            //}
            //else
            //{
            //    currentCookie.Value = Request.Cookies["Order"].Value + currentProduct + " - ";
            //}





            //note:
            //upore niche deoyar ki jani ekta jamela chilo

            //currentCookie.Expires = DateTime.Now.AddDays(10);
            //Response.Cookies.Add(currentCookie);


            //string[] strArr = currentCookie.Value.Split('-');
            //System.Diagnostics.Debug.Write("array of cookies\n");
            //for (int i = 0; i < strArr.Length; i++)
            //{
            //    System.Diagnostics.Debug.Write(strArr[i].ToString());
            //    System.Diagnostics.Debug.Write("\n");
            //}
            //System.Diagnostics.Debug.Write("\n\n\n");
            //con.Close();
        }



     

































        public int currentlyAvailableInStore(int id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product where id='" + id_jetaDekhbo + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            int amountAvaliable = 0;
            foreach(DataRow dr in dt.Rows)
            {
                amountAvaliable = Convert.ToInt32(dr["product_qty"].ToString());
            }
            return amountAvaliable;
        }

        protected void viewCartButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/user/view_cart.aspx");
        }
    }
}