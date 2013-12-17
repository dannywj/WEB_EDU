<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_PersonUpdate.aspx.cs" Inherits="Admin_Admin_ArticleAdd" ValidateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

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
        修改中心人员
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            人员姓名：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
        </div>
    </div>
         <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            人员链接：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtTeacherURL" runat="server" Width="300px"></asp:TextBox>
        </div>
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            职称：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtZhicheng" runat="server" Width="300px"></asp:TextBox>
        </div>
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            电话：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtPhone" runat="server" Width="300px" Text=""></asp:TextBox>
        </div>
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            Email：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtEmail" runat="server" Width="300px" Text=""></asp:TextBox>
        </div>
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            人员类型：
        </div>
        <div class="t2" style="text-align: left">
            <asp:RadioButton GroupName="ptype" ID="radioType1" runat="server" Checked="true" />全职<asp:RadioButton ID="radioType2" GroupName="ptype" runat="server" />兼职
        </div>
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            语言版本：
        </div>
        <div class="t2" style="text-align: left">
            <asp:RadioButton ID="RadioButton1" GroupName="lang" runat="server" Checked="true" />中文 
            <asp:RadioButton ID="RadioButton2" GroupName="lang" runat="server" />英文
        </div>
    </div>

    <div class="tr" style="border-top: solid 1px #dedede; width: 800px; height: 50px;">
        <div class="t1">
            领域：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtLingyu" runat="server" Width="300px" Text="" TextMode="MultiLine" Height="38px"></asp:TextBox>
        </div>
    </div>
    <div class="end " style="border: none;">
        <asp:Button ID="Button_sure" runat="server" Text="确认修改" OnClick="Button_sure_Click"
            Width="90px" />

    </div>

    </form>
</body>
</html>
