<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Presentation.Protected.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Staff Page<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Hello"></asp:Label>
            <br />
            <br />
            Global.asax event handler TryIt<br />
            Gets username and roles for user after they sign-in using a cookie and the handler: Application_AuthenticateRequest():<br />
            <br />
            username:
            <asp:Label ID="Label2" runat="server" Text="--"></asp:Label>
            <br />
            role: <asp:Label ID="Label3" runat="server" Text="--"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" Width="100px" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign out" Width="100px" />
        </div>
    </form>
</body>
</html>
