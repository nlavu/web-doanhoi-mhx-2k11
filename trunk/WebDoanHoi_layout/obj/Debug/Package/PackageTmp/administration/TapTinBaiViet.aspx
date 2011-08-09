<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="TapTinBaiViet.aspx.cs" Inherits="administration_TapTinBaiViet" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionTapTinBaiViet" Src="~/administration/templateLoad/BaiViet/wucTapTinBaiViet.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyTapTinBaiViet" Src="~/administration/templateQuanLy/BaiViet/wucQuanLyTapTinBaiViet.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionTapTinBaiViet ID="controlTapTinBaiViet" Runat="Server" />
    <asp:Panel ID="Panel2" runat="server">
        <Auction:AuctionQuanLyTapTinBaiViet ID="AuctionQuanLyTapTinBaiViet" Runat="Server" />
    </asp:Panel>
</asp:Content>

