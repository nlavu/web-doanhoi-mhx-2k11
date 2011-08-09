<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="HeThongToChuc.aspx.cs" Inherits="HeThongToChuc" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionHeThongToChuc" Src="~/administration/templateLoad/BaiViet/wucHeThongToChuc.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyHeThongToChuc" Src="~/administration/templateQuanLy/BaiViet/wucQuanLyHeThongToChuc.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionHeThongToChuc ID="controlHeThongToChuc" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyHeThongToChuc ID="controlQuanLyHeThongToChuc" Runat="Server" />
    </asp:Panel>
</asp:Content>