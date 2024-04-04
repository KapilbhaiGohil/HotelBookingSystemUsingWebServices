if (reservationInfo === "") {
    window.location.href = "/Pages/Home.aspx";
}
//showMsg({info:"Thanks For Choosing Us",status:0})
function isValidDateFormat(dateString) {
    var regexPattern = /^\d{4}-\d{2}-\d{2}$/;
    return regexPattern.test(dateString);
}
console.log(reservationInfo.checkin);
if (isValidDateFormat(reservationInfo.checkin)) {
    let dateStr = reservationInfo.checkin;
    reservationInfo.checkin = new Date(reservationInfo.checkin).toLocaleDateString("en-GB");
    reservationInfo.checkout = new Date(reservationInfo.checkout).toLocaleDateString("en-GB");
} else {
    reservationInfo.checkout = new Date(parseInt(reservationInfo.checkout.replace(/\/Date\((\d+)\)\//, '$1'))).toLocaleDateString("en-GB");
    reservationInfo.checkin = new Date(parseInt(reservationInfo.checkin.replace(/\/Date\((\d+)\)\//, '$1'))).toLocaleDateString("en-GB");
}
console.log(reservationInfo);

document.getElementById("home-image").style.display = 'none';
let confirmContent = `
                     <div class="overview-book">
                        <div class="booking-id">
                            <div class="info-head">
                                Booking-Id
                            </div>
                            <div class="info-info">
                                ${reservationId}
                            </div>
                        </div>
                        <div class="checkin-date">
                            <div class="info-head">
                                Check - In
                            </div>
                            <div class="info-info">
                                ${reservationInfo.checkin}
                            </div>
                        </div>
                        <div class="checkoutdate">
                            <div class="info-head">
                                 Check - Out
                            </div>
                            <div class="info-info">
                                  ${reservationInfo.checkout}
                            </div>
                        </div>
                        <div>
                            <div class="info-head">
                                Total Rooms 
                            </div>
                            <div class="info-info">
                                  ${reservationInfo.rooms.length}
                            </div>
                        </div>
                        <div>
                            <div class="info-head">
                                Adults 
                            </div>
                            <div class="info-info">
                                 ${reservationInfo.rooms.reduce((acc, per) => acc + per.adults, 0)}
                            </div>
                        </div>
                        <div>
                            <div class="info-head">
                                Children 
                            </div>
                            <div class="info-info">
                                      ${reservationInfo.rooms.reduce((acc, per) => acc + per.children, 0)}
                            </div>
                        </div>
                        <div class="total">
                            <div class="info-head">
                                Total Price 
                            </div>
                            <div class="info-info">
                                  &#x20B9; ${reservationInfo.price.toLocaleString()}
                            </div>
                        </div>
                        <div class="status">
                            <div class="info-head">
                                Status
                            </div>
                            <div class="info-info" style="color: green; rotate: initial; font-weight: bold; text-transform: capitalize;">
                                Confirmed
                            </div>
                        </div>
                    </div>
                    <div class="gauest">
                        <div class="gauest-head">
                            <h2>Gauest Details</h2>
                        </div>
                        <div class="gauest-details">
                            <div class="firstname">
                                <img src="../Images/man.png" />
                                <p>  ${reservationInfo.firstname + reservationInfo.lastname}</p>
                            </div>
                            <div class="phone">
                                <img src="../Images/call.png" />
                                <p>  ${reservationInfo.number}</p>
                            </div>
                            <div class="email">
                                <img src="../Images/icons8-mail-25.png"/>
                                <p>  ${reservationInfo.email}</p>
                            </div>
                        </div>
                    </div>
                    <div class="room-details">
                        <div class="room-head">
                            <h2>Room Details</h2>
                        </div>
                        <div class="room-info">
                            <table>
                                <thead>
                                    <tr>
                                        <th>Room Type</th>
                                        <th>Adults</th>
                                        <th>Children</th>
                                        <th>Price</th>
                                    </tr>
                                </thead>
                                <tbody id = "tbody">
                                    
                                </tbody>
                            </table>
                        </div>
                    </div>
`;
let parentDiv = document.getElementById("infoConfirm");
parentDiv.innerHTML = confirmContent;
let roomInfoInnerHtml = ``;
let tbody = document.getElementById("tbody")
for (let i = 0; i < reservationInfo.rooms.length; i++) {
    roomInfoInnerHtml += `   <tr>
                                        <td>${reservationInfo.rooms[i].heading}</td>
                                        <td>${reservationInfo.rooms[i].adults}</td>
                                        <td>${reservationInfo.rooms[i].children}</td>
                                        <td> &#x20B9; ${reservationInfo.rooms[i].price.toLocaleString()}</td>
                                    </tr>`;
}
roomInfoInnerHtml += `
<tr style="background:#e3dad6;color:black;font-weight:bold;">
    <td colspan="3">Total</td>
    <td>&#x20B9;${reservationInfo.price}</td >
<tr>
`
tbody.innerHTML = roomInfoInnerHtml;


function captureHtmlAndSubmit() {
    let htmlContent = document.getElementById("pdfcontent").innerHTML;
    document.getElementById(hiddenInnerHtmlId).value =
        `
                   <!DOCTYPE html>
                    <html>
                    <head>
                            <link rel="stylesheet" type="text/css" href="Css/pdf.css" />
                    </head>
                   <body>
                `+
        htmlContent +
        `</body>
                </html>
                `;
    console.log(document.getElementById(hiddenInnerHtmlId).value);
    document.getElementById(print_submitId).click();
}
function cancelClick() {
    if (window.confirm("Are You Sure ?")) {
        document.getElementById(cancel_submitId).click();
    }
}

