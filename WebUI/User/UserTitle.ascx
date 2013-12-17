<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserTitle.ascx.cs" Inherits="User_UserTitle" %>
<script>

    function GetRequest() {
        var url = location.search; //获取url中"?"符后的字串   
        var theRequest = new Object();
        if (url.indexOf("?") != -1) {
            var str = url.substr(1);
            strs = str.split("&");
            for (var i = 0; i < strs.length; i++) {
                theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
            }
        }
        return theRequest;
    }
    //--通知公告 1
    //--中心概况 2
    //--中心人员 3
    //--学术讲座 4
    //--研究成果 5
    //--资源下载 6

    //--中心动态 7
    //--合作机构 8
    //--科研项目 9

    function GetNameByTypeid(id) {
        var result = '';
        if (id == 1) {
            result = '通知公告';
        } else
            if (id == 2) {
                result = '中心概况';
            } else
                if (id == 3) {
                    result = '中心人员';
                } else
                    if (id == 4) {
                        result = '学术讲座';
                    } else
                        if (id == 5) {
                            result = '研究成果';
                        } else
                            if (id == 6) {
                                result = '资源下载';
                            }
                            else
                                if (id == 7) {
                                    result = '中心动态';
                                }
                                else
                                    if (id == 8) {
                                        result = '合作机构';
                                    }
                                    else
                                        if (id == 9) {
                                            result = '科研项目';
                                        }
                                        else
                                if (id == 99) {
                                    result = '联系我们'
                                }
                                else {
                                    result = '首页';
                                }
        return result;
    }

    window.onload = function () {
        var Request = new Object();
        Request = GetRequest();
        var typeid;
        typeid = Request['typeId'];

        var name = GetNameByTypeid(typeid);
        document.getElementById("location").innerHTML = "<a class='LinkPath' href='index_cn.aspx'>能源经济中心</a>&nbsp;>>&nbsp;" + name;

    }
</script>
<div class="D_top">
    <dl>
        <dt>
            <div class="D_Logo" title=""></div>
            <div class="clearbox"></div>
        </dt>

        <dt class="Channel">

            <ul>
                <li>
                    <a href="Index_cn.aspx" title="中心首页">中心首页</a>
                </li>
                <li>
                    <a href="ArticleList_cn.aspx?typeId=2&language=cn" title="">中心概况</a>
                </li>
                <li>
                    <a href="Person_cn.aspx?typeId=3&language=cn" title="">中心人员</a>
                </li>
                <li>
                    <a href="SeminarsList_cn.aspx?typeId=4&language=cn" title="">学术讲座</a>
                </li>
                <li>
                    <a href="ArticleList_cn.aspx?typeId=5&language=cn" title="">研究成果</a>
                </li>
                <li>
                    <a href="FileList_cn.aspx?typeId=6&language=cn" title="">资源下载</a>
                </li>
                <li>
                    <a href="ContactUs_cn.aspx?typeId=99&language=cn" title="English">联系我们</a>
                </li>
            </ul>
        </dt>
        <dt class="Path">
            <div style="float: right;">  
                 &nbsp;&nbsp;<asp:LinkButton ID="btnRegister" runat="server" OnClick="btnRegister_Click"  >注册</asp:LinkButton>
                 &nbsp;&nbsp;<asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" >登录</asp:LinkButton>
                <asp:LinkButton ID="btnEnd" runat="server" Visible="false" OnClick="btnEnd_Click" OnClientClick="return confirm('确认退出？')"></asp:LinkButton>   &nbsp;&nbsp;<a href="index_cn.aspx">中文</a>&nbsp;&nbsp;<a href="index_en.aspx">English</a></div>
            <div class="Ann" style="width: 400px;">
               <%-- <div class="Con">
                    <marquee onmouseover="this.stop()" onmouseout="this.start()"
                        scrollamount="1" scrolldelay="4" width="100" align="left">
							&nbsp;&nbsp;&nbsp;&nbsp; <a class="AnnounceBody2" href="#"
								onclick="javascript:window.open('/Announce.asp?ChannelID=0&ID=1', 'newwindow', 'height=440, width=400, toolbar=no, menubar=no, scrollbars=auto, resizable=no, location=no, status=no')"
								title="">[欢迎使用人民大学网站测试版]</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</marquee>
                </div>
                <strong>欢迎使用：</strong>--%>
            </div>
            您现在的位置：&nbsp;
					<span id="location"></span>
        </dt>
    </dl>
</div>
