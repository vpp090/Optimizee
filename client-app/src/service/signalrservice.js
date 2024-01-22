// signalRService.js
import * as signalR from "@microsoft/signalr";
import API_BASE_URL from "./constants";

const startConnection = (onReceiveData) => {
  const connection = new signalR.HubConnectionBuilder()
    .withUrl(`${API_BASE_URL}/datahub`)
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
