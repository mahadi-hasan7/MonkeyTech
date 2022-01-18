<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="payment_gateway.aspx.cs" Inherits="s_ecws.user.payment_gateway" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    this is payment gateway page

    <asp:Button ID="paymentComplete" runat="server" Text="payment complete" OnClick="paymentComplete_Click" />
</asp:Content>
