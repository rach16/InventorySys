<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddtoInventory.aspx.cs" Inherits="CartWebApp.AddtoInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome <%=Session["id"] %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="Default.aspx">Logout</asp:LinkButton><table align="center" cellspacing ="1" style="width: 100%; background-color: #FF99CC; "
    <tr>
        <td style="padding-left: 100px;" align="left" class="auto-style1">
            Product Name :
        </td>
        <td align="left" class="auto-style1">
           <asp:TextBox ID="txtProductName" runat="server" width="212px"></asp:TextBox>
        </td>
    </tr>

     <tr>
        <td style="padding-left: 100px;" align="left" class="auto-style2">
            Product Description :
        </td>
        <td align="left" class="auto-style2">
           <asp:TextBox ID="txtProductDescription" runat="server" width="212px" Height="80px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>

     <tr>
        <td style="width: 50%; padding-left: 100px;" align="left">
            Product Price :
        </td>
        <td style="width : 50%;" align="left">
           <asp:TextBox ID="txtProductPrice" runat="server" width="212px"></asp:TextBox>
        </td>
    </tr>

        <tr>
        <td style="width: 50%; padding-left: 100px;" align="left">
            Product Category :
        </td>
        <td style="width : 50%;" align="left">
           <asp:TextBox ID="txtProductCategory" runat="server" width="212px"></asp:TextBox>
        </td>
        </tr>
     <tr>
        <td style="width: 50%; padding-left: 100px;" align="left">
            Product Quantity :
        </td>
        <td style="width : 50%;" align="left">
           <asp:TextBox ID="txtProductQuantity" runat="server" width="212px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td style="width: 50%; padding-left: 100px;" align="left">
            &nbsp;
        
        </td>
        <td style="width: 50%; align="left">
            &nbsp;
        
        </td>
        </tr>

    <tr>
        <td style="width: 50%;" align="right">
            &nbsp;
         </td>
        <td style="width: 50%;" align="left">
            <asp:Button ID="btnSubmit" runat="server" Text="Add" Width="100px" Height="30px" OnClick="btnSubmit_Click" />
        </td>

    </tr>
    </table>

        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Error" runat="server"></asp:Label>
        </p>
        <asp:Label ID="Response" runat="server"></asp:Label>

    </div>
    </form>
</body>
</html>
