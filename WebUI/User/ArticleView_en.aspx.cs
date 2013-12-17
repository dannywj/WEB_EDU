using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using Model;

public partial class User_Article : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetData();
    }

    public void GetData()
    {
        if (Request.QueryString["typeId"] != null && Request.QueryString["articleId"] != null && Request.QueryString["language"] != null)
        {
            int typeid = int.Parse(Request.QueryString["typeId"].ToString());
            int artid = int.Parse(Request.QueryString["articleId"].ToString());
            string lang = Request.QueryString["language"].ToString();

            Article art = new Article();
            art = DBTools.GetArticleById(artid, lang);
            lblAuthor.Text = art.Author;
            lblContent.Text = art.Content;
            lblTitle.Text = art.Title;

            // 绑定最新内容
            List<Article> list = DBTools.GetArticleByType(99, lang, 10);
            Rpt_NewList.DataSource = list;
            Rpt_NewList.DataBind();
        }


    }
}