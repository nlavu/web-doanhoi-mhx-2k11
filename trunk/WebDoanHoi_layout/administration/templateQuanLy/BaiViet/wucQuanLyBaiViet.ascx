<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucQuanLyBaiViet.ascx.cs"
    Inherits="WebDoanHoi_layout.administration.templateQuanLy.BaiViet.wucQuanLyBaiViet" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<div id="body" class="clearfix">
    <div class="wrapper">
        <div class="col">
            <table>
                <tr>
                    <td colspan="2" align="center">
                        <h2>
                            <asp:LinkButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" ValidationGroup="1">Cập nhật</asp:LinkButton>
                            &nbsp;-&nbsp;
                            <asp:LinkButton runat="server" ID="btnThem" CssClass="new-study-model" OnClick="btnThem_Click"
                                Text="Thêm" ValidationGroup="1"></asp:LinkButton>
                            &nbsp;-&nbsp;
                            <asp:LinkButton runat="server" ID="btnXoa" CssClass="new-study-model" OnClick="btnXoa_Click"
                                Text="Xóa" OnClientClick="delete_onclick()"></asp:LinkButton>
                                <script type="text/javascript">
                                    function delete_onclick() {
                                        return confirm("Ban co chac chan la se xoa");
                                    }

                                </script>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>                        
                        <asp:Literal runat="server" ID="lbThongBao" Visible="false"></asp:Literal>
                    </td>
                </tr>
            </table>
            <h1>Thông tin Bài Viết</h1>
            <asp:Panel runat="server" ID="UpdatePanel">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="text-align:left;">
                            <tr>
                                <td>Tiêu đề</td>
                                <td>
                                    <asp:TextBox ID="txttieude" runat="server" CssClass="field-input" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttieude"
                                        ErrorMessage="Mời bạn nhập Tiêu Đề" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Chuyên mục
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlChuyenMuc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChuyenMuc_SelectedIndexChanged"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <tr>
                                        <td>
                                            Loại bài viết
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLoaiBaiViet" runat="server" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <tr>
                                <td>
                                    Ngày đăng
                                </td>
                                <td>
                                    <asp:Label ID="lblNgayDang" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ngày cập nhật
                                </td>
                                <td>
                                      <asp:Label ID="lblNgayCapNhat" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Ảnh đại diện</td>
                                <td>
                                    <asp:FileUpload ID="fulImage" runat="server" />
                                    <asp:Image ID="imgAnhDaiDien" runat="server" Width="100px" Height="100px" ImageUrl="~/images/avatar.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tóm tắt
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTomTat" runat="server" Height="93px" TextMode="MultiLine" Width="441px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                  
              
              
                        <table>
                            <tr>
                                <td>
                                    Nội dung</td>
                            </tr>
                            <tr>
                                <td>
                                    <FCKeditorV2:FCKeditor ID="txtnoidung" runat="server" Width="800px" Height="500px" >
                                    </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
                        </table>
                          
                <div class="post-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="PanelMessage" runat="server">
                                <div class="message" style="width: 90%; display: table; background-image: url('./images/icon-error.gif');
                                    background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat;
                                    border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
                                    Chưa có dữ liệu
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PanelDanhSach" runat="Server">
                                <asp:GridView ID="GridViewTapTin" runat="server" AutoGenerateColumns="False" CssClass="tablestyle"
                                    DataKeyNames="mataptin" CellPadding="4" EnableModelValidation="True" ForeColor="#333333"
                                    GridLines="None" onrowcommand="GridViewTapTin_RowCommand" 
                                   >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField HeaderText="STT" />
                                        <asp:HyperLinkField DataNavigateUrlFields="duongdan" DataTextField="tentaptin" HeaderText="Tập tin"
                                            ItemStyle-Width="30%" NavigateUrl="~/Default.aspx" SortExpression="mataptin">
                                            <ItemStyle Width="30%" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="duongdan" HeaderText="Đường dẫn" />
                                         <asp:TemplateField HeaderText="Xóa tập tin" >
                                     <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="XoaTapTin" CommandArgument='<%#Eval("mataptin") %>' OnClientClick="delete_onclick()">Xóa</asp:LinkButton>
                                    </ItemTemplate>                   
                                    </asp:TemplateField>    
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="PanelBtnUpload" runat="server" Style="margin-top: 10px;">
                                <asp:Button ID="btnUploadFiles" runat="server" Text="Upload Files" OnClick="btnUploadFiles_Click" />
                            </asp:Panel>
                            <asp:Panel ID="PanelUploadTapTinBaiViet" runat="server" Visible="false">
                                <asp:FileUpload ID="FileUploadTapTin" runat="server" />
                                <asp:Label ID="LabelUploadStatus" runat="server"></asp:Label>
                                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                    ValidationGroup="1" />
                            </asp:Panel>
                            <asp:Panel ID="PanelDownload" runat="server">
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUpLoad" />
                            <asp:AsyncPostBackTrigger ControlID="GridViewTapTin" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                    </ContentTemplate>       
                </asp:UpdatePanel>
                <br />
            </asp:Panel>
        </div>
    </div>
</div>
