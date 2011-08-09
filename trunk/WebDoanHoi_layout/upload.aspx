<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="WebDoanHoi_layout.Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Upload File</title>
</head>
<body>
<h1>Upload File</h1>
    <asp:Label ID="Label1" runat="server" Text="Hãy chọn file mà bạn muốn upload:"></asp:Label><br />
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUploadHinhAnh" runat="server" /><br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" 
            onclick="btnUploadClick" /><br />
        <asp:Label ID="LabelUploadStatus" runat="server" Text=""></asp:Label><br />
        </div>
    </form>
</body>
</html>
