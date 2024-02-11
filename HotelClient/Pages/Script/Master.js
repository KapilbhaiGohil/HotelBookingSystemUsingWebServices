var ele = document.getElementById("checkin");
var ele2 = document.getElementById("checkout");
var today = new Date(new Date().setHours(0, 0, 0, 0)).toLocaleDateString('fr-CA');
var tommorow = new Date(+new Date().setHours(0, 0, 0, 0) + 86400000).toLocaleDateString('fr-CA')
if (ele.textContent.trim() == "" && ele2.textContent.trim() == "") {
    ele.innerHTML = today;
    ele2.innerHTML = tommorow;
}
var calander1 = document.getElementById("setTodaysDate")
var calander2 = document.getElementById("setTommorowDate")

var today = new Date().toISOString().split('T')[0];
var calander1 = document.getElementById("setTodaysDate");
calander1.value = today;
document.getElementById("setTodaysDate").setAttribute('min', today);
var tomorrow = new Date();
tomorrow.setDate(tomorrow.getDate() + 1)
tomorrow.setUTCHours(0, 0, 0, 0);
var tomorrowISOString = tomorrow.toISOString().split('T')[0];
calander2.setAttribute('min', tomorrowISOString);
calander2.value = tomorrowISOString



calander1.addEventListener("change", () => {
    if (new Date(calander1.value) >= new Date(calander2.value)) {
        let day = new Date(calander1.value);
        day.setDate(day.getDate() + 1)
        day.setUTCHours(0, 0, 0, 0);
        calander2.value = day.toISOString().split('T')[0];
    }
})
calander2.addEventListener("change", () => {
    if (new Date(calander1.value) >= new Date(calander2.value)) {
        let day = new Date(calander2.value);
        day.setDate(day.getDate() - 1)
        day.setUTCHours(0, 0, 0, 0);
        calander1.value = day.toISOString().split('T')[0];
    }
})



var lastcnt = 1;
var currentselected = 1;
//increment decrement part of the adullt and children
//id for the parent is adultno and child is childno
//data maintaining
let bookingData = {
    Rooms: [{ children: 0, adult: 1 }]
};


function incrementchild() {
    var child = document.getElementById("childno" + currentselected);
    var cnt = child.innerHTML;
    let finalCount = parseInt(cnt) + 1 <= 4 ? parseInt(cnt) + 1 : 4;
    bookingData.Rooms[currentselected - 1].children = finalCount;
    child.innerHTML = finalCount;
    console.log(bookingData)
}
function decrementchild() {
    var child = document.getElementById("childno" + currentselected);
    var cnt = child.innerHTML;
    let finalCount = parseInt(cnt) - 1 >= 0 ? parseInt(cnt) - 1 : 0;
    bookingData.Rooms[currentselected - 1].children = finalCount;
    child.innerHTML = finalCount
    console.log(bookingData)
}
function incrementadult() {
    var child = document.getElementById("adultno" + currentselected);
    var cnt = child.innerHTML;
    let finalCount = parseInt(cnt) + 1 <= 4 ? parseInt(cnt) + 1 : 4;
    bookingData.Rooms[currentselected - 1].adult = finalCount;
    child.innerHTML = finalCount;
    console.log(bookingData)
}
function decrementadult() {
    var child = document.getElementById("adultno" + currentselected);
    var cnt = child.innerHTML;
    let finalCount = parseInt(cnt) - 1 >= 1 ? parseInt(cnt) - 1 : 1;
    bookingData.Rooms[currentselected - 1].adult = finalCount;
    child.innerHTML = finalCount
    console.log(bookingData)
}



//function for adding the new room 
function addroom() {
    var parent = document.getElementById("rooms");
    createRoomElement2(parent);
    addInfoEle();
    selectRoom(lastcnt)
    bookingData.Rooms.push({ children: 0, adult: 1 });
    if (lastcnt === 5) {
        var btn = document.getElementById("addbtn")
        btn.style.display = "none";
    }
}

function removeroom() {
    var ele = document.getElementById(lastcnt);
    removeInfoEle();
    ele.remove();
    bookingData.Rooms.pop();
    if (lastcnt === currentselected) {
        currentselected--;
        var parent = document.getElementById(currentselected);
        parent.className = "room active";
        var info = document.getElementById("infoele" + currentselected);
        info.style.display = "flex";
    }
    lastcnt--;
    if (lastcnt < 5) {
        var btn = document.getElementById("addbtn")
        btn.style.display = "inline-block";
    }
}
function addInfoEle() {
    var parent = document.getElementById("info");
    createInfoElement(parent);
}
function removeInfoEle() {
    var ele = document.getElementById("infoele" + lastcnt);
    ele.remove();
}
function createInfoElement(parent) {
    const html = `
    <div class="infoele" style="display:none;" id="infoele${lastcnt}">
        <div style="border-right: 1px solid #a49494;width: 50%;">
            ADULTS
            <button onclick="decrementadult()" type="button"><span>-</span></button>
            <span id="adultno${lastcnt}">1</span>
            <button onclick="incrementadult()" type="button"><span>+</span></button>
        </div>
        <div>
            CHILDREN 
            <button onclick="decrementchild()" type="button"><span>-</span></button>
            <span id="childno${lastcnt}">0</span>
            <button onclick="incrementchild()" type="button"><span>+</span></button>
        </div>
    </div>`;
    parent.innerHTML += html;
}
function createRoomElement2(parent) {
    lastcnt++;
    const html = `
        <div class="room" id="${lastcnt}">
            <button type="button" onclick="selectRoom(${lastcnt})">
                <span>Room </span>
                <span id="room${lastcnt}">${lastcnt}</span>
            </button>
            <img src="../Images/close.png" width="10%" onclick="removeroom()"/>
      </div>
    `;
    parent.innerHTML += html;
}
function selectRoom(receivedcnt) {
    var current = document.getElementById(currentselected)
    current.className = "room"
    var currinfo = document.getElementById("infoele" + currentselected);
    currinfo.style.display = "none"

    currentselected = receivedcnt;
    var parent = document.getElementById(currentselected);
    parent.className = "room active";
    var info = document.getElementById("infoele" + currentselected);
    info.style.display = "flex";
}

function toggleForm() {
    var form = document.getElementById("toggle-form");
    if (form.style.display === "block") {
        form.style.display = "none";
    } else {
        form.style.display = "block";
    }
}

//handle submit of the booking form 
async function handleSubmit() {
    bookingData.from = calander1.value;
    bookingData.to = calander2.value
    console.log("This is Booking information" + bookingData);
    const jsonData = await JSON.stringify(bookingData);
    document.getElementById(hiddenInputClientId).value = jsonData;
    var form = document.getElementById("toggle-form");
    form.style.display = "none";
    document.getElementById(complexDataClientId).click();
}
