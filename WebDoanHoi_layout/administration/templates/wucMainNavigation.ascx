<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMainNavigation.ascx.cs" Inherits="WebDoanHoi_layout.administration.templates.wucMainNavigation" %>
<div>
    <asp:Menu ID="Menu1" runat="server" ForeColor="Blue">
        <Items>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý Chuyên mục" NavigateUrl="../ChuyenMuc.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý loại bài viết" NavigateUrl="../LoaiBaiViet.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý tập tin bài viết" NavigateUrl="../TapTinBaiViet.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý bài viết" NavigateUrl="../BaiViet.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý hệ thống tổ chức" NavigateUrl="../HeThongToChuc.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý các bài giới thiệu" NavigateUrl="../GioiThieu.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý các thông báo" NavigateUrl="../ThongBao.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý loại hoạt động" NavigateUrl="../LoaiHoatDong.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý hoạt động" NavigateUrl="../HoatDong.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý Đăng ký hoạt động" NavigateUrl="../DangKyHoatDong.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý lịch làm việc" NavigateUrl="..."></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý Khảo sát" NavigateUrl="../KhaoSat.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý câu hỏi khảo sát" NavigateUrl="../CauHoiKhaoSat.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý đáp án khảo sát" NavigateUrl="../DapAnKhaoSat.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý đăng ký mượn phòng" NavigateUrl="../DangKyMuonPhong.aspx" Enabled=false></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý bài hát" NavigateUrl="http://mp3.zing.vn" ></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý hình ảnh" NavigateUrl="https://picasaweb.google.com/115481308871412250631"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý người dùng" NavigateUrl="../Nguoidung.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý vai trò người dùng" NavigateUrl="../LoaiVaiTro.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý quảng cáo" NavigateUrl="../QuangCao.aspx"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý banner" NavigateUrl="../Banner.aspx"></asp:MenuItem>
                  <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Quản lý hoạt động nổi bật" NavigateUrl="../HDNoiBat.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/administration/Common/ico-dashboard.png" 
                Text="Xem góp ý" NavigateUrl="../GopY.aspx"></asp:MenuItem>
      
        </Items>
    </asp:Menu>   
</div>


