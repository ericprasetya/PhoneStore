<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/main.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="projectPSD.Views.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
     <div class="container m-5"> 
         <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" id="alertBox">
          <asp:Label ID="msgLbl" runat="server"></asp:Label>
          <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
         <h1 class="text-center mb-4">Product List</h1> 
         <div class="row"> 
             <asp:Repeater ID="ProductRepeater" runat="server"> 
             <ItemTemplate> 
                 <div class="col-md-4 mb-3"> 
                 <div class="card"> 
                     <div class="position-absolute px-3 py-2 text-white" style="background-color: rgba(0,0,0,0.7);"> 
                         <p class="p-0 m-0 text-decoration-none"><%# Eval("ProductBrand") %></p> 
                     </div> 
                     <asp:Image ID="productImage" runat="server" ImageUrl='<%# ProductImageAlt(Eval("ProductImage")) %>' CssClass="card-img-top"/>
                     <div class="card-body"> 
                         <h5 class="card-title"><%#Eval("ProductName") %></h5> 
                         <p class="card-text text-black-50 text-success"><%#Eval("ProductPrice") %></p> 
                         <p class="card-text"><%#Eval("ProductDescription") %></p> 
                         <div class="d-flex"> 
                             <asp:LinkButton ID="ViewDetailBtn" runat="server" CssClass="btn btn-primary" CommandArgument='<%#Eval("ProductId") %>'  OnClick="ViewDetailBtn_Click">View Details</asp:LinkButton> 
                         </div> 
                     </div> 
                 </div>  
                </div> 
             </ItemTemplate> 
             </asp:Repeater> 
         </div> 
     </div> 
</asp:Content>
