
//login page
//change the checkbox
let img = document.getElementById("checkbox");
let btn = document.getElementById(btnLoginId);
btn.style.opacity = 0.5;
let ok = false;
btn.disabled = true;
function changeCheckbox() {
    if (ok) {
        img.src = "../Images/checkbox_unchecked.png";
        btn.disabled = true;
        btn.style.opacity = 0.5;
        ok = false;
    } else {
        btn.disabled = false;
        btn.style.opacity = 1;
        img.src = "../Images/checkbox_checked.png";
        ok = true;
    }
}

btn.addEventListener('click', () => {
    
})

let email = document.getElementById(emaiInputId);
let pass = document.getElementById(passInputId);
email.required = true;
pass.required = true;