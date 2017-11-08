$(document).ready(function () {

    var code = new QRCode("qrcode");

    function makeCode() {
        var elText = document.getElementById("ContentPlaceHolder1_ID_QR");
        code.makeCode(elText.value);
    }

    makeCode();
});

var copyTextareaBtn = document.querySelector('#Icon');

copyTextareaBtn.addEventListener('click', function (event) {
    var copyTextarea = document.querySelector('#ContentPlaceHolder1_TextPwd');
    copyTextarea[0].select();

    try {
        var successful = document.execCommand('copy');
        var msg = successful ? 'successful' : 'unsuccessful';
        console.log('Copying text command was ' + msg);
    } catch (err) {
        console.log('Oops, unable to copy');
    }
});