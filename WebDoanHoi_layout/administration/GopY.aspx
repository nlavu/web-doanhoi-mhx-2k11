<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="GopY.aspx.cs" Inherits="BaiViet" Title="Untitled Page" ValidateRequest="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Auction" TagName="AuctionGopY" Src="~/administration/templateLoad/GopY/wucGopY.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionGopY ID="controlGopY" Runat="Server" />
    
</asp:Content>


    
