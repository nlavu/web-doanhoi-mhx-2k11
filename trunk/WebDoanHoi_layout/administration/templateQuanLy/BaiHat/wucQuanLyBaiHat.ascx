<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyBaiHat.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.BaiHat.wucQuanLyBaiHat" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>              
                <asp:Panel runat="server" ID="UpdatePanel">                   
                    
                    <table class="normal-form" style="text-align:center">
                        <tr>   
                            <td colspan="3"><h2>Thông tin Bài Hát</h2>
                            </td>
                        </tr>
                        <tr>
                            <td><label>Mã Bài Hát</label>
                            </td>
                            <td><asp:TextBox runat="server" CssClass="field-input" ID="txtmabaihat" 
                                Enabled="False" EnableTheming="True" ></asp:TextBox></td>                            
                        </tr>
	                    <tr>
                            <td><label>Tên Bài Hát</label></td>
		                    <td><asp:TextBox runat="server" CssClass="field-input" ID="txttenbaihat" ></asp:TextBox></td>
		                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txttenbaihat" 
                                ErrorMessage="Mời bạn nhập Tên Bài Hát"></asp:RequiredFieldValidator></td>
	                    </tr>
	                    <tr>
                            <td><label>Link Bài Hát</label></td>
		                    <td><asp:TextBox runat="server" CssClass="field-input" ID="txtlinkbaihat" ></asp:TextBox></td>
		                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtlinkbaihat" 
                                ErrorMessage="Mời bạn nhập Link Bài Hát"></asp:RequiredFieldValidator></td>	                        
	                    </tr>
			            <tr>
                            <td colspan="3"><asp:Literal runat="server" ID="lbThongBao" Visible="false"></asp:Literal>
                            </td>
                         </tr>
                         <tr>   
                            <td colspan="3">
                                <asp:LinkButton runat="server" ID="btnCapNhat" CssClass="new-study-model" OnClick="btnCapNhat_Click" Text="Cập nhật"></asp:LinkButton>
			                    <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click" Text="Thêm"></asp:LinkButton>
			                    <asp:LinkButton runat="server" ID="btnXoa" CssClass="new-study-model" OnClick="btnXoa_Click" Text="Xóa"></asp:LinkButton>	             
                            </td>
                         </tr>
                     </table>
			     </asp:Panel>			     
			</div>
		</div>
	</div>