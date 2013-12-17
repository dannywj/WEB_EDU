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
            TextBox_content.Text = art.Content;
            txtAuthor.Text = art.Author;
            ddlType.SelectedValue = art.Typeid.ToString();

            if (art.Language == "en")
            {
                RadioButton2.Checked = true;
            }
        }
    }

    protected void Button_sure_Click(object sender, EventArgs e)
    {
        string title = TextBox_title.Text.Trim();
        string content = TextBox_content.Text.ToString();
        int typeid = int.Parse(ddlType.SelectedItem.Value);
        string author = txtAuthor.Text.Trim();
        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写标题和内容后提交！');</script>");
            return;
        }
        Article art = new Article();
        art.Author = author;
        art.Content = content;
        art.Language = language;
        art.Title = title;
        art.Id = int.Parse(Request.QueryString["articleId"].ToString());
        DBTools.UpdateArticle(art);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('文章更新成功！');window.location='Admin_ArticleManage.aspx'</script>");
    }
}