<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucGopY.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateLoad.GopY.wucGopY" %>

<div class="section-title">
    <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
    <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Góp Ý" Font-Bold="True"
        Font-Size="Large" ForeColor="Blue"></asp:Label>
    <asp:Panel ID="PanelMessage" runat="server">
        <div class="message" style="width: 90%; display: table; background-image: url('./images/icon-error.gif');
            background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat;
            border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
            Chưa có dữ liệu
        </div>
    </asp:Panel>
</div>

    <ContentTemplate>
        <asp:GridView ID="GridViewGopY" runat="server" 
    AutoGenerateColumns="False" CssClass="tablestyle"
            DataKeyNames="magopy" AllowPaging="True"
            Width="750px" AllowSorting="True" 
    onpageindexchanging="GridViewGopY_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="STT" />
               
                <asp:BoundField DataField="magopy" HeaderText="Mã góp ý" Visible="false" />
                 <asp:BoundField DataField="MSSV" HeaderText="MSSV" />
                 <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:HyperLinkField DataTextField="tieude" HeaderText="Tiêu Đề"
                    DataNavigateUrlFields="magopy" DataNavigateUrlFormatString="~/administration/GopY.aspx?id={0}"
                    ItemStyle-Width="30%" SortExpression="magopy">
                    <ItemStyle Width="30%" />
                </asp:HyperLinkField>
                             
            </Columns>
        </asp:GridView>
     
        <asp:Panel ID="PanelDanhSach" runat="server">
        <div class="options">
            <asp:Label ID="Label1" runat="server" Text="Chọn số dòng hiển thị: "></asp:Label>
            <asp:DropDownList ID="DropDownListPaging" runat="server" OnSelectedIndexChanged="DropDownListPaging_SelectedIndexChanged"
                AutoPostBack="True">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem Selected="True">10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
        </div>
        </asp:Panel>
    <table style="text-align:left;">
        <tr>
            <td>Tiêu đề</td>
            <td>
                <asp:TextBox ID="txtTieuDe" Text="" runat="server" CssClass="field-input" Width="200px"></asp:TextBox>
               
            </td>
        </tr>
    
        <tr>
            <td>
                Nội dung:
            </td>
            <td>
                <asp:TextBox ID="txtNoiDung" Text="" runat="server" Height="93px" TextMode="MultiLine" Width="441px"></asp:TextBox>
            </td>
        </tr>
    </table>
   
    </ContentTemplate>