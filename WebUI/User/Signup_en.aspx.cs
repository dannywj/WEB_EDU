using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DataLibrary;

public partial class User_Signup_cn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Model.User user = new User();
        user.Email = txtEmail.Text.Trim();
        user.Password = txtPwd.Text.Trim();
        user.School = txtSchool.Text.Trim();
        user.Station = 0;
        user.TrueName = txtTrueName.Text.Trim();
        user.Interest = txtInterest.Text.Trim();

        if (DBTools.AddUser(user))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Successful！');window.location='Index_en.aspx';</script>");
        }
        else
        {
            errorMsgServer.Text = "Exist User！";
        }
    }
}