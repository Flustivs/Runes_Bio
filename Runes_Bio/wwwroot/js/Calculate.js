function CheckValue(answ1, answ2, answ3, answ4) {
    var question1 = document.getElementById('question1').value;
    var question2 = document.getElementById('question2').value;
    var question3 = document.getElementById('question3').value;
    var question4 = document.getElementById('question4').value;

    if (question1 == answ1 && question2 == answ2 && question3 == answ3 && question4 == answ4) {
        var congrats = document.getElementById('CongratsBox');
        congrats.style.visibility = 'visible';
        congrats.style.opacity = '1';
        setTimeout(function () {
            congrats.style.opacity = '0';
            congrats.style.visibility = 'hidden';
            setTimeout(function () {
                document.location.href = '/ToDo';
            }, 500);
        }, 2000)
    }
    else {
        var failed = document.getElementById('FailedBox');
        failed.style.visibility = 'visible';
        failed.style.opacity = '1';
        setTimeout(function () {
            failed.style.opacity = '0';
            failed.style.visibility = 'hidden';
        }, 2000)
    }
}