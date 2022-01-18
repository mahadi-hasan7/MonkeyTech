using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace s_ecws.user
{
    public partial class display_item : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shakil\source\repos\s_ecws\s_ecws\App_Data\shopping.mdf;Integrated Security=True");

        // এর জন্য আগে Web.config-র connectionString set করে দিতে হবে
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}

            //if (Request.QueryString["category"] == null)


            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            if (Request.QueryString["search"] != null)
            {
                //System.Diagnostics.Debug.WriteLine("inside search");
                //System.Diagnostics.Debug.WriteLine(Request.QueryString["search"].ToString());
                String searchTag = Request.QueryString["search"].ToString();
                cmd.CommandText = "select * from product where lower(product_name) like('%" + searchTag.ToLower() + "%') or lower(product_desc) like ('%" + searchTag.ToLower() + "%')";

                //Note:
                    // trying to do nested query, but it's not working
                    //জানি না কিভাবে করতে হবে
                //String searchTag = Request.QueryString["search"].ToString();

                //System.Diagnostics.Debug.WriteLine(Request.QueryString["search"].ToString());
                ////cmd.CommandText = "select * from product where lower(product_name) like('%" + searchTag.ToLower() + "%') or lower(product_desc) like ('%" + searchTag.ToLower() + "%')";

                //cmd.CommandText = "select * from product";
                //SqlDataAdapter initDataTable = new SqlDataAdapter(cmd);

                //DataTable temp = new DataTable();
                //initDataTable.Fill(temp);
                //cmd.CommandText = "select * from '" + temp + "'  where lower(product_name) like('%" + searchTag.ToLower() + "%') or lower(product_desc) like ('%" + searchTag.ToLower() + "%') ";
                //cmd.ExecuteNonQuery();

                //SqlDataAdapter changeTable = new SqlDataAdapter(cmd);
                ////string[] queryTag = searchTag.Split();
                ////for(int i=0;i<queryTag.Length; ++i)
                ////{
                ////    System.Diagnostics.Debug.WriteLine(queryTag[i]);
                ////}

                //DataTable dt = new DataTable();
                //changeTable.Fill(dt);
                //d1.DataSource = dt;
                //d1.DataBind();
            }
            else
            {

                cmd.CommandText = "select * from product";
                System.Diagnostics.Debug.WriteLine("SomeText");
            }

            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            d1.DataSource = dt;
            d1.DataBind();

            con.Close();
        }


        protected void seachButtonTest_Click(object sender, EventArgs e)
        {
            String searchPage = "display_item.aspx?search=" + searchItem.Text;
            Response.Redirect(searchPage);
        }


    }
}