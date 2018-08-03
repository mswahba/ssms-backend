import React from "react";
import UserState from "./UserState";
import { Consumer } from "../AppStore";
export default () => (
  <Consumer>
    {({ user, _getUsers, getUsers }) => {
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
