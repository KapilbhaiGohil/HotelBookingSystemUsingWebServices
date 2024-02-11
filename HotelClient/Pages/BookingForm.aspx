<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingForm.aspx.cs" MasterPageFile="~/Pages/HeaderAndFooter.Master" Inherits="HotelClient.Pages.BookingForm" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Reservation Form | Taj Lake Palace, Udaipur | Taj Hotels </title>
    <link rel="stylesheet" type="text/css" href="Css/BookingForm.css" />
</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="MainContent" runat="server">
    <div class="error" id="error">
        <div class="error-text" id="error-text"></div>
    </div>
    <div class="booking-form-outer">
        <div class="booking-heading-upper">
            <span>Review Your Booking</span>
        </div>
        <div class="booking-cover">
            <div class="booking-form-uppe">
                <div class="booking-image">
                    <img src="../Images/tajBookForm.jpeg" width="18%" />
                </div>
                <div class="booking-data">
                    <div class="booking-head">
                        <span>Taj Lake Palace, Udaipur</span>
                        <p>Udaipur, Rajasthan, 313001, Rajasthan, India, India</p>
                    </div>
                    <div class="booking-body">
                        <div class="booking-date">
                            <div id="finalBookingDataCheckin">Check in Date</div>
                            <div id="finalBookingDataCheckout">Checkout Date</div>
                        </div>
                        <div class="booking-rooms">
                            <div class="booking-data-info">
                                <span id="dayAndNight">2 Days & 1 Night</span>
                                <span style="float: right;">
                                    <input type="button" onclick="goBack()" value="Change Room" /></span>
                            </div>
                            <div id="each-room-info" class="booking-each-room-info">
                                <div>
                                    <span>
                                        <img src="../Images/bedIcon.png" width="5%" /></span>
                                    ROOM 1:Palace Room Lake View - 1 Adult | 0 Child
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="booking-form-lower">
                <div class="booking-lower-heading">
                    <h1>Selected rooms</h1>
                </div>
                <div class="selectedRoomId" id="selectedRoom">
                </div>
            </div>
        </div>
    </div>
    <div class="travellers-details-outer">
        <h1>Enter Traveller Details</h1>
        <div class="travellers-form">
            <h1>Guest details</h1>
            <div class="actual-form">
                <div class="first-row">
                    <div>
                        <label for="">FirstName*</label>
                        <input required="true" id="firstname" type="text" />
                    </div>
                    <div>
                        <label for="">LastName*</label>
                        <input required="true" id="lastname" type="text" />
                    </div>
                </div>
                <div class="second-row">
                    <div>
                        <label for="">Email*</label>
                        <input required="true" id="email" type="email" />
                    </div>
                    <div>
                        <label for="">Country*</label>
                        <input style="width: 6rem; padding: 0.3rem"
                            type="text" value="India(+91)" readonly="true" />
                    </div>
                    <div>
                        <label for="">Phone Number*</label>
                        <input required="true" id="number" type="number" />
                    </div>
                </div>
                <div class="third-row">
                    <div>
                        <label for="">Special Requests</label>
                        <textarea style="width: 52.5rem; height: 10rem;    padding: 1rem;"
                            id="specialrequest"></textarea>
                    </div>
                </div>
                <!--<div class="agreement">
                    <div>
                        <span>
                            <img src="../Images/checkbox_unchecked.png" width=" 1.2%" /></span>
                        <span>I have read and understood the <a>Privacy Policy.</a>*</span>
                    </div>
                    <div>
                        <span>
                            <img src="../Images/checkbox_unchecked.png" width=" 1.2%" /></span>
                        <span>I have read and agree to the <a>General Terms & Conditions</a>*</span>
                    </div>
                </div>-->
            </div>
            <div class="final-button-container">
                <input type="hidden" value="hiddenbtn3" runat="server" id="hiddenField" />
                <asp:Button runat="server" Style="display: none" ID="finalBookButton" OnClick="finalBookButton_Click" />
                <input onclick="BookARoom()" type="button" value="Book" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        let finalBookingData = <%=Session["finalBookingData"] ?? "''"%>;
        let jsrooms = <%=Session["jsrooms"] ?? "''"%>;
        let finalAspButton = '<%= finalBookButton.ClientID%>';
        let finalStorage = '<%= hiddenField.ClientID%>';
        function goBack() {
            window.location.href = "/Pages/BookRoomList.aspx";
        }
    </script>
    <script src="Script/BookingForm.js"></script>
</asp:Content>
