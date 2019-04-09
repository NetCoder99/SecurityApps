function ShowMessage(div_message, message, error, delayAmt = 3000) {
    console.log("ShowMessage:");
    if (error == true) {
        div_message.find("#img_common_success").hide();
        div_message.find("#img_common_warning").show();
    }
    if (error == false) {
        div_message.find("#img_common_success").show();
        div_message.find("#img_common_warning").hide();
    }
    if (error == null) {
        div_message.find("#img_common_success").hide();
        div_message.find("#img_common_warning").hide();
    }
    div_message.find("#lbl_common_message").text(message);

    if (delayAmt >= 0) {
        console.log("setting delay");
        div_message.show(0).delay(delayAmt).hide(0);
    }
    else {
        console.log("no delay");
        div_message.show(0);
    } 

}
