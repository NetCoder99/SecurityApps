function GetAppCounts(appGuid) {
    console.log("GetAppCounts: " + appGuid);
    $.ajax({
        type: 'GET',
        url: '/Applications/GetAppCounts',
        data: {
            'appGuid': appGuid
        },
        dataType: "json",
        error: function () {
            console.log("GetAppCounts: error");
            window.location.href = "/Error/Index";
        },
        success: function (data) {
            console.log("success");
            console.log(JSON.stringify(data));
            ShowConfirmDialog(data);
        },
        complete: function () {
            console.log("complete");
        }
    });
}