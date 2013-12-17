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
        Model.User result = DBTools.CheckLogin(user);
        if (result == null)
        {
            errorMsgServer.Text = "Wrong UserName or Password！";
            return;
        }
        else
        { 
            string key=DateTime.Now.ToString("_yyyyMMddHHmmss");
            HttpContext.Current.Session["user_" + result.Email] = result.Email + "&" + key;
            Response.Cookies["user_key"].Value = result.Email +"&"+ key;

            HttpContext.Current.Session["UserModel_" + result.Email] = result;
            Response.Redirect("Index_en.aspx");
        }
    }
}