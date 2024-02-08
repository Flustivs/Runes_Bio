function FlyInBox(num) {
    var box = document.getElementById('FlyInBox');
    box.classList.remove('flyin');
    setTimeout(function () {
        var flybox = document.getElementById('FlyInBox');
        var olddiv = document.getElementById('FlyBoxText');
        var preForm = document.getElementById('allForm');
        if (olddiv != null) {
            olddiv.remove();
            if (preForm.lastChild && preForm.lastChild.tagName === 'P') {
                preForm.removeChild(preForm.lastChild);
                preForm.removeChild(preForm.lastChild);
            }
            if (preForm.lastChild && preForm.lastChild.tagName === 'INPUT') {
                preForm.removeChild(preForm.lastChild);
                preForm.removeChild(preForm.lastChild);
            }
        }
        var div = document.createElement('div');
        div.id = 'FlyBoxText';
        div.style.textAlign = 'center; position: fixed;';
        switch (num) {
            case 1:
                box.classList.add('flyin');
                div.innerHTML = 'Hvilke priser vil du gerne ændre bare skriv den ønskede pris udfra den billet';

                var inputfield1 = document.createElement('input');
                inputfield1.type = 'number';
                inputfield1.placeholder = '89.95';
                inputfield1.name = 'Inputfield1';
                inputfield1.style = 'position: fixed; top: 30%; left: 55%;';

                var inputfield2 = document.createElement('input');
                inputfield2.placeholder = '89.95';
                inputfield2.name = 'Inputfield2';
                inputfield2.style = 'position: fixed; top: 40%; left: 55%;';

                var normalPrice = document.getElementById('normalPrice').value;
                var text1 = document.createElement('p');
                text1.innerHTML = 'Prisen for normal billet: ' + normalPrice;
                text1.style = 'position: fixed; top: 30%; left: 15%;';

                var luxuryPrice = document.getElementById('luxuryPrice').value;
                var text2 = document.createElement('p');
                text2.innerHTML = 'Prisen for luksus billet: ' + luxuryPrice;
                text2.style = 'position: fixed; top: 40%; left: 15%;';

                preForm.appendChild(inputfield1);
                preForm.appendChild(inputfield2);
                preForm.appendChild(text1);
                preForm.appendChild(text2);
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