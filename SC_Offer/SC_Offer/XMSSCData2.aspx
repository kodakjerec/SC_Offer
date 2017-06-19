<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMSSCData2.aspx.cs" Inherits="SC_Offer.XMSSCData2" %>

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
            $("input[type=text][id*=txb_DateS]").datepick({ dateFormat: 'yyyy/mm/dd' });
            $("input[type=text][id*=txb_DateE]").datepick({ dateFormat: 'yyyy/mm/dd' });
        });
        // 顯示讀取遮罩
        function ShowProgressBar() {
            displayProgress();
            displayMaskFrame();
        }

        // 隱藏讀取遮罩
        function HideProgressBar() {
            var progress = $('#divProgress');
            var maskFrame = $("#divMaskFrame");
            progress.hide();
            maskFrame.hide();
        }
        // 顯示讀取畫面
        function displayProgress() {
            var w = $(document).width();
            var h = $(window).height();
            var progress = $('#divProgress');
            progress.css({ "z-index": 999999, "top": (h / 2) - (progress.height() / 2), "left": (w / 2) - (progress.width() / 2) });
            progress.show();
        }
        // 顯示遮罩畫面
        function displayMaskFrame() {
            var w = $(window).width();
            var h = $(document).height();
            var maskFrame = $("#divMaskFrame");
            maskFrame.css({ "z-index": 999998, "opacity": 0.7, "width": w, "height": h });
            maskFrame.show();
        }
    </script>

    <title>SC合約維護</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        產生完畢會跳出訊息視窗，不要重複點，執行時間很久非常久~~
        <table>
            <tr>
                <td class="EditTD1">
                    <asp:Label ID="Label1" runat="server" Text="倉別"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_S_qthe_SiteNo" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="EditTD1">
                    <asp:Label ID="Label2" runat="server" Text="廠編"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txb_supdid" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="EditTD1">
                    <asp:Label ID="Label3" runat="server" Text="起日"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txb_DateS" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="迄日"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txb_DateE" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Button ID="btn_Query" runat="server" Text="產生" OnClick="btn_Query_Click" OnClientClick="ShowProgressBar()" />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Count" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="divProgress" style="text-align: center; display: none; position: fixed;
        top: 50%; left: 50%;">
        <asp:Image ID="imgLoading" runat="server" ImageUrl="CSS/loading.gif" />
        <br />
        <font color="#1B3563" size="2px">資料處理中</font>
    </div>
    <div id="divMaskFrame" style="background-color: #F2F4F7; display: none; left: 0px;
        position: absolute; top: 0px;">
    </div>
    </form>
</body>
</html>
