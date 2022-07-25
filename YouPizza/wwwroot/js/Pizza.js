$(document).ready(function () {
    $('#tbl').DataTable({
        ajax: 'data/arrays.txt',
    });
});