$(document).ready(function () {
    $('#table_id').DataTable();
});

// Agregar un evento de clic a las filas de la tabla
var filas = document.getElementsByClassName('fila-datos');

if (filas.length > 0) {
    filas[0].classList.add('fila-seleccionada');
}

for (var i = 0; i < filas.length; i++) {
    filas[i].addEventListener('click', function () {
        for (var j = 0; j < filas.length; j++) {
            filas[j].classList.remove('fila-seleccionada');
        }

        // Obtener el id de la fila clicada
        var idRol = this.getAttribute('data-id');
        var descripcion = this.cells[1].innerText;

        // Actualizar el formulario con los datos correspondientes
        document.getElementById('idRol').value = idRol;

        // Puedes agregar aquí la lógica para cargar otros datos en el formulario si es necesario
        document.getElementById('descripcion').value = descripcion;

        // Agregar la clase de fila seleccionada a la fila clicada
        this.classList.add('fila-seleccionada');
    });
}