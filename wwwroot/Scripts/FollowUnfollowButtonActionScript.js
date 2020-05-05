
$('.FollowButton').click((e) => {
    $(e.target).css('display', 'none');
    $(e.target).siblings('a').css('display', 'inline');
});

$('.FollowButton').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/FollowUser",
        data: { id: $(e.target).parent().attr('data-userId') },
        success: (responce) => {

        },
        failure: (responce) => {

        }
    });
});

$('.UnfollowButton').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/UnfollowUser",
        data: { id: $(e.target).parent().attr('data-userId') },
        success: (responce) => {

        },
        failure: (responce) => {

        }
    });
});

$('.UnfollowButton').click((e) => {
    $(e.target).css('display', 'none');
    $(e.target).siblings('a').css('display', 'inline');
});

