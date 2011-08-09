<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sb_dangnhap.ascx.cs"
    Inherits="WebDoanHoi_layout.wuc.sb_dangnhap" %>
<div class="module">
    <div class="post-title">
        Đăng nhập
    </div>
    <table>
        <tr>
            <td>
                Tên đăng nhập
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTenDangNhap" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Mật khẩu - Quên mật khẩu
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" />
            </td>
        </tr>
    </table>
</div>
