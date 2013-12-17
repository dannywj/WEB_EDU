using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DataLibrary;


public partial class Admin_Admin_UserManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        List<User> list = DBTools.GetAllUserList();
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = list;
        pds.AllowPaging = true;
        pds.PageSize = 50;
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


        Repeater_userManage.DataSource = pds;
        Repeater_userManage.DataBind();

    }
}