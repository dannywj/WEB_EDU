<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonView_en.aspx.cs" Inherits="User_Article" %>

<%@ Register Src="UserFooter_en.ascx" TagName="UserFooter" TagPrefix="uc1" %>

<%@ Register Src="UserTitle_en.ascx" TagName="UserTitle" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GB2312" />
    <title>People-RUCEE</title>
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
                    <dt class="D_Red26"><a href="#" title="最新内容">News</a></dt>
                    <dd class="D_ContentList">
                        <ul class="P">
                        </ul>
                        <ul class="L">
                            <asp:Repeater ID="Rpt_NewList" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <img src="../Images/Article_common2.gif">&nbsp;<a class="" href="ArticleView_en.aspx?typeId=<%#((Model.Article)Container.DataItem).Typeid %>&articleId=<%#((Model.Article)Container.DataItem).Id %>&language=<%#((Model.Article)Container.DataItem).Language %>"
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
                        <div style="width: 720px; margin: 0 auto; height: 830px;">
                            <%--图片展示框--%>
                            <asp:Repeater ID="Rpt_person" runat="server">
                                <ItemTemplate>
                                    <div class="itemK">
                                        <div class="itemKL">
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td class="itName">Name: </td>
                                                     <td class="itValue">&nbsp;&nbsp;  <a target="_blank" href="<%#((Model.Person)Container.DataItem).TeacherURL %>"><%#((Model.Person)Container.DataItem).Pname %></a> </td>
                                                </tr>
                                                <tr>
                                                    <td class="itName">Title: </td>
                                                    <td class="itValue">&nbsp;&nbsp;<%#((Model.Person)Container.DataItem).Zhicheng %></td>
                                                </tr>
                                              <%--  <tr>
                                                    <td class="itName">Type: </td>
                                                    <td class="itValue">&nbsp;&nbsp;<%#((Model.Person)Container.DataItem).Type %></td>
                                                </tr>--%>
                                                <tr>
                                                    <td class="itName">Phone: </td>
                                                    <td class="itValue">&nbsp;&nbsp;<%#((Model.Person)Container.DataItem).Phone %></td>
                                                </tr>
                                                <tr>
                                                    <td class="itName">E-mail: </td>
                                                    <td class="itValue">&nbsp;&nbsp;<%#((Model.Person)Container.DataItem).Email %></td>
                                                </tr>
                                                <tr>
                                                    <td class="itName">Research Field: </td>
                                                    <td class="itValue">&nbsp;&nbsp;<%#((Model.Person)Container.DataItem).Lingyu %></td>
                                                </tr>
                                            </table>

                                        </div>
                                        <div class="itemKR">
                                             <a style="color:#ccc" target="_blank" href="<%#((Model.Person)Container.DataItem).TeacherURL %>"> 
                                            <img src="<%#((Model.Person)Container.DataItem).FileURL %>" width="110px" height="155px"  /></a>
                                        </div>
                                    </div>

                                </ItemTemplate>

                            </asp:Repeater>




                            <table cellpadding="0" cellspacing="0" border="0" width="90%" style="margin: 0 auto; display:inline-block;">
                                <tr>
                                    <td style="text-align: center; font-size: 14px; height: 40px; line-height: 40px;">The&gt; <font color="red" style="font-weight: bold">
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></font>&lt;Page &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                <asp:HyperLink ID="HyperLink1" runat="server"><span class="kuang">Previous</span></asp:HyperLink>&nbsp;&nbsp;
               
                <asp:HyperLink ID="HyperLink2" runat="server"><span  class="kuang">Next</span></asp:HyperLink>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total&gt; <font color="red" style="font-weight: bold">
                                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></font> &lt;Page
                                    </td>
                                </tr>
                            </table>
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
