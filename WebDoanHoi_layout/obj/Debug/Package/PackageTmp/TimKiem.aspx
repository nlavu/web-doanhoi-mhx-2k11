<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="TimKiem.aspx.cs" Inherits="WebDoanHoi_layout.TimKiem" %>
<%@ Reference Control = "~/wuc/search/wucSinhVienSearch.ascx" %>
<%@ Register TagPrefix="TimKiem" TagName="TimKiemSV" Src="~/wuc/search/wucSinhVienSearch.ascx" %>
<%@ Register TagPrefix="TimKiem" TagName="TimKiemBV" Src="~/wuc/search/wucBaiVietSearch.ascx" %>
<%@ Register TagPrefix="TimKiem" TagName="TimKiemHD" Src="~/wuc/search/wucHoatDongSearch.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server" >
    <asp:Image ID="Image1" runat="server" Height="122px" 
        ImageUrl="~/images/searchicon.jpg" Width="145px" />
    <asp:Label ID="Label1" runat="server" Text="Tìm Kiếm" Font-Size="XX-Large" 
        ForeColor="#CC0000"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;
    &nbsp;
    Bạn muốn tìm kiếm
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>...</asp:ListItem>
        <asp:ListItem>Sinh viên</asp:ListItem>
        <asp:ListItem>Bài viết</asp:ListItem>
        <asp:ListItem>Họat động</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible ="false">
    <TimKiem:TimKiemSV ID = "TKSV" runat="server"/>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible ="false">
    <TimKiem:TimKiemBV ID = "TimKiemBV" runat="server"/>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible ="false">
    <TimKiem:TimKiemHD ID = "TimKiemHD" runat="server"/>
    </asp:PlaceHolder>
</asp:Content>
