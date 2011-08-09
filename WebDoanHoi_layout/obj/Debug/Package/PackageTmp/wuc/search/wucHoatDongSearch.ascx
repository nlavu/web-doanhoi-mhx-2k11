<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucHoatDongSearch.ascx.cs" Inherits="WebDoanHoi_layout.wuc.search.wucHoatDongSearch" %>
<p>
    Tên họat động&nbsp;
</p>
<p>
    &nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Width="305px"></asp:TextBox>
</p>
<p>
    &nbsp;
    <asp:Button ID="Button1" runat="server" Text="Tìm" OnClientClick = "Button1_Click" onclick="Button1_Click" Width="155px" />
</p>
<p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None" onpageindexchanging="GridView1_PageIndexChanging" 
        Width="760px">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="MaHoatDong" 
                DataNavigateUrlFormatString="~/ChiTietHoatDong.aspx?id={0}" 
                DataTextField="TenHoatDong" HeaderText="Tên Hoạt Động" 
                Text="Tên Họat Động" />
            <asp:BoundField DataField="NgayDienRa" HeaderText="Ngày Diễn Ra" />
            <asp:BoundField DataField="ThoiGianBatDauDangKy"
                HeaderText="Thời Gian Bắt Đầu Đăng Ký" />
            <asp:BoundField DataField="ThoiGianKetThucDangKy" 
                HeaderText="Thời Gian Kết Thúc Đăng Ký" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</p>
<p>
    Số kết quả hiển thị trên 1 trang
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
    </asp:DropDownList>
</p>
