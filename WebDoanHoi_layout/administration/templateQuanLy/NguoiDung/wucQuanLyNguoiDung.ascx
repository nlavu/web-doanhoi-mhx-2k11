<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyNguoiDung.ascx.cs"
    Inherits="WebDoanHoi_layout.administration.templateQuanLy.NguoiDung.wucQuanLyNguoiDung" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 100px;
    }
    .style3
    {
        width: 99px;
    }
    .style4
    {
        width: 98px;
    }
    .style5
    {
        width: 97px;
    }
    .style6
    {
        width: 196px;
    }
    .style7
    {
        width: 212px;
    }
    .style8
    {
        width: 211px;
    }
    .style9
    {
        width: 209px;
    }
</style>
<div id="body" class="clearfix">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="wrapper">
                <div class="col">
                    <h2 class="fancy">
                        Thông tin Sinh Viên - Cán Bộ</h2>
                    <asp:Panel runat="server" ID="UpdatePanel">
                        <table class="style1">
                            <tr>
                                <td class="style2">
                                    <label>
                                        Mã Sinh Viên</label>
                                </td>
                                <td class="style9">
                                    <asp:TextBox ID="txtmasinhvien" runat="server" CssClass="field-input" Width="190px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmasinhvien"
                                        ErrorMessage="Mời bạn nhập Mã Sinh Viên" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <label>
                                        Password</label>
                                </td>
                                <td class="style8">
                                    <asp:TextBox ID="txtpass" runat="server" CssClass="field-input" Enabled="False" ReadOnly="True"
                                        Width="190px"></asp:TextBox>
                                    <asp:LinkButton ID="lkUpdatePass" runat="server" OnClick="LinkButton1_Click">Update Pass</asp:LinkButton>
                                    <asp:LinkButton ID="lkThemPass" runat="server" OnClick="ThemPass_Click">Thêm Pass</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpass"
                                        ErrorMessage="Mời bạn nhập Password" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    <label>
                                        Họ Tên</label>
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="txthoten" runat="server" CssClass="field-input" Width="190px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txthoten"
                                        ErrorMessage="Mời bạn nhập Họ Tên" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    <label>
                                        Email</label>&nbsp;
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="field-input" Width="190px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemail"
                                        ErrorMessage="Mời bạn nhập Email" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    <label>
                                        Vai Trò</label>&nbsp;
                                </td>
                                <td class="style6">
                                    <asp:DropDownList ID="txtvaitro" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceVaiTro"
                                        DataTextField="TenLoaiVaiTro" DataValueField="MaLoaiVaiTro" Width="190px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceVaiTro" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                        SelectCommand="SELECT * FROM [LOAIVAITRO]"></asp:SqlDataSource>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtvaitro"
                                        ErrorMessage="Mời bạn nhập Vai Trò" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <asp:Literal runat="server" ID="lbThongBao" Visible="false"></asp:Literal>
                        <br />
                        <asp:LinkButton runat="server" ID="btnCapNhat" CssClass="new-study-model" OnClick="btnCapNhat_Click"
                            Text="Cập nhật" ValidationGroup="1"></asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click"
                            Text="Thêm" ValidationGroup="1"></asp:LinkButton>&nbsp;&nbsp;
                         <asp:LinkButton runat="server" ID="btnXoa" CssClass="new-study-model" OnClick="btnXoa_Click"
                                Text="Xóa" OnClientClick="delete_onclick()"></asp:LinkButton>
                                <script type="text/javascript">
                                    function delete_onclick() {
                                        return confirm("Ban co chac chan la se xoa");
                                    }

                                </script>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
