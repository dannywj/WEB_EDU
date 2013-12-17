<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_UserManage.aspx.cs" Inherits="Admin_Admin_UserManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理</title>

    <link rel="stylesheet" type="text/css" href="css/Admin.css" />
    <style>
        .top {
            width: 95%;
            height: 30px;
            font-size: 16px;
            font-weight: bold;
            text-align: center;
            margin: 0 auto;
            line-height: 30px;
            margin-top: 6px;
            border: solid 2px #dedede;
        }

        .tr {
            width: 95%;
            height: 28px;
            margin: 0 auto;
            text-align: center;
            font-size: 12px;
            line-height: 28px;
            border-bottom: solid 1px #dedede;
            border-left: solid 1px #dedede;
            border-right: solid 1px #dedede;
        }

        .th {
            width: 95%;
            height: 28px;
            margin: 0 auto;
            text-align: center;
            font-weight: bold;
            font-size: 12px;
            line-height: 28px;
            border: solid 1px #dedede;
            background-color: #dedede;
            margin-top: 4px;
        }

        .t_begin {
            height: 28px;
            float: left;
            border-right: solid 1px #dedede;
        }

        .t_end {
            width: 18%;
            height: 28px;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="top ">
        用户管理
    </div>
    <div class="th">
        <div class="t_begin" style="width: 5%">
            序号
       
        </div>
        <div class="t_begin" style="width: 20%">
            用户邮箱
       
        </div>
        <div class="t_begin" style="width: 10%">
            真实姓名
       
        </div>
        <div class="t_begin" style="width: 10%">
            注册时间
       
        </div>

        <div class="t_begin" style="width: 20%">
            毕业院校
       
        </div>
        <div class="t_end " style="width: 34%">
            用户兴趣
       
        </div>
    </div>
    <asp:Repeater ID="Repeater_userManage" runat="server">
        <ItemTemplate>
            <div class="tr">
                <div class="t_begin" style="width: 5%">
                    <%#Container.ItemIndex+1 %>
                </div>
                <div class="t_begin" style="width: 20%">

                    <%#((Model.User)Container.DataItem).Email %>
                </div>
                <div class="t_begin" style="width: 10%">

                    <%#((Model.User)Container.DataItem).TrueName %>
                </div>
                <div class="t_begin" style="width: 10%">
                    <%#((Model.User)Container.DataItem).AddDate %>
                </div>

                <div class="t_begin" style="width: 20%">
                    <%#((Model.User)Container.DataItem).School %>
                </div>
                <div class="t_end " style="width: 34%">
                    <%#((Model.User)Container.DataItem).Interest %>
                </div>

            </div>
        </ItemTemplate>
    </asp:Repeater>
    <table cellpadding="0" cellspacing="0" border="0" width="90%" style="margin: 0 auto;">
        <tr>
            <td style="text-align: center; font-size: 14px; height: 40px; line-height: 40px;">第&gt; <font color="red" style="font-weight: bold">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></font>&lt;页 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                <asp:HyperLink ID="HyperLink1" runat="server"><span class="kuang">上一页</span></asp:HyperLink>&nbsp;&nbsp;
               
                <asp:HyperLink ID="HyperLink2" runat="server"><span  class="kuang">下一页</span></asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 共&gt; <font color="red" style="font-weight: bold">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></font> &lt;页
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
