function PickUpTrash() {
    var button = document.querySelector(".button");
    button.classList.add("fade-out");
    setTimeout(function () {
        window.location.href = "/Pick-Trash";
    }, 1000);
}
