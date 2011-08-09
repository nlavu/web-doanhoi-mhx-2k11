<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyThongBao.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.HoatDong.wucQuanLyThongBao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 184px;
    }
    .style3
    {
        width: 249px;
    }
</style>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
			
				<h2 class="fancy">Thông tin Thông Báo</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <table class="style1">
                        <tr>
                            <td class="style2">
                                <label>
                                Tiêu Đề</label>
                            </td>
                            <td class="style3">
                                <asp:TextBox ID="txttieude" runat="server" CssClass="field-input" Width="223px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txttieude" ErrorMessage="Mời bạn nhập Tiêu Đề"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <label>
                                Hoạt Động</label></td>
                            <td class="style3">
                                <asp:DropDownList ID="drlHoatDong" runat="server" Height="25px" Width="210px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <label>
                                Nội Dung</label></td>
                               
                            <td class="style3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtnoidung" ErrorMessage="Mời bạn nhập Nội Dung"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    </asp:Panel>
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                    <table width="100%">
		                     <tr>
                            <td >
                             <cc1:Editor ID="txtnoidung" runat="server" />
                             
                                </td>
                        </tr>
                        </table>
                    <br />
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
			     
			     
			</div>
		</div>
	</div>