<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="addNewRoom.aspx.cs" Inherits="HTRoomMgmtInfoSys.form.addNewRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="CreateNewOrder" class="layui-form" style="width: 300px;margin: 0 auto;">
        <div style="width:200px;height:50px; margin:0 auto;padding-left:110px;">
            <h1>添加新房间</h1>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">房间号</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Rnumber" class="layui-input" placeholder="必填,不可重复" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">房间类型</label>
            <div class="layui-input-block">
                <asp:DropDownList ID="DDL_Rtype" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">房间状态</label>
            <div class="layui-input-block">
		        <select ID="So_Rcondition" runat="server">
                    <option value=""></option>
			        <option value="空房，已打扫">空房，已打扫</option>
			        <option value="空房，未打扫">空房，未打扫</option>
		        </select>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">负责人</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Rprincipal" name="OstadyTime" class="layui-input" placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <div class="layui-input-block">
              <asp:Button ID="Btn_submit" class="layui-btn" runat="server" Text="完成" OnClick="Btn_submit_Click" />
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
