// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})

function validateCheckBoxes() {
    var positiveChecked = $('.positiveAttribute:checkbox:checked').length;
    var negativeChecked = $('.negativeAttribute:checkbox:checked').length;
    if (positiveChecked !== 12) {
        alert("12 positive adjectives must be selected. You have " + positiveChecked + " selected");
        return false;
    }
    if (negativeChecked !== 7) {
        alert("7 negative adjectives must be selected. You have " + negativeChecked + " selected");
        return false;
    }
}

$(".positiveAttribute").click(function () {
    $("#positiveTotal").text($('.positiveAttribute:checkbox:checked').length);
});

$(".negativeAttribute").click(function () {
    $("#negativeTotal").text($('.negativeAttribute:checkbox:checked').length);
});


function printDiv(idToPrint) {
    var mywindow = window.open('', 'PRINT');

    mywindow.document.write('<html><head><title>' + document.title + '</title>');
    mywindow.document.write('<link rel="stylesheet" href="/lib/bootstrap/dist/css/bootstrap.min.css" />');
    mywindow.document.write('<link rel="stylesheet" href="/lib/fontawesome/css/all.min.css" />');
    mywindow.document.write('<link rel="stylesheet" href="/css/site.css" />');
    mywindow.document.write('</head><body><div class="container">');
    mywindow.document.write(document.getElementById(idToPrint).innerHTML);
    mywindow.document.write('</div></body></html>');

    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/

    mywindow.print();
    mywindow.close();
}