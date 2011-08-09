<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true" CodeBehind="GopY.aspx.cs" Inherits="WebDoanHoi_layout.GopY" Title="Góp ý" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
<div id="BVNoiBatDiv">

<table style="width: 71%" align="center">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblTieuDe" runat="server" 
                    Text="Tiêu đề:"></asp:Label>
            </td>
        </tr>
         <tr>
            <td colspan="3">
               <asp:TextBox ID="txtTieuDe" runat="server" Height="30px" Width=100% TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblNoiDung" runat="server" 
                    Text="Nội dung:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
               <asp:TextBox ID="txtNoiDungGopY" runat="server" Height="200px" Width=100% TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblThongBao" runat="server" 
                    Text="Vui lòng điền đúng MSSV và email đã sử dụng!"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMSSV" runat="server" Text="MSSV:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMSSV" runat="server" Width="237px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtEmail" runat="server" Width="237px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 19px">
                <asp:Button ID="btGopY" runat="server" Text="Góp Ý" onclick="btGopY_Click1" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Literal ID="lblThongTin" runat="server"></asp:Literal>
            </td>
        </tr>
        </table>

   </div>
</asp:Content>
