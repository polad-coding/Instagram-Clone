$('#FollowButton').click((e) => {
    $('#FollowButton').css('display', 'none');
    $('#UnfollowButton').css('display', 'inline');
    $('#number-of-followers :first').text(`${parseInt($('#number-of-followers').text()) + 1}`);
    $('#number-of-followers :last').text('followers');
});

$('#FollowButton').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/FollowUser",
        data: { id: $('#follow-unfollow-button-container').attr('data-user-id') },
        success: (responce) => {

        },
        failure: (responce) => {

        }
    });
});

$('#UnfollowButton').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/UnfollowUser",
        data: { id: $('#follow-unfollow-button-container').attr('data-user-id') },
        success: (responce) => {

        },
        failure: (responce) => {

        }
    });
});

$('#UnfollowButton').click((e) => {
    $('#UnfollowButton').css('display', 'none');
    $('#FollowButton').css('display', 'inline');
    $('#number-of-followers :first').text(`${parseInt($('#number-of-followers').text()) - 1}`);
    $('#number-of-followers :last').text('followers');
});