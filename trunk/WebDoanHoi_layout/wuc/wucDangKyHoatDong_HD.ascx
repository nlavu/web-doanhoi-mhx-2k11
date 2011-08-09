<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDangKyHoatDong_HD.ascx.cs"
    Inherits="WebDoanHoi_layout.wuc.wucDangKyHoatDong_HD" %>
<div class="section-title">
    <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
    <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Sinh Viên Đăng Ký Hoạt Động"
        Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
</div>
<asp:Panel ID="PanelMessage" runat="server">
    <div class="message" style="width: 90%; display: table; background-image: url('./images/icon-error.gif');
        background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat;
        border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
        Chưa có dữ liệu
    </div>
</asp:Panel>
<asp:Panel ID="PanelDanhSach" runat="server">
    <asp:GridView ID="GridViewDangKyHoatDong" runat="server" AutoGenerateColumns="False"
        CssClass="tablestyle" DataKeyNames="MaNguoiDung" AllowPaging="True" OnPageIndexChanging="GridViewDangKyHoatDong_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="STT" />
            <asp:BoundField DataField="Username" HeaderText="MSSV" />
            <asp:HyperLinkField DataNavigateUrlFields="MaNguoiDung" 
                DataNavigateUrlFormatString="~/ThongTinCaNhan.aspx?id={0}" 
                DataTextField="HoTen" HeaderText="Họ Tên" ItemStyle-Width="30%" 
                NavigateUrl="~/default.aspx" SortExpression="Username" Text="HoTen">
                <ItemStyle HorizontalAlign="Center" Width="30%" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
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
    <div class="export to excel">
        <asp:Button ID="btExport" runat="server" Text="Xuất ra Excel" 
            onclick="btExport_Click" />
    </div>
</asp:Panel>
