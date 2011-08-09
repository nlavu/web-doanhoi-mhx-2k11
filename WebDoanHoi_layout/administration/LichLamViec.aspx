<%@ Page Language="C#" MasterPageFile="~/Masterpages/AdminDefault.master"AutoEventWireup="true" CodeBehind="LichLamViec.aspx.cs" Inherits="WebDoanHoi_layout.administration.LichLamViec" %>

<%@ Register TagPrefix="Auction" TagName="AuctionLichLamViec" Src="~/administration/templateLoad/LichLamViec/wucLichLamViec.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyLichLamViec" Src="~/administration/templateQuanLy/LichLamViec/wucQuanLyLichLamViec.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionLichLamViec ID="controlLichLamViec" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyLichLamViec ID="AuctionQuanLyLichLamViec" Runat="Server" />
    </asp:Panel>
</asp:Content>
