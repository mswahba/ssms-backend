import React, { Component, Fragment } from 'react';
import SignIn from './users/SignIn';
import UsersList from './users/UsersList';
import './App.css';

class App extends Component {
  render() {
    return (
      <Fragment>
        <SignIn/>
        <UsersList/>
      </Fragment>
    );
  }
}

export default App;
