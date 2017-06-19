<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCQuote.aspx.cs" Inherits="SC_Offer.SCQuote" %>

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

        $(document).ready(function() {

            $("#txb_EffectDateS").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_EffectDateE").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_ContractDateS").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_ContractDateE").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_ScDateS").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_ScDateE").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_DC2XD_DateS").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_DC2XD_DateE").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_AmountDateS").datepick({ dateFormat: 'yyyy-mm-dd' });
            $("#txb_AmountDateE").datepick({ dateFormat: 'yyyy-mm-dd' });
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
                    <asp:Label ID="lbl_CustInf" runat="server" Text="客戶資料"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnl_Header" runat="server">
            <table width="100%">
                <tr>
                    <td class="EditTD1" width="15%">
                       <asp:Label ID="Label5" ForeColor="Red" runat="server">*</asp:Label>
                       報價對象:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txb_Object" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_Obj" runat="server" Text="選擇對象" 
                            OnClientClick="window.open('SCObject.aspx','','menubar=no,location=no');" 
                            style="height: 21px" />
                    </td>
                    <td class="EditTD1" width="15%">
                        <asp:Label ID="Label6" ForeColor="Red" runat="server">*</asp:Label>
                        影響範圍:
                    </td>
                    <td width="35%">
                        <asp:DropDownList ID="ddl_Ares" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddl_Ares_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Button ID="btn_InsAres" runat="server" Text="加入" 
                            OnClick="btn_InsAres_Click" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">
                    </td>
                    <td width="35%">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:GridView ID="gv_Area" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_Area_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="地區" DataField="City" />
                                <asp:ButtonField ButtonType="Button" CommandName="Delete_Edu" Text="移除" HeaderText="移除" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">
                        含稅確認:
                    </td>
                    <td width="35%" class="rbt">
                        <asp:RadioButtonList ID="rbt_Tax" runat="server" RepeatColumns="2">
                        </asp:RadioButtonList>
                    </td>
                    <td class="EditTD1" width="15%">
                        <asp:Label ID="Label7" ForeColor="Red" runat="server">*</asp:Label>
                        報價有效期:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txb_EffectDateS" runat="server"></asp:TextBox>
                        ~
                        <asp:TextBox ID="txb_EffectDateE" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">
                        一次性進貨:
                    </td>
                    <td width="35%" class="rbt">
                        <asp:RadioButtonList ID="rbt_OT" runat="server" RepeatColumns="2">
                            <asp:ListItem Value="0" Selected="true">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="EditTD1" width="15%">
                        自動拋單:
                    </td>
                    <td width="35%" class="rbt">
                        <asp:RadioButtonList ID="rbt_AutoOrder" runat="server" RepeatColumns="2">
                            <asp:ListItem Value="0" Selected="true">是</asp:ListItem>
                            <asp:ListItem Value="1">否</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">
                       備註:
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txb_MemoH" runat="server" MaxLength="250" Width="98%"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Submit" runat="server" Text="確定" OnClick="btn_Submit_Click" Style="height: 21px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnl_Item" runat="server">
            <table width="100%">
                <tr>
                    <td class="HeaderStyle ">
                        <asp:Label ID="lbl_Inf" runat="server" Text="報價資料"></asp:Label>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td class="EditTD1" width="15%">
                        作業名稱:
                    </td>
                    <td width="65%" colspan="3" class="rbt">
                        <asp:CheckBoxList ID="cbl_Wotk" runat="server" RepeatColumns="3">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">
                       <asp:Label ID="Label1" ForeColor="Red" runat="server">*</asp:Label>
                        作業商品:
                    </td>
                    <td width="35%">
                        <asp:DropDownList ID="ddl_ObjType" runat="server" 
                            onselectedindexchanged="ddl_ObjType_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:FileUpload ID="ful_InGoo" runat="server" />
                        <asp:Button ID="btn_InGoo" runat="server" Text="匯入" onclick="btn_InGoo_Click" 
                            style="height: 21px" />
                    </td>
                    <td class="EditTD1" width="15%">
                    <asp:Label ForeColor="Red" runat="server">*</asp:Label>
                        作業商品代碼:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txb_ObjCode" runat="server" MaxLength="14"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">
                    <asp:Label ID="Label2" ForeColor="Red" runat="server">*</asp:Label>
                        作業數量:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txb_Qty" runat="server" onkeyup="if (isNaN(value)) value='';" onblur="if (isNaN(value)) value='';"
                            MaxLength="10"></asp:TextBox>
                    </td>
                    <td class="EditTD1" width="15%">
                    <asp:Label ID="Label3" ForeColor="Red" runat="server">*</asp:Label>
                        後續處理:
                    </td>
                    <td width="35%">
                        <asp:DropDownList ID="ddl_End" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="EditTD1" width="15%">
                    <asp:Label ID="Label4" ForeColor="Red" runat="server">*</asp:Label>
                        合約期間:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txb_ContractDateS" runat="server"></asp:TextBox>
                        ~
                        <asp:TextBox ID="txb_ContractDateE" runat="server"></asp:TextBox>
                    </td>
                    <td class="EditTD1" width="15%">
                       SC開始補貨日期:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txb_ScDateS" runat="server"></asp:TextBox>
                        ~<asp:TextBox ID="txb_ScDateE" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td  class="EditTD1" width="15%">
                   DC2XD起迄日:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_DC2XD_DateS" runat="server"></asp:TextBox>
                    ~<asp:TextBox ID="txb_DC2XD_DateE" runat="server"></asp:TextBox>
                </td>
                 <td  class="EditTD1" width="15%">
                     計價期間:
                 </td>
                <td width="35%">
                    <asp:TextBox ID="txb_AmountDateS" runat="server"></asp:TextBox>
                    ~<asp:TextBox ID="txb_AmountDateE" runat="server"></asp:TextBox>
                </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_ItemIns" runat="server" OnClick="btn_ItemIns_Click" Text="新增" />
                    </td>
                </tr>
            </table>
            <table width="100%">
                <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
                    Width="100%" AllowPaging="True" OnPageIndexChanging="gv_List_PageIndexChanging"
                    PageSize="15" AllowSorting="True" OnRowCommand="gv_List_RowCommand">
                    <HeaderStyle CssClass="GVHead" />
                    <RowStyle CssClass="one" />
                    <PagerStyle CssClass="GVPage" />
                    <EmptyDataRowStyle HorizontalAlign="Center" />
                    <%--   <AlternatingRowStyle CssClass="two" />--%>
                    <Columns>
                        <asp:ButtonField ButtonType="Button" Text="刪除" CommandName="Delete_Edu">
                            <ItemStyle HorizontalAlign="Center" Width="5" />
                        </asp:ButtonField>
                        <asp:BoundField HeaderText="報價單號" DataField="Offer_No_Ext">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作業大類" DataField="Charge_CateName">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作業名稱" DataField="Work_Name">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="收費類型" DataField="Charge_TypeName">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="金額" DataField="Chage_amount">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作業商品" DataField="Object_TypeName">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作業商品代碼" DataField="Object_Code">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作業數量" DataField="Offer_Qty">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="合約起日" DataField="Contract_Dates">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="合約迄日" DataField="Contract_Datee">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="備註" DataField="Memo">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </table>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_ItemSubmit" runat="server" Text="確定" OnClick="btn_ItemSubmit_Click"
                            Visible="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:HiddenField ID="hid_SysOfferNo" runat="server" />
        <asp:HiddenField ID="hid_City" runat="server" />
        <asp:HiddenField ID="hid_Way" runat="server" />
    </div>
    </form>
</body>
</html>
