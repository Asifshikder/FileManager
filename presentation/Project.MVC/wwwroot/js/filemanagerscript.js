function addRequestVerificationToken(data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
}
function UploadFileToServer() {
    var parentid = $("#RootFolderId").val();
    var totalfiles = document.getElementById('uploadfiles').files.length;
    var header = {};
    var AntiForgeryToken = $("input[name='__RequestVerificationToken']").val();
    header['__RequestVerificationToken'] = AntiForgeryToken;
    var formData = new FormData();
    var model = { folderid: parentid };
    var totalfiles = document.getElementById('uploadfiles').files.length;
    for (var index = 0; index < totalfiles; index++) {
        formData.append("files[]", document.getElementById('uploadfiles').files[index]);
    }
    formData.append('UploadModel', JSON.stringify(model));
    $("#modalcontentupload").empty();
    $("#btnfileuploadcancel").prop("disabled", true);;
    $("#btnfileupload").prop("disabled", true);;
    $("#modalcontentupload").append('<div class="spinner-border" role="status"> <span class= "visually-hidden" ></span ></div>Uploading');
    $.ajax({
        type: "POST",
        url: "/Files/Upload",
        headers: header,
        data: formData,
        processData: false,
        contentType: false,
        success: function (result) {
            if (result.success) {
                toastr.success(result.message)
            }
            else {
                toastr.error(result.message)
            }
        }

    });
}