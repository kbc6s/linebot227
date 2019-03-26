<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="linebot227.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="輸入姓名:"></asp:Label><asp:TextBox ID="searchNameTxb" runat="server" ></asp:TextBox> <asp:Button ID="searchNameButton" runat="server" Text="search" OnClick="SearchMember" />
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="Label" Visible = "false"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label" Visible = "false"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Button" Visible="false" Onclick="verify" BackColor="Red" />
        <br />
        <asp:GridView ID="PersonData" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Seq" HeaderText="" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Name" HeaderText="名稱" />
        <asp:BoundField DataField="Valid" HeaderText="權限" />
        <asp:BoundField DataField="AuthTime" HeaderText="申請時間" />
        <asp:ButtonField ButtonType="Button" Text="給予權限"   CommandName="verify"  />
<%--        <asp:BoundField DataField="Role" HeaderText="權限" />--%>
    </Columns>
</asp:GridView>
    </form>
</body>
</html>
