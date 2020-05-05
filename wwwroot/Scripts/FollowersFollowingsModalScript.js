$('#number-of-followers').click((e) => {
    $('#followers-followings-modal').css('display', 'flex');

    $.ajax({
        type: "GET",
        url: "/Account/GetFollowers",
        data: { id: $('#user-account-container').attr('data-user-id') },
        success: (responce) => {
            $('#followers-followings-label').text('Followers');
            $('#modal-central-part').html(responce);
        },
        failure: (responce) => {
        }
    });
});

$('#number-of-followings').click((e) => {
    $('#followers-followings-modal').css('display', 'flex');
    $.ajax({
        type: "GET",
        url: "/Account/GetFollowings",
        data: { id: $('#user-account-container').attr('data-user-id') },
        success: (responce) => {
            $('#followers-followings-label').text('Followings');

            $('#modal-central-part').html(responce);

        },
        failure: (responce) => {

        }
    });
});

$('#close').click((e) => {
    $('#followers-followings-modal').css('display', 'none');
});