$(document).ready(function () {
    if (localStorage.getItem("Token")) {
        $.ajaxSetup({
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("Token")
            }
        });
    }
    $.ajaxSetup({
        statusCode: {
            401: function () {
                localStorage.removeItem("Token");
                localStorage.removeItem("Endpoint");
                window.location.replace("/Account/Login");
            }
        }
    });
});