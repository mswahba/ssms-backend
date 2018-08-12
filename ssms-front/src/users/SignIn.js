import React, { Component } from "react";
import { connect } from "react-redux";
import { userActions } from "../store/user";
import { axiosOne } from "../axios";
import M from "materialize-css";

class SignIn extends Component {
  state = {
    userId: "",
    userPassword: ""
  };
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
          onClick={() => userActions.signIn(axiosOne("post", "/Users/SignIn", this.state)) }
        >
          <i className="material-icons right">cloud</i>
          Sign-in
        </a>
      </form>
    );
  }
}

const mapStateToProps = state => {
  if (state.user.error)
    return {
      ...state.user,
      error: M.toast({ html: JSON.stringify(state.user.error) })
    };
  else if(state.user.loggedUser.userId)
    return {
      ...state.user,
      message: M.toast({ html: JSON.stringify(state.user.loggedUser.userId) })
    };
  else
    return {
      ...state.user,
    };
};

export default connect(mapStateToProps)(SignIn);
