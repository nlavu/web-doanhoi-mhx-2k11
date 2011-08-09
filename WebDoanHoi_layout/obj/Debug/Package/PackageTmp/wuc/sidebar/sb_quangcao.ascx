<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sb_quangcao.ascx.cs"
    Inherits="WebDoanHoi_layout.wuc.sb_quangcao" %>
<div class="post-title">
    <div class="moduleHeader><span style="float:right" class="ui-icon ui-icon-grip-diagonal-se"></span>
        Quảng cáo
    </div>
    <%
        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
        try
        {
            string strRoot = Server.MapPath("/");
            xmlDoc.Load(strRoot + "XML\\QuanLyQuangCao.xml");

            System.Xml.XmlNodeList nodeList = xmlDoc.SelectNodes("//QC");
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
</div>