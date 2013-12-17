<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Top.aspx.cs" Inherits="Admin_Admin_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>top</title>
    <style >
         a:link,a:visited{text-decoration:none;color:#595959;}
a:active,a:hover{text-decoration:underline;color:#FF4600;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style ="text-align :center ; height :50px; width :100%;"><h2>后台管理系统</h2></div>
    <div style="height: 30px; vertical-align: baseline;  border-bottom: solid 2px #dedede; font-size :12px;">
        欢迎你
      &nbsp;系统管理员&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton_end" runat="server"
            OnClientClick="window.parent.location='../User/Index_cn.aspx'">[返回用户首页]</asp:LinkButton>
    </div>
    </form>
</body>
</html>