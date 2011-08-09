using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using DTOAuction;
namespace WebDoanHoi_layout
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Duong dan den thu muc anh upload
            Application["FCKeditor:UserFilesPath"] = "../../../../../upload/";
            XmlDocument xmlDoc = new XmlDocument();
            string strRoot = Server.MapPath("/");
            xmlDoc.Load(strRoot+"XML\\WebInfor.xml");            
            XmlNode node = xmlDoc.SelectSingleNode("//PageView");
            Application.Add("accesses",Int32.Parse(node.InnerText));           
            //Application["accesses"] = 12000;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["accesses"] = (int)Application["accesses"] + 1;
            XmlDocument xmlDoc = new XmlDocument();
            string strRoot = Server.MapPath("/");
            xmlDoc.Load(strRoot + @"XML\WebInfor.xml");
            XmlNode node = xmlDoc.SelectSingleNode("//PageView");
            node.InnerText = Application["accesses"].ToString();
            xmlDoc.Save(strRoot + @"XML\WebInfor.xml");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
         
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
          
        }

        protected void Application_End(object sender, EventArgs e)
        {
           
        }
    }
}