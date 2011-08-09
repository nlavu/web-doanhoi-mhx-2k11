<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebDoanHoi_layout.index1" Theme="Blue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div id="BVNoiBatDiv">
            <div id="BVNoiBatNhatDiv">
        <div id="imgBVNoiBat">
            <asp:HyperLink ID="hlBVNoiBatNhat1" runat="server" style="display:block; text-align: center;" >
                <asp:Image ID="imgBVNoiBatNhat" runat="server"  CssClass="hinhdaidienTinNoiBat" Width="514px"/></asp:HyperLink>
                </div>
                <div id="BVNoiBatNhatTitle" >
                    <asp:HyperLink ID="hlTieuDeNoiBatNhat"  runat="server">
                        </asp:HyperLink>
                </div>
                <div id="BVNoiBatNhatContent">
                    <asp:Label ID="lbTomTat" runat="server" Text="" ></asp:Label>
                    <asp:HyperLink ID="hlXemTiep" runat="server" CssClass="XemTiep"  >(Xem Tiếp >>)</asp:HyperLink>
                </div>
                
        </div>
        <div id="DSBVNoiBatDiv">
            <div class="DSBVNoiBatDiv-area"> 
                <div class="imgDSBVNoiBatDiv">
                    <asp:Label ID="lblHinh1" runat="server" Text="Hinh1"></asp:Label>
                </div>
                <div class="DSBVNoiBatDiv-title">
                    <asp:Label ID="lblTieuDe1" runat="server" Text="TieuDe1"></asp:Label>
                </div>
            </div>
            <div class="DSBVNoiBatDiv-area">
                <div class="imgDSBVNoiBatDiv">
                    <asp:Label ID="lblHinh2" runat="server" Text="Hinh2"></asp:Label>
                </div>
                <div class="DSBVNoiBatDiv-title">
                    <asp:Label ID="lblTieuDe2" runat="server" Text="TieuDe2"></asp:Label>
                </div>
            </div>
            <div class="DSBVNoiBatDiv-area">
                <div class="imgDSBVNoiBatDiv">
                    <asp:Label ID="lblHinh3" runat="server" Text="Hinh3"></asp:Label>
                </div>
                <div class="DSBVNoiBatDiv-title">
                    <asp:Label ID="lblTieuDe3" runat="server" Text="TieuDe3"></asp:Label>
                </div>
            </div>
            <div class="DSBVNoiBatDiv-area">
                <div class="imgDSBVNoiBatDiv">
                    <asp:Label ID="lblHinh4" runat="server" Text="Hinh4"></asp:Label>
                </div>
                <div class="DSBVNoiBatDiv-title">
                    <asp:Label ID="lblTieuDe4" runat="server" Text="TieuDe4"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblChuyenMuc" runat="server" Text="Label"></asp:Label>
</asp:Content>



