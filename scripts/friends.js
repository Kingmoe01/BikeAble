$(document).ready(function () {
    $("#ContentPlaceHolder1_newFriends").tooltip();


});
function isFriendsExists(email) {
    email = email.value;
    var xhttp;

    if(email == "")
    {
        document.getElementById("isOk").src = "../img/none.jpg";
        return;
    }
    xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            if(this.responseText == "Nope"){
                document.getElementById("isOk").src = "../img/x.png";
            }
            else {
                document.getElementById("isOk").src = "../img/check.png";
            }
        }
    }

    xhttp.open("GET", "../AJAX/FriendExists.aspx?email=" + email, true);
    xhttp.send();

}
