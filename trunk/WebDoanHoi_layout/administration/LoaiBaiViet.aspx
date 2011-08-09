<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="LoaiBaiViet.aspx.cs" Inherits="administration_LoaiBaiViet" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionLoaiBaiViet" Src="~/administration/templateLoad/BaiViet/wucLoaiBaiViet.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyLoaiBaiViet" Src="~/administration/templateQuanLy/BaiViet/wucQuanLyLoaiBaiViet.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <Auction:AuctionLoaiBaiViet ID="controlLoaiBaiViet" Runat="Server" />
    <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyLoaiBaiViet ID="AuctionQuanLyLoaiBaiViet" Runat="Server" />
    </asp:Panel>
</asp:Content>
