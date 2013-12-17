<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_LinkAdd.aspx.cs" Inherits="Admin_Admin_ArticleAdd" ValidateRequest="false" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/Admin.css" />
    <link rel="stylesheet" type="text/css" href="css/public.css" />
</head>
<body>
      <form id="form1" runat="server">
    <div class="top " style="width: 800px">
        增加新合作机构</div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            合作机构名称：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="TextBox_title" runat="server" Width="300px"></asp:TextBox>
        </div>
    </div>
           
           <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            合作机构链接：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtAuthor" runat="server" Width="300px" Text="http://"></asp:TextBox>
        </div>
    </div>
           <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            语言版本：
        </div>
        <div class="t2" style="text-align: left">
             <asp:RadioButton ID="RadioButton1" GroupName="lang" runat="server" Checked="true" />中文  <asp:RadioButton ID="RadioButton2" GroupName="lang" runat="server" />英文
        </div
               >
    </div>
   
    <div class="end " style="border: none;">
        <asp:Button ID="Button_sure" runat="server" Text="确认提交" OnClick="Button_sure_Click"
            Width="90px" />
       </div>
     
    </form>
</body>
</html>
