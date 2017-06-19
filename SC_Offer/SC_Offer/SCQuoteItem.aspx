<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCQuoteItem.aspx.cs" Inherits="SC_Offer.SCQuoteItem" %>

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

        function DisplayTd(Show) {
            if (Show == '0') {
                //                document.getElementById('TD_1').style.display = "inline";
                document.getElementById('UpdatePanel1').style.display = "inline";
            }
            if (Show == '1') {
                //                document.getElementById('TD_1').style.display = "none";
                document.getElementById('UpdatePanel1').style.display = "none";

            }
        }

        function DisplayBtn() {

            document.getElementById('TD_1').style.display = "inline";
            document.getElementById('btn_Update').style.display = "none";
            document.getElementById('btn_Del').style.display = "none";
            document.getElementById('btn_Submit').style.display = "inline";
            document.getElementById("ddl_WorkName").value = "";

            document.getElementById("hid_SySNo").value = "";
            document.getElementById("lbl_ChargeCate").innerText = "";
            document.getElementById("lbl_WorkType").innerText = "";
            document.getElementById("hid_WorkType").value = "";
            document.getElementById("lbl_ChargeType").innerText = "";
            document.getElementById("hid_ChargeType").value = "";
            document.getElementById("lbl_ChageAmount").innerText = "";
            document.getElementById("ddl_EndProc").value = "";
            document.getElementById("ddl_ObjectType").value = "";
            document.getElementById("txb_ObjectCode").value = "";
            document.getElementById("txb_OfferQty").value = "";
            document.getElementById("txb_ContractDateS").value = "";
            document.getElementById("txb_ContractDateE").value = "";
            document.getElementById("txb_ScDateS").value = "";
            document.getElementById("txb_ScDateE").value = "";
            document.getElementById("txb_MemoD").value = "";
            document.getElementById("txb_ContractDateS").disabled = false;
            document.getElementById("txb_ScDateS").disabled = false;
            document.getElementById("txb_DC2XD_DateS").value = "";
            document.getElementById("txb_DC2XD_DateE").value = "";
            document.getElementById("txb_DC2XD_DateS").disabled = false;
            document.getElementById("txb_AmountDateS").disabled = false;
            document.getElementById("txb_AmountDateS").value = "";
            document.getElementById("txb_AmountDateE").value = "";


        }

        function d() {
            $(document).ready(function() {

                $("#txb_EffectDateS").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_EffectDateE").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_ContractDateS").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_ContractDateE").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_ScDateS").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_ScDateE").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_StopDate").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_DC2XD_DateS").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_DC2XD_DateE").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_AmountDateS").datepick({ dateFormat: 'yyyy-mm-dd' });
                $("#txb_AmountDateE").datepick({ dateFormat: 'yyyy-mm-dd' });
            });
        }
       
    </script>

    <title>綜合性報價</title>
