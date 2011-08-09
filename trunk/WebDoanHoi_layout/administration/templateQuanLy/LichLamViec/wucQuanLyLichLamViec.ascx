<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyLichLamViec.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.KhaoSat.wucLichLamViec" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 177px;
    }
    .style3
    {
        width: 176px;
    }
    .style4
    {
        width: 229px;
    }
</style>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin lịch làm việc</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
                        <li>
                            &nbsp;<table class="style1">
                                <tr>
                                    <td class="style2">
                                        <label>
                                        Ngày bắt đầu lịch làm việc</label></td>
                                    <td>
                                        <asp:TextBox ID="txtNgayBatDau" runat="server" CssClass="field-input" 
                                            Width="200px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" 
                                            TargetControlID="txtNgayBatDau">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtNgayBatDau" 
                                            ErrorMessage="Mời bạn nhập ngày bắt đầu lịch làm việc"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </li>
	                    <li>
		                    &nbsp;<table class="style1">
                                <tr>
                                    <td class="style3">
                                        <label>
                                        Ngày kết thúc lịch làm việc</label></td>
                                    <td>
                                        <asp:TextBox ID="txtNgayKetThuc" runat="server" CssClass="field-input" 
                                            Width="200px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" 
                                            TargetControlID="txtNgayKetThuc">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtNgayKetThuc" 
                                            ErrorMessage="Mời bạn nhập ngày kết thúc lịch làm việc"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
	                    </li>
	                    <li>
                            &nbsp;<table class="style1">
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label1" runat="server" Text="Hãy chọn file lịch làm việc"></asp:Label>
                                    </td>
                                    <td class="style4">
                                        <asp:FileUpload ID="FileUploadLichLamViec" runat="server" Width="200px" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="FileUploadLichLamViec" 
                                            ErrorMessage="Mời bạn chọn file chứa lịch làm việc"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <asp:Label ID="LabelUploadStatus" runat="server"></asp:Label>
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                        </li>
			         </ul>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			         <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click" Text="Thêm"></asp:LinkButton>&nbsp;&nbsp;
			         <asp:LinkButton runat="server" ID="btnCapNhat" CssClass="new-study-model" OnClick="btnCapNhat_Click" Text="Cập Nhật"></asp:LinkButton>
			     </asp:Panel>
			     
			</div>
		</div>
	</div>