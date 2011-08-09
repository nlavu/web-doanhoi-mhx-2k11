<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="XemThongTinNguoiDung.aspx.cs" Inherits="WebDoanHoi_layout.Masterpages.XemThongTinNguoiDung" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 165px">
                Thông tin người dùng</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 165px">
                Username</td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">
                Họ và tên</td>
            <td>
                <asp:TextBox ID="txtHoTen" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">
                Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">
                Vai trò</td>
            <td>
                <asp:TextBox ID="txtVaiTro" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
