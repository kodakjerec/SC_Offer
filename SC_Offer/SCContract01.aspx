<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCContract01.aspx.cs" Inherits="SC_Offer.SCContract01" %>

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

    <title>SC合約</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    SC合約
                </td>
            </tr>
            <tr>
                <td class="HeaderStyle ">
                    <asp:Label ID="lbl_QueryQuote" runat="server" Text="SC合約查詢"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <table id="Table_Query" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lb_strno" runat="server" Text="報價對象"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tb_strno" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lb_siteno" runat="server" Text="倉別"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList_siteno" runat="server">
                    <asp:ListItem Value="DC1">DC1,觀音</asp:ListItem>
                    <asp:ListItem Value="DC2">DC2,岡山</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_goono" runat="server" Text="貨號"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tb_goono" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox_IsShowStopFlag" runat="server" Text="顯示已截止的合約" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btn_Query" runat="server" Text="查詢" OnClick="btn_Query_Click" />
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lbl_Count" runat="server" Text="共0筆"></asp:Label>
            </td>
        </tr>
        <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
            Width="100%" AllowPaging="True" OnRowDataBound="gv_List_RowDataBound">
            <HeaderStyle CssClass="GVHead" />
            <RowStyle CssClass="one" />
            <Columns>
                <asp:BoundField DataField="site_no" HeaderText="倉別" />
                <asp:BoundField DataField="goo_no" HeaderText="貨號" />
                <asp:BoundField DataField="contract_date_s" HeaderText="合約起" DataFormatString="{0:yyyy/MM/dd}"
                    HtmlEncode="False" />
                <asp:BoundField DataField="contract_date_e" HeaderText="合約迄" DataFormatString="{0:yyyy/MM/dd}"
                    HtmlEncode="False" />
                <asp:BoundField DataField="sc_date_s" HeaderText="銷補起" DataFormatString="{0:yyyy/MM/dd}"
                    HtmlEncode="False" />
                <asp:BoundField DataField="sc_date_e" HeaderText="銷補迄" DataFormatString="{0:yyyy/MM/dd}"
                    HtmlEncode="False" />
                <asp:BoundField DataField="dc2xd_date_s" HeaderText="DC2XD起" DataFormatString="{0:yyyy/MM/dd}"
                    HtmlEncode="False" />
                <asp:BoundField DataField="dc2xd_date_e" HeaderText="DC2XD迄" DataFormatString="{0:yyyy/MM/dd}"
                    HtmlEncode="False" />
                <asp:TemplateField HeaderText="一次性進貨">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="截止">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Memo" HeaderText="截止原因" />
            </Columns>
            <PagerStyle CssClass="GVPage" />
            <EmptyDataRowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </table>
    </form>
</body>
</html>
