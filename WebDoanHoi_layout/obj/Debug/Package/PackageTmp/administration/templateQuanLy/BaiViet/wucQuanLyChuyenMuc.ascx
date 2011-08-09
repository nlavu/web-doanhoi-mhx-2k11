<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyChuyenMuc.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateQuanLy.BaiViet.wucQuanLyChuyenMuc" %>
  <div class="section-title">
                  <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
            <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Chuyên Mục" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
    </div>   
     <asp:Panel ID="PanelMessage" runat="server">
             <div class="message" style="width:90%;display:table; background-image:url('./images/icon-error.gif'); background-color:#FFFFCC;background-position:10px 50%;background-repeat:no-repeat; border:0.1em solid #CC0000;margin:0.5em 0;padding:10px 10px 10px 36px;">
                   Chưa có dữ liệu
            </div>
            </asp:Panel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <asp:GridView ID="GridViewChuyenMuc" runat="server" 
                AutoGenerateColumns="False" 
                CssClass="tablestyle" DataKeyNames="machuyenmuc" AllowPaging="True" 
                onpageindexchanging="GridViewChuyenMuc_PageIndexChanging" 
            onrowcommand="GridViewChuyenMuc_RowCommand" EnableModelValidation="True">             
                <Columns>
                    <asp:BoundField HeaderText="STT" />
                    <asp:BoundField DataField="machuyenmuc" HeaderText="Chuyên mục" />
                    
                    <asp:HyperLinkField DataTextField="tenchuyenmuc" HeaderText="Tên chuyên mục" 
                        NavigateUrl="~/Default.aspx" DataNavigateUrlFields="machuyenmuc" 
                        DataNavigateUrlFormatString="~/administration/ChuyenMuc.aspx?id={0}" 
                        ItemStyle-Width="30%" SortExpression="machuyenmuc" >
                        <ItemStyle Width="30%" />
                     </asp:HyperLinkField>                    
                    
                    <asp:TemplateField HeaderText="Xóa" >
                   <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="XoaChuyenMuc" CommandArgument='<%#Eval("machuyenmuc") %>' OnClientClick="delete_onclick()">Xóa</asp:LinkButton>
                   </ItemTemplate>                   
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
           <script type="text/javascript">
               function delete_onclick() {
                   var rs = confirm("Bạn có chắc chắn là muốn xóa?");
                   if (rs == true) {
                       return confirm("Bạn có muốn xóa hết tất cả các bài viết?")
                   }
                   return false;
               }
           </script>            
    <div class="options">
        <asp:Label ID="Label1" runat="server" Text="Chọn số dòng hiển thị: "></asp:Label>
        <asp:DropDownList ID="DropDownListPaging" runat="server" 
            onselectedindexchanged="DropDownListPaging_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem Selected="True">10</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
        </asp:DropDownList>
        
    </div> 
     </ContentTemplate> 
     </asp:UpdatePanel>
<div id="body" class="clearfix">
		<div class="wrapper">
			<div class="col">
			<p class="fancy">&nbsp;</p>
				<h2 class="fancy">Thông tin Chuyên Mục</h2>                
                <asp:Panel runat="server" ID="UpdatePanel">        
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate> 
                    <ul class="normal-form">
                        <li>
                            <label>Mã Chuyên Mục</label>
                            <asp:TextBox runat="server" CssClass="field-input" ID="txtmachuyenmuc" Enabled="false" ></asp:TextBox>
                            <asp:RequiredFieldValidator I D="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtmachuyenmuc" 
                                ErrorMessage="Mời bạn nhập Mã Chuyên Mục" ValidationGroup="1"></asp:RequiredFieldValidator>
                        </li>
	                    <li>
		                    <label>Tên Chuyên Mục</label>
		                    <asp:TextBox runat="server" CssClass="field-input" ID="txttenchuyenmuc" ></asp:TextBox>
	                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txttenchuyenmuc" 
                                ErrorMessage="Mời bạn nhập Tên Chuyên Mục" ValidationGroup="1"></asp:RequiredFieldValidator>
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
                                        var rs = confirm("Bạn có chắc chắn là muốn xóa?");
                                        if (rs == true) {
                                            return confirm("Bạn có muốn xóa hết tất cả các bài viết?")
                                        }
                                        return false;
                                    }
                                </script>
                                </ContentTemplate>
                                </asp:UpdatePanel>
			     </asp:Panel>
			     
			</div>
		</div>
	</div>