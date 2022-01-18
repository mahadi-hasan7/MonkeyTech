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
    public partial class ifOrderisDone : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {
            //if the order is complete
            int orderId = Convert.ToInt32(Request.QueryString["orderId"].ToString());

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from pendingOrder where pendingId = '"+orderId+"'";
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("display_order.aspx");
        }
    }
}