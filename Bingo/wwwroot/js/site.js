const carton1 = Array.from(document.getElementsByClassName('celdaCarton1'));
const carton2 = Array.from(document.getElementsByClassName('celdaCarton2'));
const carton3 = Array.from(document.getElementsByClassName('celdaCarton3'));
const carton4 = Array.from(document.getElementsByClassName('celdaCarton4'));
const labelCarton1 = document.getElementById("labelCarton1");
const labelCarton2 = document.getElementById("labelCarton2");
const labelCarton3 = document.getElementById("labelCarton3");
const labelCarton4 = document.getElementById("labelCarton4");
const label = document.getElementById("label1");


async function sortear() {
    const numero = Math.random() * (90 - 0);
    const bolilla = numero.toFixed(0);
    label.innerHTML = bolilla;
    getCarton(bolilla);
    GuardarHistorialBolillero(bolilla);
}


async function GuardarHistorialBolillero(bolilla) {
    let body = {
        fechaYHora: "foo",
        numeroDeBolilla: parseInt(bolilla),
    }
    fetch('https://localhost:7185/api/bingo/GuardarHistorialBolilla',{
        method: "POST",
        headers: { "Content-type": "application/json; charset=UTF-8" },
        body: JSON.stringify(body),
    })
    .then(response => response.json())
    .then(json => console.log(json))
    .catch (err => console.log(err));
}


async function getCarton(bolilla) {

    for (let i = 0; i < carton1.length; i++) {
        if (bolilla == carton1[i].outerText) {
            carton1[i].style.backgroundColor = 'rgb(255, 87, 51)';
            carton1.splice(i, 1)
            if (carton1.length === 0) {
                labelCarton1.innerHTML = "CARTÓN GANADOR"
            }
        }
    }

    for (let i = 0; i < carton2.length; i++) {
        if (bolilla == carton2[i].outerText) {
            carton2[i].style.backgroundColor = 'rgb(255, 87, 51)';
            carton2.splice(i, 1)
            if (carton2.length === 0) {
                labelCarton2.innerHTML = "CARTÓN GANADOR"
            }
        }
    }

    for (let i = 0; i < carton3.length; i++) {
        if (bolilla == carton3[i].outerText) {
            carton3[i].style.backgroundColor = 'rgb(255, 87, 51)';
            carton3.splice(i, 1)
            if (carton3.length === 0) {
                labelCarton3.innerHTML = "CARTÓN GANADOR"
            }
        }
    }

    for (let i = 0; i < carton4.length; i++) {
        if (bolilla == carton4[i].outerText) {
            carton4[i].style.backgroundColor = 'rgb(255, 87, 51)';
            carton4.splice(i, 1)
            if (carton4.length === 0) {
                labelCarton4.innerHTML = "CARTÓN GANADOR"
            }
        }
    }
}




