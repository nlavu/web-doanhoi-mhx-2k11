<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="QuenMatKhau.aspx.cs" Inherits="WebDoanHoi_layout.QuenMatKhau" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
<div id="BVNoiBatDiv">
<table style="width: 71%" align="center">
        <tr>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" 
                    Text="Vui lòng điền đúng MSSV và email đã sử dụng để đăng ký"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Text="MSSV:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMSSV" runat="server" Width="237px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtEmail" runat="server" Width="237px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 19px">
                <asp:Button ID="btLayMatKhau" runat="server" onclick="btLayMatKhau_Click" 
                    Text="Lấy mật khẩu" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Literal ID="txtThongTin" runat="server"></asp:Literal>
            </td>
        </tr>
        </table>
   </div>
</asp:Content>
