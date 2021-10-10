
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
            if (result.isSuccess) {
                toastr.success(result.message)
                $.each(result.ids, function (index, value) {
                    var rowid = "#row" + value + "";
                    $(rowid).remove();
                });
                removeallitemfromarray();
                $('#multideleteModal').modal('hide');
                divhideorshow();
            }
            else {
                toastr.error('Sommething went wrong!')
            }
        }
    });
}