var startGame = false;

function StartGame() {
    startGame = true;
    document.addEventListener('mousemove', function (e) {

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
        setInterval(function () {
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

                var fallSpeed = 4; // Adjust this value to change the speed of the popcorn
                var fallInterval = setInterval(function () {
                    var topPosition = parseInt(popcorn.style.top);
                    if (topPosition > window.innerHeight) {
                        clearInterval(fallInterval);
                        document.body.removeChild(popcorn);
                    } else {
                        popcorn.style.top = (topPosition + fallSpeed) + 'px';
                    }
                }, 10);
            }
        }, 300); // Adjust this value to change the rate at which new popcorn appears
        setTimeout(function () {
            setInterval(function () {
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
                                }
                            }
                        }
                    }
                }
            }, 1);
        }, 100)
    }
}