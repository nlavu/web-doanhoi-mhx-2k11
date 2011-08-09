<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sb_banner.ascx.cs"
    Inherits="WebDoanHoi_layout.wuc.sb_banner" %>
  <div class="bannerslideshow" >    
   
    <%
        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
        try
        {
            string strRoot = Server.MapPath("/");
            xmlDoc.Load(strRoot + "XML\\QuanLyBanner.xml");

            System.Xml.XmlNodeList nodeList = xmlDoc.SelectNodes("//Banner");
            int count = 0;
            if (nodeList == null)
                return;
            foreach (System.Xml.XmlNode node in nodeList)
            {
     %>
                
                        <a href="<%Response.Write(node.SelectSingleNode("URLLink").InnerText);%>"><img src="<%Response.Write(node.SelectSingleNode("ImageLink").InnerText); %>"/></a>    
          
    <%
                count++;
            }
        }
        catch (Exception exp) { };
     %>
</div>