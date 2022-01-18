<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="confirmOrder.aspx.cs" Inherits="s_ecws.user.confirmOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentOfHeadSection" runat="server">


    <style type="text/css">
        .confirmStatus{
            margin: 120px 0;
            color: green;

            
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">


    <div class="confirmStatus">
        Your order is successfully done!
    </div>

</asp:Content>
