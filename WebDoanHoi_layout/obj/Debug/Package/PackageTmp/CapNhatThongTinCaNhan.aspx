<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main_3col.Master" AutoEventWireup="true" CodeBehind="CapNhatThongTinCaNhan.aspx.cs" Inherits="CapNhatThongTinCaNhan" %>
<%@ Register TagPrefix="Auction" TagName="AuctionCapNhatThongTinCaNhan" Src="~/wuc/wucCapNhatThongTinCaNhan.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" Runat="Server">
<div id="BVNoiBatDiv">
<Auction:AuctionCapNhatThongTinCaNhan ID="controlCapNhatThongTinCaNhan" runat="server" />
</div>
</asp:Content>

