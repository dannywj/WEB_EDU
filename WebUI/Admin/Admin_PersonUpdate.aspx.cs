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
            GetData();
        }
        
    }

    public void GetData()
    {

        if (Request.QueryString["personId"] != null && Request.QueryString["lang"] != null)
        {
            int pid = int.Parse(Request.QueryString["personId"].ToString());
            string lang = Request.QueryString["lang"].ToString();
            Person p = DBTools.GetOnePerson(pid, lang);
            txtName.Text = p.Pname;
            txtZhicheng.Text = p.Zhicheng;
            txtEmail.Text = p.Email;
            txtPhone.Text = p.Phone;
            if (p.Language == "en")
            {
                RadioButton2.Checked = true;
            }

            txtLingyu.Text = p.Lingyu;
            
            if (p.Type=="1")
            {
                radioType2.Checked = true;
            }


            txtTeacherURL.Text = p.TeacherURL;
        }
    }

    protected void Button_sure_Click(object sender, EventArgs e)
    {
        int pid = int.Parse(Request.QueryString["personId"].ToString());
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

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(zhicheng))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写内容后提交！');</script>");
            return;
        }

        Person p = new Person();
        p.Id = pid;
        p.Email = email;
        // p.FileURL = fileURL;
        p.TeacherURL = txtTeacherURL.Text.Trim();
        p.Language = language;
        p.Lingyu = lingyu;
        p.Phone = phone;
        p.Pname = name;
        p.Type = type;
        p.Zhicheng = zhicheng;
        DBTools.UpdateOnePerson(p);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('人员修改成功！');window.location='Admin_PersonManage.aspx'</script>");
    }
}