function DisableInputs(flag) {
    if (flag) {
        $(":button").prop("disabled", true);
        $(":input").prop("disabled", true);
        $(".form-horizontal").prop("disabled", true);
        $(".small_inp_box").prop("disabled", true);
        $("input:password").prop("disabled", true);
        $("select").prop('disabled', true);
    }
    else {
        $(":button").prop("disabled", false);
        $(":input").prop("disabled", false);
        $(".form-horizontal").prop("disabled", false);
        $(".small_inp_box").prop("disabled", false);
        $("input:password").prop("disabled", false);
        $("select").prop('disabled', false);
        $(".xdisabled").prop("disabled", true);
    }
}