var positions = [];
function Clicked(aPos, numPos) {
    var id = aPos + numPos;
    var button = document.getElementById(id);
    if (button.style.scale == '1.5') {
        button.style.scale = '1';
        button.style.backgroundColor = 'white';
        positions.forEach(function (item) {
            if (item == id) {
                let index = positions.indexOf(item);
                positions.splice(index, 1);
            }
        })
    }
    else {
        button.style.scale = '1.5';
        button.style.backgroundColor = 'yellow';
        positions.push(id);
    }
}

function Bought(name, email) {
    console.log(name + ". " + email);
    var hiddenInput = document.getElementById('inputSeat');
    let pos = '';

    var dropdown = document.getElementById('DropDown');
    var hiddenPrice = document.getElementById('inputPrice');
    hiddenPrice.value = dropdown.value;
    positions.forEach(function (item) {
        pos += ' ' + item;
    })>	Bought [localhost꞉7017/js/Ticket.js] Line 27	JavaScript

    hiddenInput.value = pos;
}