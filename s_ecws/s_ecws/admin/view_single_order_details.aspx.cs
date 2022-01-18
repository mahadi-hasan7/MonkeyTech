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
        int orderId;
        protected void Page_Load(object sender, EventArgs e)
        {

            orderId = Convert.ToInt32(Request.QueryString["orderId"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from pendingOrder where pendingId='" + orderId + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            string orderProductList = "";
            foreach (DataRow dr in dt.Rows)
            {
                orderProductList = dr["productList"].ToString();
            }
            //System.Diagnostics.Debug.WriteLine("singleOrderProduct List : " + orderProductList);
            DataTable storeTable = new DataTable();
            storeTable.Columns.AddRange(new DataColumn[5] {
                new DataColumn("productName"),
                new DataColumn("productDesc"),
                new DataColumn("productPrice"),
                new DataColumn("productImage"),
                //একটা product কত গুলা order করসে
                new DataColumn("orderedCount")
            });

            if (orderProductList.Length > 0)
            {
                System.Diagnostics.Debug.WriteLine("column count: " + storeTable.Columns.Count);
                string[] singleItem = orderProductList.Split('|');
                //System.Diagnostics.Debug.WriteLine("single item: " + singleItem[0]);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                for(int i=0;i<singleItem.Length; ++i)
                {
                    System.Diagnostics.Debug.WriteLine(i + 1 + " singleItem: " + singleItem[i] + "\n");
                    //productId_orderedQuanity[0] = product id
                    //productId_orderedQuanity[1] = কত গুলা order করছে 
                    string[] productId_orderedQuanity = singleItem[i].Split(',');
                    cmd.CommandText = "select * from product where id='" + productId_orderedQuanity[0].ToString() + "'";
                    cmd.ExecuteNonQuery();

                    dt = new DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        storeTable.Rows.Add(dr["product_name"].ToString(), dr["product_desc"].ToString(), dr["product_price"].ToString(), dr["product_images"].ToString(), productId_orderedQuanity[1].ToString());
                    }
                    //System.Diagnostics.Debug.WriteLine(i+1 + " productId_orderedQuanity: " + productId_orderedQuanity[0] + ' ' + productId_orderedQuanity[1] + "\n");
                }

                d1.DataSource = storeTable;
                d1.DataBind();



                con.Close();
            }
        }
    }
}