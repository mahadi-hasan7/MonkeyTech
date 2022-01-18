<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="editSingleProduct.aspx.cs" Inherits="s_ecws.admin.editSingleProduct" %>



<asp:Content ID="Content1" ContentPlaceHolderID="contentOfHeadSection" runat="server">

    <link href="../user/css/product_details.css" rel="stylesheet" />




    <style>
        .curremtlyAvailable {
            /*font-weight: bold;*/
            text-align: center;
            margin-bottom: 12px;
        }
    </style>

</asp:Content>






<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
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


                        <div class="about-content">
                            <h4>Specification</h4>

                            <%#Eval("product_desc") %>
                        </div>
                    </article>
                </div>

            </section>

            <div class="container curremtlyAvailable">
                Currently available : <%#Eval("product_qty") %>
            </div>

            
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
                <%-- this is something new
                    wouldn't allow to press any other key except 0 to 9 
                    --%>
                <asp:TextBox class="form-control rounded" ID="enterQuantity" runat="server" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
            </td>
            <td>
                <asp:Button class="btn btn-light" ID="updateProductQuantity" runat="server" Text="Update" OnClick="updateProductQuantity_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="overflowQuantityLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>


</asp:Content>




<asp:Content ID="Content3" ContentPlaceHolderID="c2" runat="server">
</asp:Content>
