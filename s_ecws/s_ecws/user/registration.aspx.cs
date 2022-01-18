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
    public partial class registration : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUp_Click(object sender, EventArgs e)
        {




            string EMAIL = email.Text;
            if(isThere(EMAIL))
            {
                messageLabel.Text = "there is already a user with this email";
            }
            else
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into registration values('" + fname.Text + "','"
                    + lname.Text + "','" +
                    email.Text + "','" +
                    password.Text + "','" +
                    address.Text + "','" +


                    ""+""+""+
                    //city.Text + "','" +
                    //state.Text + "','" +
                    //pincode.Text + "','" +


                    mobile.Text + "')";
                cmd.ExecuteNonQuery();

                con.Close();


                fname.Text = "";
                lname.Text = "";
                email.Text = "";
                password.Text = "";
                address.Text = "";
                //city.Text = "";
                //state.Text = "";
                //pincode.Text = "";
                mobile.Text = "";

                messageLabel.Text = "Registratopn complete";
            }
        }


        bool isThere(string email)
        {

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from registration where email='"+email+"'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();

            return dt.Rows.Count > 0;
        }
    }
}