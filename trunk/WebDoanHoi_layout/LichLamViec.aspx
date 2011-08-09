<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/main_3col.Master" CodeBehind="LichLamViec.aspx.cs" Inherits="WebDoanHoi_layout.LichLamViec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div id="BVNoiBatDiv">
     <asp:Panel ID="PanelMessage" runat="server">
             <div style="width:90%;display:table; background-image:url('./images/icon-error.gif'); background-color:#FFFFCC;background-position:10px 50%;background-repeat:no-repeat; border:0.1em solid #CC0000;margin:0.5em 0;padding:10px 10px 10px 36px;">
                   Chưa có dữ liệu
            </div>
            </asp:Panel>
    <asp:Panel ID="PanelDanhSach" runat="server">
            
    <div>
        <asp:GridView ID="GridViewLichLamViec" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CssClass="tablestyle" DataKeyNames="MaTapTin" 
            style="margin-right: 0px">

            <Columns>
                <asp:BoundField HeaderText="STT"/>
                <asp:BoundField 
                DataField="TenTapTin" HeaderText="Lịch Làm Việc" />
                <asp:HyperLinkField DataNavigateUrlFields="DuongDan" 
                    DataTextField="TenTapTin" HeaderText="Link Download" />
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
        
    </div>   
    </asp:Panel>
    </div>
</asp:Content>