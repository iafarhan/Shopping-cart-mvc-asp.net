function InvalidName(textbox) {

    if (textbox.value == '') {
        textbox.setCustomValidity('Please enter your username.');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}

function InvalidSex(textbox) {

    if (textbox.value == '') {
        textbox.setCustomValidity('Please select your gender.');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}
function InvalidAge(textbox) {

    if (textbox.value == '') {
        textbox.setCustomValidity('Please enter your age.');
    }
    else if (textbox.value < 18 ) {
        textbox.setCustomValidity('Age should be greater than 18.');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}
function InvalidEmail(textbox) {

    if (textbox.value == '') {
        textbox.setCustomValidity('Please enter your username.');
    }
    else if (textbox.validity.typeMismatch) {
        textbox.setCustomValidity('Please enter a valid email address');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}
function InvaliPass(textbox) {

    if (textbox.value == '') {
        textbox.setCustomValidity('Please enter your Password.');
    }
    else if (textbox.value.length < 6) {
        textbox.setCustomValidity('Password should be greater than 6 digits.');

    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}