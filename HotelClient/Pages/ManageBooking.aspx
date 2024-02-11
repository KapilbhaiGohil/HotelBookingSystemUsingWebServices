<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/HeaderAndFooter.Master" CodeBehind="ManageBooking.aspx.cs" Inherits="HotelClient.Pages.ManageBooking" %>


<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Taj Lake Palace, Udaipur - Grand Palace Hotel in Udaipur at Lake Pichola | Taj Hotels</title>
    <link rel="stylesheet" type="text/css" href="Css/ManageBoooking.css" />
</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="MainContent" runat="server">
    <div class="manage-main">
        <div class="manage-head">
            <span>Find Your Reservations</span>
        </div>
        <div  class="manage-outside">
            <div class="manage-form-head">
                <span>With BookingId # And Email #</span>
            </div>
            <div style="display:none" id="errMsg" class="err-msg">
                <div class="err-img">
                    <img src="../Images/error.png"/>
                </div>
                <div>
                    <p>We Apologize. We Cannot Locate Your Reservation. Please Check Your Information And Try Again.</p>
                </div>
            </div>
           
            <div class="manage-form">
                <div>
                    <asp:TextBox required ="true" type="text" runat="server" ID="bookingid" placeholder="Booking No"/>
                </div>
                <div>
                    <asp:TextBox required ="true" type="email" runat="server" ID="email" placeholder="Email Address"/>
                </div>
                <div>
                    <asp:Button runat="server" ID="findReservation" OnClick="findReservation_Click" type="submit" text="FIND RESERVATION"/>
                </div>
            </div>
            <div class="mange-text">
                <p>Don't know your confirmation #?</p>
                <p>Your confirmation # was included in an email sent at the time of booking. Please check your email to recover the number.</p>
            </div>
        </div>
    </div>
    <script src="Script/ManageBooking.js"></script>
</asp:Content>
