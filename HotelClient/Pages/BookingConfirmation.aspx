<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="BookingConfirmation.aspx.cs" MasterPageFile="~/Pages/HeaderAndFooter.Master" Inherits="HotelClient.Pages.BookingConfirmation" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Conform Your Booking | Taj Lake Palace, Udaipur | Taj Hotels</title>
    <link rel="stylesheet" type="text/css" href="Css/BookingConfirmation.css" />
</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pdfcontent">
        <div class="main-confirm" id="mainContent">
            <div class="half-confirm">
                <div class="image-confirm">
                    <img src="../Images/confirmBooking.png" />
                </div>
                <div class="head-confirm">
                    <h1>Thank You</h1>
                </div>
                <div class="print-conform">
                    <input type="button" onclick="captureHtmlAndSubmit()" id="print" value="PRINT" />
                    <input type="button" onclick="cancelClick()" id="cancel" value="Cancel Reservation" />
                    <asp:Button runat="server" OnClick="print_Click" Style="display: none" ID="print_submit" />
                    <asp:Button runat="server" ID="cancelBook" style="display:none" OnClick="cancelBook_Click"/>
                </div>
            </div>
            <div class="lower-half-confirm">
                <div class="general-confi">
                    <p style="font-weight: bold;">IDENTIFICATION REQUIRED</p>
                    <p>Driving License |Voter ID Card |Aadhaar Card |Bank Pass Book with Photograph |Passport and valid visa(mandatory for foreign nationals)</p>
                </div>
                <div class="details-confirm">
                    <div class="head-details-confirm">
                        <h3>Booking Details</h3>
                    </div>
                    <div id="infoConfirm" class="info-confirm">
                    </div>

                </div>
            </div>
            <input type="hidden" value="hiddenInputForData" runat="server" id="hiddenInnerHtml" />
        </div>
    </div>
    <script type="text/javascript">
        let hiddenInnerHtmlId = '<%=hiddenInnerHtml.ClientID%>';
        let print_submitId = '<%=print_submit.ClientID%>';
        let cancel_submitId = '<%=cancelBook.ClientID%>';
        let reservationInfo = <%=Session["reservationInfo"] ?? "''"%>;
        let reservationId = <%=Session["bookingId"] ?? "''"%>;
    </script>
    <script src="Script/confirmBook.js"></script>
</asp:Content>
