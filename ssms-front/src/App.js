import React, { Component, Fragment } from 'react';
import SignIn from './users/SignIn';
import UsersList from './users/UsersList';
import SignUpParent from './users/SignUpParent';
import Hijri from './shared/Hijri';
import HGDatePicker from './shared/HGDatePicker';
import './App.css';

class App extends Component {
  render() {
    return (
      <Fragment>
      {/*
        <SignIn/>
        <UsersList/>
        <SignUpParent/>
        <Hijri />
      */}
      <div className="container">
        <HGDatePicker label="HireDate"
                      HKey="HireDateH"
                      GKey="HireDateG"
                      HDate={'01/01/1439'}
                      GDate={new Date()}
        />
      </div>
      </Fragment>
    );
  }
}

export default App;
