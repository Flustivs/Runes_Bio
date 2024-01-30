function FlyInBox(num) {
    var box = document.getElementsByClassName('popUpBox');
    box[0].classList.remove('flyin');
    setTimeout(function () {
        var flybox = document.getElementById('FlyInBox');
        var olddiv = document.getElementById('FlyBoxText');
        if (olddiv != null) {
            olddiv.remove();
        }
        var div = document.createElement('div');
        div.id = 'FlyBoxText';
        div.style.textAlign = 'center';
        switch (num) {
            case 1:
                box[0].classList.add('flyin');
                div.innerHTML = 'Hvilke priser vil du gerne ændre bare skriv den ønskede pris udfra den billet';
                var form = document.createElement('form');
                form.method = 'post';
                var button = document.createElement('button');
                button.type = 'submit';
                button.innerHTML = 'Bekræft'
                var inputfield = document.createElement('input');
                inputfield.type = 'number';
                inputfield.placeholder = '89.95';
                form.appendChild(inputfield);
                form.appendChild(button);
                div.appendChild(form);
                flybox.appendChild(div);
                break;
            case 2:
                box[0].classList.add('flyin');
                div.innerHTML = 'Hvilke film vil du gerne tilføje / fjerne';
                flybox.appendChild(div);
                break;
            case 3:
                box[0].classList.add('flyin');
                var div3 = document.createElement('div');
                div3.id = 'div3';
                flybox.appendChild(div3);
                break;
            default:
                break;
        }
    }, 200)
}