<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="view_cart.aspx.cs" Inherits="s_ecws.user.view_cart" %>



<asp:Content ID="Content0" ContentPlaceHolderID="contentOfHeadSection" runat="server">

    <%--<link href="css/testing.css" rel="stylesheet" />--%>
    <link href="css/viewCart.css" rel="stylesheet" />

</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
   

    <asp:Repeater ID="d1" runat="server">

        <HeaderTemplate>
            <div class="orderedProductList">
        </HeaderTemplate>
        <ItemTemplate>

            <div class="singleItem">
                <img src="<%#Eval("productImage") %>"/>
        
                      <asp:Label class="orderInfo" ID="productName" runat="server" Text="">                                                                                                                
                          <%#Eval("productName") %> <br />
                          Price = <%#Eval("productPrice") %> Taka <br />
                          Ordered Count = <%#Eval("productQty") %> <br />
                      </asp:Label>

                <a href="delete_cart.aspx?id=<%#Eval("id") %>"> <i class="fa fa-trash" aria-hidden="true"></i> </a>
                           
            </div>

        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="c2" runat="server">
 
     <p>
        <asp:Label runat="server">Total Price: </asp:Label>
        <asp:Label ID="totalPrice" runat="server"></asp:Label>
        <asp:Label runat="server">Taka </asp:Label>
    </p>
    <asp:Button class="btn btn-dark" ID="checkOut" runat="server" Text="Confirm" OnClick="confirmBuying"/>

</asp:Content>
