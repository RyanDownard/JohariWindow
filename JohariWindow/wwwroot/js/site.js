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