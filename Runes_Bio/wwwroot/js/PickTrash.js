let buttonPressCount;

function reset() {
    localStorage.setItem("img1", false)
    localStorage.setItem("img2", false)
    localStorage.setItem("img3", false)
    localStorage.setItem("img4", false)
    localStorage.setItem("img5", false)
    buttonPressCount = 0;
}

function hideImage(event, image) {
    event.preventDefault();
    var img = document.getElementById('img' + image);
    img.style.visibility = 'hidden';
    localStorage.setItem('img' + image, true);
    buttonPressCount++
    VisibleImage();
};

function PopUp() {
    let popup = document.getElementsByClassName('PopUp');
    if (popup.length > 0) {
        popup[0].style.opacity = '1';
        popup[0].style.visibility = 'visible';
    }
    setTimeout(function () {
        window.location.href = '/ToDo?won=won&task=Trash-Pick-Up';
    }, 4000)
}

function VisibleImage() {
    if (buttonPressCount === 5) {
        let images = document.getElementsByClassName('Trash');
        PopUp();
        setTimeout(function () {
            for (var i = 0; i < images.length; i++) {
                images[i].style.visibility = 'visible';
            }
            //window.location.href = "/EmployeeIndex";
            reset();
        }, 4100);
    }
}

window.onload = function () {
    for (let i = 1; i < 6; i++) {
        var imgHidden = localStorage.getItem('img' + i)
        if (imgHidden == true) {
            document.getElementById('img' + i).style.visibility = 'hidden';
        }
    }
}

var elements = document.getElementsByClassName('site');
for (let i = 0; i < elements.length; i++) {
    elements[i].addEventListener('click', function (e) { hideImage(e, i + 1); });
}