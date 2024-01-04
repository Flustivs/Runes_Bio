// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function hideImage(event, image) {
    event.preventDefault();
    var img = document.getElementById("img" + image);
    img.style.visibility = 'hidden';
    localStorage.setItem("img" + image, true);
};

window.onload = function () {
    for (let i = 1; i < 6; i++) {
        var imgHidden = localStorage.getItem("img" + i)
        if (imgHidden == true) {
            document.getElementById("img" + i).style.visibility = "hidden";
        }
    }
}

// Attach event listeners
var elements = document.getElementsByClassName('site');
for (let i = 0; i < elements.length; i++) {
    elements[i].addEventListener('click', function (e) { hideImage(e, i + 1); });
}