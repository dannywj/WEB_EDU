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
        string title = txtTitle.Text.Trim();
      
        int typeid =4;
        string content = txtContent.Text.Trim();
        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }
        string fileurl = txtFileURL.Text.Trim();
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(fileurl))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写内容后提交！');</script>");
            return;
        }
        Article art=new Article ();
        art.Content = content;
        art.Language=language;
        art.Title=title;
        art.Typeid=typeid;
        art.FileURL = fileurl;
        DBTools.AddArticle(art);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加成功！');window.location='Admin_SeminarsManage.aspx'</script>");
    }
}