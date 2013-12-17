using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using Model;
using System.IO;

public partial class Admin_Admin_UserManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (HttpContext.Current.Session["Language"] != null)
            {
                //ddlLanguage.SelectedItem.Value = HttpContext.Current.Session["Language"].ToString();
                ddlLanguage.SelectedValue = HttpContext.Current.Session["Language"].ToString();
            }
            GetData();
        }


    }

    public void GetData()
    {
        List<Article> list = null;
        if (HttpContext.Current.Session["Language"] != null)
        {
            list = DBTools.GetArticleByType(6, HttpContext.Current.Session["Language"].ToString());
            ddlLanguage.SelectedItem.Value = HttpContext.Current.Session["Language"].ToString();
        }
        else
        {

            list = DBTools.GetArticleByType(6, ddlLanguage.SelectedItem.Value);
        }


        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = list;
        pds.AllowPaging = true;
        pds.PageSize = 10;
        int curpage;
        if (Request.QueryString["page"] != null)
        {
            curpage = Convert.ToInt32(Request.QueryString["page"]);
        }
        else
        {
            curpage = 1;
        }
        pds.CurrentPageIndex = curpage - 1;
        Label1.Text = curpage.ToString();
        Label2.Text = pds.PageCount.ToString();

        int intAllNum = pds.PageCount;
        string strPager = "";
        if (intAllNum > 0)
        {
            for (int i = 0; i < intAllNum; i++)
            {
                strPager += "<a style=\"color:#ff0000\" href ='?page=" + (i + 1) + "'>" + (i + 1) + "</a>&nbsp;";
            }
            Label3.Text = strPager;

        }
        if (!pds.IsFirstPage)
        {
            HyperLink1.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(curpage - 1);
        }
        if (!pds.IsLastPage)
        {
            HyperLink2.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(curpage + 1);
        }

        Rpt_Article.DataSource = pds;
        Rpt_Article.DataBind();
    }

    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {

        HttpContext.Current.Session["Language"] = ddlLanguage.SelectedItem.Value;
        //GetData();
        Response.Redirect("Admin_FileManage.aspx");
    }
    protected void Rpt_Article_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            try
            {
                string file = DBTools.GetArticleById(id, ddlLanguage.SelectedValue.ToString()).FileURL;
                string RootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
                string DeletefileURL = RootDir + file.Replace("../", "").Replace("/", "\\");
                File.Delete(DeletefileURL);
            }
            catch (Exception ex)
            {

            }

            DBTools.DeleteArticleById(id);
        }
        GetData();
    }
}