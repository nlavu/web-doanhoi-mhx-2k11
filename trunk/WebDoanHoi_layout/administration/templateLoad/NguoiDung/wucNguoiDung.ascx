<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucNguoiDung.ascx.cs"
    Inherits="WebDoanHoi_layout.administration.templateLoad.NguoiDung.wucNguoiDung" %>
<div class="section-title">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Image ID="imgTitle" runat="server" 
                ImageUrl="~/administration/Common/ico-dashboard.png" />
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Large" 
                ForeColor="Blue" Text="Danh Sách Sinh Viên / Cán Bộ"></asp:Label>
            <asp:Panel ID="PanelMessage" runat="server">
                <div class="message" 
                    style="width: 90%; display: table; background-image: url('./images/icon-error.gif'); background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat; border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
                    Chưa có dữ liệu
                </div>
            </asp:Panel>
            <asp:GridView ID="GridViewSinhVien" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="tablestyle" DataKeyNames="manguoidung" 
                EnableModelValidation="True" 
                OnPageIndexChanging="GridViewSinhVien_PageIndexChanging" 
                style="margin-top: 0px">
                <Columns>
                    <asp:BoundField HeaderText="STT" />
                    <asp:BoundField DataField="manguoidung" HeaderText="Sinh Viên" 
                        Visible="false" />
                    <asp:HyperLinkField DataNavigateUrlFields="manguoidung" 
                        DataNavigateUrlFormatString="~/administration/NguoiDung.aspx?id={0}" 
                        DataTextField="username" HeaderText="Mã Số Sinh Viên" 
                        NavigateUrl="~/Default.aspx" SortExpression="username" />
                    <asp:BoundField DataField="password" HeaderText="password" />
                    <asp:BoundField DataField="hoten" HeaderText="Họ Tên" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:HyperLinkField DataNavigateUrlFields="mavaitro" 
                        DataNavigateUrlFormatString="~/administration/LoaiVaiTro.aspx?id={0}" 
                        DataTextField="tenloaivaitro" HeaderText="Vai Trò" NavigateUrl="~/Default.aspx" 
                        SortExpression="tenloaivaitro" />
                 <asp:TemplateField HeaderText="Xóa" >
                   <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Xoa" CommandArgument='<%#Eval("manguoidung") %>' OnClientClick="delete_onclick()">Xóa</asp:LinkButton>
                   </ItemTemplate>                   
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
           <script type="text/javascript">
               function delete_onclick() {
                   return confirm("Bạn có chắc chắn là muốn xóa?");
               }
        </script> 
            <asp:Label ID="Label1" runat="server" Text="Chọn số dòng hiển thị: "></asp:Label>
            <asp:DropDownList ID="DropDownListPaging" runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="DropDownListPaging_SelectedIndexChanged">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem Selected="True">10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</div>
<asp:Panel ID="PanelDanhSach" runat="server">
    <div class="options">
    </div>
</asp:Panel>
