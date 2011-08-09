<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="ThongBao.aspx.cs" Inherits="ThongBao" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionThongBao" Src="~/administration/templateLoad/HoatDong/wucThongBao.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyThongBao" Src="~/administration/templateQuanLy/HoatDong/wucQuanLyThongBao.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionThongBao ID="controlThongBao" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyThongBao ID="controlQuanLyThongBao" Runat="Server" />
    </asp:Panel>
</asp:Content>
