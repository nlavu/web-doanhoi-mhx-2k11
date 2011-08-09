<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyLoaiBaiViet.ascx.cs"
    Inherits="WebDoanHoi_layout.administration.templateQuanLy.BaiViet.wucQuanLyLoaiBaiViet" %>
<div id="body" class="clearfix">
    <div class="wrapper">
        <div class="col">
            <p class="fancy">
                &nbsp;</p>
            <h2 class="fancy">
                Thông tin Loại Bài Viết</h2>
            <asp:Panel runat="server" ID="UpdatePanel">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <label>
                                Tên Loại Bài Viết</label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="field-input" ID="txttenloaibaiviet"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttenloaibaiviet"
                                ErrorMessage="Mời bạn nhập Tên Loại Bài Viết" ValidationGroup="1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Chuyên Mục</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChuyenMuc" runat="server" >
                            </asp:DropDownList>
                           
                        </td>
                    </tr>
                </table>
                <asp:Literal runat="server" ID="lbThongBao" Visible="false"></asp:Literal>
                <br />
                <asp:LinkButton runat="server" ID="btnCapNhat" CssClass="new-study-model" OnClick="btnCapNhat_Click"
                    Text="Cập nhật"></asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click"
                    Text="Thêm"></asp:LinkButton>&nbsp;&nbsp;
                 <asp:LinkButton runat="server" ID="btnXoa" CssClass="new-study-model" OnClick="btnXoa_Click"
                                Text="Xóa" OnClientClick="delete_onclick()"></asp:LinkButton>
                                <script type="text/javascript">
                                    function delete_onclick() {
                                        var rs = confirm("Bạn có chắc chắn là muốn xóa?");
                                        if (rs == true) {
                                            return confirm("Bạn có muốn xóa hết tất cả các bài viết?")
                                        }
                                        return false;
                                    }
                                </script>
            </asp:Panel>
        </div>
    </div>
</div>
