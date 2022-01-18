<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="all_product.aspx.cs" Inherits="s_ecws.admin.all_product" %>



<asp:Content ID="Content0" ContentPlaceHolderID="contentOfHeadSection" runat="server">

    <%--<link href="css/all_product.css" rel="stylesheet" />--%>

</asp:Content>




<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">


    <asp:Repeater ID="d1" runat="server">


        <HeaderTemplate>

            
        </HeaderTemplate>

        <ItemTemplate>

            <div class="card">
                <div class="product_image">

                    <a href="editSingleProduct.aspx?productId=<%#Eval("id") %>">
                        <img src="<%# Eval("product_images") %>" alt="">
                    </a>
                </div>


                <div class="product_information">
                    <div class="product_name">

                        <b>
                            <%# Eval("product_name") %>
                        </b>
                        
                    </div>
<%--                    <div class="short_info">
                        Specification: <%# Eval("product_desc") %>
                    </div>--%>
                    <div class="price">
                        <%# Eval("product_price") %> Taka
                    </div>
                    <div class="price">
                        Available: <%# Eval("product_qty") %> piece
                    </div>
                </div>

                <div class="container">
                    <a href="delete_product.aspx?id=<%#Eval("id") %>"><i class="fa fa-trash" aria-hidden="true"></i></a>
                </div>

            </div>


        </ItemTemplate>

        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
