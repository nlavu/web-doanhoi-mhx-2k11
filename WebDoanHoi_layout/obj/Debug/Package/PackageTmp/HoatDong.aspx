<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="HoatDong.aspx.cs" Inherits="WebDoanHoi_layout.HoatDong" Title="Danh sách hoạt động" %>
<%@ Register TagPrefix="Auction" TagName="AuctionHoatDong" Src="~/wuc/wucHoatDong.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" Runat="Server">
    <div id="BVNoiBatDiv">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <Auction:AuctionHoatDong ID="controlHoatDong" Runat="Server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

