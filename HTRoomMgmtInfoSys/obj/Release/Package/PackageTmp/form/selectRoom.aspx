<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="selectRoom.aspx.cs" EnableEventValidation="false" Inherits="HTRoomMgmtInfoSys.form.selectRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:800px;height:50px;margin:0 auto;text-align:center;">
        房型：<asp:TextBox ID="Tb_type" runat="server"></asp:TextBox>&nbsp;
        价格： <asp:TextBox ID="Tb_price" runat="server"></asp:TextBox>
        <asp:Button ID="Btn_seach" CssClass="layui-btn layui-btn-sm layui-btn-radius" runat="server" Text="搜索" OnClick="Btn_seach_Click" />

    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1080px" Height="400px" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="6" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:BoundField DataField="Rnumber" HeaderText="房间号" ReadOnly="True">
            <ControlStyle Height="25px" Width="70px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="Rtype" HeaderText="房间类型" ReadOnly="True">
            <ControlStyle Height="25px" Width="70px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="Rprice" HeaderText="价格" ReadOnly="True">
            <ControlStyle Height="25px" Width="70px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="Rsize" HeaderText="人数" ReadOnly="True">
            <ControlStyle Height="25px" Width="40px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="Rwindow" HeaderText="窗户" ReadOnly="True">
            <ControlStyle Height="25px" Width="70px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="Rfacility" HeaderText="设施" ReadOnly="True">
            <ControlStyle Height="25px" Width="200px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="Rcondition" HeaderText="房间状态">
            <ControlStyle Height="25px" Width="70px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Rprincipal" HeaderText="负责人">
            <ControlStyle Height="25px" Width="70px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="信息更新" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass='layui-btn layui-btn-normal layui-btn-xs' CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CssClass='layui-btn  layui-btn-danger layui-btn-xs' CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass='layui-btn layui-btn-xs' CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                </ItemTemplate>
                <ControlStyle Width="70px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <PagerTemplate>  
            <div style="text-align: center; color: #0094ff">  
            <asp:LinkButton ID="cmdFirstPage" runat="server" CommandName="Page" CommandArgument="First" Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex!=0 %>">首页</asp:LinkButton>  
            <asp:LinkButton ID="cmdPreview" runat="server" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex!=0 %>">前页</asp:LinkButton>  
            第<asp:Label ID="lblcurPage" ForeColor="Blue" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex+1  %>'></asp:Label>页/共  
            <asp:Label ID="lblPageCount" ForeColor="blue" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>'></asp:Label>页  
            <asp:LinkButton ID="cmdNext" runat="server" CommandName="Page" CommandArgument="Next" Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 %>">后页</asp:LinkButton>  
            <asp:LinkButton ID="cmdLastPage" runat="server"  CommandArgument="Last" CommandName="Page" Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 %>">尾页</asp:LinkButton>  
            <%--<asp:TextBox ID="txtGoPage" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex+1 %>' Width="32px"></asp:TextBox>页  
            <asp: Button ID="btn_jump" CssClass='button' class="button" runat="server" OnClick="Turn_Click" Text="转到" />--%></div>  
        </PagerTemplate>
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    <br />
    <asp:Button ID="Btn_ToExcel" runat="server" CssClass='layui-btn' Text="导出到Excel" OnClick="Btn_ToExcel_Click" />
</asp:Content>
