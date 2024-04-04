const date1 = new Date(requiredRooms.from);
const date2 = new Date(requiredRooms.to);
const timeDifference = date2.getTime() - date1.getTime();
const TotalDays = Math.floor(timeDifference / (1000 * 60 * 60 * 24));
console.log(jsrooms);
let totalrooms = document.getElementById("totalRooms");
let html = "";
for (let j = 0; j < RefactorRooms.length; j++) {
    const numericPrice = parseInt(RefactorRooms[j].Price) * TotalDays;
    html += `
     <div class="room-outer">
        <div class="room-image">
            <img src="../Images/Rooms/`+ RefactorRooms[j].Type + `.jpeg"/>
        </div>

        <div class="room-details">
            <div class="heading">
                <span>`+ RefactorRooms[j].Type + `</span>
            </div>
            <div class="text-content">
                <p> `+ RefactorRooms[j].Desc + `</p>
            </div>
            <div class="room-facilities">
                <div class="facilities">
                    <div>
                        <div>
                            <img src="../Images/area.png" />
                            <p>`+ RefactorRooms[j].Area + `</p>
                        </div>
                        <div>
                            <img src="../Images/wifi.png" />
                            <p>Inclusive Wifi</p>
                        </div>

                    </div>
                    <div>
                        <div>
                            <img src="../Images/maximumOccoumpany.png" />
                            <p>Up to `+ RefactorRooms[j].Capasity +`  guest</p>
                        </div>
                        <div>
                            <img src="../Images/bedType.png" />
                            <p>`+ RefactorRooms[j].Bedtype + `</p>
                        </div>

                    </div>
                </div>`
    if (!isAvailable(RefactorRooms[j].Type)/*condition for the room should show price or not*/) {
        html += `
               <div class="price">
                    <p style="    width: 22rem;text-align: justify;font-weight: bold;">
                        This Room doesn't match your search criteria.Please try selecting alternate dates, modifying your search options, or choosing an alternate property.</p>
                </div>
            </div>
        </div>
    </div>
        `
    } else {
        html += `
               <div class="price">
                <span>&#x20B9; `+ numericPrice.toLocaleString() + `</span>
 <p>Rate (including all days)</p>
 <input type="button" onclick="addToCart('`+ RefactorRooms[j].Type + `','` + numericPrice + `')" value="Select Room" />
               </div>
            </div>
        </div>
    </div>
        `
    }
}
totalrooms.innerHTML = html;

function isAvailable(heading) {
    //console.log(heading)
    //jsrooms.map((obj) => console.log(obj.Type));
    const res = jsrooms.findIndex((obj) => obj.Type === heading);
    console.log(res);
    if (res!==-1) return true;
    return false;
}


let cart = document.getElementById("cart");
let cartCheckoutBtn = `<div id="cardCheckoutBtn" onclick="handleBookingDataSubmit()" class="cart-button">
            <div class="cart-image">
                <img src="../Images/cart.svg"/>
            </div>
            <div class="cart-price">
                <div id="finalprice">
                    0
                </div>
                <div>
                    CHECKOUT
                </div>
            </div>
        </div>`;

let cartData = [];
let currentCartIndex = 0;
let randomId = 0;
refreshCart();
function addToCart(heading, price) {
    if (currentCartIndex !== requiredRooms.Rooms.length) {
        cart.style.display = "flex";
        let obj = {};
        obj.heading = heading;
        obj.price = price;
        obj.adults = requiredRooms.Rooms[currentCartIndex].adult;
        obj.children = requiredRooms.Rooms[currentCartIndex].children;
        randomId = (randomId + 1) % 10;
        obj.randomId = randomId;
        objInnterHtml = cart.innerHTML+`
        <div id="`+ (obj.heading + randomId) + `" class="cart-item">
            <div class="cart-text-content">
                <div class="cart-room-heading">
                    <span>`+ obj.heading.substring(0, 20) + "..." + `</span>
                </div>
                <div class="cart-info">
                    <p>&#x20B9; ${obj.price.toLocaleString()} | ${TotalDays} night</p>
                    <p>1 Room | `+ obj.adults + ` Guests, ` + obj.children + ` Child</p>
                </div>
            </div>
            <div class="cart-delete-img">
                <img onclick="deleteCartItem('`+ obj.heading + `',` + randomId + `)" src="../Images/icons8-delete-100.png" width="2%" />
            </div>
        </div>
`;
        cart.innerHTML = objInnterHtml;
        currentCartIndex++;
        cartData.push(obj);
        refreshCart();
    }
}

function deleteCartItem(heading, randomId) {
    console.log("INside the delete cartdata", cartData, heading, randomId)
    cartData = cartData.filter((obj) => ((obj.heading !== heading) || (obj.randomId !== randomId)));
    currentCartIndex--;
    console.log("after delete cartdata", cartData)
    refreshCart();
}
function refreshCart() {
    console.log("Inside the refreshCart ", cartData);
    let finalhtml = "";
    let TotalPrice = 0;
    for (let j = 0; j < cartData.length; j++) {
        finalhtml = finalhtml + getCartItem(cartData[j], j);
        TotalPrice = TotalPrice+(parseInt(cartData[j].price));
    }
    cart.innerHTML = finalhtml + cartCheckoutBtn;
    document.getElementById("finalprice").innerHTML = `&#x20B9; ${TotalPrice.toLocaleString()}`;
    let emptyRoom = `<div class="cart-additem">SELECT ROOM + </div>`;
    if (requiredRooms.Rooms.length > 1) {
        let emptycarthtml = "";
        for (let i = 0; i < requiredRooms.Rooms.length - cartData.length; i++) {
            emptycarthtml += emptyRoom;
        }
        cart.innerHTML += emptycarthtml;
    }
    if (currentCartIndex === 0) cart.style.display = "none";
}
function getCartItem(obj,i) {
    return `
        <div id="`+ (obj.heading + randomId) + `" class="cart-item">
            <div class="cart-text-content">
                <div class="cart-room-heading">
                    <span>`+ obj.heading.substring(0, 20) + "..." + `</span>
                </div>
                <div class="cart-info">
                    <p>&#x20B9;${parseInt(obj.price).toLocaleString()} | ${TotalDays} night</p>
                    <p>1 Room | `+ requiredRooms.Rooms[i].adult + ` Guests, ` + requiredRooms.Rooms[i].children + ` Child</p>
                </div>
            </div>
            <div class="cart-delete-img">
                <img onclick="deleteCartItem('`+ obj.heading + `',` + obj.randomId + `)" src="../Images/icons8-delete-100.png" width="2%" />
            </div>
        </div>
`
}
const FinalBookingDataObject = {};
function handleBookingDataSubmit() {
    if (cartData.length !== requiredRooms.Rooms.length) {
        window.alert("Pls Select All Rooms");
    } else {
        const TotalBill = parseInt((document.getElementById("finalprice").textContent).replace(/[^0-9.*]/g, ''));
        FinalBookingDataObject.price = TotalBill;
        FinalBookingDataObject.checkin = requiredRooms.from;
        FinalBookingDataObject.checkout = requiredRooms.to;
        FinalBookingDataObject.rooms = cartData;
        FinalBookingDataObject.totaldays = TotalDays;
        console.log(FinalBookingDataObject)
        document.getElementById(hiddenInputForBookingDataClientId).value = JSON.stringify(FinalBookingDataObject);
        document.getElementById(complexDataForBookingDataClientId).click(); 
    }
};


console.log("This is a RefactorRooms : ", RefactorRooms)