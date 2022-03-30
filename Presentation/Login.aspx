<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Login to Enter Member/Staff Page<br />
            <br />
            For Staff Page, try credentials: User name: “TA” and Password: “Cse445ta!”, excluding the quotes.<br />
            For Member Page, register and account or try credentials:&nbsp; User name: “bob” and Password: “testy”, excluding the quotes.<br />
            <br />
            Enter User Name and Password:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" Width="72px" />
&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Keep me signed in" />
&nbsp;&nbsp;
            <br />
            <asp:Label ID="Label1" runat="server" Text="---"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Register" Width="72px" />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
