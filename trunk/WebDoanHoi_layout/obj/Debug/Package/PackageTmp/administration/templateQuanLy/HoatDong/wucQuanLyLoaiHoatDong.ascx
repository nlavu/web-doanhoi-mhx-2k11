<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyLoaiHoatDong.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.HoatDong.wucQuanLyLoaiHoatDong" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Loại Hoạt Động</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
                            <label>Mã Loại Hoạt Động&nbsp; </label>
                            &nbsp;<asp:TextBox runat="server" CssClass="field-input" ID="txtmaloaihoatdong" 
                                ReadOnly="True" Width="190px" ></asp:TextBox>
                        </li>
	                    <li>
		                    <label>Tên Loại Hoạt Động </label>
		                    &nbsp;<asp:TextBox runat="server" CssClass="field-input" 
                                ID="txttenloaihoatdong" Width="190px" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txttenloaihoatdong" 
                                ErrorMessage="Mời bạn nhập Tên Loại Hoạt Động"></asp:RequiredFieldValidator>
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