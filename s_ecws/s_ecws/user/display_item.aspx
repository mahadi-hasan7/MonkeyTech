<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="display_item.aspx.cs" Inherits="s_ecws.user.display_item" %>



<asp:Content ID="searchBar" ContentPlaceHolderID="LogoAndsearchBar" runat="server">
                <div class="search">
                <div class="imageSearch">
                    <ul class="social-media">
                        <li><a href="display_item.aspx?search=keyboard"><i class="fas fa-keyboard"></i></a></li>
                        <li><a href="display_item.aspx?search=laptop"><i class="fas fa-laptop"></i></a></li>
                        <li><a href="display_item.aspx?search=desktop"><i class="fas fa-desktop"></i></i></a></li>
                        <li><a href="display_item.aspx?search=mouse"><i class="fas fa-mouse"></i></a></li>
                    </ul>
                </div>

                <div class="searchBar">
                    <div class="container">
                        <div class="row d-flex justify-content-center align-items-center">
                            <div class="col-md-6">
                                <div class="form">
                                    <%--<i class="fa fa-search"></i>--%>
                                    <asp:TextBox class="form-control form-input" runat="server" ID="searchItem" />
                                    <span class="searchButton">
                                        <asp:Button class="searchButton" runat="server" OnClick="seachButtonTest_Click"/>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">


    <asp:Repeater ID="d1" runat="server">

        <HeaderTemplate>
            
        </HeaderTemplate>

        <ItemTemplate>
            <%-- Note:
                        
                        product_description.aspx?icchaMoto=কিছু একটা

                        icchaMoto   =   page-র URL ei format-e আসবে
                            // http://localhost:32481/user/product_description.aspx?icchaMoto=7    
            --%>



            <%-- notic what i write here --%>
            <%-- kono product er image e click korle jate oitar details dekhai --%>
            <%-- ?id -> eita table er id na, ja iccha dite pari,
                        iccha_moto dile oita diye product_description.aspc.cs page e access korte hbe
            --%>


            <%--<img src="../<%# Eval("product_images") %>" alt="" />--%></a>
       
            
            <%--            
    
    <ul>
                <li class="last">
                    <a href="product_description.aspx?icchaMoto=<%#Eval("id") %>">
                        <img src="<%# Eval("product_images") %>" alt="" /></a>
                  
                    <div class="product-info">
                        <h3><%# Eval("product_name") %></h3>
                        <div class="product-desc">
                            <h4>available quantity : <%# Eval("product_qty") %></h4>
                            <p><%# Eval("product_desc") %></p>
                            <strong class="price">$<%# Eval("product_price") %></strong><strong><%#Eval("id") %></strong>
                        </div>
                    </div>
                </li>
            </ul>
    
    
            --%>






            <div class="card">
                <div class="product_image">

                    <a href="product_description.aspx?icchaMoto=<%#Eval("id") %>">
                        <img src="<%# Eval("product_images") %>" alt="">
                    </a>
                </div>


                <div class="product_information">
                    <div class="product_name">
                        <%# Eval("product_name") %>
                    </div>
<%--                    <div class="short_info">
                        Specification: <%# Eval("product_desc") %>
                    </div>--%>
                    <div class="price">
                        $<%# Eval("product_price") %>
                    </div>
                </div>

                <div class="container">
                    <button class="btn btn-outline-dark">Details</button>
                    <button class="btn btn-outline-dark">Buy</button>
                </div>

            </div>


        </ItemTemplate>

        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>



</asp:Content>
