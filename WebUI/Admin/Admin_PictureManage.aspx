<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_PictureManage.aspx.cs" Inherits="Admin_Admin_ArticleAdd" ValidateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/Admin.css" />
    <link rel="stylesheet" type="text/css" href="css/public.css" />
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
    <div class="top " style="width: 800px">
        增加首页图片
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
            选择文件：
        </div>
        <div class="t2" style="text-align: left">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            附件大小不超5MB，支持类型 bmp，jpg，png，gif
        </div>
    </div>
    <div class="end " style="border: none;">
        <asp:Button ID="Button_sure" runat="server" Text="确认提交" OnClick="Button_sure_Click" OnClientClick="this.style.disabled=disabled"
            Width="90px" />
    </div>

    <div class="top ">
        图片管理
    </div>

    <div class="th">
        <div class="t_begin" style="width: 10%">
            序号
       
        </div>
        <div class="t_begin" style="width: 50%">
            图片标题
        </div>
        <div class="t_begin" style="width: 20%">
            浏览
        </div>
        <%--  <div class="t_begin" style="width: 20%">
            是否显示在首页
        </div>--%>
        <div class="t_end " style="width: 19%">
            删除
        </div>
    </div>

    <asp:Repeater ID="Rpt_Pic" runat="server" OnItemCommand="Rpt_Pic_ItemCommand">
        <ItemTemplate>
            <div class="tr">
                <div class="t_begin" style="width: 10%">
                    <%#Container.ItemIndex+1 %>
                </div>
                <div class="t_begin" style="width: 50%">
                    <%#((Model.Picture)Container.DataItem).Title %>
                </div>
                <div class="t_begin" style="width: 20%">
                    <a href="<%#((Model.Picture)Container.DataItem).FileURL %>" target="_blank">浏览</a>
                </div>
                <%--  <div class="t_begin" style="width: 20%">
                    <asp:CheckBox ID="cb" runat="server" AutoPostBack="true" />
                </div>--%>
                <div class="t_end " style="width: 19%">
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument="<%#((Model.Picture)Container.DataItem).Id %>" OnClientClick="return confirm('确认删除？')">删除</asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


    </form>
</body>
</html>
