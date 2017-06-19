<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCTypeQuery.aspx.cs" Inherits="SC_Offer.SCTypeQuery" %>

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

    <title>作業類別費用</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    作業類別費用
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td colspan="4" class="HeaderStyle ">
                    作業類別費用查詢
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    作業名稱:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_WorkName" runat="server"></asp:TextBox>
                </td>
                <td class="EditTD1" width="15%">
                   作業對象:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_Object" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    作業大類:
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_ChargeCate" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="EditTD1" width="15%">
                    收費類型:
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_ChargeType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    作業類型:
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_WorkType" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="EditTD1" width="15%">
                    &nbsp;</td>
                <td width="35%">
                    &nbsp;</td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_Query" runat="server" Text="查詢" onclick="btn_Query_Click" />
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
                PageSize="10" onrowcommand="gv_List_RowCommand">
                <HeaderStyle CssClass="GVHead" />
                <RowStyle CssClass="one" />
                <PagerStyle CssClass="GVPage" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="作業名稱">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%--<asp:Label ID="lbl_WorkName" runat="server" Text='<%# Bind("Work_Name") %>'></asp:Label>--%>
                            <asp:LinkButton ID="lbtn_WorkName" runat="server" Text='<%# Bind("Work_Name") %>' CommandName="Select"></asp:LinkButton>
                            <asp:HiddenField ID="hid_WorkCode" runat="server" Value='<%# Bind("Work_Code") %>' />
                            <asp:HiddenField ID="hid_Obj" runat="server"  Value='<%# Bind("Object_No") %>'/>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="作業對象" DataField="ObjName">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="作業大類" DataField="CCN">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="作業類型" DataField="WTN">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="收費類型" DataField="CTN">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="收費金額" DataField="Chage_amount">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </table>
    </div>
    </form>
</body>
</html>
