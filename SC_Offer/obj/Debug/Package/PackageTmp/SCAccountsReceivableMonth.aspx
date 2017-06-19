<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCAccountsReceivableMonth.aspx.cs" Inherits="SC_Offer.SCAccountsReceivableMonth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
    <title>SC應收表(月)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div_Query">
    <table class="tborder">
            <tr>
                <td class="EditTD1">
                    供應商編號：
                </td>
                <td>
                    <asp:TextBox ID="Txb_S_qthe_SupdId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="EditTD1">
                    報價日期：
                </td>
                <td>
                    <asp:TextBox ID="txb_D_qthe_ContractS_Qry" runat="server" />
                    至
                    <asp:TextBox ID="txb_D_qthe_ContractE_Qry" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_Query" runat="server" Text="查詢" OnClick="btn_Query_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="Div_Quotation" runat="server" visible="false">
                <table class="tborder" width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="GV_Quotation_Query" runat="server" Width="100%" AutoGenerateColumns="False"
                                CssClass="GVStyle" AllowPaging="True" PageSize="5" OnPageIndexChanging="GV_Quotation_Query_PageIndexChanging"
                                OnRowDataBound="GV_Quotation_Query_RowDataBound" OnRowCommand="GV_Quotation_Query_RowCommand">
                                <HeaderStyle CssClass="GVHead" />
                                <RowStyle CssClass="one" />
                                <AlternatingRowStyle CssClass="two" />
                                <PagerStyle CssClass="GVPage" />
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="供應商" HeaderText="供應商" />

                                    <asp:BoundField DataField="S_qthe_Memo" HeaderText="備註" />
                                    <asp:BoundField DataField="建單人" HeaderText="建單人" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
