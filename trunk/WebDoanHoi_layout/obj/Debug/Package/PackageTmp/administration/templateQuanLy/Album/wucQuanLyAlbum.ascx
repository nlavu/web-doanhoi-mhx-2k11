<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyAlbum.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.Album.wucQuanLyAlbum" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Album</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
                            <label>Mã album</label>
                            <asp:TextBox runat="server" CssClass="field-input" ID="txtmaalbum" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtmaalbum" 
                                ErrorMessage="Mời bạn nhập Mã album"></asp:RequiredFieldValidator>
                        </li>
	                    <li>
		                    <label>Tên Album</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txttenalbum" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txttenalbum" 
                                ErrorMessage="Mời bạn nhập Tên Album"></asp:RequiredFieldValidator>
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