<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="linebot227.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            輸入姓名
            <br />
            <asp:TextBox ID="Txb1" Name="ChannelAccessToken" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            <br />
            <br />
            輸入Gmail
            <br />
            <asp:TextBox ID="Txb2" CssClass="form-control" runat="server" Text=""></asp:TextBox>
            <br />
            <br />
   <%--         輸入訊息
            <br />
            <asp:TextBox ID="Txb3" CssClass="form-control" runat="server" placeholder="提示" Text=""></asp:TextBox>
            <br />--%>
            <br />
            <asp:Button ID="Button1" CssClass="form-controll" OnClick="insertSQL" runat="server" Text="send" />
            <br />
            <br />
<%--            <asp:Button ID="Button2" CssClass="form-controll" OnClick="selectSQL" runat="server" Text="testButton" />--%>
            <br />
            <br />
<%--            <asp:Label ID="kai" Text="ttt" runat="server" />--%>
        </div>
    </form>
</body>
</html>
