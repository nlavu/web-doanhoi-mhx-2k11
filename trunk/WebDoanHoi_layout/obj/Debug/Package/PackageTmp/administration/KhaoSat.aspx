<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="KhaoSat.aspx.cs" Inherits="administration_KhaoSat" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionKhaoSat" Src="~/administration/templateLoad/KhaoSat/wucKhaoSat.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyKhaoSat" Src="~/administration/templateQuanLy/KhaoSat/wucQuanLyKhaoSat.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionKhaoSat ID="controlKhaoSat" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyKhaoSat ID="controlQuanLyKhaoSat" Runat="Server" />
    </asp:Panel>
</asp:Content>

