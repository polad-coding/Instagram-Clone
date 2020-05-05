$('#inner-span-f').click((e) => {
    if (e.target.tagName !== 'DIV') {
        $(e.target).closest('#inner-span-f').css({ 'border-top': '1px solid black', 'margin-top': '-6px', 'padding-top': '5px', 'opacity': '', 'filter': '' });
        document.getElementById('inner-span-s').style.removeProperty('border-top');
        document.getElementById('inner-span-s').style.setProperty('opacity', '0.4');
        document.getElementById('inner-span-s').style.setProperty('filter', 'alpha(opacity=40)');
    }
    else {
        $(e.target).css({ 'border-top': '1px solid black', 'margin-top': '-6px', 'padding-top': '5px', 'opacity': '', 'filter': '' });
        document.getElementById('inner-span-s').style.removeProperty('border-top');
        document.getElementById('inner-span-s').style.setProperty('opacity', '0.4');
        document.getElementById('inner-span-s').style.setProperty('filter', 'alpha(opacity=40)');
    }
});

$('#inner-span-f').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/GetAllPosts",
        data: { userId: $('#user-account-container').attr('data-user-id') },
        success: (responce) => {
            $('#users-photos-part').html(responce);
        },
        failure: (responce) => {

        }
    });
});


$('#inner-span-s').click((e) => {
    if (e.target.tagName !== 'DIV') {
        $(e.target).closest('#inner-span-s').css({ 'border-top': '1px solid black', 'margin-top': '-6px', 'padding-top': '5px', 'opacity': '', 'filter': '' });
        document.getElementById('inner-span-f').style.removeProperty('border-top');
        document.getElementById('inner-span-f').style.setProperty('opacity', '0.4');
        document.getElementById('inner-span-f').style.setProperty('filter', 'alpha(opacity=40)');
    }
    else {
        $(e.target).css({ 'border-top': '1px solid black', 'margin-top': '-6px', 'padding-top': '5px', 'opacity': '', 'filter': '' });
        document.getElementById('inner-span-f').style.removeProperty('border-top');
        document.getElementById('inner-span-f').style.setProperty('opacity', '0.4');
        document.getElementById('inner-span-f').style.setProperty('filter', 'alpha(opacity=40)');
    }


});

$('#inner-span-s').click((e) => {
    $.ajax({
        type: "GET",
        url: "/Account/GetAllBookmarks",
        data: {},
        success: (responce) => {
            $('#users-photos-part').html(responce);
        },
        failure: (responce) => {

        }
    });
});