<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/main.Master" AutoEventWireup="true" CodeBehind="productDetails.aspx.cs" Inherits="projectPSD.Views.productDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="container d-flex my-5 justify-content-around">
    <div style="height: 500px; overflow:hidden;" class="rounded-4 shadow" >
        <asp:Image ID="productImage" runat="server" CssClass="h-100"/>
    </div>
    <div class="" style="width: 400px">
       <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" id="alertBox">
          <asp:Label ID="msgLbl" runat="server"></asp:Label>
          <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
      <h1>
          <asp:Label ID="nameLbl" runat="server"></asp:Label></h1>
      <h5><asp:Label ID="priceLbl" runat="server"></asp:Label></h5>
      <nav>
        <div class="nav nav-tabs" id="nav-tab" role="tablist">
          <button class="nav-link active" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Description</button>
        </div>
      </nav>
      <div class="tab-content mt-3" id="nav-tabContent">
        <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab" tabindex="0">
          <h5><asp:Label ID="brandLbl" runat="server"></asp:Label></h5>
          <p><asp:Label ID="descriptionLbl" runat="server"></asp:Label></p>
        </div>
      </div>
      <div class="card" style="width: 100%;height:fit-content;margin-top:50px" ID="UserAction" runat="server">
        <div class="card-header">
          Buy Now!
        </div>
        <div class="card-body d-flex align-items-center">
            <asp:TextBox ID="quantityTxt" runat="server" TextMode="Number" Text="1" CssClass="form-control w-25 d-inline-block"></asp:TextBox>
            <asp:LinkButton ID="addToCartBtn" runat="server" CssClass="btn btn-primary ms-1" OnClick="addToCartBtn_Click">Add To Cart</asp:LinkButton>
        </div>
      </div>
       <div class="card" style="width: 100%;height:fit-content;margin-top:50px" ID="AdminAction" runat="server">
        <div class="card-header">
          Action
        </div>
        <div class="card-body d-flex align-items-center">
            <asp:LinkButton ID="EditBtn" runat="server" CssClass="btn btn-warning" OnClick="EditBtn_Click">Edit</asp:LinkButton>
            <asp:LinkButton ID="DeleteBtn" runat="server" CssClass="btn btn-danger ms-1" OnClick="DeleteBtn_Click">Delete</asp:LinkButton>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
