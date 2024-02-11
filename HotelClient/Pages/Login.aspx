<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/HeaderAndFooter.Master" CodeBehind="Login.aspx.cs" Inherits="HotelClient.Pages.Login" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Taj Login</title>
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
                <p>Sign in to proceed.</p>
            </div>
        </div>
        <div class="login-main">
            <div class="login-text">
                <span>Login</span>
            </div>
            <div class="input-email">
                <asp:TextBox runat="server" required="true" ID="email" type="email" placeholder="Enter Email ID" AutoCompleteType="Email" />
                <asp:TextBox runat="server" required="true" ID="pass" type="password" placeholder="Enter Password" />
            </div>
            <div class="login-privacy">
                <span>
                    <img src="../Images/checkbox_unchecked.png" onclick="changeCheckbox()" id="checkbox" width="1.3%" /></span>
                <span>I agree to the</span>
                <a href="">Privacy Policy</a>
                <a style="margin-left: 9rem;" href="Register.aspx">Register here</a>
            </div>
            <div class="login-button">
                <!--<input type="button" value="Continue" id="login_button"/>-->
                <asp:Button  Text="Continue" disabled="true" ID="login_button" runat="server" OnClick="login_button_Click" />
            </div>
            <div class="login-terms">
                <span>By continuing you agree to our</span>
                <a href="">Terms of Use</a>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        let btnLoginId = '<%=login_button.ClientID%>';
        let emaiInputId = '<%=email.ClientID%>';
        let passInputId = '<%=pass.ClientID%>'
    </script>
    <script src="Script/login.js" type="text/javascript"></script>
</asp:Content>
