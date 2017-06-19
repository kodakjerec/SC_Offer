<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCObject.aspx.cs" Inherits="SC_Offer.SCObject" %>

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

    <title>作業對象</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    <asp:Label ID="lbl_TypeFee" runat="server" Text="作業對象查詢"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_ObjNo" runat="server" Text="對象代碼:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_ObjNo" runat="server"></asp:TextBox>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_ObjName" runat="server" Text="對象名稱:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_ObjName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btn_Query" runat="server" Text="查詢" OnClick="btn_Query_Click" />
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td width="50%">
                    <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
                        Width="100%" AllowPaging="True" OnPageIndexChanging="gv_List_PageIndexChanging"
                        PageSize="15" AllowSorting="True" OnRowEditing="gv_List_RowEditing">
                        <HeaderStyle CssClass="GVHead" />
                        <RowStyle CssClass="one" />
                        <PagerStyle CssClass="GVPage" />
                        <EmptyDataRowStyle HorizontalAlign="Center" />
                        <%--   <AlternatingRowStyle CssClass="two" />--%>
                        <Columns>
                            <asp:CommandField ButtonType="Button" EditText="選取" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:CommandField>
                            <asp:BoundField HeaderText="對象代碼" DataField="S_supd_id">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="對象名稱" DataField="N_supd_name">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
