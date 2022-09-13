<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/main.Master" AutoEventWireup="true" CodeBehind="carts.aspx.cs" Inherits="projectPSD.Views.carts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="table-responsive col-lg-8"  style="margin: 50px 0 50px 0;">
     <h1>
         <asp:Label ID="lblTitle" runat="server" Text="Cart List"></asp:Label></h1>
    <asp:GridView ID="cartGridView" runat="server" CssClass="table table-striped table-sm border-0" AutoGenerateColumns="False" OnRowDeleting="cartGridView_RowDeleting">
        <Columns>
            <asp:BoundField DataField="product.id" HeaderText="Product ID" SortExpression="product.id" ItemStyle-CssClass="d-none" HeaderStyle-CssClass="d-none"/>
            <asp:BoundField DataField="product.name" HeaderText="Product Name" SortExpression="product.name" />
            <asp:BoundField DataField="product.price" HeaderText="Product Price" SortExpression="product.price" />
            <asp:BoundField DataField="product.product_brands.name" HeaderText="Product Brand" SortExpression="product.product_brands.name" />
            <asp:BoundField DataField="quantity" HeaderText="Product Quantity" SortExpression="quantity" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
        </asp:GridView>
    <asp:LinkButton ID="CheckoutBtn" runat="server" CssClass="btn btn-primary" OnClick="CheckoutBtn_Click">Checkout</asp:LinkButton>

    </div>
</asp:Content>
