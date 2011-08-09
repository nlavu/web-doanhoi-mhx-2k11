<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="ChiTietHoatDong.aspx.cs" Inherits="WebDoanHoi_layout.ChiTietHoatDong" Title="Chi tiết hoạt động" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyHoatDong" Src="~/wuc/wucDangKyHoatDong_HD.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div id="BVNoiBatDiv">
    <asp:Panel ID="PanelThongTinHoatDong" runat="server">
    
    <table align="center" style="">
        <tr>
            <td style="width: 341px;text-align:center;font-size:16px;line-height:25px;font-weight:bold;color:Blue" colspan="2">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" 
                    Text="THÔNG TIN HOẠT ĐỘNG"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 341px">
                <asp:Label ID="Label1" runat="server" Text="Hoạt Động:"></asp:Label>
            </td>
            <td style="width: 420px">
                <asp:Label ID="lbHoatDong" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 341px">
                <asp:Label ID="Label2" runat="server" Text="Ngày Diễn Ra:"></asp:Label>
            </td>
            <td style="width: 420px">
                <asp:Label ID="lbNgayDienRa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 341px">
                <asp:Label ID="Label3" runat="server" Text="Ngày Bắt Đầu Đăng Ký:"></asp:Label>
            </td>
            <td style="width: 420px">
                <asp:Label ID="lbBatDauDK" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 341px">
                <asp:Label ID="Label4" runat="server" Text="Ngày Kết Thúc Đăng Ký:"></asp:Label>
            </td>
            <td style="height: 21px; width: 420px">
                <asp:Label ID="lbKetThucDK" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 341px">
                &nbsp;</td>
            <td style="height: 21px; width: 420px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="color:Red;">
                <asp:Literal ID="txtTrangThai" runat="server"></asp:Literal>
            </td>
        </tr>

    </table>
    
    
    </asp:Panel>
    
    <asp:Panel ID="PanelDangKy" runat="server">                
                    <asp:Button ID="btDangKy" runat="server" onclick="btDangKy_Click" 
                        Text="Đăng ký" />
                      
                    
    </asp:Panel>
    
    <asp:Panel ID="PanelHuyDangKy" runat="server">
    <asp:Button ID="btHuy" runat="server" onclick="btHuy_Click" Text="Hủy Đăng Ký" />
    </asp:Panel>
    
    <br />
   <asp:Panel ID="PanelDanhsachSinhVien" runat="server">
        <Auction:AuctionQuanLyHoatDong ID="controlQuanLyHoatDong" Runat="Server" />
    </asp:Panel>
    
    <br />
    <asp:Label ID="lbDanhSachThongBao" runat="server" 
        Text="Danh Sách Các Thông Báo Liên Quan" Font-Bold="True" Font-Size="Large" 
        ForeColor="#6600FF"></asp:Label>
        <br />
    <asp:Label ID="lblDanhSachThongBao" runat="server" Text="Thong Bao"></asp:Label>
</div>
</asp:Content>


