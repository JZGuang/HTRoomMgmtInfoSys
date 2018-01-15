<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="addNewRoomType.aspx.cs" Inherits="HTRoomMgmtInfoSys.form.addNewRoomType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="CreateNewOrder" class="layui-form" style="width: 500px;margin: 0 auto;">
        <div style="width:200px;height:50px; margin:0 auto; text-align:center;">
            <h1>添加新房型</h1>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">名称</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Rtype" class="layui-input" placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">价格</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Rprice" class="layui-input" placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">容纳人数</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Rsize" class="layui-input" placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
		<div class="layui-form-item">
            <label class="layui-form-label">窗户</label>
            <div class="layui-input-block" >
                <input type="radio" ID="Tb_Window" name="Rwindow" value="有窗" title="有窗" checked>
                <input type="radio" ID="Tb_NoWindow" name="Rwindow" value="无窗" title="无窗" >
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">房间设施</label>
            <div class="layui-input-block" >
                <input type="checkbox" name="Rfacility" value="独卫" title="独卫">
                <input type="checkbox" name="Rfacility" value="空调" title="空调"> 
                <input type="checkbox" name="Rfacility" value="淋浴" title="淋浴"> 
                <input type="checkbox" name="Rfacility" value="浴缸" title="浴缸"> 
                <input type="checkbox" name="Rfacility" value="WIFI" title="WIFI" checked> 
                <input type="checkbox" name="Rfacility" value="电视" title="电视"> 
                <input type="checkbox" name="Rfacility" value="电脑" title="电脑">
                <input type="checkbox" name="Rfacility" value="厨房" title="厨房">
            </div>
        </div>
        <div class="layui-form-item">
            <div class="layui-input-block">
              <asp:Button ID="Btn_submit" class="layui-btn" runat="server" Text="立即添加" OnClick="Btn_submit_Click" />
              <button type="reset" class="layui-btn layui-btn-primary">重置</button>
            </div>
        </div>
    </div>
    <script>
        layui.use('form', function(){
          var form = layui.form;
          form.on('submit(formDemo)', function(data){
            layer.msg(JSON.stringify(data.field));
            return false;
          });
        });
    </script>

</asp:Content>
