<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/main.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="projectPSD.Views.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="container"  style="margin: 50px 0 50px 0;">
        <div class="alert alert-success alert-dismissible fade show" role="alert" runat="server" id="alertBox">
          <asp:Label ID="msgLbl" runat="server"></asp:Label>
          <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <div class="table-responsive" id="CustomerTable" runat="server">
           <h1>
               <asp:Label ID="lblTitle" runat="server" Text="Transaction list"></asp:Label></h1>
            <table class="table table-striped table-sm"> 
            <thead>
              <tr>
                <th scope="col">Transaction Id</th>
                <th scope="col">Transaction Date</th>
                <th scope="col">Payment Type</th>
                <th scope="col">Status</th>
                <th scope="col">Action</th>
              </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="TransactionRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                      <td><%# Eval("Id") %></td>
                      <td><%# Eval("transaction_date") %></td>
                      <td><%# Eval("payment.name") %></td>
                      <td><%# Eval("status") %></td>
                      <td>
                          <asp:LinkButton ID="ViewDetailBtn" runat="server" OnClick="ViewDetailBtn_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary">View Details</asp:LinkButton>
                      </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </tbody>
          </table>
        </div>
        <div class="table-responsive" id="AdminTable" runat="server">
            <h1>Waiting Transaction list</h1>
            <table class="table table-striped table-sm"> 
            <thead>
              <tr>
                <th scope="col">Transaction Id</th>
                <th scope="col">Customer Name</th>
                <th scope="col">Transaction Date</th>
                <th scope="col">Payment Type</th>
                <th scope="col">Status</th>
                <th scope="col">Action</th>
              </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="AdminWaitingRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                      <td><%# Eval("Id") %></td>
                      <td><%# Eval("user.name") %></td>
                      <td><%# Eval("transaction_date") %></td>
                      <td><%# Eval("payment.name") %></td>
                      <td><%# Eval("status") %></td>
                      <td>
                          <asp:LinkButton ID="ViewDetailBtn" OnClick="ViewDetailBtn_Click" runat="server" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary">View Details</asp:LinkButton>
                          <asp:LinkButton ID="AcceptBtn" runat="server" OnClick="AcceptBtn_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-success">Accept</asp:LinkButton>
                          <asp:LinkButton ID="DeclineBtn" runat="server" OnClick="DeclineBtn_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger">Decline</asp:LinkButton>
                      </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </tbody>
          </table>
        </div>
        <div class="table-responsive" id="AdminTable2" runat="server">
            <h1>All Transaction list</h1>
            <table class="table table-striped table-sm"> 
            <thead>
              <tr>
                <th scope="col">Transaction Id</th>
                <th scope="col">Customer Name</th>
                <th scope="col">Transaction Date</th>
                <th scope="col">Payment Type</th>
                <th scope="col">Status</th>
                <th scope="col">Action</th>
              </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="AdminRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                      <td><%# Eval("Id") %></td>
                      <td><%# Eval("user.name") %></td>
                      <td><%# Eval("transaction_date") %></td>
                      <td><%# Eval("payment.name") %></td>
                      <td><%# Eval("status") %></td>
                      <td>
                          <asp:LinkButton ID="ViewDetailBtn" OnClick="ViewDetailBtn_Click" runat="server" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary">View Details</asp:LinkButton>
                      </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </tbody>
          </table>
        </div>

    </div>
</asp:Content>
