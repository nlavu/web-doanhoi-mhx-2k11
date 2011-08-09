<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucBaiVietSearch.ascx.cs" Inherits="WebDoanHoi_layout.wuc.search.wucBaiVietSearch" %>
<p>
    Tiêu đề&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
<asp:TextBox ID="TextBox1" runat="server" Width="250px"></asp:TextBox>
<p>
    Nội dung&nbsp;&nbsp;&nbsp;
</p>
<asp:TextBox ID="TextBox2" runat="server" Width="249px"></asp:TextBox>
<p style="font-style: italic">
    &nbsp;</p>
<p style="font-style: italic">
    <asp:Button ID="Button1" runat="server" Text="Tìm" Width="79px" 
        onclick="Button1_Click" OnClientClick = "Button1_Click"/>
</p>
<p style="font-style: italic">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" AutoGenerateColumns="False" 
        onpageindexchanging="GridView1_PageIndexChanging">
        <RowStyle BackColor="White" ForeColor="#003399" />
        <Columns>
            <asp:HyperLinkField DataTextField="TieuDe" HeaderText="Tiêu Đề" 
                DataNavigateUrlFields="MaBaiViet" 
                DataNavigateUrlFormatString="~/BaiViet.aspx?id={0}" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
    </asp:GridView>
</p>
<p style="font-style: italic">
    Kết quả hiển thị trên 1 trang   <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
</p>


