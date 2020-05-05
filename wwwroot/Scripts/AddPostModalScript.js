$('#add-post-action').click((e) => {
    $('#add-post-modal').css('display', 'flex');
});
$('#add-post-modal-close').click((e) => {
    $('#add-post-modal').css('display', 'none');
});
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            if ($(input).attr('name') === 'ProfilePicture') {
                $('#user-picture').attr('src', e.target.result);
            }
            else {
                $('#file-selected').attr('src', e.target.result);
                $('#file-selected').css('display', 'inline');
            }

        }

        reader.readAsDataURL(input.files[0]);
    }
}
$(".file-upload").change(function () {
    readURL(this);
});