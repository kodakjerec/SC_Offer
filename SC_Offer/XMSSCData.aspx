<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMSSCData.aspx.cs" Inherits="SC_Offer.XMSSCData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        [disabled]#Button
        {
            color: #933;
            background-color: #ffc;
        }
    </style>

    <script src="js/jquery-1.4.2.js" type="text/javascript"></script>

    <script src="js/jquery.datepick.js" type="text/javascript"></script>

    <script src="js/jquery.datepick-zh-TW.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function() {
            $("input[type=text][id*=txb_contract_date_s]").datepick({ dateFormat: 'yyyy/mm/dd' });
            $("input[type=text][id*=txb_contract_date_e]").datepick({ dateFormat: 'yyyy/mm/dd' });
            $("input[type=text][id*=txb_sc_date_s]").datepick({ dateFormat: 'yyyy/mm/dd' });
            $("input[type=text][id*=txb_sc_date_e]").datepick({ dateFormat: 'yyyy/mm/dd' });
        });
    </script>

    <title>SC合約維護</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding:20px">
        <asp:Label ID="lbl_goo_no" runat="server" Text="貨號"></asp:Label>
        <asp:TextBox ID="txb_goo_no" runat="server" Width="100px" class="easyui-textbox" style="width:100;height:38px">01130070</asp:TextBox>
        <asp:Button ID="btn_Query" runat="server" Text="Search" OnClick="btn_Query_Click"  class="easyui-linkbutton"  iconCls="icon-search" />
        只能查詢一年內的合約
    </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lbl_Count" runat="server" Text="共0筆"></asp:Label>
            </td>
        </tr>
        <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
            Width="100%" AllowPaging="True" PageSize="20" OnPageIndexChanging="gv_List_PageIndexChanging"
            OnRowEditing="gv_List_RowEditing" OnRowDataBound="gv_List_RowDataBound" OnRowCancelingEdit="gv_List_RowCancelingEdit"
            OnRowUpdating="gv_List_RowUpdating" OnRowCommand="gv_List_RowCommand">
            <HeaderStyle CssClass="GVHead" />
            <RowStyle CssClass="one" />
            <PagerStyle CssClass="GVPage" />
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField HeaderText="倉別">
                    <EditItemTemplate>
                        <asp:Label ID="TextBox3" runat="server" Text='<%# Bind("site_no") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("site_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="貨號">
                    <EditItemTemplate>
                        <asp:Label ID="TextBox2" runat="server" Text='<%# Bind("goo_no") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("goo_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="品名規格">
                    <EditItemTemplate>
                        <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("N_merd_name") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("N_merd_name") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="合約日期S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txb_contract_date_s" runat="server" Text='<%# Bind("Contract_date_s", "{0:yyyy/MM/dd}") %>'
                            Width="60%"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Contract_date_s", "{0:yyyy/MM/dd}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="合約日期E">
                    <EditItemTemplate>
                        <asp:TextBox ID="txb_contract_date_e" runat="server" Text='<%# Bind("Contract_date_e", "{0:yyyy/MM/dd}") %>'
                            Width="60%"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Contract_date_e", "{0:yyyy/MM/dd}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SC銷補S">
                    <EditItemTemplate>
                        <asp:TextBox ID="txb_sc_date_s" runat="server" Text='<%# Bind("sc_date_s", "{0:yyyy/MM/dd}") %>'
                            Width="60%"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("sc_date_s", "{0:yyyy/MM/dd}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SC銷補E">
                    <EditItemTemplate>
                        <asp:TextBox ID="txb_sc_date_e" runat="server" Text='<%# Bind("sc_date_e", "{0:yyyy/MM/dd}") %>'
                            Width="60%"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("sc_date_e", "{0:yyyy/MM/dd}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" DataTextField="stop_date" DataTextFormatString="{0:yyyy/MM/dd}"
                    Text="按鈕" HeaderText="截止日" CommandName="btn_Stop_date" />
                <asp:TemplateField HeaderText="級配">
                    <EditItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("SnFlag") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("SnFlag") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </table>
    </form>
</body>
</html>
