import React, { Component } from 'react'
import MdForm from "../shared/MdForm";
import { connect } from "react-redux";
import { lookupActions } from "../store/lookup";
import { userActions } from '../store/user';

const fields = {
  fName: {
    type: "text",
    label: "fName"
  },
  mName: {
    type: "text",
    label: "mName"
  },
  gName: {
    type: "text",
    label: "gName"
  },
  lName: {
    type: "text",
    label: "lName"
  },
  countries: {
    type: "autocomplete",
    label: "Country",
    options: {}
  },
  mobile: {
    type: "text",
    label: "Mobile"
  },
  idType: {
    type: "radio",
    label: "IdType",
    options: []
  },
  parentId: {
    type: "text",
    label: "ID"
  },
  idExpireDateG: {
    type: "datepicker",
    label: "ID Expire DateG"
  },
  email: {
    type: "email",
    label: "email",
    icon: "account_circle"
  },
  userId: {
    type: "text",
    label: "UserId"
  },
  password: {
    type: "password",
    label: "password",
    icon: "vpn_key"
  },
  countryId: {
    type: "select",
    label: "Country",
    options: []
  },
  submit: {
    type: "button",
    label: "Save"
  }
};
class SignUpParent extends Component {
  componentDidMount() {
    lookupActions.setLookupKeys(['docTypes','countries']);
    // lookupActions.getLookupData(
    //   axiosAll([
    //     axiosOne('get','/DocTypes?filters=docTypeId|<|4&fields=docTypeId,docTypeAr,docTypeEn'),
    //     axiosOne('get','/Countries?fields=countryId,countryAr,countryEn')
    //   ])
    // );
    lookupActions.getLookupData(
    {
      req: [
        ['get','/DocTypes?filters=docTypeId|<|4&fields=docTypeId,docTypeAr,docTypeEn'],
        ['get','/Countries?fields=countryId,countryAr,countryEn']
      ]
    }
    );
  }
  completeFields = () => {
    fields.idType.options = this.props.docTypes.map(item => ({
      text: item.docTypeEn,
      value: item.docTypeId
    }));
    fields.countryId.options = this.props.countries.map(item => ({
      text: item.countryEn,
      value: item.countryId
    }));
    fields.countries.options = this.props.countries.reduce((data, item) => {
      data[item.countryEn] = null;
      return data;
    }, {});
    // pass the axios request to addParent and return the inner function which
    // will be called later by the MdForm and will dispatch [ADD_PARENT] Action
    fields.submit.submitFunc = userActions.addParent({ method: 'post', url: '/Users/Add'});
  }
  render() {
    // console.group(`SignUpParent render @${(new Date()).getFullTime()}`)
    // console.log(this.props)
    // console.groupEnd()
    if(this.props.docTypes.length && this.props.countries.length) {
      this.completeFields();
      return <MdForm {...fields} />
    }
    return null;
  }
}

const mapStateToProps = state => ({
  ...state.lookup
});

export default connect(mapStateToProps)(SignUpParent);