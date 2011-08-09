<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="CauHoiKhaoSat.aspx.cs" Inherits="CauHoiKhaoSat" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionCauHoiKhaoSat" Src="~/administration/templateLoad/KhaoSat/wucCauHoiKhaoSat.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyCauHoiKhaoSat" Src="~/administration/templateQuanLy/KhaoSat/wucQuanLyCauHoiKhaoSat.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionCauHoiKhaoSat ID="controlCauHoiKhaoSat" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyCauHoiKhaoSat ID="controlQuanLyCauHoiKhaosat" Runat="Server" />
    </asp:Panel>
 
</asp:Content>