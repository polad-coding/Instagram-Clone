$('.user-photo').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/GetProperBookmarksIcon",
        data: { postId: $(e.target).attr('data-post-id') },
        success: (responce) => {
            $('#bookmark-post-button').html(responce);
        },
        failure: (responce) => {

        }
    });
});

$('.user-photo').mouseenter((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/GetPostStats",
        data: { postId: $(e.target).attr('data-post-id') },
        success: (responce) => {
            $(e.target.nextElementSibling).html(responce);
        },
        failure: (responce) => {

        }
    });
    $(e.target.nextElementSibling).css('visibility', 'visible');
});

$('.user-photo').mouseleave((e) => {
    $(e.target.nextElementSibling).css('visibility', 'hidden');
});

$('.user-photo').click((e) => {
    $('#post-modal').css('display', 'flex');
});

$('.user-photo').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/GetProperLikeIcon",
        data: { postId: $(e.target).attr('data-post-id') },
        success: (responce) => {
            $('#like-picture-placeholder').html(responce);
        },
        failure: (responce) => {

        }
    });
});

$('.user-photo').click((e) => {
    $('#post-caption-part').attr('data-post-id', $(e.target).attr('data-post-id'));
});

$('.user-photo').one('click', (e) => {
    $('#number-of-likes-part p').text(`Liked by ${$(e.target).attr('data-number-likes')} users`);
});

$('.user-photo').click((e) => {
    $('#photo-part').append(`<img style="width:100%;height:100%;" src="${$(e.target).attr('src')}"/>`);
    $.ajax({
        type: "GET",
        url: "/Account/GetAuthorGeneralInfo",
        data: { id: $(e.target).attr('data-author-id'), postId: $(e.target).attr('data-post-id') },
        success: (responce) => {

            $('#comments-top-part').html(responce);
        },
        failure: (responce) => {

        }
    });
    $.ajax({
        type: "GET",
        url: "/Account/GetAllCaptions",
        data: { postId: $(e.target).attr('data-post-id') },
        success: (responce) => {
            console.log('blah');
            $('#comments-central-part').html(responce);
        },
        failure: (responce) => {

        }
    });
});