<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucBaiHat.ascx.cs" Inherits="WebDoanHoi_layout.wuc.wucBaiHat" %>

<asp:Panel ID="PanelBaiHat" runat="server">
<p style="color:Red;font-size:16px;text-align:center;">Album nhạc</p>
<div style="text-align:left;line-height:25px;width:550px" id="baihat">
    <%
        System.Collections.Generic.List<DTOAuction.BAIHAT> lt = new System.Collections.Generic.List<DTOAuction.BAIHAT>();

        BUSAuction.BUSBaiHat BUSBaiHat = new BUSAuction.BUSBaiHat();

        lt = BUSBaiHat.SelectBAIHATsAll();
        if (lt.Count > 0)
        {
      %>
            <%
                foreach (DTOAuction.BAIHAT bh in lt)
                {
            %>
            <div class="divbh">
                <div class="bh ui-corner-top ui-widget-header">
                    <a href="#" style="color:White;" name="<% Response.Write(bh.LinkBaiHat);%>"><% Response.Write(bh.TenBaiHat);%></a>
                 </div>
                 <div style="text-align:center;" class=" ui-widget-content">
                    <embed class="bhZing" src="<% Response.Write(bh.LinkBaiHat);%>" quality="high" wmode="transparent" type="application/x-shockwave-flash" width="400" height="400">
                 </div>
             </div>
             <%
                }
             %>
     <%
        }
     %>
  </div>  
</asp:Panel>
 