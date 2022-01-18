<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="admin_login.aspx.cs" Inherits="s_ecws.admin.admin_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentOfHeadSection" runat="server">

    <title>Admin Login</title>
    <link href="css/admin_login.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <div class="admin_login_form">

        <div class="signIn">
            <div>
                <label class="form-label" for="email">Email</label>
                <asp:textbox class="form-control" id="email" runat="server"></asp:textbox>
            </div>
            <div>
                <label class="form-label" for="password">Password</label>
                <asp:textbox class="form-control" id="password" runat="server" textmode="Password"></asp:textbox>

            </div>
            <asp:button cssclass="btn btn-dark" id="loginButton" runat="server" text="Login" onclick="loginButton_Click" />
            <asp:label id="messageLabel" runat="server" text=""></asp:label>
        </div>
    </div>
</asp:Content>
