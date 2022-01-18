<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="view_full_order.aspx.cs" Inherits="s_ecws.user.view_full_order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">


    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>

            <table>
                <tr>
                    <td>product image</td>
                    <td>product name</td>
                    <td>product price</td>
                    <td>product qty</td>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>

            <tr>
                <td>
                    <img src="<%#Eval("product_images") %>" height="100px" width="100px" />
                </td>
                <td>
                    <%#Eval("product_name") %>
                </td>
                <td>
                    <%#Eval("product_price") %>
                </td>
                <td>
                    <%#Eval("product_qty") %>
                </td>
            </tr>

        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
