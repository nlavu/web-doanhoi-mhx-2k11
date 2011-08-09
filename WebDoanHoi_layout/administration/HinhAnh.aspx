<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="HinhAnh.aspx.cs" Inherits="HinhAnh" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionHinhAnh" Src="~/administration/templateLoad/Album/wucHinhAnh.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyHinhAnh" Src="~/administration/templateQuanLy/Album/wucQuanLyHinhAnh.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
 <Auction:AuctionHinhAnh ID="controlHinhAnh" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyHinhAnh ID="AuctionQuanLyHinhAnh" Runat="Server" />
    </asp:Panel>
</asp:Content>