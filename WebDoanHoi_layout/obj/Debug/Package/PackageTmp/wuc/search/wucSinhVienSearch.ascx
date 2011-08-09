<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucSinhVienSearch.ascx.cs" Inherits="WebDoanHoi_layout.wuc.search.wucSinhVienSearch" %>
<p>
    Tài Khoản&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
<p>
    <asp:TextBox ID="TextBox1" runat="server" Width="212px"></asp:TextBox>
</p>
<p>
    Họ tên người dùng
</p>
<p>
    <asp:TextBox ID="TextBox2" runat="server" Width="209px"></asp:TextBox>
</p>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click"
        style="text-align: center" Text="Tìm" Width="94px" 
        OnClientClick="Button1_Click" />
</p>

<%if (lstNguoiDung != null)
  {
      Response.Write(@"<p>Kết quả tìm kiếm</p>");    
  }
      %>
      <asp:GridView ID="GridView1"  runat="server" 
    AllowPaging="True" AutoGenerateColumns="False" 
    CellPadding="4" DataKeyNames="Username" 
    OnPageIndexChanging="GridView1_PageIndexChanging" ForeColor="#333333" 
    GridLines="None"   >
          <RowStyle BackColor="#EFF3FB" />
          <Columns>
              <asp:HyperLinkField DataTextField="Username" HeaderText="Username" 
                  Text="Username" NavigateUrl="~/XemThongTinNguoiDung.aspx" />
              <asp:BoundField DataField="HoTen" HeaderText="Họ Tên" />
              <asp:BoundField DataField="Email" HeaderText="Email" />
          </Columns>
     <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<p>
    Số kết quả hiển thị trên 1 trang
    <asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
        AutoPostBack="True">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
</p>

