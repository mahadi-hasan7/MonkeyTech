using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;





namespace s_ecws.user
{
    
    public partial class payment_gateway : System.Web.UI.Page
    {
       
        int tot = 0;
        string[] a = new string[6];

        string order_no;
        protected void Page_Load(object sender, EventArgs e)
        {


            
            if (Request.Cookies["Order"] != null)
            {
                string s = Convert.ToString(Request.Cookies["Order"].Value);
                string[] strArr = s.Split('$');
                for(int i=0;i<strArr.Length;++i)
                {
                    string t = Convert.ToString(strArr[i].ToString());
                    string[] strArr1 = t.Split(',');
                    for(int j = 0; j < strArr1.Length; ++j)
                    {
                        a[j] = strArr1[j].ToString();
                    }
                    tot = tot + (Convert.ToInt32(a[2].ToString()) * Convert.ToInt32(a[3].ToString()));
                }
                Session["tot"] = tot.ToString();
            }



            Random r = new Random();
            order_no = r.Next().ToString();
            //Response.Write(order_no);
            Session["order_no"] = order_no.ToString();






            //Response.Write("<form action='https://www.sandbox.paypal.com/cgi-bin/webscr' method='post' name='buyCredits' id='buyCredits'>");
            //Response.Write("<input type='hidden' name='cmd' value='_xclick'>");
            //Response.Write("<input type='hidden' name='business' value='amit_1266030690@gmail.com'>");
            //Response.Write("<input type='hidden' name='currency_code' value='USD'>");
            //Response.Write("<input type='hidden' name='item_name' value='payment for donate'>");
            //Response.Write("<input type='hidden' name='item_number' value='0'>");
            //Response.Write("<input type='hidden' name='amount' value='"+Session["tot"].ToString()+"'>");
            //Response.Write("<input type='hidden' name='return' value='https://localhost:36272/shopping_website/user/payment_sucess.aspx?order="+order_no.ToString()+"'>");
            //Response.Write("</form>");


            //Response.Write("<script type='text/javascript'>");
            //Response.Write("document.getElementById('buyCredits').submit();");
            //Response.Write("</script>");

        }

        protected void paymentComplete_Click(object sender, EventArgs e)
        {
            Response.Redirect("payment_sucess.aspx?order="+order_no);
        }
    }
}