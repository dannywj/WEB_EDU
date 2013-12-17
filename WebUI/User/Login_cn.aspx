<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login_cn.aspx.cs" Inherits="User_Signup_cn" %>

<%@ Register Src="UserTitle.ascx" TagName="UserTitle" TagPrefix="uc1" %>
<%@ Register Src="UserFooter.ascx" TagName="UserFooter" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录-中国人民大学能源经济中心</title>
    <link rel="stylesheet" type="text/css" href="../CSS/DefaultSkin.css" />
    <script>
        function isEmail(str) {
            var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
            return reg.test(str);
        }

        function check() {
            var name = document.getElementById('txtEmail');
            var pwd = document.getElementById('txtPwd');
           
            var errorMsg = document.getElementById('errorMsg');
            if (name.value == '' || pwd.value == '' ) {
                errorMsg.innerHTML = "请输入Email和密码！";
                return false;
            }
            if (!isEmail(name.value)) {
                errorMsg.innerHTML = "请输入正确的Email地址！";
                return false;
            }
           
            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

    <uc1:UserTitle ID="UserTitle1" runat="server" />
    <div style="border: solid 1px #dedede;">
        <p style="color: #CC0000; font-size: 16px; font-weight: bold; margin-left: 50px;">用户登录</p>
        <table cellpadding="0" cellspacing="0" border="0" style="margin: 0 auto; padding-bottom:50px;">
             <tr style="height: 40px;">
                <td></td>
                <td style="color:red;">
                    <span id="errorMsg" ></span>
                    <asp:Label ID="errorMsgServer" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr style="height: 40px;">
                <td class="loginLeft"><span class="loginMast">*</span>Email地址：</td>
                <td>
                   <asp:TextBox ID="txtEmail" runat="server" CssClass="loginTxt"></asp:TextBox>
                </td>

            </tr>
            <tr style="height: 40px;">
                <td class="loginLeft"><span class="loginMast">*</span>登录密码：</td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="loginTxt"></asp:TextBox>
                </td>

            </tr>
            
            <tr style="height: 40px;">
                <td></td>
                <td></td>
            </tr>
            <tr style="height: 40px;">
                <td></td>
                <td><asp:Button ID="Button1" runat="server" Text="登 录" CssClass="loginBtn" OnClientClick="return check()" OnClick="Button1_Click" /></td>
                
            </tr>
        </table>

    </div>
    <uc2:UserFooter ID="UserFooter1" runat="server" />
    </form>
</body>
</html>
