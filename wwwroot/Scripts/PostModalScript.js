
$('#caption-post-form').submit((e) => {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Account/AddComment",
        data: { text: $('#caption-post-form').children(':first').val(), postId: $('#post-caption-part').attr('data-post-id') },
        success: (responce) => {
            $('#comments-central-part').html(responce);
            $('#text-input').val('');
            $('#caption-submit-button').css('opacity', '0.4');
            $('#caption-submit-button').css('filter', 'alpha(opacity=40)');
        },
        failure: (responce) => {

        }
    });
});

$('#post-modal-close').click((e) => {
    $('#post-modal').css('display', 'none');
    $('#photo-part img').remove();
});


$('#text-input').keyup((e) => {
    if ($(e.target).val().replace(/\s+/g, '').length > 0) {
        $('#caption-submit-button').removeAttr('disabled');
        $('#caption-submit-button').css('opacity', '');
        $('#caption-submit-button').css('filter', '');
    }
    else {
        $('#caption-submit-button').attr('disabled');
        $('#caption-submit-button').css('opacity', '0.4');
        $('#caption-submit-button').css('filter', 'alpha(opacity=40)');
    }
});