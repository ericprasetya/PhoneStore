<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="projectPSD.Views.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    
    <div class="form-signin col-lg-6" style="margin: 100px 0 100px 0;">
        <h1 class="h3 mb-3 fw-normal">Please Login</h1>

        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Text=""></asp:Label>

        <asp:LinkButton ID="loginBtn" runat="server" CssClass="w-100 btn btn-lg btn-primary" OnClick="loginBtn_Click">Log in</asp:LinkButton>
    </div>
</asp:Content>
