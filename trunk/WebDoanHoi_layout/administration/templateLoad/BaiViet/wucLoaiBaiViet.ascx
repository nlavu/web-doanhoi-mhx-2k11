<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucLoaiBaiViet.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateLoad.BaiViet.wucLoaiBaiViet" %>
<div class="section-title">

            <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
            <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Loại Bài Viết trong mỗi Chuyên Mục" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
    </div>   
     <asp:Panel ID="PanelMessage" runat="server">
             <div class="message" style="width:90%;display:table; background-image:url('./images/icon-error.gif'); background-color:#FFFFCC;background-position:10px 50%;background-repeat:no-repeat; border:0.1em solid #CC0000;margin:0.5em 0;padding:10px 10px 10px 36px;">
                   Chưa có dữ liệu
            </div>
            </asp:Panel>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:Panel ID="PanelDanhSach" runat="server">
            <asp:GridView ID="GridViewLoaiBaiViet" runat="server" AutoGenerateColumns="False"
                CssClass="tablestyle" DataKeyNames="maloaibaiviet" AllowPaging="True" OnPageIndexChanging="GridViewLoaiBaiViet_PageIndexChanging"
                OnRowCommand="GridViewLoaiBaiViet_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="STT" />                    
                    <asp:BoundField DataField="maloaibaiviet" HeaderText="Loại bài viết" Visible="true" />
                    <asp:HyperLinkField DataTextField="tenloaibaiviet" HeaderText="Loại bài viết"
                        DataNavigateUrlFields="maloaibaiviet" DataNavigateUrlFormatString="~/administration/LoaiBaiViet.aspx?id={0}"
                        ItemStyle-Width="30%" SortExpression="maloaibaiviet">
                        <ItemStyle Width="30%" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="tenchuyenmuc" HeaderText="Tên chuyên mục" />
                    <asp:TemplateField HeaderText="Xóa">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="XoaLoaiBaiViet" CommandArgument='<%#Eval("maloaibaiviet") %>'
                                OnClientClick="delete_onclick()">Xóa</asp:LinkButton>
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
                <asp:DropDownList ID="DropDownListPaging" runat="server" OnSelectedIndexChanged="DropDownListPaging_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem Selected="True">10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                </asp:DropDownList>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
