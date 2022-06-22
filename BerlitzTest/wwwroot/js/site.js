// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    //call datatable
    $('#tblProducts').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "There is no information",
            "info": "Showing _START_ a _END_ de _TOTAL_ Entrances",
            "infoEmpty": "Showing 0 to 0 of 0 Entrances",
            "infoFiltered": "(Filtering of _MAX_ total entrances)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Show _MENU_ Entrances",
            "loadingRecords": "Loading...",
            "processing": "Processing...",
            "search": "Search:",
            "zeroRecords": "No results found",
            "paginate": {
                "first": "First",
                "last": "Last",
                "next": "Next",
                "previous": "Previous"
            }
        }
    });
});