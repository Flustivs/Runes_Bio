function loggedin() {
    let logged = localStorage.getItem('loggedin');
    let loginbutton = document.getElementById('login');
    let registerbutton = document.getElementById('register');
    if (logged === 'true') {
        loginbutton.style.visibility = 'hidden';
        registerbutton.style.visibility = 'hidden';
    }
    if (loginbutton == null || registerbutton == null) {
        console.log('No content of type loginButton or registerButton');
    }
    else {
        loginbutton.style.visibility = 'visible';
        registerbutton.style.visibility = 'visible';
    }
}

window.onload = function () {
    $('loginForm').on('submit', function (e) {
        e.preventDefault();
        $.ajax({
            url: '@URL.Page("/Login")',
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    localStorage.setItem('loggedin', 'true');
                    console.log("Succes true");
                } else {
                    localStorage.setItem('loggedin', 'false');
                    console.log("success false");
                }
            },
            error: function (jqxhr, textStatus, errorThrown) {
                console.error('Error' + textStatus);
            }
        });
    });
}
//$(document).ready(function () {
//    $('#loginForm').on('submit', function (e) {
//        e.preventDefault();
//        $.ajax({
//            url: '@URL.Page("/Login")',
//            type: 'POST',
//            data: $(this).serialize(),
//            success: function (response) {
//                if (response.Success) {
//                    localStorage.setItem('loggedin', 'true');
//                } else {
//                    localStorage.setItem('loggedin', 'false')
//                }
//            },
//            error: function (jqXHR, textStatus, errorThrown) {
//                console.error('Error: ' + textStatus);
//            }
//        });
//    });
//});