document.getElementById("home-image").style.display = 'none';
console.log(jsrooms);
if (finalBookingData == "" || jsrooms == "") {
    window.location.href = "/Pages/Home.aspx";
}

console.log(finalBookingData);
let finalBookingDataCheckin = document.getElementById("finalBookingDataCheckin")
let finalBookingDataCheckout = document.getElementById("finalBookingDataCheckout")
let dayAndNight = document.getElementById("dayAndNight");
let rooms = document.getElementById("each-room-info");
let selectedRoom = document.getElementById("selectedRoom");

finalBookingDataCheckin.innerHTML = "<p>From : </p><p>" + finalBookingData.checkin +"</p>";
finalBookingDataCheckout.innerHTML = "<p>To : </p><p>" + finalBookingData.checkout + "</p>";
dayAndNight.innerHTML = getDaysAndNight();
rooms.innerHTML = getRoomsList();
selectedRoom.innerHTML = getSelectedRoomsList();


function BookARoom() {
    const data = {...finalBookingData}
    let specialreqest = document.getElementById("specialrequest").value;
    let firstname = document.getElementById("firstname").value;
    let lastname = document.getElementById("lastname").value;
    let number = document.getElementById("number").value;
    let email = document.getElementById("email").value;
    data.firstname = firstname;
    data.lastname = lastname;
    data.email = email;
    data.number = number;
    data.specialrequest = specialreqest;
    console.log("thiss a final booking data" + JSON.stringify(data));
    let submitbtn = document.getElementById(finalAspButton);
    document.getElementById(finalStorage).value = JSON.stringify(data);
    if (number.length != 10) {
        showMsg({ info:"Pls Enter A Valid Mobile Number", status:1})
    } else {
        submitbtn.click();
    }
}
function getDaysAndNight() {
    return `
        ${finalBookingData.totaldays + 1} Days && ${finalBookingData.totaldays} Nights
    `
}
function getRoomsList() {
    let innrtHtml = "";
    for (let i = 0; i < finalBookingData.rooms.length; i++) {
        innrtHtml += `
        <div>
            <span>
                <img src="../Images/bedIcon.png" width="5%" />
            </span>
                ROOM ${i + 1}:${finalBookingData.rooms[i].heading} - ${finalBookingData.rooms[i].adults}  Adult | ${finalBookingData.rooms[i].children}  Child
       </div>
    `;
    }
    return innrtHtml;
}

function getSelectedRoomsList() {
    let innertHtml = "";
    for (let i = 0; i < finalBookingData.rooms.length; i++) {
        innertHtml += `
        <div class="booking-lower-visual">
              <div class="booking-lower-head">
                        <img src="../Images/Rooms/${finalBookingData.rooms[i].heading}.jpeg" />
                    </div>
                    <div class="booking-lower-info">
                        <div class="booking-lower-room-img"></div>
                        <div class="booking-loewr-price-info">
                            <span>Rate description:</span>
                            <p>${jsrooms.find((room) => room.Type === finalBookingData.rooms[i].heading).Desc}</p>
                            <p><b>Room only rate include basic Wi-Fi up to 4 Devices. Taxes extra</b></p>
                        </div>
                        <div class="booking-lower-gauest-info">
                            <div class="man">
                                <span>
                                    <img src="../Images/man.png" width="4%" /></span>
                                <span>${finalBookingData.rooms[i].adults}</span>
                            </div>
                            <div class="children">
                                <span>
                                    <img src="../Images/children.png" width="4%" /></span>
                                <span>${finalBookingData.rooms[i].children}</span>
                            </div>
                        </div>
                        <div class="booking-lower-price">
                            <span>₹ ${finalBookingData.rooms[i].price} *</span>
                        </div>
                    </div>
                </div>
        </div>
        `
    }
    return innertHtml;
}