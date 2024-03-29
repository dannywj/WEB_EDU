<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Person_cn.aspx.cs" Inherits="User_Article" %>

<%@ Register Src="UserFooter.ascx" TagName="UserFooter" TagPrefix="uc1" %>

<%@ Register Src="UserTitle.ascx" TagName="UserTitle" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GB2312" />
    <title>中心人员-中国人民大学能源经济中心</title>
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
            </div>
            <div class="D_L735">
                <dl class="Content_P5">
                    <dd class="ArticleContent">
                        <div style="width: 720px; margin: 0 auto; height: auto;">
                            <h3 style="color: #cc0000; margin-left: 20px; font-weight: bold">中心人员</h3>
                            <p><a href="PersonView_cn.aspx?personType=0&typeId=3&language=cn">全职人员</a>  </p>  <%-- 0--%>
                            <p><a href="PersonView_cn.aspx?personType=1&typeId=3&language=cn">兼职人员</a></p>      <%--1--%>
                            <p><a href="Committee_cn.aspx?typeId=3&language=cn">顾问委员会</a></p>
                        </div>
                    </dd>
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
