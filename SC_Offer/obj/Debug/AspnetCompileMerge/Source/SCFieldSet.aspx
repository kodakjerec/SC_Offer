<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCFieldSet.aspx.cs" Inherits="SC_Offer.SCFieldSet" %>

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

    <title>選單設定</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    系統設定
                </td>
            </tr>
            <tr>
                <td class="HeaderStyle ">
                    <asp:Label ID="lbl_CustInf" runat="server" Text="選單設定"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_Cate" runat="server" Text="選單種類:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_Cate" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="EditTD1" width="15%">
                </td>
                <td width="35%">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_Add" runat="server" Text="新增" OnClick="btn_Add_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btn_Upd" runat="server" Text="更新" OnClick="btn_Upd_Click" />
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_CateName" runat="server" Text="選項名稱:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_CateName" runat="server"></asp:TextBox>
                </td>
                <td width="15%" colspan="2">
                   
                </td>
            </tr>
            <tr>
                <td colspan="4">
                     <asp:Button ID="btn_Ins" runat="server" Text="新增確定" />
                </td>
            </tr>
            <tr>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_Item" runat="server" Text="選項:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddl_Item" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="EditTD1" width="15%">
                    <asp:Label ID="lbl_ShowName" runat="server" Text="顯示名稱:"></asp:Label>
                </td>
                <td width="35%">
                    <asp:TextBox ID="txb_ShowName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_Update" runat="server" Text="更新確定" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
