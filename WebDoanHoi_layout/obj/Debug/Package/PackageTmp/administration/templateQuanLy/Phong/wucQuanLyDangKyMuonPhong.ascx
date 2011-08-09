<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyDangKyMuonPhong.ascx.cs"
    Inherits="WebDoanHoi_layout.administration.templateQuanLy.Phong.wucQuanLyDangKyMuonPhong" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
        <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Ðăng Ký Mượn Phòng" Font-Bold="True"
            Font-Size="Large" ForeColor="Blue"></asp:Label>
        <asp:Panel ID="PanelMessage" runat="server">
            <div class="message" style="width: 90%; display: table; background-image: url('./images/icon-error.gif');
                background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat;
                border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
                Chưa có dữ liệu
            </div>
        </asp:Panel>       
        <div id="body" class="clearfix">
            <div class="wrapper">
                <div class="col">
                    <p class="fancy">
                    </p>
                    <h2 class="fancy">
                        Thông tin đăng ký mượn phòng</h2>
                    <asp:Panel runat="server" ID="UpdatePanel">
                        <table class="normal-form">
                            <tr>                              
                                <td>
                                    Ngày
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="DateTimeMuonPhong" ID="txtngay"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtngay">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtngay"
                                        ErrorMessage="Mời bạn nhập ngày" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Số Lượng
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="field-input" ID="txtsoluong"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsoluong"
                                        ErrorMessage="Mời bạn nhập số lượng" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mục Ðích
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="field-input" ID="txtmucdich"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmucdich"
                                        ErrorMessage="Mời bạn nhập mục đích" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Đơn Vị Mượn
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="field-input" ID="txtdonvimuon"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdonvimuon"
                                        ErrorMessage="Mời bạn nhập đơn vị mượn" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Thời gian từ
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="field-input" ID="TGTu"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TGTu"
                                        ErrorMessage="Mời bạn nhập thời gian mượn" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Thời gian đến
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="field-input" ID="TGDen"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TGDen"
                                        ErrorMessage="Mời bạn nhập thời gian mượn" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phòng
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="field-input" ID="txtPhong"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:LinkButton runat="server" ID="btnCapNhat" CssClass="new-study-model" OnClick="btnCapNhat_Click"
                            Text="Cập Nhật" ValidationGroup="MuonPhong"></asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click"
                            Text="Thêm" ValidationGroup="MuonPhong"></asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="btnXoa" CssClass="new-study-model" OnClick="btnXoa_Click"
                                Text="Xóa" OnClientClick="delete_onclick()"></asp:LinkButton>
                                <script type="text/javascript">
                                    function delete_onclick() {
                                        return confirm("Ban co chac chan la se xoa");
                                    }

                                </script>
                        <br />
                        <br />
                        <asp:LinkButton runat="server" ID="btnXoaNhieu" CssClass="new-study-model" OnClick="btnXoaNhieu_Click"
                            Text="Xóa trước ngày: "></asp:LinkButton>
                            <br />
                        <asp:TextBox ID="txtXoaNhieu" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="txtXoaNhieu_CalendarExtender" runat="server"  Format="dd/MM/yyyy"
                            TargetControlID="txtXoaNhieu">
                        </asp:CalendarExtender>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
