<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index_cn.aspx.cs" Inherits="User_Index" %>

<%@ Register Src="UserTitle.ascx" TagName="UserTitle" TagPrefix="uc1" %>
<%@ Register Src="UserFooter.ascx" TagName="UserFooter" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=GB2312" />
    <title>中国人民大学能源经济中心</title>
    <link rel="stylesheet" type="text/css" href="../CSS/DefaultSkin.css" />

</head>
<body id="Driving02">
    <form id="form1" runat="server">
    <!--Top-->
    <uc1:UserTitle ID="UserTitle1" runat="server" />

    <!-- 滚动图片栏-->
    <div id="demo" class="D_Middle" style="height: 200px; border: solid 1px #dedede; margin-top: 4px;">

        <div>
            <div id="indemo">
                <div id="demo1">
                    <asp:Repeater ID="Rpt_PictureList" runat="server">
                        <ItemTemplate>
                            <a href="#">
                                <img src="<%#((Model.Picture)Container.DataItem).FileURL %>" border="0" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="demo2"></div>
            </div>
        </div>
        <script type="text/javascript">

            var speed = 30;
            var tab = document.getElementById("demo");
            var tab1 = document.getElementById("demo1");
            var tab2 = document.getElementById("demo2");
            tab2.innerHTML = tab1.innerHTML;
            function Marquee() {
                if (tab2.offsetWidth - tab.scrollLeft <= 0)
                    tab.scrollLeft -= tab1.offsetWidth
                else {
                    tab.scrollLeft++;
                }
            }
            var MyMar = setInterval(Marquee, speed);
            tab.onmouseover = function () { clearInterval(MyMar) };
            tab.onmouseout = function () { MyMar = setInterval(Marquee, speed) };

        </script>
    </div>

    <!--Middle-->
    <div class="D_Middle_Article2" style="margin-top: 2px;">
        <dl class="BG300">
            <div class="D_R650">

                <div class="D_Loop320">
                    <dl>
                        <dt>
                            <a href="ArticleList_cn.aspx?typeId=7&language=cn" title='0'>中心动态</a>
                        </dt>
                        <dd>
                            <div class="RightCon">
                                <asp:Repeater ID="Rpt_gaikuang" runat="server">
                                    <ItemTemplate>
                                        <div class="art_line">
                                            <img src="../Images/Article_common2.gif">
                                            &nbsp; 
										<a href="ArticleView_cn.aspx?typeId=<%#((Model.Article)Container.DataItem).Typeid %>&articleId=<%#((Model.Article)Container.DataItem).Id %>&language=<%#((Model.Article)Container.DataItem).Language %>"
                                            title="<%#((Model.Article)Container.DataItem).Title %>" target="_self"><%#((Model.Article)Container.DataItem).Title.Length>40?((Model.Article)Container.DataItem).Title.Substring(0,39)+"..":((Model.Article)Container.DataItem).Title %></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="art_more">
                                    <a href="ArticleList_cn.aspx?typeId=2&language=cn">more>>
                                    </a>
                                </div>



                            </div>
                            <div class="clearbox"></div>
                        </dd>
                    </dl>
                </div>
                <div class="D_Loop320">
                    <dl>
                        <dt>
                            <a href='SeminarsList_cn.aspx?typeId=4&language=cn'>学术讲座</a>
                        </dt>
                        <dd>
                            <div class="RightCon">
                                <asp:Repeater ID="Rpt_jiangzuo" runat="server">
                                    <ItemTemplate>
                                        <div class="">
                                            <img src="../Images/Article_common2.gif">
                                            &nbsp; 
                                            <%#((Model.Article)Container.DataItem).Title %>: <a title="<%#((Model.Article)Container.DataItem).Content %>" href="<%#((Model.Article)Container.DataItem).FileURL %>" target="_blank">
                                                <%#((Model.Article)Container.DataItem).Content.Length>50?((Model.Article)Container.DataItem).Content.Substring(0,49)+"..":((Model.Article)Container.DataItem).Content %>     </a>

									
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="art_more">
                                    <a href="SeminarsList_cn.aspx?typeId=4&language=cn">more>>
                                    </a>
                                </div>

                            </div>
                            <div class="clearbox"></div>
                        </dd>
                    </dl>
                </div>
                <div class="D_Loop320">
                    <dl>
                        <dt>
                            <a href='ArticleList_cn.aspx?typeId=5&language=cn'>研究成果</a>
                        </dt>
                        <dd>
                            <div class="RightCon">
                                <asp:Repeater ID="Rpt_chengguo" runat="server">
                                    <ItemTemplate>
                                        <div class="">
                                            <img src="../Images/Article_common2.gif">
                                            &nbsp; 
										<a href="ArticleView_cn.aspx?typeId=<%#((Model.Article)Container.DataItem).Typeid %>&articleId=<%#((Model.Article)Container.DataItem).Id %>&language=<%#((Model.Article)Container.DataItem).Language %>"
                                            title="<%#((Model.Article)Container.DataItem).Title %>" target="_self"><%#((Model.Article)Container.DataItem).Title.Length>40?((Model.Article)Container.DataItem).Title.Substring(0,39)+"..":((Model.Article)Container.DataItem).Title %></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="art_more">
                                    <a href="ArticleList_cn.aspx?typeId=5&language=cn">more>>
                                    </a>
                                </div>
                            </div>
                            <div class="clearbox"></div>
                        </dd>
                    </dl>
                </div>
                <div class="D_Loop320">
                    <dl>
                        <dt>
                            <a href='ArticleList_cn.aspx?typeId=9&language=cn'>科研项目</a>
                        </dt>
                        <dd>
                            <div class="RightCon">
                                <asp:Repeater ID="Rpt_down" runat="server">
                                    <ItemTemplate>
                                        <div class="">
                                            <img src="../Images/Article_common2.gif">
                                            &nbsp; 
										<a href="ArticleList_cn.aspx?typeId=<%#((Model.Article)Container.DataItem).Typeid %>&articleId=<%#((Model.Article)Container.DataItem).Id %>&language=<%#((Model.Article)Container.DataItem).Language %>"
                                            title="<%#((Model.Article)Container.DataItem).Title %>" target="_self"><%#((Model.Article)Container.DataItem).Title.Length>40?((Model.Article)Container.DataItem).Title.Substring(0,39)+"..":((Model.Article)Container.DataItem).Title %></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="art_more">
                                    <a href="ArticleList_cn.aspx?typeId=9&language=cn">more>>
                                    </a>
                                </div>
                            </div>
                            <div class="clearbox"></div>
                        </dd>
                    </dl>
                </div>
            </div>
            <div style="float: left; width: 300px;">
                <div style="height: 5px; font-size: 0; background: #fff;"></div>
                <div class="D_L300">
                    <dl>
                        <dt class="D_Red26">
                            <a href="ArticleList_cn.aspx?typeId=1&language=cn" title="">通知公告</a>
                        </dt>
                        <dd class="D_ContentList">
                            <ul class="P">
                            </ul>
                            <ul class="L">


                                <asp:Repeater ID="Rpt_gonggao" runat="server">
                                    <ItemTemplate>
                                        <div>
                                            <img src="../Images/Article_common2.gif">
                                            &nbsp; 
										<a href="ArticleView_cn.aspx?typeId=<%#((Model.Article)Container.DataItem).Typeid %>&articleId=<%#((Model.Article)Container.DataItem).Id %>&language=<%#((Model.Article)Container.DataItem).Language %>"
                                            title="<%#((Model.Article)Container.DataItem).Title %>"
                                            target="_self"><%#((Model.Article)Container.DataItem).Title %> </a>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="art_more">
                                    <a href="ArticleList_cn.aspx?typeId=1&language=cn">more>>
                                    </a>
                                </div>


                            </ul>
                        </dd>
                        <dt class="D_Red26">
                            <a href="javascript:void(0)" title="">合作机构</a>
                        </dt>
                        <dd class="D_ContentList">
                            <ul class="P">

                                <asp:Repeater ID="Rpt_renyuan" runat="server">
                                    <ItemTemplate>
                                        <div style="border-bottom: 1px dashed #CCCCCC; text-align: left">
                                            <img src="../Images/Article_common2.gif">
                                            &nbsp; 
									<%--	<a href="ArticleView_cn.aspx?typeId=<%#((Model.Article)Container.DataItem).Typeid %>&articleId=<%#((Model.Article)Container.DataItem).Id %>&language=<%#((Model.Article)Container.DataItem).Language %>"
                                            title="<%#((Model.Article)Container.DataItem).Title %>"
                                            target="_self"><%#((Model.Article)Container.DataItem).Title %> </a>
                                    --%>
                                            <a href="<%#((Model.Article)Container.DataItem).Content %>" target="_blank"><%#((Model.Article)Container.DataItem).Title %>   </a>


                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>

                                <div class="art_more">
                                    <a href="LinkList_cn.aspx?typeId=8&language=cn">more>>
                                    </a>
                                </div>

                            </ul>
                            <ul class="L">
                            </ul>
                        </dd>

                    </dl>
                </div>
            </div>
            <div class="clearbox"></div>
        </dl>
    </div>
    <!--Banner2-->

    <uc2:UserFooter ID="UserFooter1" runat="server" />

    </form>

</body>
</html>
