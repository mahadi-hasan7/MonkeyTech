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
    public partial class display_order : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Write(Session["user"].ToString());

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from orders where email='"+Session["user"].ToString()+"' order by id desc";

            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            r1.DataSource = dt;
            r1.DataBind();

            con.Close();
        }
    }
}