using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;



namespace s_ecws.admin
{
    public partial class editSingleProduct : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shakil\source\repos\s_ecws\s_ecws\App_Data\shopping.mdf;Integrated Security=True");


        // যে product-র discription দেখাবো তার id(MAIN DATABASE TABLE-এ, projectDatabase)
        int productId;
        protected void Page_Load(object sender, EventArgs e)
        {
            // যদি কোনো user নিচের মত কিছু click করলে, error না দেই
            // http://localhost:32481/user/product_description.aspx?icchaMoto
            // কোনো value নাই, এই link-এ
            if (Request.QueryString["productId"] == null)
            {
                Response.Redirect("all_product.aspx");
            }
            else
            {

                productId = Convert.ToInt32(Request.QueryString["productId"].ToString());


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from product where id='" + productId + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                d1.DataSource = dt;
                d1.DataBind();

                con.Close();
            }

        }

        protected void updateProductQuantity_Click(object sender, EventArgs e)
        {
            productId = Convert.ToInt32(Request.QueryString["productId"].ToString());


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update product set product_qty = '"+enterQuantity.Text+"' where id = '"+productId+"'";
            cmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("editSingleProduct.aspx?productId=" + productId);
        }
    }
}