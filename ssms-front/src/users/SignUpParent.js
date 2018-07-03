import React, { Component } from 'react'
import MdForm from '../shared/MdForm'
import axios from 'axios'

const fields = {
  fName: {
    type: 'text',
    label: 'fName'
  },
  mName: {
    type: 'text',
    label: 'mName'
  },
  gName: {
    type: 'text',
    label: 'gName'
  },
  lName: {
    type: 'text',
    label: 'lName'
  },
  mobile: {
    type: 'text',
    label: 'Mobile'
  },
  idType: {
    type: 'radio',
    label: 'IdType',
    options: []
  },
  parentId: {
    type: 'text',
    label: 'ID'
  },
  idExpireDateG: {
    type: 'datepicker',
    label: 'ID Expire DateG'
  },
  email: {
    type: 'email',
    label: 'email',
    icon:'account_circle'
  },
  userId: {
    type: 'text',
    label: 'UserId'
  },
  password: {
    type: 'password',
    label: 'password',
    icon:'vpn_key'
  },
  countryId: {
    type: 'select',
    label: 'Country',
    options: []
  },
  submit: {
    type: 'button',
    label: 'Save',
    className: 'btn-large'
  }
}

export default class SignUpParent extends Component {

  state = {
    form: null
  }

  componentWillMount() {
    axios.all([
      axios.get('/DocTypes?filters=docTypeId|<|4&fields=docTypeId,docTypeAr,docTypeEn'),
      axios.get('/Countries?fields=countryId,countryAr,countryEn')
    ])
      .then(axios.spread( (docTypes, countries) => {
        console.table(docTypes.data);
        console.table(countries.data);
        fields.idType.options = docTypes.data.map(item => ({text: item.DocTypeEn, value: item.DocTypeId}))
        fields.countryId.options = countries.data.map(item => ({text: item.CountryEn, value: item.CountryId}))
        this.setState({
          form: <MdForm {...fields} />
        })
      }))
  }

  render() {
    return this.state.form;
  }
}