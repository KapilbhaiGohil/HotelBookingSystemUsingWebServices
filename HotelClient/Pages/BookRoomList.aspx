<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookRoomList.aspx.cs" MasterPageFile="~/Pages/HeaderAndFooter.Master" Inherits="HotelClient.Pages.BookRoomList" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Available Room's List | Taj Lake Palace, Udaipur | Taj Hotels</title>
    <link rel="stylesheet" type="text/css" href="Css/BookRoom.css" />
</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="complexDataForBookingData" runat="server" OnClick="complexDataForBookingData_Click" Style="display: none" Text="none" />
    <input type="hidden" runat="server" id="hiddenInputForBookingData" />

    <div class="information">
        <div class="info-heading">
            <span>Guest Rooms at Taj Lake Palace, Udaipur</span>
        </div>
        <div class="text">
            <div class="normal-text">
                <p>Our suites & rooms in Udaipur have it all worked out for you. Smart and elegant, these beautifully designed, our suites & rooms are spacious and well equipped with the best amenities that offer picturesque view of the gardens or city or the hills. </p>
            </div>
            <div class="bold-text">
                <p>In light of the current situation, we have implemented enhanced precautionary hygiene measures across our hotel.</p>
                <p>As per the latest Government advisory, a copy of Vaccination certificate is mandatory on arrival at the hotel. After 31st January 2022 double dose of vaccination will be mandatory.</p>
                <p>The health and safety of our guests and associated is our utmost priority and we look forward to welcoming you at the hotel.</p>
                <p>For further details, kindly contact prior to check-in at lakepalace.udaipur@tajhotels.com</p>
            </div>
        </div>
        <div class="selection">
            <span style="color: #aa7938">Select Room 1</span>
            <span>for 1 adult and 0 child</span>

        </div>
    </div>
    <div id="totalRooms">
    </div>
    <div id="cart" style="display:none"  class="cart">

    </div>
    <script type="text/javascript">
        let RefactorRooms = <%=Session["RefactorRooms"] ?? "" %>;
        let jsrooms = <%=Session["jsrooms"] ?? "''"%>
        let requiredRooms = <%=Session["requiredRooms"] ?? "''" %>
        var complexDataForBookingDataClientId = "<%= complexDataForBookingData.ClientID %>";
        var hiddenInputForBookingDataClientId = '<%= hiddenInputForBookingData.ClientID %>';
        
    </script>
    <script src="Script/BookRoom.js"></script>
</asp:Content>
