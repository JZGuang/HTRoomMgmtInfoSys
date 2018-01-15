<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HTRoomMgmtInfoSys.form.login" %>

<!DOCTYPE html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/login.css" />
    <title>HTRoomMgmtInfoSys登录</title>
</head>
<body>
    <h1>HTRoomMgmtInfoSys</h1>
    <div class="container w3">
        <h2>现在登录</h2>
    <form id="form1" runat="server" defaultbutton="Btn_login">
        <div class="username">
				<span class="username" style="height:19px">用户:</span>
                <asp:TextBox ID="Tb_name" class="name" runat="server"></asp:TextBox>
				<div class="clear"></div>
			</div>
			<div class="password-agileits">
				<span class="username"style="height:19px">密码:</span>
                <asp:TextBox ID="Tb_PassWord" TextMode="Password" class="password"  runat="server"></asp:TextBox>
				<div class="clear"></div>
			</div>
            <div class="password-agileits">
				<span class="username"style="height:19px">验证码:</span>
                <asp:TextBox ID="Tb_Vcode" class="name" style="width:100px;" runat="server"></asp:TextBox>
                <asp:ImageButton ID="Img_Vcode" runat="server" title="点击更换" src="Vcode.aspx" Width="122px" height="40px" OnClick="Img_Vcode_Click"></asp:ImageButton>
				<div class="clear"></div>
			</div>
			<div class="rem-for-agile">
			<br />
				<a href="findpwd.aspx">忘记了密码</a><br />
			</div>
			<div class="login-w3">
                <asp:Button ID="Btn_login" class="login" runat="server" Text="Login" OnClick="Btn_login_Click" />
			</div>
			<div class="clear"></div>
    </form>
    </div>
	<div class="footer-w3l">
		<p>© HTRoomMgmtInfoSys Power By <a href="https:www.llanc.cn">llanc.cn</a></p>
	</div>
</body>
</html>
