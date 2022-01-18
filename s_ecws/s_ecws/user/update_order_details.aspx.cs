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
    public partial class update_order_details : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {


            if(IsPostBack)
            {
                return;
            }


            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from registration where email = '" + Session["user"].ToString() + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows) {
                TextBox1.Text = dr["firstname"].ToString();
                TextBox2.Text = dr["lastname"].ToString();
                TextBox3.Text = dr["address"].ToString();
                TextBox4.Text = dr["city"].ToString();
                TextBox5.Text = dr["state"].ToString();
                TextBox6.Text = dr["mobile"].ToString();
            }

            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update registration set firstname='"+TextBox1.Text+"', lastname='"+ TextBox2.Text + "',address='"+TextBox3.Text+"',city='"+ TextBox4.Text + "',state='"+ TextBox5.Text + "',mobile='"+ TextBox6.Text + "' where email = '"+Session["user"].ToString()+"'";
            cmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("payment_gateway.aspx");
        }
    }
}