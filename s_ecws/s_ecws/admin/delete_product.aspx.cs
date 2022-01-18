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
    public partial class delete_product : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shakil\source\repos\s_ecws\s_ecws\App_Data\shopping.mdf;Integrated Security=True");
        string[] a = new string[6];
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from product where id = '"+id+"'";
            cmd.ExecuteNonQuery();

            con.Close();

            
            Response.Redirect("all_product.aspx");
        }
    }
}