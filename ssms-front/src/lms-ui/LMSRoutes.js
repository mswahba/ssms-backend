import React, { Component } from 'react'
import { Switch, Route } from 'react-router-dom'
import UsersList from './users/UsersList'
import SignIn from './users/SignIn'
import SignUpParent from './users/SignUpParent'
import Schools from './basic/Schools'
import Hijri from '../shared/Hijri'
import HGDatePicker from '../shared/HGDatePicker'
import { ToastContainer } from 'react-toastify'
import '../node_modules/react-toastify/dist/ReactToastify.min.css';
export default class AppRoutes extends Component {
  render() {
    return (
      <>
        <Switch>
          <Route path='/hijri' component={Hijri} />
          <Route path='/hg-datepicker' component={ () => (
            <div className="my-container">
                <HGDatePicker label="HireDate"
                              HLabel="HireDate Hijri"
                              GLabel="HireDate Gregorian"
                              HKey="HireDateH"
                              GKey="HireDateG"
                              HDate={null}
                              GDate={new Date()}
                              getDates={console.log}
                />
              </div>
            )}
          />
          <Route path='/schools' component={Schools} />
          <Route path='/signUpParent' component={SignUpParent} />
          <Route path='/sign-in' component={SignIn} />
          <Route path='/usersList' component={UsersList} />
          <Route path='/' component={() => <h2> 404 Page not Found ...</h2> } />
        </Switch>
        <ToastContainer autoClose={5000} pauseOnFocusLoss={true} />
      </>
    );
  }
}