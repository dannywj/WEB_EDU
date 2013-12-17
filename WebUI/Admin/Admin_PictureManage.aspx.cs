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
        List<Picture> list = DBTools.GetAllPicture();
        Rpt_Pic.DataSource = list;
        Rpt_Pic.DataBind();
    }

    protected void Button_sure_Click(object sender, EventArgs e)
    {
        
        string title = txtTitle.Text.Trim();

        string language = "cn";

        if (string.IsNullOrEmpty(title) || this.FileUpload1.PostedFile.FileName == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写标题和文件后提交！');</script>");
            return;
        }
        //检查上传文件的数量
        if (!DBTools.CheckPictureCount())
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('最多上传" + int.Parse(System.Configuration.ConfigurationManager.AppSettings["IndexPictureCount"].ToString()) + "张图片！');</script>");
            return;
        }

        string fileURL = "";
        if (this.FileUpload1.PostedFile.FileName != "")
        {
            //string file = this.FileUpload1.PostedFile.FileName.Substring(0,this.FileUpload1.PostedFile.FileName.Length-4)+"_"+System.DateTime.Now.ToString("yyyyMMddHHmmss");
            string file = Path.GetFileName(this.FileUpload1.PostedFile.FileName.Substring(0, this.FileUpload1.PostedFile.FileName.Length - 4));
            file += DateTime.Now.ToString("_yyyyMMddHHmmss");
            string ex = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
            if (ex == ".bmp" || ex == ".jpg" || ex == ".png" || ex == ".jpeg" || ex == ".gif")
            {
                if (this.FileUpload1.PostedFile.ContentLength > 5 * 1024 * 1024)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('附件大小超出5MB，请压缩后上传！')</script>");
                    return;
                }
                FileUpload1.PostedFile.SaveAs(Server.MapPath("../IndexImages/") + file + ex);

            }
            else
            {
                Response.Write("<script>alert('请上传本系统所支持的文件类型！');</script>");
                return;
            }
            fileURL = "../IndexImages/" + file + ex;

            //处理图片尺寸
            string RootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            int height = int.Parse(System.Configuration.ConfigurationManager.AppSettings["IndexPictureHeight"].ToString());
            DBTools.MakeThumbnail(RootDir + "IndexImages/" + file + ex, RootDir + "IndexImages/" + "small_" + file + ex, height, height, "H");

        }

        Picture p = new Picture();
        p.FileURL = fileURL;
        p.Title = title;

        DBTools.AddPicture(p);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('图片添加成功！');</script>");

        List<Picture> list = DBTools.GetAllPicture();
        Rpt_Pic.DataSource = list;
        Rpt_Pic.DataBind();
    }

    protected void Rpt_Pic_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            string RootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            Picture p = DBTools.GetOnePicture(id);
            string DeletefileURL = RootDir + p.FileURL.Replace("../", "").Replace("/","\\");
            string DeletefileURL_small = RootDir  + p.FileURL.Replace("../", "").Replace("/", "/small_").Replace("/", "\\"); 

            if (File.Exists(DeletefileURL) && File.Exists(DeletefileURL_small))
            {
                //如果存在则删除
                File.Delete(DeletefileURL);
                File.Delete(DeletefileURL_small);
            }
            DBTools.DeletePicture(id);

            List<Picture> list = DBTools.GetAllPicture();
            Rpt_Pic.DataSource = list;
            Rpt_Pic.DataBind();
        }
    }

}