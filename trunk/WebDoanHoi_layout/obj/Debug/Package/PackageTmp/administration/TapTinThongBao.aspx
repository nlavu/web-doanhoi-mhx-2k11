<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="TapTinThongBao.aspx.cs" Inherits="administration_TapTinThongBao" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionTapTinThongBao" Src="~/administration/templateLoad/HoatDong/wucTapTinThongBao.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyTapTinThongBao" Src="~/administration/templateQuanLy/HoatDong/wucQuanLyTapTinThongBao.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionTapTinThongBao ID="controlTapTinThongBao" Runat="Server" />
    <asp:Panel ID="Panel2" runat="server">
        <Auction:AuctionQuanLyTapTinThongBao ID="AuctionQuanLyTapTinThongBao" Runat="Server" />
    </asp:Panel>
</asp:Content>



