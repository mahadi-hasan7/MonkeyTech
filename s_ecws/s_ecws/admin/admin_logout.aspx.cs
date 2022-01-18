﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace s_ecws.admin
{
    public partial class admin_logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["isAdminLoggedIn"] = "";
            Response.Redirect("admin_login.aspx");
        }
    }
}