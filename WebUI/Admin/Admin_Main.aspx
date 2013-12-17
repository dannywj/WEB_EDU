<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Main.aspx.cs" Inherits="Admin_Admin_Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台管理系统</title>
</head>
<frameset rows="100,*" cols="*" frameborder="no" border="0" framespacing="0">
    <frame src="Admin_Top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame"
        title="topFrame" />
    <frameset cols="206,*" frameborder="no" border="0" framespacing="0" id="attachucp">
        <frame src="Admin_left.html" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame"
            title="leftFrame" />
     <%--   <frame src="Admin_MainSwith.htm" name="bar" scrolling="no" noresize="noresize" id="bar" />--%>
        <frame src="Admin_Default.aspx" name="main" id="main" title="main" />
    </frameset>
</frameset>
<noframes>
    <body>
    </body>
</noframes>
</html>
