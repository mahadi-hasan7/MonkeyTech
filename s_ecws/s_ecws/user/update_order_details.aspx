<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="update_order_details.aspx.cs" Inherits="s_ecws.user.update_order_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<table>
    <tr>
        <td>first name </td>
        <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    </tr>


    <tr>
        <td>last name </td>
        <td> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
        <td>address </td>
        <td> <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>


    <tr>
        <td>city </td>
        <td> <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
        <td>state </td>
        <td> <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
        <td>mobile </td>
        <td> <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="Button1" runat="server" Text="update and continue" OnClick="Button1_Click" />
        </td>
    </tr>
    
</table>
</asp:Content>
