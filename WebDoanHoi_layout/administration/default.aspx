<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebDoanHoi_layout.administration.index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <style type="text/css">
        .Login
        {
            text-align: center;
        }
    </style>
</head>
<body style="background-color: Black">
    <form id="form1" runat="server" style="text-align: center">
    <div style="background-color:White; width: 500px; text-align: center; margin-left:auto;margin-right:auto;margin-top:auto">
                        <div align="center" style="color: Blue; font-size: 20px; font-weight: bold; line-height: 35px">
                    Hệ thống quản lý website Đoàn TNCS HCM - Hội SV Trường ĐH KHTN
                </div>
                <div align="center" style="font-size: 12px; font-family: Verdana">
                    <asp:Login ID="LoginAdmin" runat="server" FailureText="Đăng nhập chưa thành công. Vui lòng thử lại lần nữa!"
                        LoginButtonText="Đăng Nhập" OnAuthenticate="LoginAdmin_Authenticate" PasswordLabelText="Mật khẩu"
                        RememberMeText="Ghi nhớ" TitleText="Đăng nhập" UserNameLabelText="Tên đăng nhập"
                        Width="408px" LoginButtonImageUrl="~/images/Login.png" LoginButtonType="Image"
                        CssClass="Login">
                        <LayoutTemplate>
                            <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0" style="width: 408px;">
                                            <tr>
                                                <td align="center" colspan="2" style="font-size: 14px; font-weight: bold; color: Red">
                                                    Đăng nhập
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Tên đăng nhập</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" Style="margin-left: 0px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LoginAdmin">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Mật khẩu</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Style="margin-left: 0px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginAdmin">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Ghi nhớ" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:ImageButton ID="LoginImageButton" runat="server" AlternateText="Đăng Nhập" CommandName="Login"
                                                        ImageUrl="~/images/Login.png" ValidationGroup="LoginAdmin" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
                </div>
    </div>
    </form>
</body>
</html>
