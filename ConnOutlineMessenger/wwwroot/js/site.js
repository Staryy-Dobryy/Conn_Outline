
$(document).ready(function () {
    if (localStorage.getItem("Endpoint")) {
        $.ajax({
            url: localStorage.getItem("Endpoint"),
            method: 'get',
            dataType: "html",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("Token")
            },
            success: function (data) {
                $("body").html(data);
            },
            statusCode: {
                401: function () {
                    localStorage.removeItem("Token");
                    localStorage.removeItem("Endpoint");
                    window.location.replace("/");
                }
            }
        });
    }
});

async function login() {
    var loginData = {
        email: $("#login-email").val(),
        password: $("#login-password").val()
    }
    $.ajax({
        url: '/token',         /* Куда отправить запрос */
        method: 'post',             /* Метод запроса (post или get) */
        dataType: 'json',          /* Тип данных в ответе (xml, json, script, html). */
        data: loginData,     /* Данные передаваемые в массиве */
        success: function (data) {   /* функция которая будет выполнена после успешного запроса.  */
            localStorage.setItem("Token", data["access_token"]);
            loadcart();
        }
    });
}
function logout() {
    localStorage.removeItem("Token");
    localStorage.removeItem("Endpoint");
    window.location.replace("/");
}

function loadcart() {
    var targetUrl = "/Chats";
    $.ajax({
        url: targetUrl,
        method: 'get',
        dataType: "html",
        headers: {
            "Authorization": "Bearer " + localStorage.getItem("Token")
        },
        success: function (data) {
            localStorage.setItem("Endpoint", targetUrl)
            $("body").html(data);
        }
    });
}
function createChatModal() {
    $.ajax({
        url: "/Menu/CreateChat",
        method: 'get',
        dataType: "html",
        success: function (data) {
            $("#load-div").html(data);
        }
    });
}
function createChat() {
    $.ajax({
        url: "/Menu/CreateChat1",
        method: 'post',
        dataType: "html",
        success: function (data) {
            $("body").html(data);
        }
    });
}

function addFriendModal() {
    $.ajax({
        url: "/Menu/AddFriend",
        method: 'get',
        dataType: "html",
        success: function (data) {
            $("#load-div").html(data);
        }
    });
}
function addFriend() {
    $.ajax({
        url: "/Menu/AddFriend",
        method: 'post',
        dataType: "html",
        success: function (data) {
            $("body").html(data);
        }
    });
}
function showChat(obj) {
    var queryData = {
        stringChatId: obj.id
    }
    $.ajax({
        url: "/Chats/Chat",
        method: 'get',
        dataType: "html",
        data: queryData,
        success: function (data) {
            $("body").html(data);
        }
    });
}
function deleteChat(obj) {
    var queryData = {
        stringChatId: obj.id
    }
    $.ajax({
        url: "/Chats/Leave",
        method: 'post',
        dataType: "html",
        data: queryData,
        success: function (data) {
            $("body").html(data);
        }
    });
}

function deleteChat(obj) {
    var queryData = {
        stringChatId: obj.id
    }
    $.ajax({
        url: "/Chats/Leave",
        method: 'post',
        dataType: "html",
        data: queryData,
        success: function (data) {
            $("body").html(data);
        }
    });
}

function friends() {
    $.ajax({
        url: "/Menu/Friends",
        method: 'get',
        dataType: "html",
        success: function (data) {
            $("body").html(data);
        }
    });
}

console.log("creation started");
const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/Chat", { accessTokenFactory: () => localStorage.getItem("Token") })
    .build();
console.log(hubConnection);
console.log("creation end");

hubConnection.on("Receive", function (message) {
    var now = new Date(message["sendTime"]).toLocaleString();

    var newDiv = '<div id="message"><div id="message-sender">';
    if (message["sender"]["userIcon"] === null) {
        newDiv += '<img src="/images/user-icon.png">';
    }
    else {
        newDiv += '<img src="' + message["sender"]["userIcon"]["link"] + '">';
    }
    newDiv += '<h5>' + message["sender"]["userName"] + '</h5>';
    newDiv += '<sub>' + now.replace(",", "") + '</sub>';
    newDiv += '<button id="' + message["id"] +'" class="delete-button">delete</button>';
    newDiv += '</div>';
    newDiv += '<div id="message-content"><p>' + message["messageText"] + '</p></div>';
    newDiv += '</div>';

    document.querySelector('#chat-feald').innerHTML += newDiv;
    block.scrollTop = block.scrollHeight;
});

// modal
var modal = document.getElementById("myModal");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
