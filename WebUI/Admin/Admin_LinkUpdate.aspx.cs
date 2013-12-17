using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using Model;

public partial class Admin_Admin_ArticleAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }
        
    }

    public void GetData()
    {
        if (Request.QueryString["articleId"] != null && Request.QueryString["lang"] != null)
        {
            int id = int.Parse(Request.QueryString["articleId"].ToString());
            string lang = Request.QueryString["lang"].ToString();
            Article art = DBTools.GetArticleById(id, lang);
            TextBox_title.Text = art.Title;
            txtAuthor.Text = art.Content;
        }
    }

    protected void Button_sure_Click(object sender, EventArgs e)
    {
        string title = TextBox_title.Text.Trim();

        string author = txtAuthor.Text.Trim();
        
        if (string.IsNullOrEmpty(title))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写标题和内容后提交！');</script>");
            return;
        }
        Article art = new Article();
        
        art.Content = author;
        art.Language = Request.QueryString["lang"].ToString();
        art.Title = title;
        art.Id = int.Parse(Request.QueryString["articleId"].ToString());
        DBTools.UpdateArticle(art);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('更新成功！');window.location='Admin_LinkManage.aspx'</script>");
    }
}