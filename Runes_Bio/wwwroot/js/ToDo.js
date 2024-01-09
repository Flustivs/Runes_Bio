function PickUpTrash() {
    var button = document.getElementById("ButtonTrash");
    button.classList.add("fade-out");
    setTimeout(function () {
        window.location.href = "/Pick-Trash";
    }, 1000);
}
function CalculateFood() {
    var button = document.getElementById("ButtonCalFood");
    button.classList.add("fade-out");
    setTimeout(function () {
        window.location.href = "/CalculateFood";
    }, 1000);
}
function CalculateTicket() {
    var button = document.getElementById("ButtonCalTicket");
    button.classList.add("fade-out");
    setTimeout(function () {
        window.location.href = "/CalculateTickets";
    }, 1000);
}