<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="ThongBao.aspx.cs" Inherits="WebDoanHoi_layout.ThongBao" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div>
        <center><asp:Label ID="lblTieuDe" runat="server" Text="Label"></asp:Label></center>
    </div>
    <div>
        <asp:Label ID="lblNgayDang" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblNoiDungThongBao" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
