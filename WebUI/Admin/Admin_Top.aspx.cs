using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_Top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton_end_Click(object sender, EventArgs e)
    {
        Response.Cookies["UserName"].Value = "";
        Response.Cookies["UserName"].Expires = System.DateTime.Now.AddDays(-20000);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.window.location='../Login.aspx';</script>");
    }
}