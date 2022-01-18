<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="display_order.aspx.cs" Inherits="s_ecws.admin.display_order" %>


<asp:Content ID="Content0" ContentPlaceHolderID="contentOfHeadSection" runat="server">

    <link href="../user/css/viewCart.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">


    <asp:Repeater ID="r1" runat="server">
       
        <HeaderTemplate>
            <div class="orderedProductList">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="singleItem">
                <div>
                    <%#Eval("userId") %>
                    <a href="view_single_order_details.aspx?orderId=<%#Eval("pendingId")%>">Order Details</a>
                </div>
                      <asp:Label class="orderInfo" ID="productName" runat="server" Text="">                                                                                                                
                          <%#Eval("productList") %> <br />
                          Ordered Count = <%#Eval("itemCount") %> Taka <br />
                          Price = <%#Eval("totalPrice") %> <br />
                      </asp:Label>
                <a href="ifOrderisDone.aspx?orderId=<%#Eval("pendingId") %>"> <i class="fa fa-check" aria-hidden="true"></i> </a>                
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
