using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using Model;

public partial class User_Article : System.Web.UI.Page
{
    public bool isLogin = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBTools.CheckUser() == null)
        {
            isLogin = false;
        }
        else
        {
            isLogin = true;
        }
        GetData();
    }

    public void GetData()
    {
        if (Request.QueryString["typeId"] != null && Request.QueryString["language"] != null)
        {
            int typeid = int.Parse(Request.QueryString["typeId"].ToString());
            string lang = Request.QueryString["language"].ToString();

            // 绑定列表
            List<Article> typeList = DBTools.GetArticleByType(typeid, lang).OrderBy(t => t.Id).ToList();


            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = typeList;
            pds.AllowPaging = true;
            pds.PageSize = 20;
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
                    strPager += "<a style=\"color:#ff0000\" href ='?typeId=" + typeid + "&language=" + lang + "&page=" + (i + 1) + "'>" + (i + 1) + "</a>&nbsp;";
                }
                Label3.Text = strPager;

            }
            if (!pds.IsFirstPage)
            {
                HyperLink1.NavigateUrl = Request.CurrentExecutionFilePath + "?typeId=" + typeid + "&language=" + lang + "&page=" + Convert.ToString(curpage - 1);
            }
            if (!pds.IsLastPage)
            {
                HyperLink2.NavigateUrl = Request.CurrentExecutionFilePath + "?typeId=" + typeid + "&language=" + lang + "&page=" + Convert.ToString(curpage + 1);
            }

            Rpt_list.DataSource = pds;
            Rpt_list.DataBind();

            // 绑定最新内容
            List<Article> list = DBTools.GetArticleByType(99, lang, 10);
            Rpt_NewList.DataSource = list;
            Rpt_NewList.DataBind();
        }


    }
    protected void Rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "down")
        {
            int id = int.Parse(e.CommandArgument.ToString());

            if (isLogin)
            {
                Article art = DBTools.GetArticleById(id, Request.QueryString["language"].ToString());
                string RootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录

                string path = RootDir+"\\" + art.FileURL.Substring(3).Replace('/','\\');

                if (File.Exists(path))
                {

                    FileInfo file = new System.IO.FileInfo(path);
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename=" + HttpUtility.UrlEncode(file.Name, System.Text.Encoding.UTF8));
                    HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                  //  Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");

                    string fileExtension = file.Extension.ToLower();
                    switch (fileExtension)
                    {
                        case ".mp3":
                            HttpContext.Current.Response.ContentType = "audio/mpeg3";
                            break;
                        case ".mpeg":
                            HttpContext.Current.Response.ContentType = "video/mpeg";
                            break;
                        case ".jpg":
                            HttpContext.Current.Response.ContentType = "image/jpeg";
                            break;
                        case ".bmp":
                            HttpContext.Current.Response.ContentType = "image/bmp";
                            break;
                        case ".gif":
                            HttpContext.Current.Response.ContentType = "image/gif";
                            break;
                        case ".doc":
                            HttpContext.Current.Response.ContentType = "application/msword";
                            break;
                        case ".css":
                            HttpContext.Current.Response.ContentType = "text/css";
                            break;
                        case ".html":
                            HttpContext.Current.Response.ContentType = "text/html";
                            break;
                        case ".htm":
                            HttpContext.Current.Response.ContentType = "text/html";
                            break;
                        case ".swf":
                            HttpContext.Current.Response.ContentType = "application/x-shockwave-flash";
                            break;
                        case ".exe":
                            HttpContext.Current.Response.ContentType = "application/octet-stream";
                            break;
                        case ".inf":
                            HttpContext.Current.Response.ContentType = "application/x-texinfo";
                            break;
                        default:
                            HttpContext.Current.Response.ContentType = "application/octet-stream";
                            break;
                    }

                    HttpContext.Current.Response.WriteFile(file.FullName);
                    HttpContext.Current.Response.End();
                }
                else
                {
                  HttpContext.Current.Response.Write("File Not Exists");
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Please Login！');window.location='Login_en.aspx'</script>");
            }
        }
    }
}