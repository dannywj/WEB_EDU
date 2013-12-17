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
        if (Request.QueryString["typeId"] != null && Request.QueryString["language"] != null)
        {
            string lang = Request.QueryString["language"].ToString();

            //绑定最新内容
            List<Article> list = DBTools.GetArticleByType(99, lang, 10);
            Rpt_NewList.DataSource = list;
            Rpt_NewList.DataBind();
        }


    }
}