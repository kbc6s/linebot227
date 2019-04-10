<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="linebot227._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/vue.min.js"></script>
    <script src="Scripts/isRockFx.js"></script>
    <script src="Scripts/toastr.min.js"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <%-- <asp:Label ID="label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Push Text Message" />
            <br />
            <br />--%>
            <asp:Button ID="Button5" runat="server" OnClick="TestButton" Text="Test Button" />
            <br />
            <br />
          <%--  <asp:Button ID="Button6" runat="server" OnClick="Button4_deleteSQL" Text="Delete SQL" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_sendMail" Text="send Email" />
            <br />
            <br />--%>
            輸入ChannelAccessToken
            <br />
            <asp:TextBox ID="ChannelAccessToken" Name="ChannelAccessToken" CssClass="form-control" runat="server" placeholder="提示" Text=""></asp:TextBox>
            <br />
            <br />
            輸入UserID
            <br />
            <asp:TextBox ID="UserID" CssClass="form-control" runat="server" placeholder="提示" Text=""></asp:TextBox>
            <br />
            <br />
            輸入訊息
            <br />
            <asp:TextBox ID="MessageTxb" CssClass="form-control" runat="server" placeholder="提示" Text=""></asp:TextBox>
            <br />
            <br />
<%--            <asp:Button ID="Button3" runat="server" OnClick="SendMessageBT" Text="Push Message" />--%>


<%--            <asp:TextBox ID="txb_Token" CssClass="form-control" runat="server" placeholder="Channel Access Token 請從Linebot管理後台取得"></asp:TextBox>
            <label>訊息接收對象(uid) : </label>
            <asp:TextBox ID="txb_SendTo" CssClass="form-control" runat="server" placeholder="uid並非用戶id，而是類似 U6ca0zz0fc5xxc152d3618xx1658ooa5f 這樣的一串文字"></asp:TextBox>--%>
        </div>
    </form>
</body>
</html>
