<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="LoaiHoatDong.aspx.cs" Inherits="LoaiHoatDong" Title="Loại hoạt động" %>
<%@ Register TagPrefix="Auction" TagName="AuctionLoaiHoatDong" Src="~/administration/templateLoad/HoatDong/wucLoaiHoatDong.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyLoaiHoatDong" Src="~/administration/templateQuanLy/HoatDong/wucQuanLyLoaiHoatDong.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionLoaiHoatDong ID="controlLoaiHoatDong" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyLoaiHoatDong ID="controlQuanLyLoaiHoatDong" Runat="Server" />
    </asp:Panel>
</asp:Content>
