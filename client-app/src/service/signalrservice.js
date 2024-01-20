// signalRService.js
import * as signalR from "@microsoft/signalr";

const startConnection = (onReceiveData) => {
  const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:8000/datahub")
    .build();

  connection
    .start()
    .then(() => console.log("Connected to SignalR Hub"))
    .catch((err) => console.error("Error in establishing connection:", err));

  connection.on("ReceiveData", (data) => {
    onReceiveData(data);
  });

  return connection;
};

const stopConnection = (connection) => {
  if (connection) {
    connection.stop();
  }
};

export { startConnection, stopConnection };
