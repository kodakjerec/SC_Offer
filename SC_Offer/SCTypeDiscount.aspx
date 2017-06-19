<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCTypeDiscount.aspx.cs" Inherits="SC_Offer.SCTypeDiscount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CSS/Style.css" type="text/css" />
    <link rel="stylesheet" href="css/validationEngine.jquery.css" type="text/css" media="screen"
        charset="utf-8" />
    <style type="text/css">
        @import "CSS/jquery.datepick.css";
    </style>

    <script src="js/jquery-1.4.2.js" type="text/javascript"></script>

    <script src="js/jquery.datepick.js" type="text/javascript"></script>

    <script src="js/jquery.datepick-zh-TW.js" type="text/javascript"></script>

    <title>作業類別費用折扣設定</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
        <div id="div_Head">
            <table width="100%">
                <tr>
                    <td class="PageTitle">作業類別費用
                    </td>
                </tr>
            </table>
            <table class="tborder" width="100%">
                <tr>
                    <td colspan="4" class="HeaderStyle ">折扣設定
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">倉別:
                    </td>
                    <td width="35%">
                        <asp:DropDownList ID="ddl_SiteNo" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">廠商代號:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txb_VendorNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">會計科目:
                    </td>
                    <td width="35%">
                        <asp:DropDownList ID="ddl_Acci_id" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_Query" runat="server" Text="查詢或更新" OnClick="btn_Query_Click" />
                        <asp:Button ID="btn_Add_Open" runat="server" Text="開啟新增" OnClick="btn_Add_Open_Click" />
                        <asp:Button ID="btn_Del_Open" runat="server" Text="開啟刪除" OnClick="btn_Del_Open_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <table width="100%">
                    <tr align="center">
                        <td>
                            <asp:Label runat="server" ID="Cre_ErrMsg" Style="color: Red" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="div_Update" runat="server" visible="false">
                    <table class="tborder" width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
                                    Width="100%" AllowPaging="True" OnPageIndexChanging="gv_List_PageIndexChanging"
                                    PageSize="20">
                                    <HeaderStyle CssClass="GVHead" HorizontalAlign="Left" />
                                    <RowStyle CssClass="one" />
                                    <PagerStyle CssClass="GVPage" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField HeaderText="倉別" DataField="Field_Name">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="廠商代號" DataField="VendorNo">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="廠商名稱" DataField="ALIAS">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="會計科目" DataField="S_Acci_Name">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="折扣">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderTemplate>
                                                折扣
                                                <asp:TextBox ID="txb_Discount_Header" runat="server" Width="50">100.00</asp:TextBox>%
                                                <asp:Button ID="btn_EditDiscount_Header" runat="server" Text="批次修改" OnClick="btn_EditDiscount_Header_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txb_Discount" runat="server" Text='<%# Bind("Discount") %>' Width="50"></asp:TextBox>%
                                                <asp:HiddenField ID="hid_Sn" runat="server" Value='<%# Bind("Sn") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table class="tborder" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btn_Submit" runat="server" Text="更新本頁資訊" OnClick="btn_Submit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_Add" runat="server" visible="false">
                    <table class="tborder" width="100%">
                        <tr>
                            <td class="EditTD1" width="15%">廠商代號:
                            </td>
                            <td width="35%">
                                <asp:TextBox ID="txb_VendorNo_Add" runat="server"></asp:TextBox>
                                三倉折扣設定相同，如欲更改請新增後，再個別查詢變更
                            </td>
                        </tr>
                        <tr>
                            <td class="EditTD1" width="15%">G21,進貨上架費:
                            </td>
                            <td width="35%">
                                <asp:TextBox ID="txb_G21_Add" runat="server" Width="50">100.00</asp:TextBox>%
                            </td>
                        </tr>
                        <tr>
                            <td class="EditTD1" width="15%">G22,倉租費:
                            </td>
                            <td width="35%">
                                <asp:TextBox ID="txb_G22_Add" runat="server" Width="50">100.00</asp:TextBox>%
                            </td>
                        </tr>
                        <tr>
                            <td class="EditTD1" width="15%">G23,理貨費:
                            </td>
                            <td width="35%">
                                <asp:TextBox ID="txb_G23_Add" runat="server" Width="50">100.00</asp:TextBox>%
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btn_Add" runat="server" Text="新增" OnClick="btn_Add_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_Del" runat="server" visible="false">
                    <table class="tborder" width="100%">
                        <tr>
                            <td class="EditTD1" width="15%">廠商代號:
                            </td>
                            <td width="35%">
                                <asp:TextBox ID="txb_VendorNo_Del" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btn_Del" runat="server" Text="刪除" OnClick="btn_Del_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
