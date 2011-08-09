<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/main_3col.Master" AutoEventWireup="true"
    CodeBehind="MuonPhong.aspx.cs" Inherits="WebDoanHoi_layout.MuonPhong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPost" runat="server">
    <div id="BVNoiBatDiv">
        <input type="button" id="btnDangKyPhong" OnClick="dangky_onclick()" value="Đăng ký phòng" 
            ></input>
       <script type="text/javascript">
           function dangky_onclick() {
               $('#formDangKyPhong').show('slow');
       }
       </script>
        <div id="formDangKyPhong" style="display:none" >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Đăng Ký Mượn Phòng" Font-Size="X-Large"
                        ForeColor="#000099"></asp:Label>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtMaNguoiDung" runat="server" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMaNguoiDung"
                                    ErrorMessage="Mời bạn nhập mã người dùng" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 213px">
                                <asp:Label ID="Label2" runat="server" Text="Ngày Mượn"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNgayMuon" class="DateTimeMuonPhong" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNgayMuon"
                                    ErrorMessage="Mời bạn nhập ngày mượn" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 213px">
                                <asp:Label ID="Label7" runat="server" Text="Thời gian từ"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTGTu" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTGTu"
                                    ErrorMessage="Mời bạn nhập giờ mượn" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 213px">
                                <asp:Label ID="Label9" runat="server" Text="Thời gian đến"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTGDen" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTGDen"
                                    ErrorMessage="Mời bạn nhập giờ mượn" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 213px">
                                <asp:Label ID="Label3" runat="server" Text="Số Lượng dự kiến"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSoLuong"
                                    ErrorMessage="Mời bạn nhập số lượng" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 213px">
                                <asp:Label ID="Label4" runat="server" Text="Mục Đích"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMucDich" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMucDich"
                                    ErrorMessage="Mời bạn nhập mục đích mượn" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 213px">
                                <asp:Label ID="Label5" runat="server" Text="Đơn Vị Mượn"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDonViMuon" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDonViMuon"
                                    ErrorMessage="Mời bạn nhập đơn vị mượn" ValidationGroup="MuonPhong"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 213px" colspan="2">
                                <asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 213px" colspan="2">
                                <asp:Button ID="btnDangKy" runat="server" OnClick="Button2_Click1" Text="Đăng Ký"
                                    ValidationGroup="MuonPhong" />
                                <asp:Label ID="lbDangKy" runat="server" ForeColor="Red" Text="Bạn phải đăng nhập mới được phép đăng ký"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="PanelMessage" runat="server">
                        <div class="message" style="width: 90%; display: table; background-image: url('./images/icon-error.gif');
                            background-color: #FFFFCC; background-position: 10px 50%; background-repeat: no-repeat;
                            border: 0.1em solid #CC0000; margin: 0.5em 0; padding: 10px 10px 10px 36px;">
                            Chưa có dữ liệu
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
      </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel ID="PanelDanhSach" runat="server">
                    <div class="options">
                        <asp:GridView ID="GridViewDanhSachPhongMuon" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="tablestyle" DataKeyNames="madangky" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" EnableModelValidation="True"
                            Style="margin-right: 297px" 
                            onrowcommand="GridViewDanhSachPhongMuon_RowCommand" 
                            onselectedindexchanged="GridViewDanhSachPhongMuon_SelectedIndexChanged">
                            <%--onpageindexchanging="GridViewLoaiVaiTro_PageIndexChanging"--%>
                            <Columns>
                                <asp:BoundField DataField="madangky" HeaderText="Mã Đăng Ký" Visible="False" />
                                <asp:BoundField DataField="username" HeaderText="UserName" Visible="False" />
                                <asp:BoundField DataField="ngaysudung" HeaderText="Ngày Mượn" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="TGBatDau" HeaderText="Từ lúc" />
                                <asp:BoundField DataField="TGKetThuc" HeaderText="Đến lúc" />
                                <asp:BoundField DataField="KQPhong" HeaderText="Đã duyệt" />
                                <asp:TemplateField HeaderText="Chi tiết" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Xem" CommandArgument='<%#Eval("madangky") %>'>Xem chi tiết</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:Label ID="Label8" runat="server" Text="Chọn số dòng hiển thị: "></asp:Label>
                        <asp:DropDownList ID="DropDownListPaging" runat="server" AutoPostBack="True">
                            <%--onselectedindexchanged="DropDownListPaging_SelectedIndexChanged"--%>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem Selected="True">10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
       
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
             <div id="chiTiet">
            <asp:DetailsView ID="dvMuonPhong" runat="server" Height="50px" 
                EnableModelValidation="True" AutoGenerateRows ="False" >
                <Fields>
                    <asp:BoundField DataField="madangky" HeaderText="Mã đăng ký" ReadOnly="True" />
                    <asp:BoundField DataField="ngaydangky" DataFormatString="{0:g}" 
                        HeaderText="Ngày đăng ký" />
                    <asp:BoundField DataField="ngaysudung" HeaderText="Ngày sử dụng" 
                        DataFormatString="{0:d}" />
                    <asp:BoundField DataField="TGBatDau" HeaderText="Thời gian bắt đầu" />
                    <asp:BoundField DataField="TGKetThuc" HeaderText="Thời gian kết thúc" />
                    <asp:BoundField DataField="SoLuong" HeaderText="Số lượng người" />
                    <asp:BoundField DataField="mucdich" HeaderText="Mục đích sử dụng" />
                    <asp:BoundField DataField="donvimuon" HeaderText="Đơn vị mượn" />
                    <asp:BoundField DataField="kqphong" HeaderText="Kết quả phòng" />
                    <asp:BoundField DataField="ketqua" HeaderText="Tình trạng" />
                </Fields>
            </asp:DetailsView>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </asp:Content>
