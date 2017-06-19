<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCMain.aspx.cs" Inherits="SC_Offer.SCMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SC綜合報價系統</title>
</head>
    <frameset cols="15%,*" frameborder="NO" border="1" framespacing="1">
        <%--<frame name="left" src="Menu.aspx" />--%>
        <frame name="left" src="Menu01.aspx" />
        <frame name="right" src="SCQueryQuote.aspx" />
    </frameset>
</html>
