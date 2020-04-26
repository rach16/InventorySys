<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="CartWebApp.UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" BackColor="Maroon" BorderColor="Black" BorderStyle="Double" ForeColor="#FFCCFF" Text=" Welcome to Web Cart"></asp:Label>
            <br />
            &nbsp;</h1>

        <h4>Welcome <%=Session["id"] %></h4>
        <a href="AddtoCart.aspx">Start Shopping!</a>&nbsp;
        <br />
        <br />
    </div>
    </form>
</body>
</html>
