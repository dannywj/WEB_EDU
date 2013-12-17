using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class User_UserTitle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('begin！');</script>");

        User user = new User();
        if (HttpContext.Current.Request.Cookies["user_key"] == null)// 没登陆
        {
            this.btnEnd.Visible = false;
            btnLogin.Visible = true;
        }
        else
        {
            string key = HttpContext.Current.Request.Cookies["user_key"].Value.ToString();
            if (HttpContext.Current.Session["user_" + key.Split('&')[0].ToString()] == null)
            {
                this.btnEnd.Visible = false;
                btnLogin.Visible = true;
            }
            else
            {
                if (HttpContext.Current.Session["user_" + key.Split('&')[0].ToString()].ToString() != key)
                {
                    this.btnEnd.Visible = false;
                    btnLogin.Visible = true;
                }
                else
                {
                    user = (User)HttpContext.Current.Session["UserModel_" + key.Split('&')[0].ToString()];
                    this.btnEnd.Visible = true;
                    btnLogin.Visible = false;
                    btnEnd.Text = "&nbsp;&nbsp;" + user.Email + "  [安全退出]";
                }
            }
        }
    }


    protected void btnEnd_Click(object sender, EventArgs e)
    {
        
        HttpCookie aCookie;
        string cookieName;
        int limit = Request.Cookies.Count;
        for (int i = 0; i < limit; i++)
        {
            cookieName = Request.Cookies[i].Name;
            aCookie = new HttpCookie(cookieName);
            aCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(aCookie);
        }
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>window.location='Index_cn.aspx';</script>");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login_cn.aspx");
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Signup_cn.aspx");
    }
}