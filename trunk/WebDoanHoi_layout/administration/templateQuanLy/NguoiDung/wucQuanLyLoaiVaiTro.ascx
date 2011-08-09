<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyLoaiVaiTro.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.NguoiDung.wucQuanLyLoaiVaiTro" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 114px;
    }
    .style3
    {
        width: 115px;
    }
    .style4
    {
        width: 232px;
    }
    .style5
    {
        width: 233px;
    }
</style>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Loại Vai Trò</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
                            <table class="style1">
                                <tr>
                                    <td class="style3">
                                        <label>
                                        Mã Loại Vai Trò</label></td>
                                    <td class="style4">
                                        <asp:TextBox ID="txtmaloaivaitro" runat="server" CssClass="field-input" 
                                            ReadOnly="True" Width="217px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </li>
	                    <li>
		                    <table class="style1">
                                <tr>
                                    <td class="style2">
                                        <label>
                                        Tên Vai Trò</label></td>
                                    <td class="style5">
                                        <asp:TextBox ID="txttenloaivaitro" runat="server" CssClass="field-input" 
                                            Width="218px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txttenloaivaitro" ErrorMessage="Mời bạn nhập Tên Vai Trò"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
	                    </li>
			         </ul>
			         <asp:Literal runat="server" ID="lbThongBao" Visible="false"></asp:Literal>
			         <br />
			         <asp:LinkButton runat="server" ID="btnCapNhat" CssClass="new-study-model" OnClick="btnCapNhat_Click" Text="Cập nhật"></asp:LinkButton>&nbsp;&nbsp;
			         <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click" Text="Thêm"></asp:LinkButton>&nbsp;&nbsp;
			         <asp:LinkButton runat="server" ID="btnXoa" CssClass="new-study-model" OnClick="btnXoa_Click" Text="Xóa"></asp:LinkButton>
			     </asp:Panel>
			     
			</div>
		</div>
	</div>