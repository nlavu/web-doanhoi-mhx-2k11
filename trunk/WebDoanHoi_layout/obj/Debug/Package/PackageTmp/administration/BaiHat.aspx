<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="BaiHat.aspx.cs" Inherits="BaiHat"%>
<%@ Register TagPrefix="Auction" TagName="AuctionBaiHat" Src="~/administration/templateLoad/BaiHat/wucBaiHat.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyBaiHat" Src="~/administration/templateQuanLy/BaiHat/wucQuanLyBaiHat.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
 <div id="BVNoiBatDiv">
    <Auction:AuctionBaiHat ID="controlBaiHat" Runat="Server" />
     <asp:Panel ID="Panel1" runat="server">
        <Auction:AuctionQuanLyBaiHat ID="controlQuanLyBaiHat" Runat="Server" />
    </asp:Panel>
    </div>
</asp:Content>
