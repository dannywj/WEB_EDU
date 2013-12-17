<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup_en.aspx.cs" Inherits="User_Signup_cn" %>

<%@ Register Src="UserTitle_en.ascx" TagName="UserTitle" TagPrefix="uc1" %>
<%@ Register Src="UserFooter_en.ascx" TagName="UserFooter" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp-RUCEE</title>
    <link rel="stylesheet" type="text/css" href="../CSS/DefaultSkin.css" />
    <script type="text/javascript">
        
        function isEmail(str) {
            var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
            return reg.test(str);
        }

        function check() {
            var name = document.getElementById('txtEmail');
            var pwd = document.getElementById('txtPwd');
            var pwd2 = document.getElementById('txtPwd2');
            var errorMsg = document.getElementById('errorMsg');
            if (name.value == '' || pwd.value == '' || pwd2.value == '') {
                errorMsg.innerHTML = "please input email and password！";
                return false;
            }
            if (!isEmail(name.value)) {
                errorMsg.innerHTML = "please input valid Email！";
                return false;
            }
            if (pwd.value != pwd2.value) {
                errorMsg.innerHTML = "please check your password！";
                pwd.value = '';
                pwd2.value = '';
                return false;
            }
            if (pwd.value.length<6) {
                errorMsg.innerHTML = "please input more then 6 password！";
                pwd.value = '';
                pwd2.value = '';
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
        <p style="color: #CC0000; font-size: 16px; font-weight: bold; margin-left: 50px;">User Signup</p>
        <table cellpadding="0" cellspacing="0" border="0" style="margin: 0 auto; padding-bottom: 50px;">
            <tr style="height: 40px;">
                <td></td>
                <td style="color: red;">
                    <asp:Label ID="errorMsgServer" runat="server" Text=""></asp:Label>
                    <span id="errorMsg"></span>
                </td>

            </tr>
            <tr style="height: 40px;">
                <td class="loginLeft"><span class="loginMast">*</span>Email Address：</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="loginTxt"></asp:TextBox>
                </td>

            </tr>
            <tr style="height: 40px;">
                <td class="loginLeft"><span class="loginMast">*</span>Password：</td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="loginTxt"></asp:TextBox>
                </td>

            </tr>
            <tr style="height: 40px;">
                <td class="loginLeft"><span class="loginMast">*</span>Check Password：</td>
                <td>
                    <asp:TextBox ID="txtPwd2" runat="server" TextMode="Password" CssClass="loginTxt"></asp:TextBox>
                </td>

            </tr>
            <tr style="height: 40px;">
                <td class="loginLeft">Real Name：</td>
                <td>
                    <asp:TextBox ID="txtTrueName" runat="server" CssClass="loginTxt"></asp:TextBox>
            </tr>
            <tr style="height: 40px;">
                <td class="loginLeft">School：</td>
                <td>
                    <asp:TextBox ID="txtSchool" runat="server" CssClass="loginTxt"></asp:TextBox>
            </tr>
            <tr style="height: 40px;">
                <td class="loginLeft">Interest：</td>
                <td>
                    <asp:TextBox ID="txtInterest" runat="server" CssClass="loginTxt"></asp:TextBox>
            </tr>
            <tr style="height: 40px;">
                <td></td>
                <td></td>
            </tr>
            <tr style="height: 40px;">
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="loginBtn" OnClick="Button1_Click" OnClientClick="return check();" /></td>

            </tr>
        </table>

    </div>
    <uc2:UserFooter ID="UserFooter1" runat="server" />
    </form>
</body>
</html>
