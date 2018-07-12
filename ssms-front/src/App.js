import React, { Component, Fragment } from 'react';
import SignIn from './users/SignIn';
import UsersList from './users/UsersList';
import SignUpParent from './users/SignUpParent';
import Hijri from './shared/Hijri';
import './App.css';

class App extends Component {
  render() {
    return (
      <Fragment>
      {/*
        <SignIn/>
        <UsersList/>
        <SignUpParent/>
      */}
        <Hijri />
      </Fragment>
    );
  }
}

export default App;
