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
  SignUpParentFormSubmit = (entity) => {
    // reshapping and adjustment entity
    console.log(entity);
    const user = {
      userId: entity.parentId,
      userPassword: entity.password,
      userTypeId: 3,
      _parent: {
        parentId: entity.parentId,
        fName: entity.fName,
        mName: entity.mName,
        gName: entity.gName,
        lName: entity.lName,
        idType: entity.idType,
        idExpireDateG: entity.idExpireDateG,
        mobile1: entity.mobile,
        email: entity.email,
        countryId: entity.countryId
      }
    };
    console.log(user);
    axios.post("/Users/Add", user)
          .then(res => {
            console.log(res);
            console.log(res.data);
          })
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
