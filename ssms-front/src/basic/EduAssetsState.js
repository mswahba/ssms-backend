import React, { Component, Fragment } from 'react'
import axios from 'axios';

export default class EduAssetsState extends Component {
  state = {
    schools: []
  }

  getSchools = () => {
    axios.get("/Schools/List/all")
      .then(res => this.setState({ schools: res.data }))
  }

  componentDidMount() {
    this.getSchools();
  }

  render() {
    const _filteredState = this.props.keys
                              .reduce( (filteredState,key) => {
                                filteredState[key] = this.state[key] || this[key];
                                return filteredState;
                              },{});
    return <Fragment>{this.props.children(_filteredState)}</Fragment>
  }
}