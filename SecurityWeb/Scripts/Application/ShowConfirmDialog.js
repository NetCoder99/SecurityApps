function ShowConfirmDialog(data) {
    var msgText = "<span>Delete this application: <span class='bold'>" + data.applicationName + " ?</span></span>";
    msgText += "<div><span class='bold'>Note: This will also delete " + data.rolesCount + " roles and " + data.usersCount + " users.</span></div>";
    bootbox.confirm({
        title: "Confirm Applicaton Delete.",
        message: msgText,
        buttons: {
            confirm: {
                label: 'Yes'
            },
            cancel: {
                label: 'No'
            }
        },
        callback: function (result) {
            if (result) {
                DeleteApplication(data.appGuid);
            }
            else {
                console.log("cancel delete");
                ShowMessage($('#div_remove_message'), "Cancelled request...", null, 7000);
                DisableInputs(false);
            }
        }
    });
    return false;
};