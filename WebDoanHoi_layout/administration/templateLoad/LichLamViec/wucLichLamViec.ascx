<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucLichLamViec.ascx.cs" Inherits="WebDoanHoi_layout.administration.templateLoad.LichLamViec.wucLichLamViec" %>
<div class="section-title">

            <asp:Image ID="imgTitle" runat="server" ImageUrl="~/administration/Common/ico-dashboard.png" />
            <asp:Label ID="lblTitle" runat="server" Text="Danh Sách Lịch Làm Việc" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
    </div>   
     <asp:Panel ID="PanelMessage" runat="server">
             <div class="message" style="width:90%;display:table; background-image:url('./images/icon-error.gif'); background-color:#FFFFCC;background-position:10px 50%;background-repeat:no-repeat; border:0.1em solid #CC0000;margin:0.5em 0;padding:10px 10px 10px 36px;">
                   Chưa có dữ liệu
            </div>
            </asp:Panel>
    <asp:Panel ID="PanelDanhSach" runat="server">
            
    <div class="options">
        <asp:GridView ID="GridViewTAPTINBAIVIET" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CssClass="tablestyle" DataKeyNames="MaTapTin" 
            OnRowCommand="GridViewTAPTINBAIVIET_RowCommand"
            style="margin-right: 0px">

            <Columns>
                <asp:BoundField HeaderText="STT"/>
                <asp:HyperLinkField DataNavigateUrlFields="MaTapTin" DataNavigateUrlFormatString="~/administration/LichLamViec.aspx?id={0}"
                DataTextField="TenTapTin" HeaderText="Lịch Làm Việc" />
                <asp:HyperLinkField DataNavigateUrlFields="DuongDan" 
                    DataTextField="TenTapTin" HeaderText="Link Download" />
                <asp:ButtonField  CommandName="XoaFile" HeaderText="Xóa Lịch Làm Việc" 
                    ShowHeader="True" Text="Xóa" CausesValidation="False" />
            </Columns>

        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="Chọn số dòng hiển thị: "></asp:Label>
        <asp:DropDownList ID="DropDownListPaging" runat="server" 
            onselectedindexchanged="DropDownListPaging_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem Selected="True">10</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
        </asp:DropDownList>
        
    </div>   </asp:Panel>