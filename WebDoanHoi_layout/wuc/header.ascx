<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebDoanHoi_layout.wuc.header" %>
<div id="header-banner">
	<img src="../Upload/BANNER WEB.png"/ width="1000">
</div>
<div id="header-flash" style="display:none">
    <object id="FlashID" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="1000" height="125">
    <param name="movie" value="../Uploads/title.swf" />
    <param name="quality" value="high" />
    <param name="wmode" value="opaque" />
    <param name="swfversion" value="6.0.65.0" />
    <!-- This param tag prompts users with Flash Player 6.0 r65 and higher to download the latest version of Flash Player. Delete it if you don’t want users to see the prompt. -->
    <param name="expressinstall" value="../Scripts/expressInstall.swf" />
    <!-- Next object tag is for non-IE browsers. So hide it from IE using IECC. -->
    <!--[if !IE]>-->
    <object type="application/x-shockwave-flash" data="../Uploads/title.swf" width="1000" height="125">
        <!--<![endif]-->
        <param name="quality" value="high" />
        <param name="wmode" value="opaque" />
        <param name="swfversion" value="6.0.65.0" />
        <param name="expressinstall" value="../Scripts/expressInstall.swf" />
        <!-- The browser displays the following alternative content for users with Flash Player 6.0 and older. -->
        <div>
        <h4>Content on this page requires a newer version of Adobe Flash Player.</h4>
        <p><a href="http://www.adobe.com/go/getflashplayer"><img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" /></a></p>
        </div>
        <!--[if !IE]>-->
    </object>
    <!--<![endif]-->
    </object>
</div>
<!-- navigation end -->
<!-- navigation end -->
<div class="header-menu" id="menu">
    <asp:Label ID="lblMenu" runat="server" Text="Label"></asp:Label>
</div>
<div id="header-submenu">
    <div style="float:right;width:150px;line-height:23px;margin-left:10px;">
        <a style="float:left;">Chọn màu: </a>
        <div class="skin_blue" onclick="skin_blue(this);">
            <div class="skin_blue_selected"></div>
        </div>
        <div class="skin_orange" onclick="skin_orange(this)">
            <div class=""></div>
        </div>
    </div>
    <div style="float:right">
        <span>
		<asp:Label ID="txtTime" runat="server"></asp:Label> - Văn bản - tài liệu
            <asp:DropDownList ID="ddlLienKet" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlLienKet_SelectedIndexChanged">
                <asp:ListItem Value="0">Trang web liên kết</asp:ListItem>
                <asp:ListItem Value="http://www.vnuhcm.edu.vn/">Đại học Quốc gia TP.HCM</asp:ListItem>
                <asp:ListItem Value="http://hcmus.edu.vn/">Trường DH KHTN TP.HCM</asp:ListItem>               
                <asp:ListItem Value="http://www.thanhdoan.hochiminhcity.gov.vn/webtd/vn/Home.aspx">Thành 
                Đoàn TP.HCM</asp:ListItem>
 <asp:ListItem Value="http://www.hoisinhvientphcm.com">Hội sinh viên Việt Nam TP.HCM</asp:ListItem>                  
               
            </asp:DropDownList>
        </span>
    </div>
</div>