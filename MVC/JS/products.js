function InvalidProductName(textbox) {

    if (textbox.value == '') {
        textbox.setCustomValidity('Please fill this field.');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}

