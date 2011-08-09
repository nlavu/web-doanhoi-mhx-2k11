<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="ThayDoiThongTinNguoiDung.aspx.cs" Inherits="WebDoanHoi_layout.Masterpages.ThayDoiThongTinNguoiDung" Title="Thay đổi thông tin người dùng" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
<div id="BVNoiBatDiv">
    <table style="width: 100%">
        <tr>
            <td style="width: 188px">
                Thông tin người dùng</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 188px">
                Username</td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 188px">
                Họ và tên</td>
            <td>
                <asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 188px">
                Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 188px">
                <asp:Button ID="btXacNhan" runat="server" Text="Xác nhận" 
                    onclick="btXacNhan_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 188px">
                <asp:Literal ID="lThongTin" runat="server"></asp:Literal>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
</asp:Content>
