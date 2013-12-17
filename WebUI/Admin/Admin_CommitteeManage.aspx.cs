using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using Model;
using System.Data;

public partial class Admin_Admin_ArticleAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }
    }

    protected void Button_sure_Click(object sender, EventArgs e)
    {
        
        string content = TextBox_content.Text.ToString();
       
        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }
        if (string.IsNullOrEmpty(content))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请填写内容后提交！');</script>");
            return;
        }

        DBTools.UpdateCommittee(language, content);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('更新成功！');</script>");
    }

    public void GetData()
    {
        DataTable dt = DBTools.GetCommitteeByLanguage("cn");
        TextBox_content.Text = dt.Rows[0]["info"].ToString();
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }
        DataTable dt = DBTools.GetCommitteeByLanguage(language);
        TextBox_content.Text = dt.Rows[0]["info"].ToString();
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        string language = "cn";
        if (RadioButton2.Checked)
        {
            language = "en";
        }
        DataTable dt = DBTools.GetCommitteeByLanguage(language);
        TextBox_content.Text = dt.Rows[0]["info"].ToString();
    }
}