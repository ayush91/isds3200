<%@ Page Title="View All" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewAll.aspx.cs" Inherits="Assignment8.View_All" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="bug_id" DataSourceID="ViewAllBugs">
            <Columns>
                <asp:BoundField DataField="bug_id" HeaderText="bug_id" InsertVisible="False" ReadOnly="True" SortExpression="bug_id" />
                <asp:BoundField DataField="whenCreated" HeaderText="whenCreated" SortExpression="whenCreated" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                <asp:BoundField DataField="created_by" HeaderText="created_by" SortExpression="created_by" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="ViewAllBugs" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [bug_id], [whenCreated], [description], [created_by] FROM [bugEntry]"></asp:SqlDataSource>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
