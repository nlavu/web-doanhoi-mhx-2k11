<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyHoatDong.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.HoatDong.wucQuanLyHoatDong" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 201px;
    }
    .style4
    {
        width: 202px;
    }
    .style6
    {
        width: 203px;
    }
    .style7
    {
        width: 205px;
    }
    .style8
    {
        width: 206px;
    }
    .style9
    {
        width: 204px;
    }
    .style10
    {
        width: 263px;
    }
</style>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Hoạt Động</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul class="normal-form">
	                    <li>
		                    <table class="style1">
                                <tr>
                                    <td class="style4">
                                        <label>
                                        Tên Hoạt Động</label>&nbsp;</td>
                                    <td class="style2">
                                        <asp:TextBox ID="txttenhoatdong" runat="server" CssClass="field-input" 
                                            Width="180px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txttenhoatdong" ErrorMessage="Mời bạn nhập Tên Hoạt Động"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
	                    </li>
	                   <li>
		                    <table class="style1">
                                <tr>
                                    <td class="style6">
                                        <label>
                                        Ngày Diễn Ra</label></td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtngaydienra" runat="server" CssClass="field-input" 
                                            Width="180px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" 
                                            TargetControlID="txtngaydienra"></asp:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="txtngaydienra" ErrorMessage="Mời bạn nhập Ngày Diễn Ra"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
	                    </li>
	                    <li>
		                    <table class="style1">
                                <tr>
                                    <td class="style9">
                                        <label>
                                        Loại Hoạt Động</label></td>
                                    <td>
                                        <asp:DropDownList ID="ddlLoaiHoatDong" runat="server" Width="180px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                                    </td>
                                </tr>
                            </table>
	                    </li>
	                    <li>
		                    <table class="style1">
                                <tr>
                                    <td class="style4">
                                        <label>
                                        Thời Gian Bắt Đầu Đăng Ký</label></td>
                                    <td class="style7">
                                        <asp:TextBox ID="txtthoigianbatdaudangky" runat="server" CssClass="field-input" 
                                            Width="180px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" 
                                            TargetControlID="txtthoigianbatdaudangky"></asp:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                            ControlToValidate="txtthoigianbatdaudangky" 
                                            ErrorMessage="Mời bạn nhập Thời Gian Bắt Đầu Đăng Ký"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
	                    </li>
	                     <li>
		                    <table class="style1">
                                 <tr>
                                     <td class="style4">
                                         <label>
                                         Thời Gian Kết Thúc Đăng Ký</label></td>
                                     <td class="style8">
                                         <asp:TextBox ID="txtthoigianketthucdangky" runat="server" 
                                             CssClass="field-input" Width="180px"></asp:TextBox>
                                         <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" 
                                             TargetControlID="txtthoigianketthucdangky"></asp:CalendarExtender>
                                     </td>
                                     <td>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                             ControlToValidate="txtthoigianketthucdangky" 
                                             ErrorMessage="Mời bạn nhập Thời Gian Kết Thúc Đăng Ký"></asp:RequiredFieldValidator>
                                     </td>
                                 </tr>
                             </table>
	                    </li>
	                    
                            <asp:ImageButton ID="image" runat="server"
                                 BorderColor="Black" BorderStyle="Double" 
                            Height="200px" Width="200px" Visible="False"/>
	                   
                           <li>
                               <table class="style1">
                                   <tr>
                                       <td class="style10">
                                           <asp:FileUpload ID="FileUpload" runat="server" />
                                       </td>
                                       <td>
                                           <asp:Button ID="btLoad" runat="server"
                                               Text="Load hình ảnh" onclick="btLoad_Click" />
                                       </td>
                                   </tr>
                               </table>
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