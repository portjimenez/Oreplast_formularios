$(document).ready(function () {
    // Función para manejar el evento click en las filas de datos
    function manejarClick() {
        var $fila = $(this);

        // Remover la clase de todas las filas
        $('.fila-datos').removeClass('row-selected');

        // Agregar la clase solo a la fila clicada
        $fila.addClass('row-selected');

        // Resto del código
        $fila.find('td').each(function (index) {
            var propiedadName = $('#table_id th').eq(index).text().trim();
            var $input = $('#formulario').find('[id="' + propiedadName + '"]');

            console.log(propiedadName);

            if ($input.length >= 0) {
                var value = $(this).text();
                console.log(value);
                $input.val(value);
            }
        });

    }

    // Vincular el evento click inicial
    $('body').on('click', '.fila-datos', manejarClick);

    // Vincular el evento draw.dt para manejar las actualizaciones de la tabla
    $('#table_id').on('draw.dt', function () {
        // Desvincular y volver a vincular el evento click después de que la tabla se haya redibujado
        $('body').off('click', '.fila-datos').on('click', '.fila-datos', manejarClick);

        // Eliminar estilos de selección en todas las filas
        $('.fila-datos').removeClass('row-selected');
    });
});
