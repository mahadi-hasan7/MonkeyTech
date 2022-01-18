<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="product_description.aspx.cs" Inherits="s_ecws.user.product_description" %>


<asp:Content ID="Content0" ContentPlaceHolderID="contentOfHeadSection" runat="server">

    <link href="css/product_details.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <section>
                <div class="title">
                    <h2><%#Eval("product_name")%></h2>
                    <p>
                        product short description
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum,
                aperiam!
                    </p>
                </div>

                <div class="about-center section-center">
                    <article class="about-img">
                        <img src="<%# Eval("product_images") %>" alt="" />
                    </article>
                    <article class="about">
                        <%--<div class="about-content">
                            <div class="content active" id="history">
                                <h4>Specification</h4>
                                <p>
                                    <%#Eval("product_desc") %>
                                </p>
                            </div>
                        </div>--%>

                        <div class="about-content">
                                <h4>Specification</h4>
                                <p>
                                    <%#Eval("product_desc") %>
                                </p>
                        </div>
                    </article>
                </div>

            </section>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>




    <table class="addToCartButtonTable">
        <tr>
            <td>
                <asp:Label class="form" ID="enterQuantity_OutofStock" runat="server" Text="Enter Quantity"></asp:Label>
            </td>
            <td>
                <asp:TextBox class="form-control rounded" ID="enterQuantity" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button class="btn btn-light" ID="b1" runat="server" Text="Add to cart" OnClick="addToCart" />

            </td>
            <%--<td><asp:Button ID="viewCartButton" runat="server" Text="view cart" OnClick="viewCartButton_Click" /></td>--%>
        </tr>
        <tr>
            <td>
                <asp:Label ID="overflowQuantityLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    


    <script type="text/javascript" src="js/product_details.js">
        
    </script>

</asp:Content>
