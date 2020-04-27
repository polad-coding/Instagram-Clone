$('.unfollow-button').click((e) => {
    console.log('fired');
    $.ajax({
        type: "GET",
        url: "/Account/UnfollowUser",
        data: { id: $(e.target).attr('data-current-user-id') },
        success: (responce) => {
            if ('@ViewBag.UserProfileId' == '@ViewBag.CurrUserId') {

                $('#number-of-followings :first').text(`${parseInt($('#number-of-followings').text()) - 1}`);
                $('#number-of-followings :last').text('followings');

                $('#number-of-followings :first').css('font-weight', 'bold');
            }
            $(e.target).css('display', 'none');
            $(e.target).siblings().css('display', 'inline');
        },
        error: (responce) => {
            alert('error');
        }
    });


});
$('.follow-button').click((e) => {
    console.log('fired');
    $.ajax({
        type: "GET",
        url: "/Account/FollowUser",
        data: { id: $(e.target).attr('data-current-user-id') },
        success: (responce) => {
            if ('@ViewBag.UserProfileId' == '@ViewBag.CurrUserId') {

                $('#number-of-followings :first').text(`${parseInt($('#number-of-followings').text()) + 1}`);
                $('#number-of-followings :last').text('followings');

                $('#number-of-followings :first').css('font-weight', 'bold');
            }
            $(e.target).css('display', 'none');
            $(e.target).siblings().css('display', 'inline');

        },
        error: (responce) => {
            alert('error');
        }
    });
});