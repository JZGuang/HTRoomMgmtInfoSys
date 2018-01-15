<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="findPassWord.aspx.cs" Inherits="HTRoomMgmtInfoSys.form.findPassWord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:200px;height:50px; margin:0 auto; text-align:center;">
            <h1>找回密码</h1>
    </div>
    <div class="layui-row layui-col-space10">
      <div class="layui-col-md4">
   
      </div>
      <div class="layui-col-md4">
          
          <asp:TextBox ID="Tb_find" CssClass='layui-input' runat="server"></asp:TextBox><br />
          <div style="text-align:center;">
            <asp:Button ID="Btn_Send" runat="server" CssClass="layui-btn  layui-btn-radius" Text="发送" OnClick="Btn_Send_Click" />
            <asp:Button ID="Btn_V" runat="server" CssClass="layui-btn  layui-btn-radius" Text="验证" OnClick="Btn_V_Click" />
          </div>
      </div>
      <div class="layui-col-md4">
   
      </div>
    </div>
</asp:Content>
