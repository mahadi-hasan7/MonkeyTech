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
    public partial class admin_login : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shakil\source\repos\s_ecws\s_ecws\App_Data\shopping.mdf;Integrated Security=True");
        int i;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["isAdminLoggedIn"] = "no";
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from admin_login where username = '" + email.Text + "' and password = '" + password.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 1)
            {
                //if this true then
                // navbar option will be displayed
                Session["isAdminLoggedIn"] = "yes";

                Response.Redirect("all_product.aspx");
            }
            else
            {
                messageLabel.Text = "invalid username or password";
            }
            con.Close();
        }
    }
}