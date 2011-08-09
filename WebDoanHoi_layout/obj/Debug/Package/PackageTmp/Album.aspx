<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminDefault.master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="Album" Title="Untitled Page" %>
<%@ Register TagPrefix="Auction" TagName="AuctionAlbum" Src="~/administration/templateLoad/Album/wucAlbum.ascx" %>
<%@ Register TagPrefix="Auction" TagName="AuctionQuanLyAlbum" Src="~/administration/templateQuanLy/Album/wucQuanLyAlBum.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div id="BVNoiBatDiv">
        <Auction:AuctionAlbum ID="controlAlbum" Runat="Server" />
    </div>
</asp:Content>

