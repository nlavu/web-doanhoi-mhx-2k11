<%@ Page Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true"
    CodeBehind="LoaiBaiViet.aspx.cs" Inherits="WebDoanHoi_layout.LoaiBaiViet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div id="BVNoiBatDiv">
        <div id='BVNoiBatNhatContent'>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <div id="pager" class="pager" style="float: left;">
                <img src="css/blue/first.png" class="first" />
                <img src="css/blue/prev.png" class="prev" />
                <input type="text" class="pagedisplay" />
                <img src="css/blue/next.png" class="next" />
                <img src="css/blue/last.png" class="last" />
                <select class="pagesize">
                    <option selected="selected" value="5">5</option>
                    <option value="10">10</option>
                    <option value="20">20</option>
                    <option value="30">30</option>
                    <option value="40">40</option>
                </select>
            </div>
        </div>
    </div>
</asp:Content>
