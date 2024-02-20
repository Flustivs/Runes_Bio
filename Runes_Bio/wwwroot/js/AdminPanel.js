function FlyInBox(num) {
    var box = document.getElementById('FlyInBox');
    box.classList.remove('flyin');
    setTimeout(function () {
        var flybox = document.getElementById('FlyInBox');
        var olddiv = document.getElementById('FlyBoxText');
        var defaultForm = document.getElementById('defaultForm');
        var movieForm = document.getElementById('movieForm');

        DeleteFormTag(olddiv, defaultForm, num);

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

                defaultForm.appendChild(inputfield1);
                defaultForm.appendChild(inputfield2);
                defaultForm.appendChild(text1);
                defaultForm.appendChild(text2);
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
                inputPlayingTime.name = 'movie_Length';
                inputPlayingTime.type = 'number';
                inputPlayingTime.classList.add('movieInput');
                inputPlayingTime.style.top = '35%';
                inputPlayingTime.required = true;

                var inputDate = document.createElement('input');
                inputDate.required;
                inputDate.placeholder = 'Indtast hvornår den skal spilles';
                inputDate.name = 'date';
                inputDate.type = 'datetime-local';
                inputDate.classList.add('movieInput');
                inputDate.style.top = '45%';
                inputDate.required = true;

                var inputTheater = document.createElement('input');
                inputTheater.required;
                inputTheater.placeholder = 'Indtast hvilken sal';
                inputTheater.name = 'theater';
                inputTheater.type = 'number';
                inputTheater.classList.add('movieInput');
                inputTheater.style.top = '55%';
                inputTheater.required = true;

                div.innerHTML = 'Hvilke film vil du gerne tilføje / fjerne';
                div.style.textAlign = 'center';
                div.style.top = '5%';

                var addButton = document.getElementById('addButton');
                addButton.style.visibility = 'visible';
                addButton.style.left = '20%';

                var removeButton = document.getElementById('removeButton');
                removeButton.style.visibility = 'visible';
                removeButton.style.left = '65%';
                var movieList = document.getElementById('movieSelect');

                movieBox.appendChild(movieList);
                movieForm.appendChild(movieBox);
                defaultForm.appendChild(inputName);
                defaultForm.appendChild(inputPlayingTime);
                defaultForm.appendChild(inputDate);
                defaultForm.appendChild(inputTheater);
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

function DeleteFormTag(olddiv, defaultForm, num) {
    var confirmButton = document.getElementById('ConfirmButton');
    var addButton = document.getElementById('addButton');
    var movieSelect = document.getElementById('movieSelect');
    var removeButton = document.getElementById('removeButton');
    var movieBox = document.getElementsByClassName('movieList');
    var movieForm = document.getElementById('movieForm');

    if (movieSelect != null) {
        movieForm.appendChild(movieSelect);
    }
    if (num == 2) {
        confirmButton.style.visibility = 'hidden';
        addButton.style.visibility = 'visible';
        movieSelect.style.visibility = 'visible';
        removeButton.style.visibility = 'visible';
    }
    else {
        if (movieBox)
        for (var i = 0; i < movieBox.length;){
            movieBox[i].remove();
        }
        confirmButton.style.visibility = 'visible';
        addButton.style.visibility = 'hidden';
        if (movieSelect != null) {
            movieSelect.style.visibility = 'hidden';
        }
        removeButton.style.visibility = 'hidden';
    }

    if (olddiv != null) {
        olddiv.remove();

        if (defaultForm.lastChild && defaultForm.lastChild.tagName === 'P') {
            defaultForm.removeChild(defaultForm.lastChild);
            defaultForm.removeChild(defaultForm.lastChild);
        }
        if (defaultForm.lastChild && defaultForm.lastChild.tagName === 'INPUT') {
            defaultForm.removeChild(defaultForm.lastChild);
            defaultForm.removeChild(defaultForm.lastChild);
        }
        if (defaultForm.lastChild && defaultForm.lastChild.tagName === 'INPUT') {
            defaultForm.removeChild(defaultForm.lastChild);
            defaultForm.removeChild(defaultForm.lastChild);
            if (defaultForm.lastChild && defaultForm.lastChild.tagName === 'INPUT') {
                defaultForm.removeChild(defaultForm.lastChild);
                defaultForm.removeChild(defaultForm.lastChild);
            }
        }
        if (defaultForm.lastChild && defaultForm.lastChild.tagName === 'P') {
            defaultForm.removeChild(defaultForm.lastChild);
            defaultForm.removeChild(defaultForm.lastChild);
        }
    }
}

function ClosePopUp() {
    var popUpBox = document.getElementById('FlyInBox');
    popUpBox.classList.remove('flyin');
}