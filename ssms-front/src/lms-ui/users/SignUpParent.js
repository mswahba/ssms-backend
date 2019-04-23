import React, { Component } from 'react'
import { connect } from "react-redux"
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import { Field, reduxForm, change } from 'redux-form'
import { renderInput, renderCheck, renderHGDatepicker, renderAutoComplete, Button } from '../../shared/FormInputs'
import { lookupActions } from '../../store/lookup'
import { userActions } from '../../store/user'
import { store } from '../../AppStore'
import isLength from 'validator/lib/isLength'
import isAfter from 'validator/lib/isAfter'
import isNumeric from 'validator/lib/isNumeric'

// #region local variables
const initialValues = {
  fName: '',
  mName: '',
  gName: '',
  lName: '',
  countryId: null,
  idType: '',
  parentId: '',
  idExpireDate: {idExpireDateG: '', idExpireDateH: ''},
  mobile: '',
  email: '',
  userId: '',
  password: '',
}
const formName = "signUpParent";
// #endregion

// #region The SignUpParent Form Component
class SignUpParent extends Component {
  // init state - get lookup data [docTypes, countries]
  constructor(props) {
    super(props);
    this.state = {
      idTypeOptions: [],
      countriesOptions: []
    }
    this.initAutoComplete = true;
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
  // set displayField of [docTypes, countries] based on activeLanguage and
  // map each array of [docTypes, countries] from string to object with [text/label - value]
  componentWillReceiveProps(nextProps) {
    const { trans } = nextProps;
    if (nextProps.docTypes.length && nextProps.countries.length) {
      this.setState({
        idTypeOptions: nextProps.docTypes.map(item => ({
          text: item[trans("users.signUpParent.docTypeField")],
          value: item.docTypeId
        })),
        countriesOptions: nextProps.countries.map(country => ({
          label: country[trans("users.signUpParent.countryField")],
          value: country.countryId
        }))
      })
    }
  }
  // manually set idExpireDate field values [idExpireDateG - idExpireDateH]
  setDates = (values) => {
    this.props.dispatch(change('signUpParent', 'idExpireDate', values ));
  }
  // onChange : (event, newValue, previousValue, name) to manually set UserId field value
  setUserId = (e, value) => {
    this.props.dispatch(change('signUpParent', 'userId', value ));
  }
  // render
  render() {
    const { idTypeOptions, countriesOptions } = this.state;
    const { trans, handleSubmit, pristine, submitting } = this.props;
    return (
      <form className="rtl" onSubmit={handleSubmit(userActions.addParent({ method: 'post', url: '/Users/Add' }))}>
        {/* form title */}
        <h4 className="orange-text">{trans("users.signUpParent.title")}</h4>
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
        <Field name="countryId"
          formName={formName}
          label={trans("users.signUpParent.fields.countryId")}
          className="validate autocompelete-select"
          settings={{ isClearable: true }}
          options={countriesOptions}
          component={renderAutoComplete} />
        {/* idType */}
        <Field formName={formName}
          name="idType"
          type="radio"
          options={idTypeOptions}
          labelClassName="active"
          itemsClassName="validate check-options"
          inputClassName="with-gap"
          label={trans("users.signUpParent.fields.idType")}
          component={renderCheck} />
        {/* parentId */}
        <Field name="parentId"
          label={trans("users.signUpParent.fields.parentId")}
          onChange={this.setUserId}
          component={renderInput} />
        {/* idExpireDate */}
        <Field name="idExpireDate"
          HLabel={trans("users.signUpParent.fields.idExpireDateH")}
          GLabel={trans("users.signUpParent.fields.idExpireDateG")}
          HKey="idExpireDateH"
          GKey="idExpireDateG"
          onSelect={this.setDates}
          component={renderHGDatepicker} />
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
          uiState={ { disabled: true } }
          component={renderInput} />
        {/* password */}
        <Field name="password"
          type="password"
          icon="vpn_key"
          label={trans("users.signUpParent.fields.password")}
          component={renderInput} />
        {/* Confirm password */}
        <Field name="passwordConfirm"
          type="password"
          icon="vpn_key"
          label={trans("users.signUpParent.fields.passwordConfirm")}
          component={renderInput} />
        {/* Action Button */}
        <Button classes="primary darken-3"
          name="signUpParentBtn"
          icon="send"
          label={trans("users.signUpParent.fields.btn")}
          disabled={pristine || submitting}
        />
      </form>
    )
  }
}
// #endregion

// #region The each field validate function
const validateFields = {
  fName: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.fName.required");
    else if (!value.alpha('ar') )
      return trans("users.signUpParent.validations.fName.alpha");
    else if (!isLength(value, { min:2, max: 20}))
      return trans("users.signUpParent.validations.fName.length");
  },
  mName: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.mName.required");
    else if (!value.alpha('ar'))
      return trans("users.signUpParent.validations.mName.alpha");
    else if (!isLength(value, { min:2, max: 20}))
      return trans("users.signUpParent.validations.mName.length");
  },
  gName: (trans, value) => {
    if(value) {
      if (!value.alpha('ar'))
        return trans("users.signUpParent.validations.gName.alpha");
      else if (!isLength(value, { min:2, max: 20}))
        return trans("users.signUpParent.validations.gName.length");
    }
  },
  lName: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.lName.required");
    else if (!value.alpha('ar'))
      return trans("users.signUpParent.validations.lName.alpha");
    else if (!isLength(value, { min:2, max: 20}))
      return trans("users.signUpParent.validations.lName.length");
  },
  countryId: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.countryId.required");
  },
  idType: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.idType.required");
  },
  parentId: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.parentId.required");
    else if (!isLength(value, { min:4, max: 10}))
      return trans("users.signUpParent.validations.parentId.length");
  },
  idExpireDate: (trans, { idExpireDateG }) => {
    const dateValue = (new Date(idExpireDateG)).toLocaleDateString();
    const today = (new Date()).toLocaleDateString();
    if( idExpireDateG && !isAfter(dateValue, today) )
      return trans("users.signUpParent.validations.idExpireDate.after");
  },
  mobile: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.mobile.required");
    else if (!isNumeric(value, { no_symbols: true }))
      return trans("users.signUpParent.validations.mobile.numeric");
    else if (!isLength(value, { min:4, max: 15}))
      return trans("users.signUpParent.validations.mobile.length");
  },
  email: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.email.required");
  },
  password: (trans, value) => {
    if(!value)
      return trans("users.signUpParent.validations.password.required");
    else if (!isLength(value, { min:6, max: 25}))
      return trans("users.signUpParent.validations.password.length");
  },
  passwordConfirm: (trans, value, confirmed) => {
    if(!value)
      return trans("users.signUpParent.validations.passwordConfirm.required");
    else if(value !== confirmed)
      return trans("users.signUpParent.validations.passwordConfirm.matched");
  }
}
// #endregion

// #region The Form validate function
const validate = (values) => {
  const trans = getTranslate(store.getState().localize);
  return Object.keys(validateFields).reduce( (errors, key) => {
    if(key === 'passwordConfirm')
      errors[key] = validateFields[key](trans, values[key], values.password)
    else
      errors[key] = validateFields[key](trans, values[key])
    return errors;
  }, {})
};
// #endregion

// #region define the redux form
const _SignUpParent = reduxForm({
  form: formName,
  enableReinitialize: true,
  validate
})(SignUpParent);
// #endregion

// #region map Redux State To Props
const mapStateToProps = state => ({
  "docTypes": state.lookup.docTypes,
  "countries": state.lookup.countries,
  "initialValues": initialValues,
  "trans": getTranslate(state.localize),
  "language": getActiveLanguage(state.localize).code
});
// #endregion

// exported component
export default connect(mapStateToProps)(_SignUpParent);