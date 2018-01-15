<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findpwd.aspx.cs" Inherits="HTRoomMgmtInfoSys.form.findpwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/layui/css/layui.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="layui-row layui-col-space10">
          <div class="layui-col-md4"></div>
          <div class="layui-col-md4" style="text-align:center;">
              <h1>找回密码</h1>
              <br />
                <label class="layui-form-label">手机号：</label>
                <div class="layui-input-block">
                <asp:TextBox ID="Tb_name" class='layui-input' runat="server"></asp:TextBox>
                </div>
                <br />
                <label class="layui-form-label">验证码：</label>
                <div class="layui-input-block">
                <asp:TextBox ID="Tb_v" class='layui-input' runat="server"></asp:TextBox>
                </div>
                <br />
                <asp:Button ID="Btn_find" class='layui-btn layui-btn-lg layui-btn-radius layui-btn-normal' runat="server" Text="验证" OnClick="Btn_find_Click" />
          </div>
          <div class="layui-col-md4"></div>
        </div>
    </form>
</body>
</html>
