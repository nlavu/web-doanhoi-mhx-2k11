<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/AdminDefault.master"
    AutoEventWireup="true" CodeBehind="QuangCao.aspx.cs" Inherits="WebDoanHoi_layout.administration.QuangCao"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <h3 style="color: Blue;">
                    Chỉnh sửa quảng cáo</h3>
            </div>
            <div>
                <asp:TextBox ID="txtEditor" runat="server" Font-Size="13px" Height="400px" Rows="50"
                    TextMode="MultiLine" Width="700px"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            </div>
            <asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
