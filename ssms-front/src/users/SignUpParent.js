import React from 'react'
import MdForm from '../shared/MdForm'
import SharedState from '../shared/SharedState'

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
  countries: {
    type: 'autocomplete',
    label: 'Country',
    options: {}
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
    label: 'Save'
  }
}

export default () => (
  <SharedState keys={ ['docTypes','countries', 'SignUpParentFormSubmit'] }>
    {
      ({ docTypes, countries, SignUpParentFormSubmit }) => {
        fields.idType.options = docTypes.map(item => ({text: item.docTypeEn, value: item.docTypeId}))
        fields.countryId.options = countries.map(item => ({text: item.countryEn, value: item.countryId}))
        fields.countries.options = countries.reduce( (data, item) => {
          data[item.CountryEn] = null;
          return data;
        }, {});
        fields.submit.submitFunc = SignUpParentFormSubmit;
        return (docTypes.length && countries.length)
                ? <MdForm {...fields} />
                : null
      }
    }
  </SharedState>
)