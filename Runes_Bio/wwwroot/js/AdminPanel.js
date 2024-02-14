function FlyInBox(num) {
    var box = document.getElementById('FlyInBox');
    box.classList.remove('flyin');
    setTimeout(function () {
        var flybox = document.getElementById('FlyInBox');
        var olddiv = document.getElementById('FlyBoxText');
        var preForm = document.getElementById('allForm');

        DeleteFormTag(olddiv, preForm, num);

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
                var movieBox = document.createElement('div');
                movieBox.classList.add('movieList');

                var inputName = document.createElement('input');
                inputName.required;
                inputName.placeholder = 'Indtast navnet af filmen';
                inputName.name = 'movieName';
                inputName.type = 'text';
                inputName.classList.add('movieInput');
                inputName.required = true;

                var inputPlayingTime = document.createElement('input');
                inputPlayingTime.required;
                inputPlayingTime.placeholder = 'Indtast filmens spilletid';
                inputPlayingTime.name = 'moviePlaying';
                inputPlayingTime.type = 'number';
                inputPlayingTime.classList.add('movieInput');
                inputPlayingTime.style.top = '40%';
                inputPlayingTime.required = true;

                var inputDate = document.createElement('input');
                inputDate.required;
                inputDate.placeholder = 'Indtast hvornår den skal spilles';
                inputDate.name = 'date';
                inputDate.type = 'datetime-local';
                inputDate.classList.add('movieInput');
                inputDate.style.top = '50%';
                inputDate.required = true;

                var inputTheater = document.createElement('input');
                inputTheater.required;
                inputTheater.placeholder = 'Indtast hvilken sal';
                inputTheater.name = 'theater';
                inputTheater.type = 'number';
                inputTheater.classList.add('movieInput');
                inputTheater.style.top = '60%';
                inputTheater.required = true;

                div.innerHTML = 'Hvilke film vil du gerne tilføje / fjerne';
                div.style.textAlign = 'center';
                div.style.top = '5%';

                var addButton = document.getElementById('addButton');
                addButton.style.visibility = 'visible';
                addButton.style.left = '20%';

                var movieList = document.getElementById('movieSelect');

                movieBox.appendChild(movieList);
                preForm.appendChild(movieBox);
                preForm.appendChild(inputName);
                preForm.appendChild(inputPlayingTime);
                preForm.appendChild(inputDate);
                preForm.appendChild(inputTheater);
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

function DeleteFormTag(olddiv, preForm, num) {
    var confirmButton = document.getElementById('ConfirmButton');
    var addButton = document.getElementById('addButton');
    var movieSelect = document.getElementById('movieSelect');

    if (num == 2) {
        confirmButton.style.visibility = 'hidden';
        addButton.style.visibility = 'visible';
        movieSelect.style.visibility = 'visible';
    }
    else {
        confirmButton.style.visibility = 'visible';
        addButton.style.visibility = 'hidden';
        movieSelect.style.visibility = 'hidden';
    }

    if (olddiv != null) {
        olddiv.remove();

        var oldMovieBox = document.getElementsByClassName('movieList');
        if (oldMovieBox[0] != null) {
            oldMovieBox[0].remove();
        }
        if (preForm.lastChild && preForm.lastChild.tagName === 'P') {
            preForm.removeChild(preForm.lastChild);
            preForm.removeChild(preForm.lastChild);
        }
        if (preForm.lastChild && preForm.lastChild.tagName === 'INPUT') {
            preForm.removeChild(preForm.lastChild);
            preForm.removeChild(preForm.lastChild);
        }
        if (preForm.lastChild && preForm.lastChild.tagName === 'INPUT') {
            preForm.removeChild(preForm.lastChild);
            preForm.removeChild(preForm.lastChild);
            if (preForm.lastChild && preForm.lastChild.tagName === 'INPUT') {
                preForm.removeChild(preForm.lastChild);
                preForm.removeChild(preForm.lastChild);
            }
        }
        if (preForm.lastChild && preForm.lastChild.tagName === 'P') {
            preForm.removeChild(preForm.lastChild);
            preForm.removeChild(preForm.lastChild);
        }
    }
}

function ClosePopUp() {
    var popUpBox = document.getElementById('FlyInBox');
    popUpBox.classList.remove('flyin');
}