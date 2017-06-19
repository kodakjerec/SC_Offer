<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCQueryQuote.aspx.cs" Inherits="SC_Offer.SCQueryQuote" %>

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
    $(document).ready(function() 
        { 
        $("#txb_EffectDateS").datepick({ dateFormat: 'yyyy-mm-dd'}); 
        }); 
    </script>

    <title>綜合性報價</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    綜合性報價
                </td>
            </tr>
            <tr>
                <td class="HeaderStyle ">
                    <asp:Label ID="lbl_QueryQuote" runat="server" Text="綜合性報價查詢"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td class="EditTD1" width="15%">
                    報價對象:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_Object" runat="server"></asp:TextBox>
                </td>
                <td class="EditTD1" width="15%">
                    報價單號:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_OfferNoExt" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    物流中心:
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_Area" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="EditTD1" width="15%">
                    報價有效起日:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_EffectDateS" runat="server"></asp:TextBox>
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
            <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
                Width="100%" AllowPaging="True" OnPageIndexChanging="gv_List_PageIndexChanging"
                PageSize="15" OnRowCommand="gv_List_RowCommand">
                <HeaderStyle CssClass="GVHead" />
                <RowStyle CssClass="one" />
                <AlternatingRowStyle CssClass="two" />
                <PagerStyle CssClass="GVPage" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="報價單號">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_Offer_No" runat="server" Text='<%# Bind("Offer_No_Ext") %>'
                                CommandName="Select"></asp:LinkButton>
                            <asp:HiddenField ID="hid_SysOfferNo" runat="server" Value='<%# Bind("Offer_No") %>' />
                            <asp:HiddenField ID="hid_Object" runat="server" Value='<%# Bind("Object_No") %>' />
                            <asp:HiddenField ID="hid_DC" runat="server" Value='<%# Bind("Ware") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="報價對象" DataField="SupName">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="物流中心" DataField="DC">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <%--<asp:BoundField HeaderText="後續處理" DataField="EP">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>--%>
                    <asp:BoundField HeaderText="報價有效起日" DataField="Effect_Dates">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="報價有效迄日" DataField="Effect_Datee">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <%-- <asp:BoundField HeaderText="合約期間起日" DataField="Contract_Dates">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="合約期間起日" DataField="Contract_Datee">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                </Columns>
            </asp:GridView>
        </table>
    </div>
    </form>
</body>
</html>
