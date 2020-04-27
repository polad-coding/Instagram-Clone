$('#unlike-button').click((e) => {
    console.log('nio');
    $('#unlike-button').css('display', 'none');
    $('#like-button').css('display', 'inline');
    $.ajax({
        type: "GET",
        url: "/Account/UnlikePhoto",
        data: { postId: $('#like-icon-container').attr('data-postId') },
        success: (responce) => {
            $('#number-of-likes-part p').text(responce);
        },
        failure: (responce) => {

        }
    });
});
$('#like-button').click((e) => {
    console.log('nio');

    $('#like-button').css('display', 'none');
    $('#unlike-button').css('display', 'inline');
    $.ajax({
        type: "GET",
        url: "/Account/LikePhoto",
        data: { postId: $('#like-icon-container').attr('data-postId') },
        success: (responce) => {
            $('#number-of-likes-part p').text(responce);
        },
        failure: (responce) => {

        }
    });
});