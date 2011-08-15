<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="CauHoiThuongGap.aspx.cs" Inherits="BaiViet" Title="Untitled Page" ValidateRequest="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Auction" TagName="AuctionFAQ" Src="~/administration/templateLoad/CauHoiThuongGap/wucFAQ.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <Auction:AuctionFAQ ID="controlFAQ" Runat="Server" />
    
</asp:Content>


    
