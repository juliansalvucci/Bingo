// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function test() {
    const label = document.getElementById("label1");
    const numero = Math.random(90,1);
    label.innerHTML = Math.round(numero);
}

test();

async function getCarton(carton) {
    console.log(carton);
}

getCarton();