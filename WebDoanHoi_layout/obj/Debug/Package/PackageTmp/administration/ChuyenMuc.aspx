<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="ChuyenMuc.aspx.cs" Inherits="ChuyenMuc" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyChuyenMuc" Src="~/administration/templateQuanLy/BaiViet/wucQuanLyChuyenMuc.ascx"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"> </asp:ToolkitScriptManager>
    
    <asp:Panel ID="Panel2" runat="server">
    
        <Auction:AuctionQuanLyChuyenMuc ID="AuctionQuanLyChuyenMuc" runat="Server" />
    </asp:Panel>
</asp:Content>