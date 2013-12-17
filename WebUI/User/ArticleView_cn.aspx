<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleView_cn.aspx.cs" Inherits="User_Article" %>

<%@ Register Src="UserFooter.ascx" TagName="UserFooter" TagPrefix="uc1" %>

<%@ Register src="UserTitle.ascx" tagname="UserTitle" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GB2312" />
    <title>�й������ѧ��Դ��������</title>
    <link rel="stylesheet" type="text/css" href="../CSS/DefaultSkin.css" />
</head>

<body id="Driving02">

    <form id="form1" runat="server">
    <uc2:usertitle ID="UserTitle1" runat="server" />
    <!--Middle-->
    <div class="D_Middle_Article1">
        <dl class="BG220">
            <div class="D_R210_2" style="border-bottom: solid 1px #dedede;">
                <dl>
                    <dt class="D_Red26"><a href="#" title="��������">��������</a></dt>
                    <dd class="D_ContentList">
                        <ul class="P">
                        </ul>
                        <ul class="L">
                            <asp:Repeater ID="Rpt_NewList" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <img src="../Images/Article_common2.gif">&nbsp;<a class="" href="ArticleView_cn.aspx?typeId=<%#((Model.Article)Container.DataItem).Typeid %>&articleId=<%#((Model.Article)Container.DataItem).Id %>&language=<%#((Model.Article)Container.DataItem).Language %>"
                                            target="_self"><%#((Model.Article)Container.DataItem).Title %></a></div>
                                </ItemTemplate>

                            </asp:Repeater>


                        </ul>
                    </dd>
                </dl>
            </div>
            <div class="D_L735">
                <dl class="Content_P5">
                    <dt class="ArticleTitle">
                        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></dt>
                    <dt class="ArticleInfo">
                        <asp:Label ID="lblAuthor" runat="server" Text=""></asp:Label></dt>

                    <dd class="ArticleContent">
                        <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt class="ArticleEditor">����¼�룺admin&nbsp;&nbsp;&nbsp;&nbsp;���α༭��admin&nbsp;</dt>
                   <%-- <dt class="PrevArticle">
                        <li>��һƪ���£� <a class='LinkPrevArticle' href='/Article/xzgd/201208/112.html' title='���±��⣺���Ի��ڡ������ձ���̸������ҵ��ĭ��
��&nbsp;&nbsp;&nbsp;&nbsp;�ߣ�admin
����ʱ�䣺2012-8-23 18:28:30'>���Ի��ڡ������ձ���̸������ҵ��ĭ��</a></li>
                        <br>
                        <li>��һƪ���£� û����</li>
                    </dt>--%>

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
