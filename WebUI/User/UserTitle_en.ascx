<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserTitle_en.ascx.cs" Inherits="User_UserTitle" %>
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
            result = 'Announcement';
        } else
            if (id == 2) {
                result = 'About';
            } else
                if (id == 3) {
                    result = 'People';
                } else
                    if (id == 4) {
                        result = 'Seminars';
                    } else
                        if (id == 5) {
                            result = 'Publications';
                        } else
                            if (id == 6) {
                                result = 'Download';
                            }
                            else
                                if (id == 7) {
                                    result = 'News Updates';
                                }
                                else
                                    if (id == 8) {
                                        result = 'Partners';
                                    }
                                    else
                                        if (id == 9) {
                                            result = 'Projects';
                                        }
                                        else
                                if (id == 99) {
                                    result = 'Contact'
                                }
                                else {
                                    result = 'RUCEE Home';
                                }
        return result;
    }

    window.onload = function () {
        var Request = new Object();
        Request = GetRequest();
        var typeid;
        typeid = Request['typeId'];

        var name = GetNameByTypeid(typeid);
        document.getElementById("location").innerHTML = "<a class='LinkPath' href='index_en.aspx'>RUCEE</a>&nbsp;>>&nbsp;" + name;

    }
</script>
<div class="D_top">
    <dl>
        <dt>
            <div class="D_Logo" title=""></div>
            <div class="clearbox"></div>
        </dt>

        <dt class="Channel">

            <ul >
                <li>
                    <a style="font-size:14px;" href="Index_en.aspx" title="RUCEE Home">RUCEE Home</a>
                </li>
                <li>
                    <a style="font-size:14px;" href="ArticleList_en.aspx?typeId=2&language=en" title="">About</a>
                </li>
                <li>
                    <a style="font-size:14px;" href="Person_en.aspx?typeId=3&language=en" title="">People</a>
                </li>
                <li>
                    <a style="font-size:14px;" href="SeminarsList_en.aspx?typeId=4&language=en" title="">Seminars</a>
                </li>
                <li>
                    <a style="font-size:14px;" href="ArticleList_en.aspx?typeId=5&language=en" title="">Publications</a>
                </li>
                <li>
                    <a style="font-size:14px;" href="FileList_en.aspx?typeId=6&language=en" title="">Download</a>
                </li>
                <li>
                    <a style="font-size:14px;" href="ContactUs_en.aspx?typeId=99&language=en" title="English">Contact</a>
                </li>
            </ul>
        </dt>
        <dt class="Path">
            <div style="float: right;">  
                 &nbsp;&nbsp;<asp:LinkButton ID="btnRegister" runat="server" OnClick="btnRegister_Click"  >Sign Up</asp:LinkButton>
                 &nbsp;&nbsp;<asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" >Login</asp:LinkButton>
                <asp:LinkButton ID="btnEnd" runat="server" Visible="false" OnClick="btnEnd_Click" OnClientClick="return confirm('确认退出？')"></asp:LinkButton>   &nbsp;&nbsp;<a href="index_cn.aspx">中文</a>&nbsp;&nbsp;<a href="index_en.aspx">English</a></div>
            <div class="Ann" style="width: 400px;">
              <%--  <div class="Con">
                    <marquee onmouseover="this.stop()" onmouseout="this.start()"
                        scrollamount="1" scrolldelay="4" width="100" align="left">
							&nbsp;&nbsp;&nbsp;&nbsp; <a class="AnnounceBody2" href="#"
								onclick="javascript:window.open('/Announce.asp?ChannelID=0&ID=1', 'newwindow', 'height=440, width=400, toolbar=no, menubar=no, scrollbars=auto, resizable=no, location=no, status=no')"
								title="">[Welcome]</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</marquee>
                </div>
                <strong>Welcome:</strong>--%>
            </div>
            Location：&nbsp;
					<span id="location"></span>
        </dt>
    </dl>
</div>
