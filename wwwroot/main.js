//const signalR = require("@aspnet/signalr");

let connection = new signalR.HubConnectionBuilder()
    .withUrl("/wsapi")
    .configureLogging(signalR.LogLevel.Information)
    //.configureLogging(signalR.LogLevel.Trace)
    .build();

connection.start()
    .then(() =>
        connection.stream("UnsignedDocumentsNotifications")
            .subscribe({
                next: (docs) => {
                    console.log("Received documents", docs);

                    let messages = document.getElementById("messages");
                    // clear list
                    while (messages.firstChild) 
                        messages.removeChild(messages.firstChild);
                    // fill list
                    for (i in docs) {
                        let li = document.createElement("li");
                        li.textContent = docs[i].documentName;
                        messages.appendChild(li)
                    }                    
                },
                complete: () => {
                    var li = document.createElement("li");
                    li.textContent = "Stream completed";
                    document.getElementById("messages").appendChild(li);
                },
                error: (err) => {
                    var li = document.createElement("li");
                    li.textContent = err;
                    document.getElementById("messages").appendChild(li);
                },
            })
).catch(function (err) {
    return console.error(err.toString());
});