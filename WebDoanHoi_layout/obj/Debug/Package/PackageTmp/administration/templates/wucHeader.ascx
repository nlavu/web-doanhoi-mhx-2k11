<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucHeader.ascx.cs" Inherits="WebDoanHoi_layout.administration.templates.wucHeader" %>
<script src="../../js/jquery-1.4.2.js" type="text/javascript"></script>
<script src="./Scripts/jquery.superfishmenu.js" type="text/javascript"></script>
<script type="text/javascript">
//<![CDATA[
$(document).ready(function(){$('#ctl00_ctrlMenu').superfish({autoArrows:false,speed:'fast',delay:200});});//]]>
</script>



 <div class="header">
                <div class="logo">
                </div>
                <div class="languageselector">
                    
                </div>
                <div class="links">
                    
                   
                </div>
                <div class="login-info">
                    
                            Logged in as:
                            <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>, 
                            <asp:LinkButton ID="linkButtonLogout" runat="server" 
                                onclick="linkButtonLogout_Click">Logout?</asp:LinkButton>
                        
                </div>
                <div class="version">
                    Đoàn TNCS HCM - Hội SV trường ĐH KHTN</div>
</div>
            <div class="clear">
            </div>