<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyKhaoSat.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.KhaoSat.wucQuanLyKhaoSat" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Khảo Sát</h2>                
                <asp:Panel runat="server" ID="UpdatePanel">                    
                    
                    <ul class="normal-form">
                        <li>
		                    <label>Mã Ý kiến khảo sát</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txtMaYKKS" Enabled="false"></asp:TextBox>
	                   
	                    </li>
                        <li>
                            <label>Mã Đáp Án</label>
                            <asp:TextBox runat="server" CssClass="field-input" ID="txtmadapan" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtmasinhvien" 
                                ErrorMessage="Mời bạn nhập Mã Đáp Án"></asp:RequiredFieldValidator>
                        </li>
	                    
	                    <li>
		                    Ý Kiến Khác
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txtykienkhac" ></asp:TextBox>
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