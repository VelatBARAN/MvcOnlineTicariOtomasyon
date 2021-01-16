$(document).ready(function () {
    var table = $('#tbl').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'csv', 'pdf', 'colvis']
    });

    table.buttons().container()
        .appendTo('#tbl_wrapper .col-md-6:eq(0)');
});