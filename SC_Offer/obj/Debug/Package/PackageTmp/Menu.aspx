<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="SC_Offer.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body style="background-color: #e2ffd6">
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server">
        <Nodes>
            <asp:TreeNode SelectAction="Expand" Text="綜合性報價" Value="綜合性報價">
                <asp:TreeNode NavigateUrl="~/SCQueryQuote.aspx" SelectAction="Expand" 
                    Target="right" Text="報價單查詢" Value="報價單查詢"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/SCQuote.aspx" SelectAction="Expand" Target="right" 
                    Text="綜合性報價單建立" Value="綜合性報價單建立"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="作業類別費用" Value="作業類別" SelectAction="Expand" Target="right">
                <asp:TreeNode NavigateUrl="SCTypeQuery.aspx" Target="right" Text="作業類別費用查詢" 
                    Value="作業類別費用查詢"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/SCTypeFee.aspx" Text="作業類別費用新建" Value="類別新建" 
                    Target="right">
                </asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode SelectAction="Expand" Text="應收對帳單查詢" Value="應收對帳單查詢">
                <asp:TreeNode NavigateUrl="http://192.168.110.70/Smart-Query/Squery.aspx?UserGUID=%UserGUID%&amp;GUID=%GUID%&amp;_Company=&amp;path=DRP&amp;sys=DRP&amp;filename=WMSA003&amp;RPT=WMSA003_Rpt1" 
                    Target="right" Text="應收對帳單總表" Value="應收對帳單總表"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="http://192.168.110.70/Smart-Query/Squery.aspx?UserGUID=%UserGUID%&amp;GUID=%GUID%&amp;_Company=&amp;path=DRP&amp;sys=DRP&amp;filename=WMSA002&amp;RPT=WMSA002_Rpt1" 
                    Target="right" Text="應收對帳單明細表" Value="應收對帳單明細表"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="http://192.168.110.70/Smart-Query/squery.aspx?GUID=&amp;SQ_AutoLogout=true&amp;filename=WMSA005&amp;path=DRP&amp;RPT=WMSA005_Rpt1" 
                    Target="right" Text="供應商寄庫報價單" Value="供應商寄庫報價單"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="http://192.168.110.70/Smart-Query//squery.aspx?GUID=&amp;SQ_AutoLogout=true&amp;filename=WMSA006&amp;path=DRP" 
                    Target="right" Text="SC商品狀態查詢" Value="SC商品狀態查詢"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
    </div>
    
    </form>
</body>
</html>
