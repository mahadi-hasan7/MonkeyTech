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
    public partial class all_product : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);



        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            if (Request.QueryString["search"] != null)
            {
                String searchTag = Request.QueryString["search"].ToString();
                cmd.CommandText = "select * from product where lower(product_name) like('%" + searchTag.ToLower() + "%') or lower(product_desc) like ('%" + searchTag.ToLower() + "%')";
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
    }
}