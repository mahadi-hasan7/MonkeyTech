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
    public partial class confirmOrder : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Order"] != null)
            {


                string oldCookies = Convert.ToString(Request.Cookies["Order"].Value);
                string[] splitOldCookies = oldCookies.Split('$');

                System.Diagnostics.Debug.Write("oldCookies : " + oldCookies + "\n");


                int itemCount = 0, totalPrice = 0;
                string orderedItemString = ""; 

                string[] itemsList = new string[6];
                for (int i = 0; i < splitOldCookies.Length - 1; i++)
                {
                    string individualItemDetails = splitOldCookies[i];
                    string[] splitIndividualItemDetails = individualItemDetails.Split(',');
                    for (int j = 0; j < splitIndividualItemDetails.Length; ++j)
                    {
                        itemsList[j] = splitIndividualItemDetails[j].ToString();
                    }


                    itemCount +=  Convert.ToInt32(itemsList[3].ToString());
                    totalPrice += Convert.ToInt32(itemsList[3].ToString()) * Convert.ToInt32(itemsList[2].ToString());;
                    orderedItemString += ( itemsList[5].ToString() + "," + itemsList[3].ToString() + "|");

                }




                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into pendingOrder values('" + Session["user"] + "', '" + orderedItemString.ToString() + "', '"+itemCount+"','"+totalPrice+"')";
                cmd.ExecuteNonQuery();
                con.Close();


                ////System.Diagnostics.Debug.Write("\n\n\nordered item string : " + orderedItemString + "\n\n\n");
                Response.Cookies["Order"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}