<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="DangKyMuonPhong.aspx.cs" Inherits="DangKyMuonPhong" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionDangKyMuonPhong" Src="~/administration/templateLoad/Phong/wucDangKyMuonPhong.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyDangKyMuonPhong" Src="~/administration/templateQuanLy/Phong/wucQuanLyDangKyMuonPhong.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <%--<Auction:AuctionDangKyMuonPhong ID="controlDangKyMuonPhong" Runat="Server" />--%>
     <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionDangKyMuonPhong ID="controlDangKyMuonPhong" Runat="Server" />
        <Auction:AuctionQuanLyDangKyMuonPhong ID="controlQuanLyDangKyMuonPhong" Runat="Server" />
    </asp:Panel>
</asp:Content>
