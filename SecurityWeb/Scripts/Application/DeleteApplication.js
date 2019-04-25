function DeleteApplication(appGuid) {
    console.log("DeleteApplication:" + appGuid);
    ShowMessage($('#div_remove_message'), "Processing Delete...", null, -1);

    $.ajax({
        type: 'POST',
        url: '/Applications/DeleteApplication',
        data: {
            'appGuid': appGuid
        },
        dataType: "json",
        error: function () {
            console.log("DeleteApplication:error");
            DisableInputs(false);
        },
        success: function (data) {
            console.log("DeleteApplication:success:" + appGuid);
            var table1 = $('#tbl_applications').DataTable();
            var table1_row = table1.row("#" + appGuid + "");
            table1_row.remove().draw(false);
            ShowMessage($('#div_remove_message'), "Application was deleted.", false);
            DisableInputs(false);
        },
        complete: function () {
            console.log("DeleteApplication:complete");
            DisableInputs(false);
        }
    });
    return false;
};