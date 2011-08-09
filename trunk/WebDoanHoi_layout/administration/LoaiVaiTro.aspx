<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="LoaiVaiTro.aspx.cs" Inherits="administration_LoaiVaiTro" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionLoaiVaiTro" Src="~/administration/templateLoad/NguoiDung/wucLoaiVaiTro.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyLoaiVaiTro" Src="~/administration/templateQuanLy/NguoiDung/wucQuanLyLoaiVaiTro.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionLoaiVaiTro ID="controlLoaiVaiTro" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyLoaiVaiTro ID="controlQuanLyLoaiVaiTro" Runat="Server" />
    </asp:Panel>
</asp:Content>
