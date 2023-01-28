// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function test() {
    const label = document.getElementById("label1");
    const numero = Math.random() * (90-0);
    label.innerHTML = numero.toFixed(0);
}

test();

async function getCarton() {
    const lista = Array.from(document.getElementsByClassName('celdaCarton'))
    console.log(lista)
    for (let i = 0; i < lista.length; i++) {
        console.log(lista[i].outerText)
    }
}

getCarton();