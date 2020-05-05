$('#post-submit-button').click((e) => {
    e.preventDefault();

    let content = $('#add-post-modal-content').children('textarea').val();

    if (content.length > 0 && /\S/.test(content) && document.getElementById('form-file-selected').files.length > 0 && validFileType(document.getElementById('form-file-selected').files[0])) {
        $('#add-post-modal-content').submit();
    }
    if (content.length == 0 || !/\S/.test(content)) {
        $('#text-area-error').text('Text area cannot be empty!');
    }
    if (document.getElementById('form-file-selected').files.length == 0 || !validFileType(document.getElementById('form-file-selected').files[0])) {
        $('#file-error').text('File is not selected or format of file is unsupported!')
    }

});

function validFileType(file) {
    let fileTypes = [
        'image/jpeg',
        'image/pjpeg',
        'image/png'
    ];

    if (file == null) {
        return true;
    }
    for (var i = 0; i < fileTypes.length; i++) {
        if (file.type === fileTypes[i]) {
            return true;
        }
    }

    return false;
}

$('#add-comment-button').click((e) => {
    $('#text-input').focus();
});