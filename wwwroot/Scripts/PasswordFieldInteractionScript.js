//$('#password-field').keyup((e) => {
//    if ($(e.target).val().length > 0) {
//        if ($('#show-hide-password-button').css('visibility') === 'visible') {
//            return;
//        }
//        $('#show-hide-password-button').attr('value', 'Show');
//        $('#password-field').css('width', '81%');
//        $('#show-hide-password-button').css('visibility', 'visible');
//    }
//    else {
//        $('#password-field').css('width', '100%');
//        $('#show-hide-password-button').css('visibility', 'collapse');
//        $('#show-hide-password-button').attr('value', 'Show');
//        $('#password-field').attr('type', 'password');
//    }
//});

//$('#show-hide-password-button').click((e) => {
//    if ($(e.target).attr('value') === 'Show') {
//        $('#password-field').attr('type', 'text');
//        $('#show-hide-password-button').attr('value', 'Hide');
//    }
//    else if ($(e.target).attr('value') === 'Hide') {
//        $('#password-field').attr('type', 'password');
//        $('#show-hide-password-button').attr('value', 'Show');
//    }
//});

$('#password-field').keyup((e) => {
    if ($(e.target).val().length > 0) {
        if ($('#show-hide-password-button').css('visibility') === 'visible') {
            return;
        }
        $('#show-hide-password-button').attr('value', 'Show');
        $('#password-field').css('width', '81%');
        $('#show-hide-password-button').css('visibility', 'visible');
        if ($('#email-field').val().length > 0) {
            $('#submit-button').removeAttr('disabled');
            $('#submit-button').css('opacity', '1');
            $('#submit-button').css('filter', '');
            $('#submit-button').css('cursor', 'pointer');
        }
    }
    else {
        $('#password-field').css('width', '100%');
        $('#show-hide-password-button').css('visibility', 'collapse');
        $('#show-hide-password-button').attr('value', 'Show');
        $('#submit-button').attr('disabled');
        $('#submit-button').css('opacity', '0.4');
        $('#submit-button').css('filter', 'alpha(opacity=40)');
        $('#submit-button').css('cursor', '');
        $('#password-field').attr('type', 'password');

    }
});
$('#email-field').keyup((e) => {
    if ($(e.target).val().length > 0) {
        if ($('#password-field').val().length > 0) {
            $('#submit-button').removeAttr('disabled');
            $('#submit-button').css('opacity', '1');
            $('#submit-button').css('filter', '');
            $('#submit-button').css('cursor', 'pointer');

        }
    }
    else {
        $('#submit-button').attr('disabled');
        $('#submit-button').css('opacity', '0.4');
        $('#submit-button').css('filter', 'alpha(opacity=40)');
        $('#submit-button').css('cursor', '');

    }
});

$('#show-hide-password-button').click((e) => {
    if ($(e.target).attr('value') === 'Show') {
        $('#password-field').attr('type', 'text');
        $('#show-hide-password-button').attr('value', 'Hide');

    }
    else if ($(e.target).attr('value') === 'Hide') {
        $('#password-field').attr('type', 'password');
        $('#show-hide-password-button').attr('value', 'Show');


    }
});