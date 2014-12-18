<%@ Page Title="Create New Bug" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewBug.aspx.cs" Inherits="Assignment8.Create_New_Bug" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Created_By:&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="fullName" DataValueField="emp_id">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [FullNames]"></asp:SqlDataSource>
</p>
<p>
    Category:
    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="Category" DataTextField="description" DataValueField="cat_id">
    </asp:DropDownList>
    <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>
</p>
<p>
    Status Column:
    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="Status" DataTextField="description" DataValueField="status_id">
    </asp:DropDownList>
    <asp:SqlDataSource ID="Status" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [status]"></asp:SqlDataSource>
</p>
<p>
    Description:
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</p>
<p>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
</p>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" InsertCommand="INSERT INTO bugEntry(whenCreated, Created_BY, Cat_ID, Status_ID, Description, Details, Assigned_to) VALUES( GETDATE(), @CreatedBY, @catId, @statusId, @description, @details, @assigned_to)" SelectCommand="SELECT [whenCreated], [created_BY], [cat_Id], [Status_Id], [details] FROM [bugEntry]">
    <InsertParameters>
        <asp:ControlParameter ControlID="DropDownList1" Name="CreatedBY" PropertyName="SelectedValue" DefaultValue="" />
        <asp:ControlParameter ControlID="DropDownList2" Name="catId" PropertyName="SelectedValue" />
        <asp:ControlParameter ControlID="DropDownList3" Name="statusId" PropertyName="SelectedValue" />
        <asp:ControlParameter ControlID="TextBox1" Name="description" PropertyName="Text" />
        <asp:ControlParameter ControlID="TextBox2" Name="details" PropertyName="Text" />
        <asp:Parameter DefaultValue="1" Name="assigned_to" />
    </InsertParameters>
</asp:SqlDataSource>
<p>
    Details:</p>
<p>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
</p>
<p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
</p>
<p>
    &nbsp;</p>
<p>
    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    <br />
</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
