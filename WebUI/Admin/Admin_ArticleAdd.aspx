<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_ArticleAdd.aspx.cs" Inherits="Admin_Admin_ArticleAdd" ValidateRequest="false" %>

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
        增加新文章
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            文章标题：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="TextBox_title" runat="server" Width="300px"></asp:TextBox>
        </div>
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            文章分类：
        </div>
        <div class="t2" style="text-align: left">
            <asp:DropDownList ID="ddlType" runat="server">
                  <asp:ListItem Text="通知公告" Value="1" Selected="True"></asp:ListItem>
                 <asp:ListItem Text="中心概况" Value="2"></asp:ListItem>
            <asp:ListItem Text="中心动态" Value="7"></asp:ListItem>
            <asp:ListItem Text="科研项目" Value="9"></asp:ListItem>
            <asp:ListItem Text="研究成果" Value="5"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            文章作者：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtAuthor" runat="server" Width="300px" Text="Admin"></asp:TextBox>
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
    <div class="tr" style="height:700px; width: 800px">
        <div class="t1" style="height: 300px;">
            文章内容：
        </div>
        <div class="t2" style="height: 650px;">
            <FTB:FreeTextBox ID="TextBox_content" runat="server" ToolbarStyleConfiguration="Office2003"
                Width="550px" Height="600px" Language="zh-CN" ImageGalleryPath="ArticleImages" ToolbarImagesLocation="InternalResource" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" >
            </FTB:FreeTextBox>
        </div>
    </div>
    <div class="end " style="border: none;">
        <asp:Button ID="Button_sure" runat="server" Text="确认提交" OnClick="Button_sure_Click"
            Width="90px" />
        <input id="Reset1" type="reset" value="重置" />
    </div>

    </form>
</body>
</html>
