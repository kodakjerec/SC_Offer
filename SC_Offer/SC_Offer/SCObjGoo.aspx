<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCObjGoo.aspx.cs" Inherits="SC_Offer.SCObjGoo" %>

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

    <script type="text/javascript">
        function SelectAllCheckboxes(spanChk) {
            elm = document.forms[0];
            for (i = 0; i <= elm.length - 1; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != spanChk.id) {
                    if (elm.elements[i].checked != spanChk.checked)
                        elm.elements[i].click();
                }
            }
        }
    </script>

    <title>作業品項</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    作業品項
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lblObj" runat="server" Text="作業對象:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:Label ID="lbl_Obj" runat="server" Text=""></asp:Label>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_ItemID" runat="server" Text="貨號:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_ItemID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_Query" runat="server" Text="查詢" onclick="btn_Query_Click" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnl_ItemList" runat="server">
            <table width="100%">
                <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
                    Width="50%" AllowPaging="True" OnPageIndexChanging="gv_List_PageIndexChanging"
                    PageSize="15" AllowSorting="True">
                    <HeaderStyle CssClass="GVHead" />
                    <RowStyle CssClass="one" />
                    <PagerStyle CssClass="GVPage" />
                    <EmptyDataRowStyle HorizontalAlign="Center" />
                    <%--   <AlternatingRowStyle CssClass="two" />--%>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript: SelectAllCheckboxes(this);"/>
                                   
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="5px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="貨號" DataField="Offer_No_Ext">
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="品名" DataField="Charge_CateName">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </table>
            <table width="100%">
                <asp:Button ID="btn_Add" runat="server" Text="加入" onclick="btn_Add_Click" />
            </table>
        </asp:Panel>
        <hr size="5" color="blue" /> 
        <asp:Panel ID="pnl_AddItem" runat="server">
        <table width="100%">
         <asp:GridView ID="gv_AddList" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
                    Width="50%"
                     AllowSorting="True" onrowcommand="gv_AddList_RowCommand">
                    <HeaderStyle CssClass="GVHead" />
                    <RowStyle CssClass="one" />
                    <PagerStyle CssClass="GVPage" />
                    <EmptyDataRowStyle HorizontalAlign="Center" />
                    <%--   <AlternatingRowStyle CssClass="two" />--%>
                    <Columns>
                        <asp:BoundField HeaderText="貨號" DataField="Offer_No_Ext">
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="品名" DataField="Charge_CateName">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Button" CommandName="Delete_Edu" Text="移除" HeaderText="移除" >
                         <ItemStyle HorizontalAlign="Center" Width="50" />
                         </asp:ButtonField>
                    </Columns>
                </asp:GridView>
        </table>
        <table width="100%">
            <asp:Button ID="btn_Submit" runat="server" Text="確定" 
                onclick="btn_Submit_Click" />
        </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
