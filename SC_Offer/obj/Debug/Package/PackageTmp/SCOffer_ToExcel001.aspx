﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCOffer_ToExcel001.aspx.cs"
    Inherits="SC_Offer.SCOffer_ToExcel001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CSS/Style.css" type="text/css" />
    <link rel="stylesheet" href="css/validationEngine.jquery.css" type="text/css" media="screen"
        charset="utf-8" />
    <style type="text/css">
        @import "CSS/jquery.datepick.css";

        .auto-style1 {
            width: 148px;
        }
    </style>
    <script src="js/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="js/jquery.datepick.js" type="text/javascript"></script>

    <script src="js/jquery.datepick-zh-TW.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#txb_Bmonth_CostIncome").datepick({ dateFormat: 'yyyy/mm' });
        });
    </script>
    <script type="text/javascript">
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
    <title>匯出Excel001</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--        <asp:Button Text="報價單" BorderStyle="None" ID="Tab1" CssClass="Button_Clicked" runat="server"
            OnClick="Tab1_Click" />
        <asp:Button Text="派工單" BorderStyle="None" ID="Tab2" CssClass="Button_Initial" runat="server"
            OnClick="Tab2_Click" />
        <asp:Button Text="成本及收入明細表" BorderStyle="None" ID="Tab3" CssClass="Button_Initial" runat="server"
            OnClick="Tab3_Click" />--%>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <div id="ExportCostIncome">
                            <table class="tborder" width="100%">
                                <tr>
                                    <td class="PageTitle">SC應收款明細表(for 財務入帳用)
                                    </td>
                                </tr>
                                <tr>
                                    <td class="HeaderStyle ">查詢條件
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td class="EditTD1">
                                        <asp:Label ID="Label20" runat="server" Text="查詢月份："></asp:Label>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txb_Bmonth_CostIncome" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_CostIncome" runat="server" Text="預覽" OnClick="btn_CostIncome_Click" OnClientClick="ShowProgressBar()" Style="height: 21px" />
                                        <asp:Button ID="btn_CostIncome_ToExcel" runat="server" Text="直接匯出應收款明細表" OnClick="btn_CostIncome_ToExcel_Click" OnClientClick="ShowProgressBar()" Style="height: 21px" />
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <asp:GridView ID="gv_List" runat="server" CssClass="GVStyle"
                                    Width="100%" AllowPaging="True" OnPageIndexChanging="gv_List_PageIndexChanging"
                                    PageSize="10">
                                    <HeaderStyle CssClass="GVHead" />
                                    <RowStyle CssClass="one" />
                                    <PagerStyle CssClass="GVPage" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="divProgress" style="text-align: center; display: none; position: fixed; top: 50%; left: 50%;">
            <asp:Image ID="imgLoading" runat="server" ImageUrl="images/loading.gif" />
            <br />
            <font color="#1B3563" size="2px">資料處理中</font>
        </div>
        <div id="divMaskFrame" style="background-color: #F2F4F7; display: none; left: 0px; position: absolute; top: 0px;">
        </div>

    </form>
</body>
</html>
