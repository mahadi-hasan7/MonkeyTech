<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="add_product.aspx.cs" Inherits="s_ecws.admin.add_product" %>




<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

    <div>
        <div>
            <asp:Label class="form-label" AssociatedControlID="productName" Text="Product Name" runat="server" />
            <asp:TextBox class="form-control" ID="productName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label class="form-label" AssociatedControlID="productDescription" Text="Description" runat="server" />
            <asp:TextBox class="form-control" ID="productDescription" TextMode="MultiLine" Rows="7" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label class="form-label" AssociatedControlID="productPrice" Text="Price" runat="server" />
            <asp:TextBox class="form-control" ID="productPrice" runat="server" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
        </div>
        <div>
            <asp:Label class="form-label" AssociatedControlID="productQuantity" Text="Quantity" runat="server" />
            <asp:TextBox class="form-control" ID="productQuantity" runat="server" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
        </div>


        <div>
            <asp:FileUpload ID="imageFile" runat="server" />
        </div>
        <br />

        <asp:Button CssClass="btn btn-dark" ID="uploadNewProduct" runat="server" Text="upload" OnClick="uploadNewProduct_Click" />





        <%-- for testing purpose --%>
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>

        <asp:Label ID="UploadStatusLabel"
            runat="server">
        </asp:Label>

        <%--<asp:Image ID="uploadedImage" runat="server" />--%>
    </div>
</asp:Content>
