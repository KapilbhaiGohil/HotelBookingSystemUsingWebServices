<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/HeaderAndFooter.Master" CodeBehind="Register.aspx.cs" Inherits="HotelClient.Pages.Register" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Taj Register</title>
    <link rel="stylesheet" type="text/css" href="Css/Login.css" />
</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        document.getElementById("home-image").style.display = "none";
        document.getElementById("navbar").style.display = "none";
        document.addEventListener("DOMContentLoaded", () => {
            document.getElementById("footer").style.display = "none";
        });
    </script>
    <div class="login-outer">
        <div class="login-heading">
            <div>
                <img src="../Images/logo.png" width="10%" />
                <span>Welcome Back To Hotel Taj</span>
                <p>Sign Up to proceed.</p>
            </div>
        </div>
        <div class="login-main">
            <div class="login-text">
                <span>Register</span>
            </div>
            <div class="input-email">
                <asp:TextBox runat="server" required="true" ID="name" type="text" AutoCompleteType="FirstName" placeholder="Enter Your Name" />
                <asp:TextBox runat="server" required="true" ID="email" type="email" placeholder="Enter Email ID" AutoCompleteType="Email" />
                <asp:TextBox runat="server" required="true" ID="pass" type="password" placeholder="Enter Password" />
                <asp:TextBox runat="server" required="true" ID="number" type="number" AutoCompleteType="HomePhone" placeholder="Enter Your Phone No" />
            </div>
            <div class="login-privacy">
                <a style="padding:0" href="Login.aspx">Login here</a>
            </div>
            <div class="login-button">
                
                <asp:Button Text="Continue"  ID="register_button" runat="server" OnClick="register_button_Click" />
            </div>
            <div class="login-terms">
                <span>By continuing you agree to our</span>
                <a>Terms of Use</a>
            </div>
        </div>
    </div>
  
</asp:Content>
