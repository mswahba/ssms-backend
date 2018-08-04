import React from "react";
import { Consumer } from "../AppStore";
export default () => (
  <Consumer>
    {({ user, getUsers }) => {
      if(!user.users.length)
        getUsers();
      return (
        <ol>
          {user.users.map(user => <li key={user.userId}>{user.userId}</li>)}
        </ol>
      )
    } }
  </Consumer>
);
