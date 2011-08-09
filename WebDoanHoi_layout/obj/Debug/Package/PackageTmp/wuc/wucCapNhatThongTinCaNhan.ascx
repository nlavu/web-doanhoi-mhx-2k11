<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCapNhatThongTinCaNhan.ascx.cs" Inherits="WebDoanHoi_layout.wuc.wucCapNhatThongTinCaNhan" %>
<asp:Table ID="TblTitle" runat="server">
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell ID="TableCell1" runat="server">
            <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
        </asp:TableCell>
        <asp:TableCell ID="TableCell2" runat="server" Width="500">
            <asp:Label ID="LblTitle" runat="server" Text="CẬP NHẬT THÔNG TIN CÁ NHÂN" ForeColor="Blue" Font-Bold="true" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br /><br />
<asp:Table ID="TableDetail" runat="server">

    <asp:TableRow ID="HoTen" runat="server">
        <asp:TableCell ID="TableCell7" runat="server" Width="120">
            <asp:Label ID="LblHoTen" runat="server" Text="Họ tên" ForeColor="Blue" Font-Bold="true">
            </asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell8" runat="server" Width="200">
            <asp:TextBox ID="TxbHoTen" runat="server" Width="200"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="Email" runat="server">
        <asp:TableCell ID="TableCell9" runat="server" Width="120">
            <asp:Label ID="LblEmail" runat="server" Text="Email" ForeColor="Blue" Font-Bold="true">
            </asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell10" runat="server" Width="200">
            <asp:TextBox ID="TxbEmail" runat="server" Width="200"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<asp:Table ID="TblButtons" runat="server">
    <asp:TableRow ID="RowButtons" runat="server">
        <asp:TableCell ID="TableCell14" runat="server" Width="80">
            <asp:Button ID="BtnSua" runat="server" Text="Cập nhật" Width="80" style="margin-left:80" 
    onclick="BtnSua_Click" />
        </asp:TableCell>
        <asp:TableCell ID="TableCell15" runat="server" Width="80">
            <asp:Button ID="BtnHuy" runat="server" Text="Hủy" Width="80" 
    onclick="BtnHuy_Click"/>
        </asp:TableCell>
        <asp:TableCell ID="TableCell16" runat="server" Width="80">
            <asp:Button ID="BtnThoat" runat="server" Text="Thoát" Width="80" 
    onclick="BtnThoat_Click"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
            
<asp:Literal ID="lThongTin" runat="server"></asp:Literal>

            
