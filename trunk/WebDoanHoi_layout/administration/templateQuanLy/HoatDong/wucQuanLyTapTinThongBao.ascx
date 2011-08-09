<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyTapTinThongBao.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.HoatDong.wucQuanLyTapTinThongBao" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Tập Tin</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
                            <label>Mã Tập Tin</label>
                            <asp:TextBox runat="server" CssClass="field-input" ID="txtmataptin" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtmataptin" 
                                ErrorMessage="Mời bạn nhập Mã Tập Tin"></asp:RequiredFieldValidator>
                        </li>
	                    <li>
		                    <label>Tên Tập Tin</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txttentaptin" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txttentaptin" 
                                ErrorMessage="Mời bạn nhập Tên Tập Tin"></asp:RequiredFieldValidator>
	                    </li>
	                    <li>
		                    <label>Đường Dẫn</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txtduongdan" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtduongdan" 
                                ErrorMessage="Mời bạn nhập Đường Dẫn"></asp:RequiredFieldValidator>
	                    </li>
	                    <li>
		                    <label>Mã Bài Viết</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txtmabaiviet" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtmabaiviet" 
                                ErrorMessage="Mời bạn nhập Mã Bài Viết"></asp:RequiredFieldValidator>
	                    </li>
			         </ul>
			         <asp:Literal runat="server" ID="lbThongBao" Visible="false"></asp:Literal>
			         <br />
			         <asp:LinkButton runat="server" ID="btnCapNhat" CssClass="new-study-model" OnClick="btnCapNhat_Click" Text="Cập nhật"></asp:LinkButton>&nbsp;&nbsp;
			         <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click" Text="Thêm"></asp:LinkButton>&nbsp;&nbsp;
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
	</div>