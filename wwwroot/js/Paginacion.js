$(document).ready(function () {
    $('#table_id').DataTable({
        language: {
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sEmptytable": "Ningun dato disponible en esta tabla ",
            "sInfo": "Mostrando registros del _START_ al _END_ de una tabla de _TOTAL_",
            "sSearch": "Buscar: ",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Ultimo",
                "sNext": "Siguiente",
                "sPrevious":"Anterior"
            }
        }
    });
});