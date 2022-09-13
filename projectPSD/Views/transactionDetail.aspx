<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/main.Master" AutoEventWireup="true" CodeBehind="transactionDetail.aspx.cs" Inherits="projectPSD.Views.transactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="container mb-5">

        <div class="py-5 text-center">
          <h2>Transaction Details</h2>
        </div>

        <div class="row g-5">
          <div class="col-md-7 col-lg-6 order-md-last">
            <h4 class="d-flex justify-content-between align-items-center mb-3">
              <span class="text-primary">Transaction Products</span>
            </h4>
            <ul class="list-group mb-3">
                <asp:Repeater ID="TransactionRepeater" runat="server">
                    <ItemTemplate>
                      <li class="list-group-item lh-sm">
                        <div style="height: 200px; overflow:hidden;" class="d-flex justify-content-center mb-2 pb-2 border-bottom" >
                           <asp:Image ID="Image1" runat="server" ImageUrl='<%# ProductImageAlt(Eval("product.image")) %>' class="img-fluid h-100 rounded"/>
                        </div>
                        <div class="d-flex justify-content-between ">
                          <div>
                            <h6 class="my-0">
                                <%# Eval("product.name") %>
                            </h6>
                            <small class="text-muted">Rp<%# Eval("product.price") %></small>
                          </div>
                          <span class="text-muted"><%# Eval("quantity") %> x</span>
                        </div>
                      </li>
                    </ItemTemplate>
                </asp:Repeater>
                <li class="list-group-item d-flex justify-content-between">
                    <span>Subtotal Product (IDR)</span>
                    <div>
                      <strong>Rp </strong><strong>
                          <asp:Label ID="txtSubtotal" runat="server" Text="0"></asp:Label></strong>
                    </div>
                </li>
            </ul>

            <h4 class="d-flex justify-content-between align-items-center mb-3">
              <span class="text-primary">Total</span>
            </h4>
            <ul class="list-group mb-3">
              <li class="list-group-item d-flex justify-content-between">
                <span>Delivery fee</span>
                <div>
                  <span class="text-muted">Rp </span><span class="text-muted" id="deliveryFee">20000</span>
                </div>
              </li>
              <li class="list-group-item d-flex justify-content-between">
                <span>Total (IDR)</span>
                <div>
                  <strong>Rp </strong><strong><asp:Label ID="txtTotal" runat="server" Text="0"></asp:Label></strong>
                </div>
              </li>
            </ul>

          </div>

              <div class="col-md-5 col-lg-6">
                <h4 class="mb-3">Billing address</h4>
                <div class="form-transaction">
                  <div class="row g-3">
                    <div class="col-12">
                      <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                      <asp:TextBox ID="txtName" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="col-12">
                      <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                      <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="col-12">
                      <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                      <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                    </div>


                  <hr class="my-4">

                  <h4 class="mb-3">Payment Type</h4>
                    <div class="col-12">
                      <asp:Label ID="lblPayment" runat="server" Text="Payment"></asp:Label>
                      <asp:TextBox ID="txtPayment" CssClass="form-control" runat="server" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                    </div>

                  <hr class="my-4">
                    <h4 class="mb-3">Transaction Details</h4>
                    <div class="col-12">
                      <asp:Label ID="lblDate" runat="server" Text="Transaction Date"></asp:Label>
                      <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-12">
                      <asp:Label ID="lblStatus" runat="server" Text="Transaction Status"></asp:Label>
                      <asp:TextBox ID="txtStatus" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-12">
                      <asp:Label ID="lblAssurance" runat="server" Text="Transaction Assurance"></asp:Label>
                      <asp:TextBox ID="txtAssurance" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
              </div>
            </div>
        </div>
    </div>
</asp:Content>
