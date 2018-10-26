import { HubConnectionBuilder } from '@aspnet/signalr'

export default () => {
  let connection = new HubConnectionBuilder()
                        .withUrl("http://localhost:5000/schools-hub")
                        .build();
  connection.start()
            .then(() => {
              connection.invoke("SendMessage", "Hub Connection Started ...");
              connection.invoke("SendList", "all",null,null);
            });
  connection.on("ReceiveMessage", message => console.log(message) );
  connection.on("ReceiveList", data => console.log(data) );
}

// const x = {
//   "hubName": {
//     event: fn
//   }
// }