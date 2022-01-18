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
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void loginButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            // এইটা কাজ কেন করে না?
            // delete_cart.aspx.cs তো করসে
            //cmd.CommandText = "select * from registration where email = " + TextBox1.Text + " and password = " + TextBox2.Text;



            cmd.CommandText = "select * from registration where email = '" + email.Text + "' and password = '" + password.Text + "'";
            cmd.ExecuteNonQuery();



            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            int matched = Convert.ToInt32(dt.Rows.Count.ToString());

            if (matched == 0)
            {
                messageLabel.Text = "invalid email or password";
            }
            else
            {
                Session["user"] = email.Text;
                Session["password"] = password.Text;


                //System.Diagnostics.Debug.WriteLine("first time login\n");
                //System.Diagnostics.Debug.WriteLine("user " + Session["user"].ToString());
                //System.Diagnostics.Debug.WriteLine("passwprd " + Session["password"].ToString());
                //System.Diagnostics.Debug.WriteLine("\n\n\n");


                string str = "";

                if (Session["checkoutButton"] != null)
                {
                    str = Session["checkoutButton"].ToString();
                }

                if (str == "yes")
                {
                    //Response.Redirect("update_order_details.aspx");
                    Response.Redirect("view_cart.aspx");
                }
                else
                {
                    Response.Redirect("display_item.aspx");
                }

                messageLabel.Text = "Logged IN";

            }
            con.Close();
        }
    }
}