<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucFAQ.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateLoad.CauHoiThuongGap.wucFAQ" %>

<div class="section-title">
    <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
    <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Câu Hỏi Thường Gặp" Font-Bold="True"
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
    <asp:GridView ID="GridViewFAQ" runat="server" 
AutoGenerateColumns="False" CssClass="tablestyle"
        DataKeyNames="macauhoi" AllowPaging="True"
        Width="750px" AllowSorting="True" 
onpageindexchanging="GridViewFAQ_PageIndexChanging">
       <Columns>
                <asp:BoundField HeaderText="STT" />
                <asp:BoundField DataField="macauhoi" HeaderText="Mã Câu Hỏi" Visible="false" />
                <asp:HyperLinkField DataTextField="noidungcauhoi" HeaderText="Câu Hỏi Thường Gặp"
                    DataNavigateUrlFields="macauhoi" DataNavigateUrlFormatString="~/administration/CauHoiThuongGap.aspx?id={0}"
                    ItemStyle-Width="30%" SortExpression="macauhoi">
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
        <td>Câu Hỏi</td>
        <td><asp:TextBox ID="txtCauHoi" runat="server" CssClass="field-input" Width="441px"></asp:TextBox></td>

        <td><asp:Literal ID="lblCauhoimoi" runat="server" Text="Câu hỏi mới" Visible="false"></asp:Literal></td>
        <td><asp:TextBox ID="txtCauHoiMoi" runat="server" CssClass="field-input" Width="441px" Visible="false"></asp:TextBox></td>
    </tr>    
    <tr>
        <td>Câu Trả Lời:</td>
        <td><asp:TextBox ID="txtCauTraLoi" runat="server" Height="93px" TextMode="MultiLine" Width="441px"></asp:TextBox></td>
        <td><asp:Literal ID="lblCautraloimoi" runat="server" Text="Câu trả lời mới:" Visible="false"></asp:Literal></td>
        <td><asp:TextBox ID="txtCauTraLoiMoi" runat="server" Height="93px" TextMode="MultiLine" Width="441px" Visible="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 19px">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" onclick="ThemCauHoiThuongGap" />
            <asp:Button ID="btnXoa" runat="server" Text="Xóa" onclick="XoaCauHoiThuongGap" />
            <asp:Button ID="btnSua" runat="server" Text="Cập nhật" onclick="SuaCauHoiThuongGap" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Literal ID="lblThongTin" runat="server"></asp:Literal>
        </td>
    </tr>
</table>
   
</ContentTemplate>