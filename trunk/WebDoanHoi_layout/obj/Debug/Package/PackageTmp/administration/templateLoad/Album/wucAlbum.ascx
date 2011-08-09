<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucAlbum.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateLoad.Album.wucAlbum" %>
<style type="text/css" >
    .LeftPart
    {
        width: 500px;
        height: 800px;
        float: left;
    }
    .RightPart
    {
    	display:inline;
    	left:500;
    	padding-left: 0;
    }
    .photoslist li
    {
    	display:inline;
    	float:left;
    	margin-left:15px;
    	margin-bottom:15px;
    }
</style>
<div class="section-title">
            <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
            <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Album" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
</div>   
<asp:Panel ID="PanelMessage" runat="server">
<div class="message" style="width:90%;display:table; background-image:url('./images/icon-error.gif'); background-color:#FFFFCC;background-position:10px 50%;background-repeat:no-repeat; border:0.1em solid #CC0000;margin:0.5em 0;padding:10px 10px 10px 36px;">
                   Chưa có dữ liệu
</div>
</asp:Panel>
<div class="LeftPart">
<asp:Panel ID="PanelDanhSach" runat="server">
        <asp:GridView ID="GridViewPicasa" runat="server" AutoGenerateColumns="False" 
            onpageindexchanging="GridViewPicasa_PageIndexChanging" AllowPaging="True" 
            onrowcommand="GridViewPicasa_RowCommand" Width="500px">
            <Columns>
                <asp:BoundField HeaderText="STT" ItemStyle-Width="20px" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                DataNavigateUrlFormatString="~/administration/Album.aspx?id={0}" 
                    HeaderText="Tiêu đề" DataTextField="AlbumTitle" />
                <asp:BoundField DataField="Access" HeaderText="Truy Cập" ItemStyle-Width="70px"/>
                <asp:BoundField DataField="NumPhotos" HeaderText="Số lượng ảnh" ItemStyle-Width="20px" />
                 <asp:TemplateField HeaderText="Xóa" >
                   <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="XoaAlbum" CommandArgument='<%#Eval("Id") %>' OnClientClick="delete_onclick()">Xóa</asp:LinkButton>
                   </ItemTemplate>                   
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
           <script type="text/javascript">
               function delete_onclick() {
                   return confirm("Bạn có chắc chắn là muốn xóa?");
               }
        </script>
           
            
    <div class="options">
        <asp:Label ID="Label1" runat="server" Text="Chọn số dòng hiển thị: "></asp:Label>
        <asp:DropDownList ID="DropDownListPaging" runat="server" 
            onselectedindexchanged="DropDownListPaging_SelectedIndexChanged" 
            AutoPostBack="True">
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem Selected="True">10</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
        </asp:DropDownList>
        
    </div>  
</asp:Panel>
<asp:Panel ID="PanelAlbumDetail" runat="server">
<div>
		<div >
			<div >
			<p >&nbsp;</p>
				<h2 >Thông tin Albumhông tin Album</h2>
                
                <asp:Panel runat="server" ID="UpdatePanel">
                    
                    
                    <ul>
                        <li>
                            <asp:DropDownList ID="DropDownListAccess"  runat="server" AutoPostBack="True">
                                <asp:ListItem>Public</asp:ListItem>
                                <asp:ListItem>Private</asp:ListItem>
                                <asp:ListItem Value="SigninRequired">Protected</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li>
                            <label>Tiêu đề album</label>
                            <asp:TextBox runat="server" CssClass="field-input" ID="txtalbumtitle" 
                                Width="356px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtalbumtitle" 
                                ErrorMessage="Mời bạn nhập tiêu đề album"></asp:RequiredFieldValidator>
                        </li>
	                    <li>
		                    <label>Miêu tả</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		                    <asp:TextBox runat="server" ID="txtmieuta" Height="56px" 
                                Width="352px" TextMode="MultiLine" ></asp:TextBox>
	                    </li>
			         </ul>
			         <asp:Literal runat="server" ID="lbThongBao" Visible="false"></asp:Literal>
			         <br />
                    <asp:LinkButton ID="lbtnThemAlbum" runat="server" onclick="lbtnThemAlbum_Click">Thêm</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtnCapNhatAlbum" runat="server" 
                        onclick="lbtnCapNhatAlbum_Click">Cập Nhật</asp:LinkButton>
			     </asp:Panel>
			     
			</div>
		</div>
	</div>
	</asp:Panel>
</div>

<div class="RightPart">
    <asp:ListView ID="ListViewPhotos" runat="server">
        <LayoutTemplate>
            <ul class="photoslist">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" ></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li><img id="photos" src="<%#Eval("thumbURL") %>"/></li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
            <div>
                sorry!
            </div>
        </EmptyDataTemplate>
        
    </asp:ListView>
</div>
