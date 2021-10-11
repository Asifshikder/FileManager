
function addRequestVerificationToken(data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
}

function CreateFolder() {
    $('#createfoldermodal').modal('show');
}
function UploadFile() {
    $('#uploadfilemodal').modal('show');
}

function FolderCreateConfirm() {
    var parentid = $("#RootFolderId").val();
    var name = $("#CreateFolderNameInput").val();
    const postmodel = { name: name, parentId: parentid };
    $.ajax({
        url: '/Folder/Create',
        type: 'POST',
        data: postmodel,
        success: function (result) {
            if (result.success) {
                toastr.success(result.message)
                window.location.reload().delay(100);
            }
            else {
                toastr.error(result.message)
            }
        }
    });
}