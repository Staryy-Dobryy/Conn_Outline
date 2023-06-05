try {
    var block = document.getElementById("chat-feald");
    block.scrollTop = block.scrollHeight;

    document.getElementById("sendBtn").addEventListener("click", function () {
        var chat = document.getElementById("image-feald");
        console.log("sendBtn");
        let message = document.getElementById("getMessage").value;
        var data = {
            "messageText": message,
            "chatId": chat.getAttribute("chat-id"),
            "token": localStorage.getItem("Token")
        }
        hubConnection.invoke("Send", data)
            .then(function () {
                console.log("hubConnection triggered");
            })
            .catch(function (err) {
                console.log(err);
                hubConnection.start()
                    .then(function () {
                        console.log("started");
                        document.getElementById("getMessage").value = "";
                        hubConnection.invoke("Send", data)
                    })
                    .catch(function (err) {
                        return console.error(err.toString());
                    });
            });
    });
}
catch (err) {
    console.log(err);
}