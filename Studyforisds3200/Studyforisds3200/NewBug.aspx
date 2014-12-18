<%@ Page Title="Create New Bug" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewBug.aspx.cs" Inherits="Studyforisds3200.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="fullName" DataValueField="emp_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [FullNames]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="description" DataValueField="cat_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="description" DataValueField="status_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [status]"></asp:SqlDataSource>
    </p>
    <p>
        Description</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    </p>
    <p>
        Details</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" InsertCommand="INSERT INTO bugEntry(whenCreated, Created_BY, Cat_ID, Status_ID, Description, Details) VALUES( GETDATE(), @CreatedBY, @catId, @statusId, @description, @details)" SelectCommand="SELECT whenCreated, created_by, cat_id, status_id, description,details FROM bugEntry">
            <InsertParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="CreatedBY" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DropDownList2" Name="catId" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DropDownList3" Name="statusId" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TextBox1" Name="description" PropertyName="Text" />
                <asp:ControlParameter ControlID="TextBox2" Name="details" PropertyName="Text" />
            </InsertParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>
