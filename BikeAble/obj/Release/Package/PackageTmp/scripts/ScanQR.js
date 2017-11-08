
function decodeImageFromBase64(data, callback) {
    // set callback
    qrcode.callback = callback;
    // Start decoding
    qrcode.decode(data);
}

function DecodeQR() {
    var imageURI = document.getElementById("picture").src;
    decodeImageFromBase64(imageURI, function (decodedInformation) { $("#ContentPlaceHolder1_ID_QR").val(decodedInformation); __doPostBack('ctl00$ContentPlaceHolder1$decode', ''); });
}

function previewFile() {
    var preview = document.querySelector('#picture');
    var file = document.querySelector('input[type=file]').files[0];
    var reader = new FileReader();

    reader.addEventListener("load", function () {
        preview.src = reader.result;
    }, false);

    if (file) {
        reader.readAsDataURL(file);
    }
}
