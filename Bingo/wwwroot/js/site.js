const carton1 = Array.from(document.getElementsByClassName('celdaCarton1'));
const carton2 = Array.from(document.getElementsByClassName('celdaCarton2'));
const carton3 = Array.from(document.getElementsByClassName('celdaCarton3'));
const carton4 = Array.from(document.getElementsByClassName('celdaCarton4'));
const labelCartonesGanadores = document.getElementById("cartonesGanadores");
const btnLanzarBolilla = document.getElementById("btnLanzarBolilla");
const labelCarton1 = document.getElementById("labelCarton1");
const labelCarton2 = document.getElementById("labelCarton2");
const labelCarton3 = document.getElementById("labelCarton3");
const labelCarton4 = document.getElementById("labelCarton4");
const label = document.getElementById("labelBolillero");


let cartonesGnadores = []

async function LanzarBolilla() {
    const numero = Math.random() * (90 - 0);
    const bolilla = numero.toFixed(0);
    label.innerHTML = bolilla;
    sortear(bolilla);
    GuardarHistorialBolillero(bolilla);
}

async function GuardarHistorialBolillero(bolilla) {
    let body = {
        fechaYHora: new Date().toLocaleString("es-ES"),
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


async function sortear(bolilla) {
    for (let i = 0; i < carton1.length; i++) {   //Recorrido de elementos del carton.
        if (bolilla == carton1[i].outerText) {   //Si el numero generado coincide con la propiedad outerText del div que contiene el valor numérico del cartón.
            carton1[i].style.backgroundColor = 'rgb(255, 87, 51)'; //Pintar el elemento de color rojo.
            carton1.splice(i, 1) //Remover el elemento del cartón.
            if (carton1.length === 0) { //Si el cartón ya no posee elementos (Ya que se le fueron quitando posiciones)
                labelCarton1.innerHTML = "CARTÓN LLENO" //Mostrar mensaje.
                btnLanzarBolilla.disabled = true; //Deshabilitar el botón de lanzamiento de bolillas.
                cartonesGnadores.push(1); //Guardar el numero de cartón ganador en el listado de cartones ganadores.
                GuardarHistorialCartones() //Proceder a guardar el historial de cartones ganadores.
            }
        }
    }

    for (let i = 0; i < carton2.length; i++) {
        if (bolilla == carton2[i].outerText) {
            carton2[i].style.backgroundColor = 'rgb(255, 87, 51)';
            carton2.splice(i, 1)
            if (carton2.length === 0) {
                labelCarton2.innerHTML = "CARTÓN LLENO"
                btnLanzarBolilla.disabled = true;
                cartonesGnadores.push(2);
                GuardarHistorialCartones()
            }
        }
    }

    for (let i = 0; i < carton3.length; i++) {
        if (bolilla == carton3[i].outerText) {
            carton3[i].style.backgroundColor = 'rgb(255, 87, 51)';
            carton3.splice(i, 1)
            if (carton3.length === 0) {
                labelCarton3.innerHTML = "CARTÓN LLENO"
                btnLanzarBolilla.disabled = true;
                cartonesGnadores.push(3);
                GuardarHistorialCartones()
            }
        }
    }

    for (let i = 0; i < carton4.length; i++) {
        if (bolilla == carton4[i].outerText) {
            carton4[i].style.backgroundColor = 'rgb(255, 87, 51)';
            carton4.splice(i, 1)
            if (carton4.length === 0) {
                labelCarton4.innerHTML = "CARTÓN LLENO"
                btnLanzarBolilla.disabled = true;
                cartonesGnadores.push(4);
                GuardarHistorialCartones()
            }
        }
    }
}

async function GuardarHistorialCartones() {
    let body = {  //Crear objeto para el historial de cartones.
        fechaYHora: new Date().toLocaleString("es-ES"),
        carton1: cartonesGnadores[0], //Voy asignando los numeros de cartón, para los no ganadores, El valor será NULL.
        carton2: cartonesGnadores[1],
        carton3: cartonesGnadores[2],
        carton4: cartonesGnadores[3],
    }

    fetch('https://localhost:7185/api/bingo/GuardarHistorialCartones', {
        method: "POST",
        headers: { "Content-type": "application/json; charset=UTF-8" },
        body: JSON.stringify(body),
    })
        .then(response => response.json())
        .then(json => console.log(json), mostrarCartonesGanadores())
        .catch(err => console.log(err));
}

async function mostrarCartonesGanadores() { //Mostrar listado de cartones ganadores.
    labelCartonesGanadores.innerHTML = cartonesGnadores;
}




