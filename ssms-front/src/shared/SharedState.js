import React, { Component, Fragment } from 'react'
import axios from 'axios'

export default class SharedState extends Component {
  state = {
    docTypes: [],
    countries: []
  }
  getSignUpParentFormData = () => {
    axios.all([
      axios.get('/DocTypes?filters=docTypeId|<|4&fields=docTypeId,docTypeAr,docTypeEn'),
      axios.get('/Countries?fields=countryId,countryAr,countryEn')
    ])
      .then(axios.spread( (docTypes, countries) => {
        this.setState({
          docTypes: docTypes.data,
          countries: countries.data
        })
      }))
  }
  componentDidMount() {
    this.getSignUpParentFormData();
  }
  render() {
    const _filteredState = this.props.keys.reduce( (filteredState,key) => {
      filteredState[key] = this.state[key] || this[key];
      return filteredState;
    },{});
    return <Fragment>{this.props.children(_filteredState)}</Fragment>
  }
}
