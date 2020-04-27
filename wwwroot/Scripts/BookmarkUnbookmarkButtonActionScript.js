$('#bookmark-button').click((e) => {
    $('#bookmark-button img').css('display', 'none');
    $('#unbookmark-button img').css('display', 'inline');
});
$('#unbookmark-button').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/UnbookmarkPost",
        data: { postId: $('#bookmark').attr('data-postId') },
        success: (responce) => {

        },
        failure: (responce) => {

        }
    });
});
$('#bookmark-button').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/BookmarkPost",
        data: { postId: $('#bookmark').attr('data-postId') },
        success: (responce) => {

        },
        failure: (responce) => {

        }
    });
});

$('#unbookmark-button').click((e) => {
    $('#unbookmark-button img').css('display', 'none');
    $('#bookmark-button img').css('display', 'inline');
});