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
        
    }

    protected void Button_sure_Click(object sender, EventArgs e)
    {
        
        string title =txtTitle.Text.Trim();
         
        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }
        if (string.IsNullOrEmpty(title) || this.FileUpload1.PostedFile.FileName == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写标题和文件后提交！');</script>");
            return;
        }

        string fileURL = "";
        // DateTime deadline = this.YsDateTime1.NowDate;
        if (this.FileUpload1.PostedFile.FileName != "")
        {
            //string file = this.FileUpload1.PostedFile.FileName.Substring(0,this.FileUpload1.PostedFile.FileName.Length-4)+"_"+System.DateTime.Now.ToString("yyyyMMddHHmmss");
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



        Article art=new Article ();
        art.Language=language;
        art.Title=title;
        art.FileURL = fileURL;
        art.Typeid=6;
        DBTools.AddFileInfo(art);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('文件添加成功！');window.location='Admin_FileManage.aspx'</script>");
    }
}