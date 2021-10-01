var emailPosition = 1;
$(document).ready(function () {
    $("#addEmail").click(function () {
        $("#emailList").append("<div class='form-group row my-2 emailRow'>" +
            "<div class='col-auto'>" +
            "<label>Email</label></div>" +
            "<div class='col-5'><input type='email' required class='inviteEmail form-control' name='emails[" + emailPosition + "]'/></div>" +
            "<div class='col-auto'><i class='far fa-times-circle text-danger removeEmail' onclick='removeEmail(event)'></i></div></div> ");
        emailPosition++;
    });

    $(".removeEmail").click(function () {
        console.log('Hitting it at least');
        $(this).find(".form-group").remove();
    });
});

//needs to be a function for onclick since jquery would need to reprocess for new elements. 
function removeEmail(e) {
    var jqueryObject = $(e.target);
    console.log('Hitting it at least');
    $(jqueryObject).closest(".emailRow").remove();
}

function validateEmails() {
    var emails = $(".inviteEmail");
    for (let i = 0; i < emails.length; i++) {
        if ($(emails[i]).val.length == 0) {
            alert("")
        }
    }
}