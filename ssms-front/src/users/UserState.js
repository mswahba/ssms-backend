import React, { Component, Fragment } from 'react'
import axios from 'axios'
import M from 'materialize-css';

export default class UserState extends Component {
  state = {
    users: [],
    loggedUser: {}
  }
  signIn = (userId, userPassword) => {
    axios.post('/Users/SignIn', {
        userId, userPassword
    })
        .then((response) => {
            console.log(response);
            M.toast({ html: response.data.userId });
        })
        .catch((error) => {
            if (!error.response)
                return;
            console.log(error.response.data);
            M.toast({ html: error.response.data.UserId || error.response.data.UserPassword || error.response.data})
        });
  }
  getUsers = () => {
    axios.get("/Users/List/all")
        .then(res => this.setState({ users: res.data }) )
  }
  componentDidMount() {
    this.getUsers();
  }
  render() {
    const _filteredState = this.props.keys.reduce( (filteredState,key) => {
      filteredState[key] = this.state[key] || this[key];
      return filteredState;
    },{});
    return <Fragment>{this.props.children(_filteredState)}</Fragment>
  }
}
