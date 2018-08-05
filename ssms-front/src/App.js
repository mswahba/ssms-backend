import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';
import SignIn from './users/SignIn';
import UsersList from './users/UsersList';
import SignUpParent from './users/SignUpParent';
import Hijri from './shared/Hijri';
import HGDatePicker from './shared/HGDatePicker';
import Schools from './basic/Schools'
import './App.css';

class App extends Component {
  // logDates = (dates) => console.log(dates);
  render() {
    return (
      <Switch>
        <Route path='/schools' component={Schools} />
        <Route path='/signIn' component={SignIn} />
        <Route path='/signUpParent' component={SignUpParent} />
        <Route path='/usersList' component={UsersList} />
        <Route path='/hijri' component={Hijri} />
        <Route path='/hg-datepicker' component={ () => (
          <div className="my-container">
              <HGDatePicker label="HireDate"
                            HKey="HireDateH"
                            GKey="HireDateG"
                            HDate={null}
                            GDate={new Date()}
                            getDates={this.logDates}
              />
            </div>
          )} />
        <Route path='/' component={() => <h2> 404 Page not Found ...</h2> } />
      </Switch>
    );
  }
}

export default App;
