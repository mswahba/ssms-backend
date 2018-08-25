import React, { Component } from "react";
import { connect } from "react-redux";
import { userActions } from "../store/user";
import toast from '../mdToast';

class SignIn extends Component {
  state = {
    userId: "",
    userPassword: ""
  };
  componentWillReceiveProps(newProps) {
    if (newProps.error)
      toast({ html: JSON.stringify(newProps.error), time: 5000, preventMultiple: true })
    else if(newProps.loggedUser.userId)
      toast({ html: JSON.stringify(newProps.loggedUser.userId), time: 5000, preventMultiple: true })
  }
  render() {
    return (
      <form>
        <div className="input-field ">
          <input
            type="text"
            id="userId"
            className="validate"
            value={this.state.userId}
            onChange={e => this.setState({ userId: e.target.value })}
          />
          <label htmlFor="userId">User ID</label>
        </div>
        <div className="input-field ">
          <input
            type="text"
            id="userPassword"
            className="validate"
            value={this.state.userPassword}
            onChange={e => this.setState({ userPassword: e.target.value })}
          />
          <label htmlFor="userPassword">Password</label>
        </div>
        <a
          className="waves-effect waves-light btn"
          onClick= {
            () => userActions.signIn({ req: ["post", "/Users/SignIn", this.state]})
          }
        >
          <i className="material-icons right">cloud</i>
          Sign-in
        </a>
      </form>
    );
  }
}

const mapStateToProps = state => ({
  ...state.user
});

export default connect(mapStateToProps)(SignIn);
