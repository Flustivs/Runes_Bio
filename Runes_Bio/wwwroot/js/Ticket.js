var positions = [];
function Clicked(aPos, numPos) {
    var id = aPos + numPos;
    var button = document.getElementById(id);
    if (button.style.scale == '1.5') {
        button.style.scale = '1';
        button.style.backgroundColor = 'white';
        positions.forEach(function (item) {
            if (item == id) {
                let index = positions.indexOf(item);
                positions.splice(index, 1);
            }
        })
    }
    else {
        button.style.scale = '1.5';
        button.style.backgroundColor = 'yellow';
        positions.push(id);
    }
}

function Bought(email) {
    let data = {
        seats: positions,
        email: email
    }

    jQuery.ajax({
        url: "/TicketPage?handler=OnPostSaveSeats",
        type: "POST",
        headers: {
            'Content-Type': 'application/json',
        },
        data: JSON.stringify(data),
        success: function (response) {
            console.log("Response:", response);
            if (response === "success") {
                console.log("Success!");
            } else {
                console.log("Unknown response:", response);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("AJAX Error:", textStatus, errorThrown);
            console.log("Response Text:", jqXHR.responseText);
        }

    });
}