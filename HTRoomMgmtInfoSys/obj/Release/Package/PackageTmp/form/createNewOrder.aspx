<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="createNewOrder.aspx.cs" Inherits="HTRoomMgmtInfoSys.form.createNewOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="CreateNewOrder" class="layui-form" style="width: 500px;margin: 0 auto;">
        <div style="width:200px;height:50px; margin:0 auto; text-align:center;">
            <h1>创建新订单</h1>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">房间号</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Oroom" class="layui-input" name="Oroom"  placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">入住人数</label>
            <div class="layui-input-block">
		        <select ID="So_Opeople" runat="server">
                    <option value=""></option>
			        <option value="1">1</option>
			        <option value="2">2</option>
			        <option value="3">3</option>
		        </select>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">入住天数</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Days" class="layui-input" name="Odays" placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">身份证号</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_CidNumber" class="layui-input" name="CidNumber" placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">姓名</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Cname" class="layui-input" name="Cname" placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
		<div class="layui-form-item">
            <label class="layui-form-label">性别</label>
            <div class="layui-input-block" >
                <input type="radio" ID="Tb_Csex_M" name="Csex" value="男" title="男">
                <input type="radio" ID="Tb_Csex_W" name="Csex" value="女" title="女" checked>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">电话</label>
            <div class="layui-input-block">
                <asp:TextBox ID="Tb_Cphone" class="layui-input" name="Cphone" placeholder="必填" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">入住日期</label>
            <div class="layui-input-inline">
                <asp:TextBox ID="Tb_OstadyTime" name="OstadyTime" class="layui-input" placeholder="请点击" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
		    <label class="layui-form-label">订单状态</label>
            <div class="layui-input-block">
		        <select ID="So_Ocondition" runat="server">
                    <option value=""></option>
			        <option value="已入住">已入住</option>
			        <option value="待入住">待入住</option>
		        </select>
            </div>
        </div>
        <div class="layui-form-item">
            <div class="layui-input-block">
              <asp:Button ID="Btn_submit" class="layui-btn" runat="server" Text="立即提交" OnClick="Btn_submit_Click" />
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

        layui.use('laydate', function () {
            var laydate = layui.laydate;
            laydate.render({
                elem: '#ContentPlaceHolder1_Tb_OstadyTime'
            , type: 'datetime'
            });
        });
    </script>
</asp:Content>
