<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_FileAdd.aspx.cs" Inherits="Admin_Admin_ArticleAdd" ValidateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/Admin.css" />
    <link rel="stylesheet" type="text/css" href="css/public.css" />
    <script>
        
        function show() {
            document.getElementById("msg").style.display = "block";
            document.getElementById("Button_sure").style.display = "none";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="top " style="width: 800px">
        增加新文件
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            上传文件描述：
        </div>
        <div class="t2" style="text-align: left">
            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
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
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px">
        <div class="t1">
            选择文件：
        </div>
        <div class="t2" style="text-align: left">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            附件大小不超30MB，支持类型 rar，zip，doc，pdf
        </div>
    </div>
    <div class="tr" style="border-top: solid 1px #dedede; width: 800px; display:none;" runat="server" id="msg">
        <div class="t1">
        </div>
        <div class="t2" style="text-align: left">
           <span style="color:red;">资料上传中，请稍候………………</span>
        </div>
    </div>
    <div class="end " style="border: none;">
        <asp:Button ID="Button_sure" runat="server" Text="确认提交" OnClick="Button_sure_Click" OnClientClick="show();"
            Width="90px" />
    </div>

    </form>
</body>
</html>
