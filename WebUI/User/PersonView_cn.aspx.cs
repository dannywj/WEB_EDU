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
        if (Request.QueryString["typeId"] != null && Request.QueryString["language"] != null && Request.QueryString["personType"] != null)
        {
            string lang = Request.QueryString["language"].ToString();
            string personType = Request.QueryString["personType"].ToString();
            
            int typeid = int.Parse(Request.QueryString["typeId"].ToString());

            List<Person> plist = DBTools.GetAllPersonList(lang, personType);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = plist;
            pds.AllowPaging = true;
            pds.PageSize = 8;
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
                    strPager += "<a style=\"color:#ff0000\" href ='?personType=" + personType + "&typeId=" + typeid + "&language=" + lang + "&page=" + (i + 1) + "'>" + (i + 1) + "</a>&nbsp;";
                }
                Label3.Text = strPager;

            }
            if (!pds.IsFirstPage)
            {
                HyperLink1.NavigateUrl = Request.CurrentExecutionFilePath + "?personType=" + personType + "&typeId=" + typeid + "&language=" + lang + "&page=" + Convert.ToString(curpage - 1);
            }
            if (!pds.IsLastPage)
            {
                HyperLink2.NavigateUrl = Request.CurrentExecutionFilePath + "?personType=" + personType + "&typeId=" + typeid + "&language=" + lang + "&page=" + Convert.ToString(curpage + 1);
            }

            Rpt_person.DataSource = pds;
            Rpt_person.DataBind();

            //绑定最新内容
            List<Article> list = DBTools.GetArticleByType(99, lang, 10);
            Rpt_NewList.DataSource = list;
            Rpt_NewList.DataBind();
        }


    }
}