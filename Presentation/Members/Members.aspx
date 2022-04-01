<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="Presentation.Members.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

p {
  margin: 0 0 10px 0px;
}
  p,
  h2,
  h3 {
    orphans: 3;
    widows: 3;
  }
  * {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
  *,
  *:before,
  *:after {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    -webkit-box-shadow: none !important;
    box-shadow: none !important;
  }
  a {
  color: #337ab7;
  text-decoration: none;
}
  a,
  a:visited {
    text-decoration: underline;
  }
  a {
  background-color: transparent;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Members Page<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Hello"></asp:Label>
            <br />
            <br />
            <br />
            Global.asax event handler and Cookies TryIt<br />
            Gets username and roles for user after they sign-in using a cookie and the handler: Application_AuthenticateRequest()<br />
            <br />
            username:
            <asp:Label ID="Label2" runat="server" Text="--"></asp:Label>
            <br />
            role:
            <asp:Label ID="Label3" runat="server" Text="--"></asp:Label>
            <br />
            <br />
            <br />
            Web service TryIt:
            <br />
<p>
        Exchange Rates</p>
<p>
        Gives the exchange rates for a given amount of USD to the other most popular currencies.</p>
<p>
        Method: ExchangeRates() takes a given amount of USD as a string and returns a string array of currency conversions.</p>
<p>
        URL of service: <a href="http://localhost:58242/Service1.svc">http://localhost:58242/Service1.svc</a></p>
<p>
        Enter amount of USD (example: 15.99)</p>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" Width="174px"></asp:TextBox>
            </p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Get Exchange Rates" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="--"></asp:Label>
            <br />
            <br />
            <br />
            Web service TryIt:<br />
            Crypto Prices (RESTful service)<br />
            <br />
            Given an amount of USD and a cryptocurrency name, this service returns how much of that cryptocurrency you could buy<br />
            <br />
            Enter a cryptocurrency you would like to invest in (example: bitcoin)<br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Width="174px"></asp:TextBox>
            <br />
            <br />
            Next, enter an amount of USD that you would like to invest into the specified cryptocurrency above (2000.00)<br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server" Width="170px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Get Crypto Conversion" Width="173px" />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="--"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="--"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign out" Width="100px" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" Width="100px" />
            <br />
        </div>
    </form>
</body>
</html>
