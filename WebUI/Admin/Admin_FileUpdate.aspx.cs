using System;
using System.Collections.Generic;
using System.IO;
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
            if (Request.QueryString["articleId"] != null && Request.QueryString["lang"] != null)
            {
                GetData();
            }
        }
    }

    public void GetData()
    {
        int id = int.Parse(Request.QueryString["articleId"].ToString());
        string lang = Request.QueryString["lang"].ToString();
        Article art = DBTools.GetArticleById(id, lang);
        txtTitle.Text = art.Title;
        if (art.Language == "en")
        {
            RadioButton2.Checked = true;
        }
    }

    protected void Button_sure_Click(object sender, EventArgs e)
    {
        string title = txtTitle.Text.Trim();

        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }
        if (string.IsNullOrEmpty(title))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写完整后提交！');</script>");
            return;
        }

        string fileURL = "";
        if (CheckBox1.Checked)
        {
            if (this.FileUpload1.PostedFile.FileName != "")
            {
                string file = Path.GetFileName(this.FileUpload1.PostedFile.FileName.Substring(0, this.FileUpload1.PostedFile.FileName.Length - 4));
                file += DateTime.Now.ToString("_yyyyMMddHHmmss");
                string ex = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
                if (ex == ".rar" || ex == ".doc" || ex == ".zip" || ex == ".txt" || ex == ".pdf")
                {
                    if (this.FileUpload1.PostedFile.ContentLength > 30 * 1024 * 1024)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('附件大小超出30MB，请压缩后上传！')</script>");
                        return;
                    }
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("../UploadFiles/") + file + ex);

                }
                else
                {
                    Response.Write("<script>alert('请上传本系统所支持的文件类型！');</script>");
                    return;
                }
                fileURL = "../UploadFiles/" + file + ex;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写完整后提交！');</script>");
                return;
            }
        }


        Article art = new Article();
        art.Id = int.Parse(Request.QueryString["articleId"].ToString());
        art.Language = language;
        art.Title = title;
        if (CheckBox1.Checked)
        {
            art.FileURL = fileURL;
        }

        art.Typeid = 6;
        DBTools.UpdateFile(art);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('文件更新成功！');window.location='Admin_FileManage.aspx'</script>");
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            FileUpload1.Enabled = true;
        }
        else
        {
            FileUpload1.Enabled = false;
        }
    }
}