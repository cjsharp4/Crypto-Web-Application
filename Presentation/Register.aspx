<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Presentation.WebForm2" %>


<%@ Register TagPrefix="Test" TagName="TestControl" Src="capImage.ascx" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Register to be a Member!<br />
            <br />
&nbsp;User Control TryIt (captcha verifier)<br />
&nbsp;<br />
            <br />
            Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<Test:TestControl id="TestControl" runat="Server"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get New Image" Width="120px" />
            <br />
            <br />
            Please enter the text above into the textbox:<br />
            <asp:TextBox ID="TextBox3" runat="server" Width="240px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Register" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Home" Width="70px" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="---"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="---"></asp:Label>
        </div>
    </form>
</body>
</html>
