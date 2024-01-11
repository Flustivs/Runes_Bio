function PickUpTrash() {
    var button = document.getElementById("ButtonTrash");
    button.classList.add("fade-out");
    setTimeout(function () {
        window.location.href = "/Pick-Trash";
    }, 1000);
}
function CalculateTicket() {
    var button = document.getElementById("ButtonCalTicket");
    button.classList.add("fade-out");
    setTimeout(function () {
        window.location.href = "/CalculateTickets";
    }, 1000);
}
function CatchPopCorn() {
    var button = document.getElementById('ButtonPopCorn');
    button.classList.add('fade-out');
    setTimeout(function () {
        window.location.href = '/PopCorn';
    }, 1000)
}