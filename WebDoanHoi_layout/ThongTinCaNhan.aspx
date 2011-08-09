<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main_3col.Master" AutoEventWireup="true" CodeBehind="ThongTinCaNhan.aspx.cs" Inherits="ThongTinCaNhan" %>
<%@ Register TagPrefix="Auction" TagName="AuctionThongTinCaNhan" Src="~/wuc/wucThongTinCaNhan.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" Runat="Server">
<div id="BVNoiBatDiv">
    <Auction:AuctionThongTinCaNhan ID="controlThongTinCaNhan" runat="server" />
</div>
</asp:Content>

