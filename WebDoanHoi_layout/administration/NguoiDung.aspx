<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="NguoiDung.aspx.cs" Inherits="administration_NguoiDung" Title="Danh sách Sinh viên - Cán bộ" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Auction" TagName="AuctionNguoiDung" Src="~/administration/templateLoad/NguoiDung/wucNguoiDung.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyNguoiDung" Src="~/administration/templateQuanLy/NguoiDung/wucQuanLyNguoiDung.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <Auction:AuctionNguoiDung ID="controlNguoiDung" Runat="Server" />
     <asp:Panel ID="Panel2" runat="server">
        <Auction:AuctionQuanLyNguoiDung ID="AuctionQuanLyNguoiDung" Runat="Server" />
    </asp:Panel>
</asp:Content>

