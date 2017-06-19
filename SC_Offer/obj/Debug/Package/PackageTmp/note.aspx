<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="note.aspx.cs" Inherits="SC_Offer.note" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="上傳" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Delete" />
    <br/>
    <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Button" />
    </form>
</body>
</html>
