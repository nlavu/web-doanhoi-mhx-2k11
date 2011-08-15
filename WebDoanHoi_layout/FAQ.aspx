<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" 
CodeBehind="FAQ.aspx.cs" Inherits="WebDoanHoi_layout.FAQ"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div id="BVNoiBatDiv" style="line-height:25px">
        <asp:Panel ID="PanelNoiDungAll" runat="server">
            <div class="post-content">
                <div class="tieude" style="margin-top: 5px;">
                    <center>
                        <h3 style="font:arial, black">Các câu hỏi thường gặp</h3>
                    </center>
                </div>
                <p style="margin-top: 10px; margin-left: 5px;">
                    <asp:Label ID="ltrNoiDung" runat="server" Text="Label"></asp:Label>
                </p>
            </div>            
            <%--<asp:Label ID="ltrNoiDung" runat="server"  ></asp:Label>--%>
        </asp:Panel>

        <asp:Panel ID="PanelNoiDungChiTiet" runat="server">
            <div class="post-content">
                <div class="tieude" style="margin-top: 5px;">
                    <center>
                        <h3 style="font:arial, black">Các câu hỏi thường gặp</h3>
                    </center>
                </div>
                <p style="margin-top: 10px; margin-left: 5px;">
                    <asp:Label ID="lblNoiDungBaiViet" runat="server" Text="Label"></asp:Label>
                </p>
            </div>
            <b><a href="FAQ.aspx" style="float:right; font: arial, 14px, black">Quay về</a></b>
        </asp:Panel>
    </div>    
</asp:Content>
