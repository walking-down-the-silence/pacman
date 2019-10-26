const connection = new signalR.HubConnectionBuilder()
    .withUrl("/v1/map")
    .build();

// subscribes to an event channel and executes the function
connection.on("ReceiveMessage", handleReceivedMessage);

// start listening to the connection
connection
    .start()
    .catch(err => console.error(err.toString()));

// following code implements a handler for sending a user message
document.getElementById("sendButton").addEventListener("click", handleClickEvent);

function handleReceivedMessage(user, message) {
    // TODO: add handling here
}

function handleClickEvent(event) {
    // TODO: add handling here

    connection
        .invoke("SendMessage", user, message)
        .catch(err => console.error(err.toString()));

    event.preventDefault();
}