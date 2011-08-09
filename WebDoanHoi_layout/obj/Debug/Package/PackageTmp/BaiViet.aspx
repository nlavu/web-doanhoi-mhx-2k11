<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true"
    CodeBehind="BaiViet.aspx.cs" Inherits="WebDoanHoi_layout.BaiViet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div id="BVNoiBatDiv">
        <div class="tieude" style="margin-top: 5px;">
            <center>
                <asp:Label ID="lblTieuDe" runat="server" Text="Label"></asp:Label></center>
        </div>
        <div style="text-align: right; color: Blue; margin-top: 5px;">
            <asp:Label ID="lblNgayDang" runat="server" Text="Label"></asp:Label>
        </div>
        <div style="margin-top: 10px; margin-left: 5px;">
            <asp:Label ID="lblNoiDungBaiViet" runat="server" Text="Label"></asp:Label>
        </div>
        <div style="margin-top: 10px;">
            <hr />
        </div>
        <asp:Panel ID="PanelDownload" runat="server">
            <a style="color:Blue">Tập tin đính kèm</a>
            <a style="line-height:20px"><asp:Menu ID="hplDownloadLink" runat="server" 
                StaticSubMenuIndent="">
                <DynamicHoverStyle Font-Italic="True" ForeColor="#FF3300" />
                <DynamicItemTemplate>
                    <%# Eval("Text") %>
                </DynamicItemTemplate>
            </asp:Menu>
            </a>
        </asp:Panel>
    </div>
</asp:Content>
