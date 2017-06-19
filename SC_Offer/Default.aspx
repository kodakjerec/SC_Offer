<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SC_Offer._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script type="text/javascript">
        function DisplayBtn() {
            //            var a = document.getElementById("Label1").innerText;
            //            alert(a);
            document.getElementById("TextBox1").disabled = true;

        } 
    </script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        <input type="BUTTON" name="btn_Test" value="測試" onclick="DisplayBtn();">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Text="aaa"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
