document.getElementById("home-image").style.display = 'none';
function showMsgManageBooking(err) {
    let msg = document.getElementById("errMsg");
    msg.style.display = "flex";
    setTimeout(() => { msg.style.display = "none";}, 2300);
    console.log(err);
}