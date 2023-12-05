document.addEventListener("DOMContentLoaded", function () {
    var filas = document.querySelectorAll('.fila-datos');

    if (filas.length > 0) {
        filas[0].classList.add('fila-seleccionada');
    }

    for (var i = 0; i < filas.length; i++) {
        filas[i].addEventListener('click', function () {
            for (var j = 0; j < filas.length; j++) {
                filas[j].classList.remove('fila-seleccionada');
            }

            // Obtener los datos de la fila clicada
            var datosFila = obtenerDatosFila(this);

            // Actualizar dinámicamente los campos del formulario con ID dinámico
            var camposFormulario = document.querySelectorAll('.tamano');

            for (var k = 0; k < camposFormulario.length; k++) {
                var idCampoFormulario = camposFormulario[k].id;
                var valorCampo = datosFila[idCampoFormulario] || '';

                document.getElementById(idCampoFormulario).value = valorCampo;
            }

            // Agregar la clase de fila seleccionada a la fila clicada
            this.classList.add('fila-seleccionada');
        });
    }

    function obtenerDatosFila(fila) {
        var datos = {};
        var celdas = fila.getElementsByTagName('td');

        for (var l = 0; l < celdas.length; l++) {
            var nombreCampo = obtenerTextoCelda(celdas[l]);
            var valorCampo = obtenerTextoCelda(celdas[l + 1]);
            datos[nombreCampo] = valorCampo;
            l++;
        }

        return datos;
    }

    function obtenerTextoCelda(celda) {
        return celda ? celda.innerText.trim().toLowerCase() : '';
    }
});
