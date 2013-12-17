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
      
        int typeid =8;
        string link = txtAuthor.Text.Trim();
        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(link))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写标题和内容后提交！');</script>");
            return;
        }
        Article art=new Article ();
         
        art.Content = link;
        art.Language=language;
        art.Title=title;
        art.Typeid=typeid;
        DBTools.AddArticle(art);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加成功！');window.location='Admin_LinkManage.aspx'</script>");
    }
}