</head>
<body topmargin="0" leftmargin="0" onload="DisplayTd('1')">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    綜合性報價
                </td>
            </tr>
            <tr>
                <td class="HeaderStyle ">
                    <asp:Label ID="lbl_QuoteIrem" runat="server" Text="綜合性報價明細"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_OfferNo" runat="server" Text="報價單號:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:Label ID="lblOfferNoEx" runat="server" Text=""></asp:Label>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_Object" runat="server" Text="報價對象:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:Label ID="lblObject" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_ContractAres" runat="server" Text="影響範圍:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_Ares" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btn_InsAres" runat="server" Text="加入" OnClick="btn_InsAres_Click"
                        OnClientClick="document.getElementById('hid_Change').value='1';" />
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lblDC" runat="server" Text="倉別:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:Label ID="lbl_DC" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="3">
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
                    <asp:Label ID="lbl_Tax" runat="server" Text="含稅確認:"></asp:Label>
                </td>
                <td width="35%" class="rbt">
                    <asp:RadioButtonList ID="rbt_Tax" runat="server" RepeatColumns="2" onclick="document.getElementById('hid_Change').value='1';">
                    </asp:RadioButtonList>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_EffectDate" runat="server" Text="報價有效期:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_EffectDateS" runat="server" onblur="document.getElementById('hid_Change').value='1';"></asp:TextBox>
                    ~
                    <asp:TextBox ID="txb_EffectDateE" runat="server" onblur="document.getElementById('hid_Change').value='1';"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_OT" runat="server" Text="一次性進貨"></asp:Label>
                </td>
                <td width="35%">
                    <asp:RadioButtonList ID="rbt_OT" runat="server" RepeatColumns="2">
                        <asp:ListItem Value="0">否</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_AutoOrder" runat="server" Text="自動拋單:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:RadioButtonList ID="rbt_AutoOrder" runat="server" RepeatColumns="2">
                        <asp:ListItem Value="0">是</asp:ListItem>
                        <asp:ListItem Value="1">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_Memo" runat="server" Text="備註:"></asp:Label>
                </td>
                <td width="35%" colspan="3">
                    <asp:TextBox ID="txb_Memo" runat="server" MaxLength="250" Width="98%" onblur="document.getElementById('hid_Change').value='1';"></asp:TextBox>
                </td>
              
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td width="100%" align="center">
                    <asp:Button ID="btn_UpdateHD" runat="server" Text="更新" OnClick="btn_UpdateHD_Click" />
                </td>
            </tr>
        </table>
        <hr size="5" color="blue" />
        <asp:UpdatePanel ID="upn_OffDetail" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <asp:GridView ID="gv_List" runat="server" AutoGenerateColumns="False" CssClass="GVStyle"
                        Width="100%" AllowPaging="True" OnPageIndexChanging="gv_List_PageIndexChanging"
                        PageSize="10" OnRowCommand="gv_List_RowCommand">
                        <HeaderStyle CssClass="GVHead" />
                        <RowStyle CssClass="one" />
                        <PagerStyle CssClass="GVPage" />
                        <EmptyDataRowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript: SelectAllCheckboxes(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="5px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="hid_SysNo" runat="server" Value='<%# Bind("SysNO") %>' />
                                    <asp:HiddenField ID="hid_WorkCode" runat="server" Value='<%# Bind("Work_Code") %>' />
                                    <asp:HiddenField ID="hid_WorkType" runat="server" Value='<%# Bind("Work_Type") %>' />
                                    <asp:HiddenField ID="hid_ChargeCate" runat="server" Value='<%# Bind("Charge_Cate") %>' />
                                    <asp:HiddenField ID="hid_ChargeType" runat="server" Value='<%# Bind("Charge_Type") %>' />
                                    <asp:LinkButton ID="lbtn_Id" runat="server" OnClientClick="DisplayTd('0');" Text='<%# Bind("Id") %>'
                                        CommandName="Select"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="作業名稱" DataField="Work_Name">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="作業大類" DataField="Charge_CateN">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="商品代碼" DataField="Object_Code">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="合約有效起日" DataField="Contract_Dates">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="合約有效迄日" DataField="Contract_Datee">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="對應金額" DataField="Chage_amount">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table width="100%">
            <tr>
                <td width="100%">
                    <input type="button" name="btn_Add_1" value="新增" OnClick="DisplayTd('0');DisplayBtn()" />
                    <asp:Button ID="btn_Cancel" runat="server" Text="取消" OnClick="btn_Cancel_Click" />
                    <asp:Button ID="btn_Print" runat="server" Text="列印" OnClick="btn_Print_Click" />
                    <asp:Button ID="btn_Del_Select" runat="server" Text="刪除" OnClick="btn_Del_Click1" />
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" runat="server" id="TD_1">
                    <tr>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_WorkName" runat="server" Text="作業名稱:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:DropDownList ID="ddl_WorkName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_WorkName_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hid_SySNo" runat="server" />
                        </td>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lblChargeCate" runat="server" Text="作業大類:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:Label ID="lbl_ChargeCate" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hid_ChargeCate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lblWorkType" runat="server" Text="作業類型:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:Label ID="lbl_WorkType" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hid_WorkType" runat="server" />
                        </td>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lblChargeType" runat="server" Text="收費類型:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:Label ID="lbl_ChargeType" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hid_ChargeType" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lblChageAmount" runat="server" Text="對應金額:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:Label ID="lbl_ChageAmount" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_EndProc" runat="server" Text="後續處理:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:DropDownList ID="ddl_EndProc" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_ObjectType" runat="server" Text="作業商品:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:DropDownList ID="ddl_ObjectType" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_ObjectCode" runat="server" Text="商品代碼:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="txb_ObjectCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_OfferQty" runat="server" Text="數量:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="txb_OfferQty" runat="server"></asp:TextBox>
                        </td>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_ContractDate" runat="server" Text="合約起迄日:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="txb_ContractDateS" runat="server" onclick="d();"></asp:TextBox>
                            ~<asp:TextBox ID="txb_ContractDateE" runat="server" onclick="d();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_ScDate" runat="server" Text="SC補貨起迄日"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="txb_ScDateS" runat="server" onclick="d();"></asp:TextBox>
                            ~<asp:TextBox ID="txb_ScDateE" runat="server" onclick="d();"></asp:TextBox>
                        </td>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_StopDate" runat="server" Text="終止日"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="txb_StopDate" runat="server" onclick="d();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="DC2XD" runat="server" Text="DC2XD起訖日:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="txb_DC2XD_DateS" runat="server" onclick="d();"></asp:TextBox>
                            ~
                            <asp:TextBox ID="txb_DC2XD_DateE" runat="server" onclick="d();"></asp:TextBox>
                        </td>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_AmountDate" runat="server" Text="計價期間:"></asp:Label>
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="txb_AmountDateS" runat="server" onclick="d();"></asp:TextBox>
                            ~
                            <asp:TextBox ID="txb_AmountDateE" runat="server" onclick="d();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="EditTD1" width="15%">
                            <asp:Label ID="lbl_MemoD" runat="server" Text="備註:"></asp:Label>
                        </td>
                        <td width="35%" colspan="3">
                            <asp:TextBox ID="txb_MemoD" runat="server" Width="98%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btn_Update" runat="server" Text="更新" OnClick="btn_Update_Click" />
                            <asp:Button ID="btn_Submit" runat="server" Text="確定" OnClick="btn_Submit_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btn_Del" runat="server" Text="刪除" OnClick="btn_Del_Click" OnClientClick="if(!confirm('確認要刪除？')){return false;}" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table width="100%">
        </table>
    </div>
    <asp:HiddenField ID="hid_Change" runat="server" />
    <asp:HiddenField ID="hid_OTFlg" runat="server" />
    <asp:HiddenField ID="hid_SysOfferNo" runat="server" />
    <asp:HiddenField ID="hid_Obj" runat="server" />
    <asp:HiddenField ID="hid_City" runat="server" />
    <asp:HiddenField ID="hid_DC" runat="server" />
    <asp:HiddenField ID="hid_XmsSc" runat="server" />
    </form>
</body>
</html>
