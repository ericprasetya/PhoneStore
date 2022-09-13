<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="projectPSD.Views.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="container-fluid p-0 m-0">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Public/Assets/banner1.jpg" class="img-fluid my-3 w-100" />
        <div class="p-5 mb-4 bg-light rounded-3">
          <div class="container-fluid py-5 d-flex justify-content-between px-5 headline">
             <div>
                <h1 class="display-5 fw-bold">Find Your Favorite Phone</h1>
                <p class="col-md-8 fs-4">PhoneStore provide you the best quality of products and services.</p>
                 <asp:LinkButton ID="productPageBtn" OnClick="productPageBtn_Click" class="btn btn-primary btn-lg" runat="server">Go to Products Page</asp:LinkButton>
             </div>
              <div>
                <asp:Image ID="Image2" runat="server" CssClass="headline-image" ImageUrl="~/Public/Assets/phones.svg" Width="400px"/>
              </div>
          </div>
        </div>

        <div class="p-5 mb-4 bg-dark rounded-3 text-white">
          <div class="container-fluid py-5 d-flex justify-content-between px-5 headline">
              <div>
                <asp:Image ID="Image3" runat="server" CssClass="headline-image" ImageUrl="~/Public/Assets/aboutUs2.svg" Width="400px"/>
              </div>
             <div class="d-flex align-items-end flex-column">
                <h1 class="display-5 fw-bold">Get to Know Us</h1>
                <p class="col-md-8 fs-4 text-end">PhoneStore established to give you best experience shopping new smartphones</p>
                 <asp:LinkButton ID="aboutUsPageBtn" OnClick="aboutUsPageBtn_Click" class="btn btn-primary btn-lg" runat="server">Go to About Us Page</asp:LinkButton>
             </div>
          </div>
        </div>
    </div>
</asp:Content>
