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
        if (string.IsNullOrEmpty(title)||string.IsNullOrEmpty(content))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写标题和内容后提交！');</script>");
            return;
        }
        Article art=new Article ();
        art.Author=author;
        art.Content=content;
        art.Language=language;
        art.Title=title;
        art.Typeid=typeid;
        DBTools.AddArticle(art);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('文章添加成功！');window.location='Admin_ArticleManage.aspx'</script>");
    }
}