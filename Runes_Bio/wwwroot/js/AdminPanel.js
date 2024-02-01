function FlyInBox(num) {
    var box = document.getElementById('FlyInBox');
    box.classList.remove('flyin');
    setTimeout(function () {
        var flybox = document.getElementById('FlyInBox');
        var olddiv = document.getElementById('FlyBoxText');
        var preForm = document.getElementById('allForm');
        if (olddiv != null) {
            olddiv.remove();
            if (preForm.lastChild && preForm.lastChild.tagName === 'INPUT') {
                preForm.removeChild(preForm.lastChild);
            }
        }
        var div = document.createElement('div');
        div.id = 'FlyBoxText';
        div.style.textAlign = 'center';
        switch (num) {
            case 1:
                box.classList.add('flyin');
                div.innerHTML = 'Hvilke priser vil du gerne ændre bare skriv den ønskede pris udfra den billet';

                var inputfield = document.createElement('input');
                inputfield.type = 'number';
                inputfield.placeholder = '89.95';
                inputfield.name = 'Inputfield';

                preForm.appendChild(inputfield);
                flybox.appendChild(div);
                break;
            case 2:
                box.classList.add('flyin');
                div.innerHTML = 'Hvilke film vil du gerne tilføje / fjerne';
                flybox.appendChild(div);
                break;
            case 3:
                box.classList.add('flyin');
                flybox.appendChild(div);
                break;
            default:
                break;
        }
    }, 20)
}

function ClosePopUp() {
    var popUpBox = document.getElementById('FlyInBox');
    popUpBox.classList.remove('flyin');
}