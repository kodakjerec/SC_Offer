<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCSupSet.aspx.cs" Inherits="SC_Offer.SCSupSet" %>

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

    <title>供應商設定</title>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="PageTitle">
                    供應商資料
                </td>
            </tr>
            <tr>
                <td class="HeaderStyle ">
                    <asp:Label ID="lbl_Sup" runat="server" Text="供應商設定"></asp:Label>
                </td>
            </tr>
        </table>
        <table width='100%'>
            <tr>
                <td>
                    <asp:Label ID="lbl_SupId" runat="server" Text="供應商代碼:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSupId" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_SupNa" runat="server" Text="供應商名稱:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txb_SunNa" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hid_Sup_Id" runat="server" />
    </div>
    </form>
</body>
</html>
