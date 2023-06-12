$(document).ready(function () {
    $(".viewInvites").click(function () {
        $(this).siblings('.clientInvites').slideToggle();
    });

    $(".windowDiv").click(function () {
        $(this).children(".windowLink")[0].click();
    });

    $("#searchField").keyup(function () {
        if ($(this).val().length > 0) {
            var regex = new RegExp('\\b\\w*' + $(this).val() + '\\w*\\b', 'i');
            $('.clientRow').hide().filter(function () {
                return regex.test($(this).data('client-name'));
            }).show();
        }
        else {
            $(".clientRow").show();
        }
    });
});