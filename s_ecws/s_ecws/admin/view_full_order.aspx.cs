using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace s_ecws.admin
{
    public partial class view_full_order : System.Web.UI.Page
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);
        int id_jetaDekhabo;
        protected void Page_Load(object sender, EventArgs e)
        {

            id_jetaDekhabo = Convert.ToInt32(Request.QueryString["id"].ToString());

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from order_details where order_id="+id_jetaDekhabo;
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