<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucBaiViet.ascx.cs"
    Inherits="WebDoanHoi_layout.administration.templateLoad.BaiViet.wucBaiViet" %>
<div class="section-title">
    <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
    <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Bài Viết" Font-Bold="True"
        Font-Size="Large" ForeColor="Blue"></asp:Label>
    <asp:Panel ID="PanelMessage" runat="server">
        <div class="message" style="width: 90%; display: table; background-image: url('./images/icon-error.gif');
            background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat;
            border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
            Chưa có dữ liệu
        </div>
    </asp:Panel>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="GridViewBaiViet" runat="server" AutoGenerateColumns="False" CssClass="tablestyle"
            DataKeyNames="mabaiviet" AllowPaging="True" OnPageIndexChanging="GridViewBaiViet_PageIndexChanging"
            OnRowCommand="GridViewBaiViet_RowCommand" EnableModelValidation="True" 
            Width="750px" AllowSorting="True">
            <Columns>
                <asp:BoundField HeaderText="STT" />
                <asp:BoundField DataField="MaBaiViet" HeaderText="Mã BV" />
                <asp:BoundField DataField="mabaiviet" HeaderText="Mã Bài viết" Visible="false" />
                <asp:HyperLinkField DataTextField="tieude" HeaderText="Tiêu Đề"
                    DataNavigateUrlFields="mabaiviet" DataNavigateUrlFormatString="~/administration/BaiViet.aspx?id={0}"
                    ItemStyle-Width="30%" SortExpression="mabaiviet">
                    <ItemStyle Width="30%" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="tenchuyenmuc" HeaderText="Chuyên mục" />
                <asp:BoundField DataField="tenloaibaiviet" HeaderText="Loại bài viết" />
                <asp:BoundField DataField="ngaydang" HeaderText="Ngày đăng" 
                    DataFormatString="{0:g}" />
                <asp:TemplateField HeaderText="Tin nổi bật" >
                   <ItemTemplate>
                   <center><asp:CheckBox ID="chbNoiBat" runat="server" Checked='<%# Convert.ToBoolean(Eval("TinNoiBat")) %>'
                           OnCheckedChanged="onchecked_changed" AutoPostBack="True"  />
                   </center>                       
                   </ItemTemplate>                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Xóa Bài Viết" >
                   <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="XoaBaiViet" CommandArgument='<%#Eval("mabaiviet") %>' OnClientClick="delete_onclick()">Xóa</asp:LinkButton>
                   </ItemTemplate>                   
                </asp:TemplateField>               
            </Columns>
        </asp:GridView>
        <script type="text/javascript">
            function delete_onclick() {
                return confirm("Ban co chac chan la se xoa");
        }
        </script>
        <asp:Panel ID="PanelDanhSach" runat="server">
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
