$('#comment-modal-follow-button').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/FollowUser",
        data: { id: $('#username').attr('data-userId') },
        success: (responce) => {
            $('#comment-modal-follow-button').css('display', 'none');
            $('#comment-modal-unfollow-button').css('display', 'inline');
            $('#number-of-followings :first').text(`${parseInt($('#number-of-followings').text()) + 1}`);
            $('#number-of-followings :last').text('followings');

            $('#number-of-followings :first').css('font-weight', 'bold');
        },
        failure: (responce) => {
        }
    });
});
$('#comment-modal-unfollow-button').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/UnfollowUser",
        data: { id: $('#username').attr('data-userId') },
        success: (responce) => {
            $('#comment-modal-unfollow-button').css('display', 'none');
            $('#comment-modal-follow-button').css('display', 'inline');
            $('#number-of-followings :first').text(`${parseInt($('#number-of-followings').text()) - 1}`);
            $('#number-of-followings :last').text('followings');

            $('#number-of-followings :first').css('font-weight', 'bold');
        },
        failure: (responce) => {
        }
    });
});