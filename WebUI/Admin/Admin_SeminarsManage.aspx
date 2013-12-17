<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_SeminarsManage.aspx.cs" Inherits="Admin_Admin_UserManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理</title>

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
        学术讲座管理
    </div>
    <div class="tr" style="margin-top: 4px; text-align: left; border-top: solid 1px #dedede">
        
        &nbsp;  &nbsp; 语言：

                   <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
                       <asp:ListItem Text="中文" Value="cn" Selected="True"></asp:ListItem>
                       <asp:ListItem Text="英文" Value="en"></asp:ListItem>
                   </asp:DropDownList>


    </div>
    <div class="th">
        <div class="t_begin" style="width: 4%">
            序号
       
        </div>
        <div class="t_begin" style="width: 25%">
            讲座名称
       
        </div>
        <div class="t_begin" style="width: 20%">
            地址
       
        </div>
        <div class="t_begin" style="width: 15%">
            添加时间
       
        </div>

        <div class="t_begin" style="width: 15%">
            更新时间
       
        </div>
        <div class="t_begin" style="width: 10%">
            修改
       
        </div>
        <div class="t_end " style="width: 10%">
            删除
       
        </div>
    </div>


    <asp:Repeater ID="Rpt_Article" runat="server" OnItemCommand="Rpt_Article_ItemCommand">
        <ItemTemplate>
            <div class="tr">
                <div class="t_begin" style="width: 4%">
                    <%#Container.ItemIndex+1 %>
                </div>
                <div class="t_begin" style="width: 25%">
               <%#((Model.Article)Container.DataItem).Title %>：<%#((Model.Article)Container.DataItem).Content.Length>10?((Model.Article)Container.DataItem).Content.Substring(0,9)+"..":((Model.Article)Container.DataItem).Content %>
                </div>
                <div class="t_begin" style="width: 20%">
                    <%#((Model.Article)Container.DataItem).Content.Length > 15 ? ((Model.Article)Container.DataItem).Content.Substring(0, 14) +"..": ((Model.Article)Container.DataItem).Content%>
                    <a href="<%#((Model.Article)Container.DataItem).FileURL %>" target="_blank">查看</a>
                </div>
                <div class="t_begin" style="width: 15%">
                    <%#((Model.Article)Container.DataItem).AddDate %>
                </div>

                <div class="t_begin" style="width: 15%">
                    <%#((Model.Article)Container.DataItem).UpdateDate %>
                </div>
                <div class="t_begin" style="width: 10%">
                    <a href="Admin_SeminarsUpdate.aspx?articleId=<%#((Model.Article)Container.DataItem).Id %>&lang=<%#((Model.Article)Container.DataItem).Language %>">修改</a>
                </div>
                <div class="t_end " style="width: 10%">
                    <asp:LinkButton ID="LinkButton_del" runat="server" CommandName="del" CommandArgument=" <%#((Model.Article)Container.DataItem).Id %>" OnClientClick="return confirm('确认删除？')">删除</asp:LinkButton>
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
