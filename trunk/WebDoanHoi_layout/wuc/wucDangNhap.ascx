<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDangNhap.ascx.cs"
    Inherits="WebDoanHoi_layout.wuc.wucDangNhap" %>
<div class="post-title">
    <div class="moduleHeader">
        <span class="ui-icon ui-icon-grip-diagonal-se" style="float: right"></span>Đăng
        nhập
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="post-content">
                <asp:Panel ID="PanelDangNhap" runat="server">
                    <table cellpadding="1px" cellspacing="1px" width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtusername" runat="server" BorderColor="Black" BorderWidth="1px"
                                    Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Mật khẩu"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" BorderColor="Black"
                                    BorderWidth="1px" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/QuenMatKhau.aspx#">Quên mật khẩu?</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btDangNhap" runat="server" Text="Đăng Nhập" OnClick="btDangNhap_Click"
                                    Style="height: 26px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="PanelDangXuat" runat="server">
                    <table>
                        <tr>
                            <td>
                                Chào bạn
                                <asp:HyperLink ID="hlhoten" runat="server"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a  ID="hlVaiTro" runat="server" />
                                <asp:Button ID="btDangXuat" runat="server" OnClick="btDangXuat_Click" Text="Đăng Xuất" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="PanelDangNhapSai" runat="server">
                    <table>
                        <tr>
                            <td>
                                Đăng nhập thất bại.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Lý do: Tên đăng nhâp hoặc mật khẩu sai
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btDangNhapLai" runat="server" OnClick="btDangNhapLai_Click" Text="Đăng nhập lại" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
