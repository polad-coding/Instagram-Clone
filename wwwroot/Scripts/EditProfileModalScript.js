$('#edit-profile-submit-button').click((e) => {
    e.preventDefault();

    if (validFileType(document.getElementById('profile-picture-selector').files[0])) {
        $('#edit-profile-modal-content').submit();
    }
});


$('#male-radio-button').click((e) => {
    $(e.target).css('background-color', '#3897F0');
    $(e.target).css('border', '1px solid #3897F0');
    $(e.target).css('color', 'white');
    $('#female-radio-button').css('background-color', 'white');
    $('#female-radio-button').css('border', '1px solid #DBDBDB');
    $('#female-radio-button').css('color', '#3897F0');
});
$('#female-radio-button').click((e) => {
    $(e.target).css('background-color', '#3897F0');
    $(e.target).css('border', '1px solid #3897F0');
    $(e.target).css('color', 'white');
    $('#male-radio-button').css('background-color', 'white');
    $('#male-radio-button').css('border', '1px solid #DBDBDB');
    $('#male-radio-button').css('color', '#3897F0');
});
$('#edit-profile-button').click((e) => {
    $('#edit-profile-modal').css('display', 'flex');
});
$('#edit-profile-modal-close').click((e) => {
    $('#edit-profile-modal').css('display', 'none');
});