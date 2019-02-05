import { HubConnectionBuilder } from '@aspnet/signalr';

export default () => {
  let connection = new HubConnectionBuilder()
                        .withUrl('http://localhost:5000/db-hub')
                        .build();
	function onStart() {
    console.log('connection started');
    connection.invoke("Send", "Hub Connection Started ...");
    connection.invoke('JoinGroups', [ 'users', 'schools', 'countries', 'actions' ]);
    connection.on("getMessage", console.log);
    connection.on("onChange", console.log);
	}
	connection.start().then(onStart);
};
