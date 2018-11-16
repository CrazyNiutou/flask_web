function myFunction() {
    document.getElementById('demo').innerText = '测试'
}

function validate_required(field, alerttxt) {
    with(field) {
        if (value == null || value == "") {
            alert(alerttxt);
            return false;
        } else {
            return true;
        }
    }
}

function validate_form(thisform) {
    with(thisform) {
        if (validate_required(email, "必须填写")) {
            email.focus();
            return false;
        }
    }
}

function test() {
    var flag = new Boolean("false");
    alert(flag)
}