function InvalidUsername(textbox) {

    if (textbox.value == '') {
        textbox.setCustomValidity('Please enter your username.');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}

function InvalidPass(textbox) {

    if (textbox.value == '') {
        textbox.setCustomValidity('Please enter your password.');
    }
    else if (textbox.value.length < 6) {
        textbox.setCustomValidity('Password should be greater than 6 digits.');

    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}