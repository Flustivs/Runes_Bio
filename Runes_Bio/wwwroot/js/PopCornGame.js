var startGame = false;
let x = 0;
let popcornPS = 1000;

function StartGame() {
    startGame = true;
    var button = document.getElementById('StartGame');
    button.style.visibility = 'hidden';
    button.style.opacity = '0';
    var popPS = document.getElementById('PopCornPS');
    var inputPS = document.getElementsByClassName('InputValue');
    inputPS[0].style.visibility = 'hidden';
    inputPS[0].style.opacity = '0';
    inputPS[1].style.visibility = 'hidden';
    inputPS[0].style.opacity = '0';

    let popValue = 1000 / popPS.value;
    if (popValue !== 0 && popValue >= 50 && popValue !== Infinity) {
        popcornPS = popValue;
    }
    document.addEventListener('mousemove', function (e) {
        if (!startGame) {
            button.style.visibility = 'visible';
        }
        var img = document.getElementById('PopCornBox');
        if (img != null) {
            img.style.visibility = 'visible';
            var offsetX = img.offsetWidth / 2;
            var offsetY = img.offsetHeight / 2;
            img.style.left = (e.pageX - offsetX) + 'px';
            img.style.top = (e.pageY - offsetY) + 'px';
        }
    });

    if (startGame) {
        var Counterbox = document.getElementsByClassName('PopCornCounter');
        Counterbox[0].style.visibility = 'visible';
        Counterbox[0].style.opacity = '1';
        var popcornfall = setInterval(function () {
            var popcornbox = document.getElementById('PopCornBox');
            if (popcornbox != null) {
                var popcorn = document.createElement('img');
                popcorn.src = '/Pictures/PopCorn.png';
                popcorn.style.position = 'absolute';
                popcorn.style.width = '10%';
                popcorn.style.height = '10%';
                popcorn.style.top = '-10px';
                popcorn.style.left = Math.random() * window.innerWidth + 'px';
                document.body.appendChild(popcorn);

                var fallSpeed = 2.5; // Adjust this value to change the speed of the popcorn
                var fallInterval = setInterval(function () {
                    var topPosition = parseInt(popcorn.style.top);
                    if (topPosition > window.innerHeight) {
                        clearInterval(fallInterval);
                        document.body.removeChild(popcorn);
                        clearInterval(popcornfall);
                        var counter = document.getElementById('Counter');
                        Lost();
                    } else {
                        popcorn.style.top = (topPosition + fallSpeed) + 'px';
                    }
                }, 10);
            }
        }, popcornPS); // Adjust this value to change the rate at which new popcorn appears
        setTimeout(function () {
            var collision = setInterval(function () {
                var popcornbox = document.getElementById('PopCornBox');
                if (popcornbox != null) {
                    var imageRect = document.getElementById('PopCornBox').getBoundingClientRect();
                    var popcorns = document.getElementsByTagName('img');
                    for (var i = 0; i < popcorns.length; i++) {
                        var popcorn = popcorns[i];
                        // Check if the popcorn is still in the DOM
                        if (document.body.contains(popcorn)) {
                            var popcornRect = popcorn.getBoundingClientRect();
                            if (!(imageRect.right < popcornRect.left || imageRect.left > popcornRect.right || imageRect.bottom < popcornRect.top || imageRect.top > popcornRect.bottom)) {
                                if (popcorn.id !== 'PopCornBox') {
                                    document.body.removeChild(popcorn);
                                    x++;
                                    var counter = document.getElementById('Counter');
                                    counter.innerHTML = x;
                                    if (x == 20) {
                                        clearInterval(collision);
                                        clearInterval(popcornfall);
                                        Won();
                                    }
                                }
                            }
                        }
                    }
                }
            }, 1);
        }, 10)
    }
}

function Won() {
    var won = document.getElementById('won');
    var counter = document.getElementsByClassName('PopCornCounter');
    won.style.visibility = 'visible';
    won.style.opacity = '1';
    counter[0].style.opacity = '0';
    counter[0].style.visibility = 'hidden';
    setTimeout(function () {
        window.location.href = '/ToDo?won=won&task=Catch-PopCorn';
    }, 2000)
}
function Lost() {
    var lost = document.getElementById('lost');
    var CounterBox = document.getElementsByClassName('PopCornCounter');
    var Counter = document.getElementById('Counter');
    lost.style.visibility = 'visible';
    lost.style.opacity = '1';
    CounterBox[0].style.opacity = '0';
    CounterBox[0].style.visibility = 'hidden';
    lost.innerHTML = 'Du tabte med en score på ' + Counter.innerHTML;
    setTimeout(function () {
        window.location.href = '/ToDo?won=lost%task=Catch-PopCorn';
    }, 2000)
}