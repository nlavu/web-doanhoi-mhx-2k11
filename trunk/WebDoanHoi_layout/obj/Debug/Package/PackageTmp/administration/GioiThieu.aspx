<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="GioiThieu.aspx.cs" Inherits="GioiThieu" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionGioiThieu" Src="~/administration/templateLoad/BaiViet/wucGioiThieu.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyGioiThieu" Src="~/administration/templateQuanLy/BaiViet/wucQuanLyGioiThieu.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionGioiThieu ID="controlGioiThieu" Runat="Server" />
    <asp:Panel ID="Panel2" runat="server">
        <Auction:AuctionQuanLyGioiThieu ID="AuctionQuanLyGioiThieu" Runat="Server" />
    </asp:Panel>
</asp:Content>