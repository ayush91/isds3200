<%@ Page Title="View All" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewAll.aspx.cs" Inherits="Studyforisds3200.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
<asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="bug_id" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="whenCreated" HeaderText="whenCreated" SortExpression="whenCreated" />
        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
        <asp:BoundField DataField="created_by" HeaderText="created_by" SortExpression="created_by" />
        <asp:BoundField DataField="bug_id" HeaderText="bug_id" InsertVisible="False" ReadOnly="True" SortExpression="bug_id" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [whenCreated], [description], [created_by], [bug_id] FROM [bugEntry]"></asp:SqlDataSource>
<p>
        <br />
    </p>
</asp:Content>
