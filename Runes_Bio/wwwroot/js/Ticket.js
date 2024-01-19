var positions = [];
const url = "/TicketPage";
function Clicked(aPos, numPos) {
    var id = aPos + numPos;
    var button = document.getElementById(id);
    button.style.scale = '1.5';
    button.style.backgroundColor = 'yellow';
    positions.push(id);
}

function Bought(email) {
    let data = {
        seats: positions,
        email: email
    }
    fetch(url, {
        method: "POST",
        body: JSON.stringify(data),
    })
        .then(response => {
            if (!response.ok) {
                throw new error("Http error: " + response.status);
            }
            return response.json();
        })
        .catch(error => {
            console.log("Fetch error: " + error);
        });
}