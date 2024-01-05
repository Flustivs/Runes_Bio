// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

let buttonPressCount;

function reset() {
    localStorage.setItem("img1", false)
    localStorage.setItem("img2", false)
    localStorage.setItem("img3", false)
    localStorage.setItem("img4", false)
    localStorage.setItem("img5", false)
    buttonPressCount = 0;
}

function hideImage(event, image, popUpID) {
    event.preventDefault();
    var img = document.getElementById("img" + image);
    img.style.visibility = "hidden";
    localStorage.setItem("img" + image, true);
    buttonPressCount++
    VisibleImage(popUpID);
};

function PopUp(popUpID) {
    let popup = document.getElementById("PopUpBox" + popUpID);
    popup.style.visibility = "visible";

}

function VisibleImage(popUpID) {
    if (buttonPressCount === 5) {
        let images = document.getElementsByClassName("Trash");
        PopUp(popUpID);
        setTimeout(function () {
            for (var i = 0; i < images.length; i++) {
                images[i].style.visibility = "visible";
            }
            //window.location.href = "/EmployeeIndex";
            reset();
        }, 2000);
    }
}

window.onload = function () {
    for (let i = 1; i < 6; i++) {
        var imgHidden = localStorage.getItem("img" + i)
        if (imgHidden == true) {
            document.getElementById("img" + i).style.visibility = "hidden";
        }
    }
}

var elements = document.getElementsByClassName("site");
for (let i = 0; i < elements.length; i++) {
    elements[i].addEventListener("click", function (e) { hideImage(e, i + 1); });
}