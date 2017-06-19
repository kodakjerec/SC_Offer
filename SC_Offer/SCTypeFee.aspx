<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCTypeFee.aspx.cs" Inherits="SC_Offer.SCTypeFee" %>

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
                    <asp:Label ID="lbl_TypeFee" runat="server" Text="作業類別費用"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td colspan="4" class="HeaderStyle ">
                    <asp:Label ID="lbl_Attribute" runat="server" Text="作業類別費用新增"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_WorkName" runat="server" Text="作業名稱:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_WorkName" runat="server" MaxLength="200"></asp:TextBox>
                    <asp:Label ID="lb_WokName" runat="server"></asp:Label>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_Object" runat="server" Text="作業對象:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_Object" runat="server"></asp:TextBox>
                    <asp:Label ID="lb_Object" runat="server"></asp:Label>
                    <asp:Button ID="btn_Obj" runat="server" Text="選擇對象" OnClientClick="window.open('SCObject.aspx','','menubar=no,location=no');"/>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_ChargeCate" runat="server" Text="作業大類:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_ChargeCate" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_ChargeType" runat="server" Text="收費類型:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_ChargeType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_Amount" runat="server" Text="對應金額:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_Amount" runat="server" onkeyup="if (isNaN(value)) value='';"
                        onblur="if (isNaN(value)) value='';"></asp:TextBox>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_WorkType" runat="server" Text="作業類型:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_WorkType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td class="EditTD1" width="15%">
                <asp:Label ID="lbl_Memo" runat="server" Text="註記:"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txb_Memo" runat="server" width="98%" MaxLength="255"></asp:TextBox>
             </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Button ID="btn_Submit" runat="server" Text="確定" OnClick="btn_Submit_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_Del" runat="server" Text="刪除" onclick="btn_Del_Click" OnClientClick="if(!confirm('確認要刪除？')){return false;}"/>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_Cancel" runat="server" Text="取消" 
                        onclick="btn_Cancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hid_ObjNO" runat="server" />
    <asp:HiddenField ID="hid_WorkCode" runat="server" />
    <asp:HiddenField ID="hid_Status" runat="server" />
    </form>
</body>
</html>
