<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCSupQuery.aspx.cs" Inherits="SC_Offer.SCSupQuery" %>

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

    <title>供應商資料</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    供應商資料
                </td>
            </tr>
            <tr>
                <td class="HeaderStyle ">
                    <asp:Label ID="lbl_SupQy" runat="server" Text="供應商查詢"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_SupID" runat="server" Text="供應商代碼:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_SupID" runat="server" MaxLength="6"></asp:TextBox>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_SupName" runat="server" Text="供應商名稱:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_SupName" runat="server" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <asp:Button ID="btn_Query" runat="server" Text="查詢" OnClick="btn_Query_Click" />
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="lbl_Count" runat="server" Text="共0筆"></asp:Label>
                </td>
            </tr>
            <tr align="Left">
                <td width="70%">
                    <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
                        Width="70%" AllowPaging="True" OnPageIndexChanging="gv_List_PageIndexChanging"
                        PageSize="15" OnRowCommand="gv_List_RowCommand">
                        <HeaderStyle CssClass="GVHead" />
                        <RowStyle CssClass="one" />
                        <PagerStyle CssClass="GVPage" />
                        <EmptyDataRowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="供應商名稱">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_SupAllNa" runat="server" Text='<%# Bind("SupAllNa") %>'
                                        CommandName="Select"></asp:LinkButton>
                                    <asp:HiddenField ID="hid_SupSn" runat="server" Value='<%# Bind("SupSn") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
