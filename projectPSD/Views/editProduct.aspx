<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/main.Master" AutoEventWireup="true" CodeBehind="editProduct.aspx.cs" Inherits="projectPSD.Views.editProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="container d-flex align-items-center flex-column my-5">
  <div class="border-bottom col-lg-8 py-2 mb-3">
    <h1 class="h2">Edit Product</h1>
  </div>
  <div class="col-lg-8">
      <div class="mb-3">
        <label for="name" class="form-label">Product Name</label>
        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
      </div>

      <div class="mb-3">
        <label for="value" class="form-label">Product Price</label>
        <div class="input-group mb-3">
          <span class="input-group-text">Rp</span>
            <asp:TextBox ID="TxtPrice" runat="server" CssClass="form-control" TextMode="Number" Text="0"></asp:TextBox>
        </div>
      </div>

      <div class="mb-3">
        <label for="name" class="form-label">Product Description</label>
        <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
      </div>


      <div class="mb-3">
          <label for="category" class="form-label">Product Brand</label>
          <asp:DropDownList ID="BrandList" runat="server" CssClass="form-select"></asp:DropDownList>
      </div>

      <div class="mb-3">
        <label for="image" class="form-label">Product Image</label>
          <asp:FileUpload ID="ImageFile" runat="server" CssClass="form-control" />
      </div>
          <asp:Label ID="lblError" runat="server" CssClass="text-danger" Text="this is error"></asp:Label>

      <div class="d-flex justify-content-end">
          <asp:LinkButton ID="EditProductBtn" runat="server" CssClass="btn btn-primary" OnClick="EditProductBtn_Click">Edit Product</asp:LinkButton>
      </div>
  </div>
</div>
</asp:Content>
