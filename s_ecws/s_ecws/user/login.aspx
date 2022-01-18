<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="s_ecws.user.login" %>



<asp:Content ID="Content0" ContentPlaceHolderID="contentOfHeadSection" runat="server">

    <%--<link href="css/registration.css" rel="stylesheet" />--%>
    <link href="css/signInUp.css" rel="stylesheet" />



    <script language="javascript" type="text/javascript">

        function vaildForm() {
            var isOke = true;
            var userEmail = document.getElementById("<%=email.ClientID%>").value;
            var password = document.getElementById("<%=password.ClientID%>").value;
            if (userEmail == "") {
                var temp = document.getElementById("<%=email.ClientID%>");
                temp.placeholder = "Email can't be empty";
                temp.classList.add("loginvalidation");
                isOke = false;
            }
            if (password == "") {
                var temp = document.getElementById("<%=password.ClientID%>");
                temp.placeholder = "need to enter a password";
                temp.classList.add("loginvalidation");
                isOke = false
            }

            if (isOke) return true;
            else return false;
        }
    </script>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="signIn">
        <div>
            <asp:Label class="form-label" AssociatedControlID="email" Text="Email" runat="server" />
            <asp:TextBox class="form-control" ID="email" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label class="form-label" AssociatedControlID="password" Text="Password" runat="server" />
            <asp:TextBox class="form-control" ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button CssClass="btn btn-dark" ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" OnClientClick="return vaildForm()" />
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
