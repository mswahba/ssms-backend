import React, { Component } from "react";
import { connect } from "react-redux";
import { getTranslate } from 'react-localize-redux'
import { userActions } from "../store/user";
import { toast } from 'react-toastify';

class SignIn extends Component {
  state = {
    userId: "",
    userPassword: ""
  };
  componentWillReceiveProps(newProps) {
    if (newProps.error)
      toast.error(JSON.stringify(newProps.error));
    else if(newProps.loggedUser.userId)
      toast.info(JSON.stringify(newProps.loggedUser.userId));
  }
  render() {
    const { trans } = this.props;
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
          <label htmlFor="userId">{trans("users.signIn.userId")}</label>
        </div>
        <div className="input-field ">
          <input
            type="text"
            id="userPassword"
            className="validate"
            value={this.state.userPassword}
            onChange={e => this.setState({ userPassword: e.target.value })}
          />
          <label htmlFor="userPassword">{trans("users.signIn.password")}</label>
        </div>
        <a
          className="waves-effect waves-light btn"
          onClick= {
            () => userActions.signIn({ req: ["post", "/Users/SignIn", this.state]})
          }
        >
          <i className="material-icons right">cloud</i>
          {trans("users.signIn.btn")}
        </a>
      </form>
    );
  }
}

const mapStateToProps = state => ({
  ...state.user,
  "trans": getTranslate(state.localize)
});

export default connect(mapStateToProps)(SignIn);
