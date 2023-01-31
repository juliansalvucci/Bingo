const lista = Array.from(document.getElementsByClassName('celdaCarton3'))

async function test() {
    const label = document.getElementById("label1");
    const numero = Math.random() * (90 - 0);
    const bolilla = numero.toFixed(0);
    label.innerHTML = bolilla;
    getCarton(bolilla);
}


async function getCarton(bolilla) {
    for (let i = 0; i < lista.length; i++) {
        if (bolilla == lista[i].outerText) {
            lista[i].style.backgroundColor = 'rgb(255, 87, 51)';
            lista.splice(i, 1)
            if (lista.length === 0) {
                console.log('GANASTE')
            }
        }
    }
}




