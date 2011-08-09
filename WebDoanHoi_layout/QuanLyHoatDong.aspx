<%@ Page Language="C#" MasterPageFile="~/Masterpages/AdminDefault.master" AutoEventWireup="true"
    CodeBehind="QuanLyHoatDong.aspx.cs" Inherits="WebDoanHoi_layout.QuanLyHoatDong"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <table style="width: 46%" align="center">
        <tr>
            <td style="width: 179px">
                <asp:Label ID="Label1" runat="server" Text="Mã hoạt động:"></asp:Label>
            </td>
            <td style="width: 264px">
                <asp:DropDownList ID="ddlMaHoatDong" runat="server" AutoPostBack="True" DataSourceID="Sql_HoatDong"
                    DataTextField="MaHoatDong" DataValueField="MaHoatDong" 
                    onselectedindexchanged="ddlMaHoatDong_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Sql_HoatDong" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT * FROM [HOATDONG]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="height: 24px; width: 179px">
                <asp:Label ID="Label2" runat="server" Text="Tên hoạt động:"></asp:Label>
            </td>
            <td style="width: 264px; height: 24px">
                <asp:TextBox ID="txtTenHoatDong" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                <asp:Label ID="Label3" runat="server" Text="Loại hoạt động:"></asp:Label>
            </td>
            <td style="width: 264px">
                <asp:DropDownList ID="ddlLoaiHoatDong" runat="server" AutoPostBack="True" DataSourceID="Sql_LoaiHoatDong"
                    DataTextField="TenLoaiHoatDong" DataValueField="MaLoaiHoatDong">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Sql_LoaiHoatDong" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT * FROM [LOAIHOATDONG]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                <asp:Label ID="Label4" runat="server" Text="Ngày diễn ra:"></asp:Label>
            </td>
            <td style="width: 264px">
                <asp:TextBox ID="txtNgayDienRa" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNgayDienRa" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                <asp:Label ID="Label5" runat="server" Text="Ngày bắt đầu đăng ký:"></asp:Label>
            </td>
            <td style="width: 264px">
                <asp:TextBox ID="txtThoiGianBatDauDK" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtThoiGianBatDauDK" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                <asp:Label ID="Label6" runat="server" Text="Ngày kết thúc đăng ký:"></asp:Label>
            </td>
            <td style="width: 264px">
                <asp:TextBox ID="txtThoiGianKetThucDK" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtThoiGianKetThucDK" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btThem" runat="server" Text="Thêm" onclick="btThem_Click" />
                <asp:Button ID="btCapNhat" runat="server" Text="Cập Nhật" 
                    onclick="btCapNhat_Click" />
                <asp:Button ID="btXoa" runat="server" Text="Xóa" onclick="btXoa_Click" />
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
        </tr>
        
        <tr>
            <td colspan="2">
                <asp:Literal ID="txtThongTin" runat="server"></asp:Literal>
            </td>
        </tr>
        
    </table>
</asp:Content>
