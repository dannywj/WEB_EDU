<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkList_cn.aspx.cs" Inherits="User_Article" %>

<%@ Register Src="UserFooter.ascx" TagName="UserFooter" TagPrefix="uc1" %>

<%@ Register Src="UserTitle.ascx" TagName="UserTitle" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GB2312" />
    <title>合作机构-中国人民大学能源经济中心</title>
    <link rel="stylesheet" type="text/css" href="../CSS/DefaultSkin.css" />
</head>

<body id="Driving02">
    <form id="form1" runat="server">
    <uc2:UserTitle ID="UserTitle1" runat="server" />
    <!--Middle-->
    <div class="D_Middle_Article1">
        <dl class="BG220">
            <div class="D_R210_2" style="border-bottom: solid 1px #dedede;">
                <dl>
                    <dt class="D_Red26"><a href="#" title="最新内容">最新内容</a></dt>
                    <dd class="D_ContentList">
                        <ul class="P">
                        </ul>
                        <ul class="L">
                            <asp:Repeater ID="Rpt_NewList" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <img src="../Images/Article_common2.gif">&nbsp;<a class="" href="ArticleView_cn.aspx?typeId=<%#((Model.Article)Container.DataItem).Typeid %>&articleId=<%#((Model.Article)Container.DataItem).Id %>&language=<%#((Model.Article)Container.DataItem).Language %>"
                                            target="_self"><%#((Model.Article)Container.DataItem).Title %></a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <dl>
                </dl>
            </div>
            <div class="D_L735">
                <dl class="Content_P5">
                    <dt class="ArticleTitle">
                        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></dt>
                   <p style="color:#cc0000; font-weight:bold; margin-left:10px;">合作机构</p> 
                    <dd class="ArticleContent">
                        <asp:Repeater ID="Rpt_list" runat="server">
                            <ItemTemplate>
                                  <p>
                            <img src="../Images/Article_common2.gif"><a href="<%#((Model.Article)Container.DataItem).Content %>"
                                 target="_blank"><%#((Model.Article)Container.DataItem).Title %></a> </p>

                            </ItemTemplate>

                        </asp:Repeater>



                    </dd>
                  
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
                </dl>
            </div>
            <div class="clearbox"></div>
        </dl>
    </div>
    <!--Banner2-->

    <uc1:UserFooter ID="UserFooter1" runat="server" />

    </form>

</body>
</html>
