<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="BaiHat.aspx.cs" Inherits="WebDoanHoi_layout.BaiHat1"%>
<%@ Register TagPrefix="Auction" TagName="AuctionBaiHat" Src="~/wuc/wucBaiHat.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div id="BVNoiBatDiv">
        <Auction:AuctionBaiHat ID="controlBaiHat" Runat="Server" />
    </div>    
</asp:Content>
