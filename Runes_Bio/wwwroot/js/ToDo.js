function PickUpTrash() {
    var trashInput = parseDate(document.getElementById('trashInput').value);

    if (!TwoHours(trashInput)) {
        var button = document.getElementById("ButtonTrash");
        button.classList.add("fade-out");
        setTimeout(function () {
            window.location.href = "/Pick-Trash";
        }, 1000);
    }

}
function CalculateTicket() {
    var moneyInput = parseDate(document.getElementById('moneyInput').value);

    if (!TwoHours(moneyInput)) {
        var button = document.getElementById("ButtonCalTicket");
        button.classList.add("fade-out");
        setTimeout(function () {
            window.location.href = "/CalculateTickets";
        }, 1000);
    }

}
function CatchPopCorn() {
    var popcornInput = parseDate(document.getElementById('popcornInput').value);

    if (!TwoHours(popcornInput)) {
        var button = document.getElementById('ButtonPopCorn');
        button.classList.add('fade-out');
        setTimeout(function () {
            window.location.href = '/PopCorn';
        }, 1000)
    }

}

window.onload = function () {
    var trashInput = parseDate(document.getElementById('trashInput').value);
    var moneyInput = parseDate(document.getElementById('moneyInput').value);
    var popcornInput = parseDate(document.getElementById('popcornInput').value);

    var trashBox = document.getElementById('availableTrash');
    var moneyBox = document.getElementById('availableMoney');
    var popcornBox = document.getElementById('availablePopcorn');

    if (TwoHours(trashInput)) {
        trashBox.style.backgroundColor = 'darkred';
    }
    if (TwoHours(moneyInput)) {
        moneyBox.style.backgroundColor = 'darkred';
    }
    if (TwoHours(popcornInput)) {
        popcornBox.style.backgroundColor = 'darkred';
    }
}
function parseDate(dateString) {
    var parts = dateString.split(/[- :]/);
    // Note: months are 0-based in JavaScript Date objects
    return new Date(parts[2], parts[1] - 1, parts[0], parts[3], parts[4], parts[5]);
}
function TwoHours(inputDate) {
    var dateInput = parseDate(document.getElementById('dateInput').value);

    var twoHoursLater = new Date(dateInput.getTime());
    return inputDate >= twoHoursLater;
}