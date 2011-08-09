<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sb_danhgia.ascx.cs"
    Inherits="WebDoanHoi_layout.wuc.sidebar.sb_danhgia" %>
<div class="post-title">
    <div class="moduleHeader">
        <span style="float: right" class="ui-icon ui-icon-grip-diagonal-se"></span>Đánh
        giá
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="post-content">
                <asp:Label ID="lbCauHoi" runat="server" Text="Label"></asp:Label>
                <asp:RadioButtonList ID="rblDanhSachDapAn" runat="server">
                </asp:RadioButtonList>
                <center>
                    <asp:Button ID="btSubmit" runat="server" OnClick="btSubmit_Click" Text="Submit" />
                </center>
                <hr />
                <asp:Literal ID="lThongTin" runat="server"></asp:Literal>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
