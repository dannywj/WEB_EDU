<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_CommitteeManage.aspx.cs" Inherits="Admin_Admin_ArticleAdd" ValidateRequest="false" %>

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
        管理顾问委员会</div>
           <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            语言版本：
        </div>
        <div class="t2" style="text-align: left">
             <asp:RadioButton ID="RadioButton1" GroupName="lang" runat="server" 
                 Checked="true" AutoPostBack="True" 
                 oncheckedchanged="RadioButton1_CheckedChanged" />中文  
             <asp:RadioButton ID="RadioButton2" GroupName="lang" runat="server" 
                 AutoPostBack="True" oncheckedchanged="RadioButton2_CheckedChanged" />英文
        </div
               >
    </div>
    <div class="tr" style="height: 800px; width: 800px">
        <div class="t1" style="height: 300px;">
            内容：
        </div>
        <div class="t2" style="height: 700px;">
            <FTB:FreeTextBox ID="TextBox_content" runat="server" ToolbarStyleConfiguration="Office2003"
                Width="550px" Height="610px" Language="zh-CN">
            </FTB:FreeTextBox>
        </div>
    </div>
    <div class="end " style="border: none;">
        <asp:Button ID="Button_sure" runat="server" Text="更新" OnClick="Button_sure_Click"
            Width="90px" />
        </div>
     
    </form>
</body>
</html>
