<%@ Page Language="C#" MasterPageFile="~/Masterpages/AdminDefault.master"  AutoEventWireup="true" CodeBehind="Banner.aspx.cs" Inherits="WebDoanHoi_layout.administration.Banner" ValidateRequest = "false"%>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
            <div>
                <h3 style="color: Blue;">
                    Chỉnh sửa banner</h3>
            </div>
            <div>
                <asp:TextBox ID="txtEditor" runat="server" Font-Size="13px" Height="400px" Rows="50"
                    TextMode="MultiLine" Width="700px"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            </div>
            <asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
</asp:Content>