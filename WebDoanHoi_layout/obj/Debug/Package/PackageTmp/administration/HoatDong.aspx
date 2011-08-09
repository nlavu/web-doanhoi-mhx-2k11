<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/AdminDefault.master" AutoEventWireup="true" CodeBehind="HoatDong.aspx.cs" Inherits="WebDoanHoi_layout.administration.HoatDong" %>
<%@ Register TagPrefix="Auction" TagName="AuctionHoatDong" Src="~/administration/templateLoad/HoatDong/wucHoatDong.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyHoatDong" Src="~/administration/templateQuanLy/HoatDong/wucQuanLyHoatDong.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <Auction:AuctionHoatDong ID="controlHoatDong" runat="server" />
      <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyHoatDong ID="controlQuanLyHoatDong" Runat="Server" />
    </asp:Panel>
</asp:Content>
