<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  
    <p>
        &nbsp;</p>
    <p style="font-weight: bold">
        TryIt Page<br />
    </p>
    <p>
    5 Day Temperature Forecast</p>
<p>
    Gets weather based on a given zipcode</p>
<p>
    Method: Weather5day() takes zipcode as a string a returns an array of strings.</p>
<p>
    URL of service : <a href="http://localhost:58242/Service1.svc">http://localhost:58242/Service1.svc</a></p>
<p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Weather" />
</p>
<p>
    <asp:Label ID="Label1" runat="server" Text="Enter Zipcode Above"></asp:Label>
</p>
<p>
    &nbsp;</p>
    <p>
        Word Filter </p>
    <p>
        Removes stop words from a given sentence.</p>
    <p>
        Method: WordFilter() takes a sentence as a string and returns a new string.</p>
    <p>
        URL of service: <a href="http://localhost:58242/Service1.svc">http://localhost:58242/Service1.svc</a></p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Width="370px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Remove Stop Words" Width="153px" />
    </p>
<p>
        <asp:Label ID="Label2" runat="server" Text=":"></asp:Label>
    </p>
<p>
        &nbsp;</p>
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
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Get Exchange Rates" Width="146px" />
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text=":"></asp:Label>
    </p>
<p>
        &nbsp;</p>
<p>
        Crypto Trends</p>
<p>
        Returns the top 7 trending cryptocurrencies based on searches in the last 24 hours.</p>
<p>
        Method: CryptoRank() takes no arguments and returns a string array of the most trending cryptocurrencies.</p>
<p>
        URL of service: <a href="http://localhost:57756/Service2.svc/CryptoRank">http://localhost:57756/Service2.svc/CryptoRank</a></p>
<p>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Get Trending Cryptos" Width="195px" />
    </p>
<p>
        <asp:Label ID="Label4" runat="server" Text=":"></asp:Label>
    </p>
<p>
        &nbsp;</p>

  
</asp:Content>
