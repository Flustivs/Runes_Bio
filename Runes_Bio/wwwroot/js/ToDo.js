function PickUpTrash() {
    var button = document.getElementById("ButtonTrash");
    button.classList.add("fade-out");
    setTimeout(function () {
        window.location.href = "/Pick-Trash";
    }, 1000);
}
function Calculate() {
    var button = document.getElementById("ButtonCalculate");
    button.classList.add("fade-out");
    setTimeout(function () {
        let num = Math.random(0, 2);
        if (num === 0) {
            window.location.href = "/CalculateTickets";
        }
        else {
            window.location.href = "/CalculateFood";
        }
    }, 1000);
}