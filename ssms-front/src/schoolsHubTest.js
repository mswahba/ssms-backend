import { HubConnectionBuilder } from '@aspnet/signalr'

export default () => {
  let connection = new HubConnectionBuilder()
                        .withUrl("http://localhost:5000/schools-hub", {
                          serverTimeoutInMilliseconds: 120000
                      })
                        .build();
  connection.start()
            .then(() => {
              // connection.invoke("SendMessage", "Hub Connection Started ...");
              // connection.invoke("SendList", "all",null,null);
              connection.invoke("Add", {
                "schoolId": "string",
                "schoolNameAr": "string",
                "schoolNameEn": "string",
                "startDate": "2018-10-26T13:57:50.679Z",
                "address": "string",
                "comNum": "string",
                "isActive": true
              }).catch(console.log);
            });
  connection.on("ReceiveMessage", message => console.log(message) );
  connection.on("ReceiveList", data => console.log(data) );
}

// const x = {
//   "hubName": {
//     event: fn
//   }
// }