function FlyInBox(num) {
    var box = document.getElementsByClassName('popUpBox');
    box[0].classList.remove('flyin');
    setTimeout(function () {
        switch (num) {
            case 1:
                box[0].classList.add('flyin');
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }, 200)
}