<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sb_hd_noibat.ascx.cs" Inherits="WebDoanHoi_layout.wuc.sidebar.sb_hd_noibat" %>
<div class="post-title">
    <div class="moduleHeader"><span style="float:right" class="ui-icon ui-icon-grip-diagonal-se"></span>
        Hoạt động nổi bật
    </div>
    <div class="post-content">
	 <%
        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
        try
        {
            string strRoot = Server.MapPath("/");
            xmlDoc.Load(strRoot + "XML\\QuanLyHDNoiBat.xml");

            System.Xml.XmlNodeList nodeList = xmlDoc.SelectNodes("//HD");
            int count = 0;
            if (nodeList == null)
                return;
            foreach (System.Xml.XmlNode node in nodeList)
            {
     %>
                <div style="display:block;width:194px;margin-top:10px;">
                    <a href="<%Response.Write(node.SelectSingleNode("URLLink").InnerText);%>"><img width="194px" style="border-style:solid;border-width:thin;" alt="Dành cho quảng cáo" src="<%Response.Write(node.SelectSingleNode("ImageLink").InnerText); %>" /></a>
                </div>
    <%
                count++;
            }
        }
        catch (Exception exp) { };
     %>
        <asp:ImageButton ID="imgMain" runat="server" Width="195px" Visible="false"/>
    </div>
</div>