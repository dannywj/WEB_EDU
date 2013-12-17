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
        string name = txtName.Text.Trim();
        string zhicheng = txtZhicheng.Text.ToString();
        string email = txtEmail.Text.Trim();
        string phone = txtPhone.Text.Trim();
        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }

        string lingyu = txtLingyu.Text.Trim();
        string type = "0";
        if (radioType2.Checked)
        {
            type = "1";
        }
        string teaURL = txtTeacherURL.Text.Trim();

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(zhicheng) || this.FileUpload1.PostedFile.FileName=="")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写内容后提交！');</script>");
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
            if (ex == ".jpg" || ex == ".png" || ex == ".gif" || ex == ".bmp" )
            {
                if (this.FileUpload1.PostedFile.ContentLength > 2 * 1024 * 1024)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('附件大小超出2MB，请压缩后上传！')</script>");
                    return;
                }
                FileUpload1.PostedFile.SaveAs(Server.MapPath("../PersonImages/") + file + ex);
            }
            else
            {
                Response.Write("<script>alert('请上传本系统所支持的文件类型！');</script>");
                return;
            }
            fileURL = "../PersonImages/" + file + ex;
        }
        Person p = new Person();
        p.Email = email;
        p.FileURL = fileURL;
        p.Language = language;
        p.Lingyu = lingyu;
        p.Phone = phone;
        p.Pname = name;
        p.Type = type;
        p.Zhicheng = zhicheng;
        p.TeacherURL = teaURL;
        DBTools.AddPerson(p);

        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('人员添加成功！');window.location='Admin_PersonManage.aspx'</script>");
    }
}