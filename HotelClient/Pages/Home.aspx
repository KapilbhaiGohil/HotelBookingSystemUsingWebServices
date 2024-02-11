<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" MasterPageFile="~/Pages/HeaderAndFooter.Master" Inherits="HotelClient.Home" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Taj Lake Palace, Udaipur - Grand Palace Hotel in Udaipur at Lake Pichola | Taj Hotels</title>
    <link rel="stylesheet" type="text/css" href="Css/Home.css" />

</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home-body">
        <div class="heading">
            <h1><span>Taj Lake Palace</span></h1>
        </div>
        <div>
            <div class="hotel-info-outer">
                <div class="hotel-text">
                    <div>
                        <h4><span>Grand Palace Hotel in Udaipur at Lake Pichola</span></h4>
                        <div class="links">
                            <img src="../Images/map.png" width="1.5%" />
                            <a
                                href="https://www.google.com/maps/search/Taj+Lake+Palace,Udaipur@24.575102,73.679946/@24.575493,73.6799334,17z/data=!3m1!4b1?entry=ttu"
                                target="_blank">P.O Box No. 5, Lake Pichola, Udaipur, Rajasthan, 313001, Rajasthan, India, India
                            </a>
                        </div>
                        <div class="links">
                            <img src="../Images/call.png" width="1.5%" />
                            <a
                                href="tel:+91 2942428800"
                                target="_blank">+91 294-2428800
                            </a>
                        </div>
                        <div class="links">
                            <img src="../Images/icons8-mail-25.png" width="1.5%" />
                            <a
                                href="mailto:lakepalace.udaipur@tajhotels.com"
                                target="_blank">lakepalace.udaipur@tajhotels.com
                            </a>
                        </div>
                        <p id="para">
                            Jag Niwas, constructed between 1743-1746 by Maharana Jagat Singh II, the 62
   <sup>nd</sup>
                            custodian of House of Mewar, was used as a summer retreat by the Mewar Royal family over years until Maharana Bhagwat Singh, Mewar of Udaipur in 1963 converted it into a heritage hotel. A jewel
   <span id="dots">...</span>
                            <button type="button" id="more" onclick="showMoreInfo()">Show More</button>
                        </p>
                    </div>
                    <div class="highlights">
                        <h4>Hotel Highlights</h4>
                        <div>
                            <div>
                                <img src="../Images/map.png" width="4.5%" />
                                <p>18th Century Historic Palace</p>

                            </div>
                            <div>
                                <img src="../Images/lake.png" width="4.5%" />
                                <p>Floating in the Middle of a Lakes</p>
                            </div>
                        </div>
                        <div>

                            <div>
                                <img src="../Images/map.png" width="1.7%" />
                                <p>Exclusive Palace Butler Service</p>
                            </div>
                            <div>
                                <img src="../Images/icons8-food-24.png" width="1.7%" />
                                <p>Royal Historic Boat Romantic Dinner</p>
                            </div>

                        </div>
                    </div>
                    <div class="policy">
                        <h4>Hotel Policies</h4>
                        <ul>
                            <li>Check-in time: 2:00 PM</li>
                            <li>Check-out time: 12:00 Noon</li>
                            <li>Early check-in and late check-out on request.</li>
                            <li>We accept American Express, Diner's Club, Master Card, Visa, JCB International.</li>
                            <li>Pets are not allowed.</li>
                            <li>The Palace is a Resident only facility and all services and facilities are solely for our in house guests. The resident only policy is in place to</li>
                            <li>ensure a tranquil experience for our guests.</li>
                        </ul>
                    </div>
                </div>
                <div class="hotel-image">
                    <div style="padding-bottom: 0.9rem">
                        <img src="../Images/Hotel/1.jpeg" width="100%" height="270rem" />
                    </div>
                    <div id="image-content">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="card-outer" class="card-outer">
        <div>
            <h1>Guest Rooms</h1>
        </div>
        <div id="onescreen" class="onescreen">
        </div>
        <div id="left-arr" class="left-arr">
            <img src="../Images/left.png" width="100%" />
        </div>
        <div id="right-arr" class="right-arr">
            <img src="../Images/right.png" width="100%" />
        </div>
    </div>
    <p style="margin: 1rem 7rem;">*Rates Exclusive of taxes</p>
    <div class="awards">
        <div class="award-head">
            <span>Awards</span>
        </div>
        <div class="div-award-cards" id="div-award-cards">
        </div>
        <div id="left-arr-award" class="left-arr-award">
            <img src="../Images/left.png" width="100%" />
        </div>
        <div id="right-arr-award" class="right-arr-award">
            <img src="../Images/right.png" width="100%" />
        </div>
    </div>
    <div class="location">
        <div class="location-heading">
            <span>Location</span>
        </div>
        <div class="map">
            <iframe src="https://www.google.com/maps/embed?pb=!1m28!1m12!1m3!1d21832.47422351335!2d73.69339725036292!3d24.58234187976845!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m13!3e6!4m5!1s0x3967efecf87f0b8b%3A0x2708953a0e177443!2sTaj%20Lake%20Palace%2C%20Pichola%2C%20Udaipur%2C%20Rajasthan!3m2!1d24.575492999999998!2d73.6799334!4m5!1s0x3967e56550a14411%3A0xdbd8c28455b868b0!2sUdaipur%2C%20Rajasthan!3m2!1d24.585445!2d73.712479!5e0!3m2!1sen!2sin!4v1696345392613!5m2!1sen!2sin" width="600" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
        <div class="location-info">
            <p>Taj Lake Palace, Udaipur is conveniently located within touching distance to prominent tourist attractions in and around Udaipur. Our palace hotel in Udaipur is also the perfect destination for a blissful getaway from Delhi, Jaipur & Ahmedabad. Enjoy our warm hospitality and service that make you feel at home. Explore the all meals inclusive 4D Travel offer to plan your next stay.</p>
        </div>
    </div>
    <script type="text/javascript">
        let RefactorRooms = <%=Session["RefactorRooms"] ?? "" %>;
    </script>
    <script src="Script/Home.js"></script>
</asp:Content>
