function PickUpTrash() {
    var trashInput = document.getElementById('trashInput');
    var dateInput = document.getElementById('dateInput');

    if (trashInput.value < dateInput.value) {
        var button = document.getElementById("ButtonTrash");
        button.classList.add("fade-out");
        setTimeout(function () {
            window.location.href = "/Pick-Trash";
        }, 1000);
    }

}
function CalculateTicket() {
    var moneyInput = document.getElementById('moneyInput');
    var dateInput = document.getElementById('dateInput');

    if (moneyInput.value < dateInput.value) {
        var button = document.getElementById("ButtonCalTicket");
        button.classList.add("fade-out");
        setTimeout(function () {
            window.location.href = "/CalculateTickets";
        }, 1000);
    }

}
function CatchPopCorn() {
    var popcornInput = document.getElementById('popcornInput');
    var dateInput = document.getElementById('dateInput');

    if (popcornInput.value < dateInput.value) {
        var button = document.getElementById('ButtonPopCorn');
        button.classList.add('fade-out');
        setTimeout(function () {
            window.location.href = '/PopCorn';
        }, 1000)
    }

}

window.onload = function () {
    var trashBox = document.getElementById('availableTrash');
    var moneyBox = document.getElementById('availableMoney');
    var popcornBox = document.getElementById('availablePopcorn');

    var trashInput = document.getElementById('trashInput');
    var moneyInput = document.getElementById('moneyInput');
    var popcornInput = document.getElementById('popcornInput');
    var dateInput = document.getElementById('dateInput');

    if (trashInput.value > dateInput.value) {
        trashBox.style.backgroundColor = 'darkred';
    }
    if (moneyInput.value > dateInput.value) {
        moneyBox.style.backgroundColor = 'darkred';
    }
    if (popcornInput.value > dateInput.value) {
        popcornBox.style.backgroundColor = 'darkred';
    }
}