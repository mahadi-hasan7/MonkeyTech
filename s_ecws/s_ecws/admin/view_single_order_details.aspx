<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="view_single_order_details.aspx.cs" Inherits="s_ecws.admin.view_full_order" %>

<asp:Content ID="Content0" ContentPlaceHolderID="contentOfHeadSection" runat="server">

    <link href="../user/css/viewCart.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

    <asp:Repeater ID="d1" runat="server">

        <HeaderTemplate>
            <div class="orderedProductList">
        </HeaderTemplate>
        <ItemTemplate>

            <div class="singleItem">
                <img src="<%#Eval("productImage") %>" />
                <asp:Label class="orderInfo" ID="productName" runat="server" Text="">                                                                                                                
                          <%#Eval("productName") %> <br />
                          Price = <%#Eval("productPrice") %> Taka <br />
                          Ordered Count = <%#Eval("orderedCount") %> <br />
                </asp:Label>
            </div>

        </ItemTemplate>
        <FooterTemplate>
            </div>
            
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="c2" runat="server">

    <div>
        <a href="ifOrderisDone.aspx?orderId=<%= Request.QueryString["orderId"].ToString()%>"> <i class="fa fa-check" aria-hidden="true"></i> </a>  
    </div>
    

</asp:Content>
