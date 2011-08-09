<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyHeThongToChuc.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.BaiViet.wucQuanLyHeThongToChuc" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
			<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
				<h2 class="fancy">Thông tin Hệ Thống Tổ Chức</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
                            <label>
                            Tên Hệ Thống Tổ Chức</label>
                            <asp:TextBox ID="txttenhethongtochuc" runat="server" CssClass="field-input"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txttenhethongtochuc" 
                                ErrorMessage="Mời bạn nhập Tên Hệ Thống Tổ Chức"></asp:RequiredFieldValidator>
                        </li>
                        <li>
                            <label>
                            Nội Dung</label></li>
                    </ul>
		                    <table width="100%">
		                     <tr>
                            <td >
                             <cc1:Editor ID="ednoidung" runat="server" Height="300px" />
                                </td>
                        </tr>
                        </table>
			         <asp:Literal runat="server" ID="lbThongBao" Visible="false"></asp:Literal>
			         <br />
			         <asp:LinkButton runat="server" ID="btnCapNhat" CssClass="new-study-model" OnClick="btnCapNhat_Click" Text="Cập nhật"></asp:LinkButton>&nbsp;&nbsp;
			         <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click" Text="Thêm"></asp:LinkButton>&nbsp;&nbsp;
			         <asp:LinkButton runat="server" ID="btnXoa" CssClass="new-study-model" OnClick="btnXoa_Click" Text="Xóa"></asp:LinkButton>
			     </asp:Panel>
			     
			</div>
		</div>
	</div>