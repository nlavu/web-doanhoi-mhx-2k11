<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyHinhAnh.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.Album.wucQuanLyHinhAnh" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Hình Ảnh</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
                            <label>Mã Hình Ảnh</label>
                            <asp:TextBox runat="server" CssClass="field-input" ID="txtmahinhanh" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtmahinhanh" 
                                ErrorMessage="Mời bạn nhập Mã Hình Ảnh"></asp:RequiredFieldValidator>
                        </li>
	                    <li>
		                    <label>Hình Ảnh</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txthinhanh" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txthinhanh" 
                                ErrorMessage="Mời bạn nhập Hình Ảnh"></asp:RequiredFieldValidator>
	                    </li>
	                    <li>
		                    <label>Mã Album</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txtmaalbum" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtmaalbum" 
                                ErrorMessage="Mời bạn nhập Mã Album"></asp:RequiredFieldValidator>
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