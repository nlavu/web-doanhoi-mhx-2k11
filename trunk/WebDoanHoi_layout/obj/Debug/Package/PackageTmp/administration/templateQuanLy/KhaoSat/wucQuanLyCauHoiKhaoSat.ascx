<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyCauHoiKhaoSat.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.KhaoSat.wucQuanLyCauHoiKhaoSat" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Câu Hỏi Khảo Sát</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
                            <label>Mã Câu Hỏi Khảo Sát</label>
                            <asp:TextBox runat="server" CssClass="field-input" ID="txtmacauhoikhaosat" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtmacauhoikhaosat" 
                                ErrorMessage="Mời bạn nhập Mã Câu Hỏi Khảo Sát"></asp:RequiredFieldValidator>
                        </li>
	                    <li>
		                    <label>Tiêu Đề</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txttieude" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txttieude" 
                                ErrorMessage="Mời bạn nhập Tiêu Đề"></asp:RequiredFieldValidator>
	                    </li>
	                    <li>
		                    <label>Lock</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txtlock" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtlock" 
                                ErrorMessage="Mời bạn nhập Lock"></asp:RequiredFieldValidator>
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