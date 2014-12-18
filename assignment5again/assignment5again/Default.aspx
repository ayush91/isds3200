<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="assignment5again.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            Seating Revenue</p>
        <p>
            Enter the number of tickets for each class</p>
        <p>
            Class A:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Class A:&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p>
            Class B: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Class B:&nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <p>
            Class C:
            <asp:TextBox ID="TextBox3" runat="server" style="margin-bottom: 1px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Class C:&nbsp;
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 240px">
            Total Revenue&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 240px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
        </p>
    </form>
</body>
</html>
