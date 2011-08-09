<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyGioiThieu.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.BaiViet.wucQuanLyGioiThieu" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </p>
				<h2 class="fancy">Thông tin Giới Thiệu</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
		                    <label>Tên bài giới Thiệu</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txttengioithieu" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txttengioithieu" 
                                ErrorMessage="Mời bạn nhập Tên Giới Thiệu"></asp:RequiredFieldValidator>
	                    </li>
	                    <li>
		                    <label>Nội Dung</label>
		                   
		                    </li>
			         </ul>
		                     <table width="100%">
		                     <tr>
                            <td >
                             <cc1:Editor ID="txtnoidung" runat="server" Height="300px"/>
                                </td>
                        </tr>
                        </table>
	                    
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