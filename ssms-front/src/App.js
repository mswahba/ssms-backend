import React, { Component, Fragment } from 'react';
import SignIn from './users/SignIn';
import UsersList from './users/UsersList';
import SignUpParent from './users/SignUpParent';
import Hijri from './shared/Hijri';
import HGDatePicker from './shared/HGDatePicker';
import './App.css';

class App extends Component {
  logDates = (dates) => console.log(dates);
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
                      HDate={null}
                      GDate={new Date()}
                      getDates={this.logDates}
        />
      </div>
      </Fragment>
    );
  }
}

export default App;
