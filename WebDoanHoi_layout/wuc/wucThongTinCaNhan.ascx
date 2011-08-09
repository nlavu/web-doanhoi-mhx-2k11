<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucThongTinCaNhan.ascx.cs" Inherits="WebDoanHoi_layout.wuc.wucThongTinCaNhan" %>
<asp:Table ID="TableThongTin" runat="server">
    <asp:TableRow  ID="Titile" runat="server">
        <asp:TableCell ID="TableCell1" runat="server" Width="250">
            <asp:Label ID="ThongTinTitle" runat="server" Text="THÔNG TIN CHUNG" ForeColor="Blue" Font-Bold="true" Font-Size="Large"></asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell2" runat="server" Width="100"></asp:TableCell>
        <asp:TableCell ID="TableCell3" runat="server">
            <asp:HyperLink ID="ChangeProfileLink"  runat="server" Text="Sửa thông tin cá nhân" Font-Italic="true"  ForeColor="Blue"></asp:HyperLink>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server" Width="250"></asp:TableCell>
        <asp:TableCell ID="TableCell6" runat="server" Width="100"></asp:TableCell>
        <asp:TableCell runat="server">
            <asp:HyperLink ID="ChangePassWord" runat="server" Text="Đổi mật khẩu" Font-Italic="true" ForeColor="Blue"></asp:HyperLink>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<asp:Table ID="TableDetail" runat="server">
    <asp:TableRow ID="MaSV" runat="server">
        <asp:TableCell ID="TableCell4" runat="server" Width="120">
            <asp:Label ID="LblMaSV"  runat="server" Text="Mã số sinh viên" ForeColor="Blue" Font-Bold="true"></asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell5" runat="server" Width="200">
            <asp:TextBox ID="TxbMaSV" Width="200" runat="server" ReadOnly="true"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="HoTen" runat="server">
        <asp:TableCell ID="TableCell8" runat="server" Width="120">
            <asp:Label ID="LblHoTen" runat="server" Text="Họ tên" ForeColor="Blue" Font-Bold="true">
            </asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell9" runat="server" Width="200">
            <asp:TextBox ID="TxbHoTen" runat="server" ReadOnly="true" Width="200"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="Email" runat="server">
        <asp:TableCell ID="TableCell10"  runat="server" Width="120">
            <asp:Label ID="LblEmail" runat="server" Text="Email" ForeColor="Blue" Font-Bold="true">
            </asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell11" runat="server" Width="200">
            <asp:TextBox ID="TxbEmail" runat="server" ReadOnly="true" Width="200"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="VaiTro" runat="server">
        <asp:TableCell ID="TableCell12" runat="server" Width="120">
            <asp:Label ID="LblVaiTro" runat="server" Text="Vai trò" ForeColor="Blue" Font-Bold="true">
            </asp:Label>
        </asp:TableCell>
        <asp:TableCell ID="TableCell13"  runat="server" Width="200">
            <asp:TextBox ID="TxbVaiTro" runat="server" ReadOnly="true" Width="200"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br /><br /> 
<asp:Panel ID="ThongTinMuonPhong" runat="server">
<asp:Table ID="TblThongTinMuonPhong" runat="server">
    <asp:TableRow ID="ThongTinMuonPhongTitle" runat="server">
        <asp:TableCell ID="TableCell14" runat="server">
            <asp:Label ID="LblThongTinMuonPhong" runat="server" Text="DANH SÁCH THÔNG TIN MƯỢN PHÒNG" ForeColor="Blue" Font-Bold="true" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>


<asp:Panel ID="PanelMessage1" runat="server">
    <div class="message" style="width: 90%; display: table; background-image: url('./images/icon-error.gif');
        background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat;
        border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
        Chưa có dữ liệu
    </div>
</asp:Panel>


<asp:Panel ID="PanelMuonPhong" runat="server">
<asp:GridView ID="GridViewDanhSachPhongMuon" runat="server"
 AutoGenerateColumns="false" CssClass="tablestyle" DataKeyNames="madangky">
 <Columns>
    <asp:BoundField HeaderText="STT" />
    <asp:BoundField HeaderText="Mã đăng ký" DataField="MaDangKy" />
    <asp:BoundField HeaderText="Ngày mượn" DataField="NgayMuon" />
    <asp:BoundField HeaderText="Số lượng phòng" DataField="SoLuong" />
    <asp:BoundField HeaderText="Mục đích" DataField="MucDich"/>
    <asp:BoundField HeaderText="Đơn vị mượn" DataField="DonViMuon" />
    <asp:TemplateField HeaderText="Chọn hủy">
            <ItemTemplate>
                <asp:CheckBox ID="cbChonXoaMuonPhong" runat="server" Text="Chọn xóa"/>
            </ItemTemplate>
    </asp:TemplateField>
 </Columns>
</asp:GridView>
<br />
<asp:Button ID="XoaDangKyMuonPhong" Text="Hủy đăng ký" runat="server" 
    Width="100" Height="30" style="margin-left:400" 
    onclick="XoaDangKyMuonPhong_Click"/>
    </asp:Panel>
    
    
    
    
</asp:Panel>
<br /><br />
<asp:Panel ID="ThongTinHoatDong" runat="server">
<asp:Table ID="HoatDongTitle" runat="server">
    <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell ID="TableCell17" runat="server">
            <asp:Label ID="LblHoatDong" runat="server" Text="DANH SÁCH HOẠT ĐỘNG ĐĂNG KÝ" ForeColor="Blue" Font-Bold="true" Font-Size="Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>




<asp:Panel ID="PanelMessage2" runat="server">
    <div class="message" style="width: 90%; display: table; background-image: url('./images/icon-error.gif');
        background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat;
        border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
        Chưa có dữ liệu
    </div>
</asp:Panel>

<asp:Panel ID="PanelHoatDong" runat="server">
<asp:GridView ID="GridViewHoatDong" runat="server"
 AutoGenerateColumns="false" CssClass="tablestyle">
 <Columns>
    <asp:BoundField HeaderText="STT" />
    <asp:BoundField HeaderText="Mã hoạt động" DataField="MaHoatDong" />
    <asp:TemplateField HeaderText="Tên hoạt động">
        <ItemTemplate>
            <asp:Label ID="LblTenHoatDong" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Chọn hủy">
            <ItemTemplate>
                <asp:CheckBox ID="cbChonXoaHoatDong" runat="server" Text="Chọn xóa"/>
            </ItemTemplate>
    </asp:TemplateField>
 </Columns>
</asp:GridView>
<br />
<asp:Button ID="BtbHuyDangKyHoatDong" Text="Hủy đăng ký" runat="server" 
    Width="100" Height="30" style="margin-left:400" 
    onclick="BtbHuyDangKyHoatDong_Click"/>
    <asp:Button ID="btExport" runat="server" onclick="btExport_Click" 
        Text="Xuất ra Excel" />
        
        </asp:Panel>
</asp:Panel>
