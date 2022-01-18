<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="s_ecws.user.registration" %>


<asp:Content ID="Content0" ContentPlaceHolderID="contentOfHeadSection" runat="server">
    <%--<link href="css/registration.css" rel="stylesheet" />--%>
    <link href="css/signInUp.css" rel="stylesheet" />







    <script language="javascript" type="text/javascript">
        function vaildForm() {
            var isOke = true;

            var fname = document.getElementById("<%=fname.ClientID%>").value;
            if (fname == "") {
                var temp = document.getElementById("<%=fname.ClientID%>");
                temp.placeholder = "first name is required";
                temp.classList.add("loginvalidation");
                isOke = false;
            }


            var userEmail = document.getElementById("<%=email.ClientID%>").value;
            if (userEmail == "") {
                var temp = document.getElementById("<%=email.ClientID%>");
                temp.placeholder = "Email can't be empty";
                temp.classList.add("loginvalidation");
                isOke = false;
            }

            var password = document.getElementById("<%=email.ClientID%>").value;
            if (password == "") {
                var temp = document.getElementById("<%=password.ClientID%>");
                temp.placeholder = "need to enter a password";
                temp.classList.add("loginvalidation");
                isOke = false
            }


            var phoneNumber = document.getElementById("<%=mobile.ClientID%>").value;
            if (phoneNumber == "") {
                var temp = document.getElementById("<%=mobile.ClientID%>");
                temp.placeholder = "enter a mobile number";
                temp.classList.add("loginvalidation");
                isOke = false
            }


            if (isOke) return true;
            else return false;
        }
    </script>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

    <div class="signUp">
        <div>
            <asp:Label class="form-label" AssociatedControlID="fname" Text="First Name" runat="server" />
            <asp:TextBox class="form-control" ID="fname" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label class="form-label" AssociatedControlID="lname" Text="Last Name" runat="server" />
            <asp:TextBox class="form-control" ID="lname" runat="server"></asp:TextBox>
        </div>


        <div>
            <asp:Label class="form-label" AssociatedControlID="email" Text="Email" runat="server" />
            <asp:TextBox class="form-control" ID="email" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label class="form-label" AssociatedControlID="password" Text="Password" runat="server" />
            <asp:TextBox class="form-control" ID="password" runat="server" TextMode="Password"></asp:TextBox>

        </div>


        <div>
            <asp:Label class="form-label" AssociatedControlID="address" Text="Address" runat="server" />
            <asp:TextBox class="form-control" ID="address" runat="server"></asp:TextBox>
        </div>

<%--        <div>
            <asp:Label class="form-label" AssociatedControlID="city" Text="City" runat="server" />
            <asp:TextBox class="form-control" ID="city" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label class="form-label" AssociatedControlID="state" Text="State" runat="server" />
            <asp:TextBox class="form-control" ID="state" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label class="form-label" AssociatedControlID="pincode" Text="Pincode" runat="server" />
            <asp:TextBox class="form-control" ID="pincode" runat="server"></asp:TextBox>
        </div>--%>

        <div>
            <asp:Label class="form-label" AssociatedControlID="mobile" Text="Phone Number" runat="server" />
            <asp:TextBox class="form-control" ID="mobile" runat="server"></asp:TextBox>
        </div>

        
        <asp:Button CssClass="btn btn-dark" ID="signUp" runat="server" Text="Sign Up" OnClick="signUp_Click" OnClientClick="return vaildForm()" />
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
    </div>



    <script type="text/javascript" src="vendor/jquery/jquery.min.js">

    </script>


</asp:Content>
