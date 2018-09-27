import React, { Component } from 'react'
import { connect } from "react-redux"
import { getTranslate } from 'react-localize-redux'
import { Field, reduxForm } from 'redux-form'
import { renderInput, renderCheck, Button } from '../shared/FormInputs'
import { lookupActions } from "../store/lookup"
import { store } from '../AppStore'
import { userActions } from '../store/user'

// const fields = {
//   fName: {
//     type: "text",
//     label: "fName"
//   },
//   mName: {
//     type: "text",
//     label: "mName"
//   },
//   gName: {
//     type: "text",
//     label: "gName"
//   },
//   lName: {
//     type: "text",
//     label: "lName"
//   },
//   countries: {
//     type: "autocomplete",
//     label: "Country",
//     options: {}
//   },
//   mobile: {
//     type: "text",
//     label: "Mobile"
//   },
//   idType: {
//     type: "radio",
//     label: "IdType",
//     options: []
//   },
//   parentId: {
//     type: "text",
//     label: "ID"
//   },
//   idExpireDateG: {
//     type: "datepicker",
//     label: "ID Expire DateG"
//   },
//   email: {
//     type: "email",
//     label: "email",
//     icon: "account_circle"
//   },
//   userId: {
//     type: "text",
//     label: "UserId"
//   },
//   password: {
//     type: "password",
//     label: "password",
//     icon: "vpn_key"
//   },
//   submit: {
//     type: "button",
//     label: "Save"
//   }
// };
class SignUpParent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      idTypeOptions: [],
      countriesOptions: {}
    }
    lookupActions.setSelectedTables(['docTypes','countries']);
    lookupActions.getLookupData(
    {
      req: [
        ['get','/DocTypes?filters=docTypeId|<|4&fields=docTypeId,docTypeAr,docTypeEn'],
        ['get','/Countries?fields=countryId,countryAr,countryEn']
      ]
    }
    );
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.docTypes.length && nextProps.countries.length) {
      this.setState({
        idTypeOptions: nextProps.docTypes.map(item => ({
          text: item.docTypeEn,
          value: item.docTypeId
        })),
        countriesOptions: nextProps.countries.reduce((data, item) => {
          data[item.countryEn] = null;
          return data;
        }, {})
      })
    }
  }
  // completeFields = () => {
  //   fields.idType.options = this.props.docTypes.map(item => ({
  //     text: item.docTypeEn,
  //     value: item.docTypeId
  //   }));
  //   fields.countries.options = this.props.countries.reduce((data, item) => {
  //     data[item.countryEn] = null;
  //     return data;
  //   }, {});
  //   // pass the axios request to addParent and return the inner function which
  //   // will be called later by the MdForm and will dispatch [ADD_PARENT] Action
  //   fields.submit.submitFunc = userActions.addParent({ method: 'post', url: '/Users/Add'});
  // }
  render() {
    const { trans, handleSubmit, pristine, submitting } = this.props;
    const { idTypeOptions, countriesOptions } = this.state;
    return (
      <form className="rtl" onSubmit={handleSubmit}>
      {/* form title */}
      <h4 className="orange-text">{ trans("users.signUpParent.title") }</h4>
      <div className="divider orange" />
      {/* fName */}
      <Field name="fName"
              label={trans("users.signUpParent.fields.fName")}
              component={renderInput} />
      {/* mName */}
      <Field name="mName"
              label={trans("users.signUpParent.fields.mName")}
              component={renderInput} />
      {/* gName */}
      <Field name="gName"
              label={trans("users.signUpParent.fields.gName")}
              component={renderInput} />
      {/* lName */}
      <Field name="lName"
              label={trans("users.signUpParent.fields.lName")}
              component={renderInput} />
      {/* countries */}
      <Field name="countries"
              type="autocomplete"
              options={countriesOptions}
              label={trans("users.signUpParent.fields.countries")}
              component={renderInput} />
      {/* countries */}
      <Field name="idType"
              type="radio"
              options={idTypeOptions}
              label={trans("users.signUpParent.fields.idType")}
              component={renderCheck} />
      {/* parentId */}
      <Field name="parentId"
              label={trans("users.signUpParent.fields.parentId")}
              component={renderInput} />
      <Field name="idExpireDateG"
              label={trans("users.signUpParent.fields.idExpireDateG")}
              component={renderInput} />
      {/* mobile */}
      <Field name="mobile"
              label={trans("users.signUpParent.fields.mobile")}
              component={renderInput} />
      {/* email */}
      <Field name="email"
              label={trans("users.signUpParent.fields.email")}
              component={renderInput} />
      {/* userId */}
      <Field name="userId"
              label={trans("users.signUpParent.fields.userId")}
              component={renderInput} />
      {/* password */}
      <Field name="password"
              icon="vpn_key"
              label={trans("users.signUpParent.fields.password")}
              component={renderInput} />
      {/* Action Button */}
      <Button classes="primary darken-3"
                name="signUpParentBtn"
                icon="send"
                label={ trans("users.signUpParent.fields.btn") }
                disabled={pristine || submitting}
      />
    </form>
    )
  }
}

const validate = () => {

}

// define the redux form
const _SignUpParent = reduxForm({
  form: 'signUpParent',
  enableReinitialize: true,
  validate
})(SignUpParent);

const mapStateToProps = state => ({
  "docTypes": state.lookup.docTypes,
  "countries": state.lookup.countries,
  "trans": getTranslate(state.localize)
});

export default connect(mapStateToProps)(_SignUpParent);