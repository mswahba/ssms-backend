import React, { Component, Fragment } from 'react'
import axios from 'axios'

export default class UserState extends Component {
  state = {
    users: [],
    loggedUser: {}
  }
  getUsers = () => {
    axios.get("/Users/List/all")
        .then(res => this.setState({ users: res.data }) )
  }
  componentDidMount() {
    this.getUsers();
  }
  render() {
    return <Fragment>{this.props.children(this.state)}</Fragment>
  }
}
