function Clicked(aPos, numPos) {
    var id = aPos + numPos;
    var button = document.getElementById(id);
    button.style.scale = '1.5';
    button.style.backgroundColor = 'yellow';
}