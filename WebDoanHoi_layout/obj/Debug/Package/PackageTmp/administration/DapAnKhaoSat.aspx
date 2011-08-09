<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="DapAnKhaoSat.aspx.cs" Inherits="DanAnKhaoSat" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionDapAnKhaoSat" Src="~/administration/templateLoad/KhaoSat/wucDapAnKhaoSat.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyDapAnKhaoSat" Src="~/administration/templateQuanLy/KhaoSat/wucQuanLyDapAnKhaoSat.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionDapAnKhaoSat ID="controlDapAnKhaoSat" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyDapAnKhaoSat ID="controlQuanLyDapAnKhaoSat" Runat="Server" />
    </asp:Panel>
</asp:Content>

