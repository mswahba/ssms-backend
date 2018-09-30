import React, { Component } from 'react'
import { connect } from "react-redux"
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import { Field, reduxForm, change } from 'redux-form'
import { renderInput, renderCheck, renderHGDatepicker, renderAutoComplete, Button } from '../shared/FormInputs'
import { lookupActions } from "../store/lookup"
import { userActions } from '../store/user'
import { store } from '../AppStore'
import { initAutoComplete } from '../helpers'

class SignUpParent extends Component {

  constructor(props) {
    super(props);
    this.state = {
      idTypeOptions: [],
      countriesOptions: [], // {}
      countriesSuggestions: []
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

  componentWillReceiveProps(nextProps) {
    const { language } = nextProps;
    const docTypeField = language == 'en'? 'docTypeEn' : 'docTypeAr';
    const countryField = language == 'en'? 'countryEn' : 'countryAr';
    if (nextProps.docTypes.length && nextProps.countries.length) {
      this.setState({
        idTypeOptions: nextProps.docTypes.map(item => ({
          text: item[docTypeField],
          value: item.docTypeId
        })),
        countriesOptions: nextProps.countries.map(country => ({ countryId: country.countryId, [countryField]: country[countryField] }) )
        // countriesOptions: nextProps.countries.reduce((data, item) => {
        //   data[item[countryField]] = item.countryId;
        //   return data;
        // }, {})
      })
    }
  }

  setDates = (values) => {
    const { dispatch } = this.props;
    dispatch(change('signUpParent', 'idExpireDate', values ));
  }

  doAutoComplete = ({ query }) => {
    console.log('TCL: ---------------------------------------------------');
    console.log('TCL: SignUpParent -> doAutoComplete -> query', query);
    console.log('TCL: ---------------------------------------------------');
    const { countriesOptions } = this.state;
    console.log('TCL: -------------------------------------------------------------------------');
    console.log('TCL: SignUpParent -> doAutoComplete -> countriesOptions', countriesOptions);
    console.log('TCL: -------------------------------------------------------------------------');
    const { language } = this.props;
    const countryField = language == 'en'? 'countryEn' : 'countryAr';
    if(countriesOptions.length) {
      const results = countriesOptions.filter( country => country[countryField].includes(query) );
      this.setState({ countriesSuggestions: results });
    }
  }

  onAutocomplete = ({ value }) => {
    console.log('TCL: ---------------------------------------------------');
    console.log('TCL: SignUpParent -> onAutocomplete -> value', value);
    console.log('TCL: ---------------------------------------------------');
    const { dispatch, language } = this.props;
    const countryField = language == 'en'? 'countryEn' : 'countryAr';
    dispatch(change('signUpParent', countryField, value ));
  }

  render() {
    const { trans, handleSubmit, pristine, submitting, language } = this.props;
    const { idTypeOptions, countriesSuggestions } = this.state;
    const countryField = language == 'en'? 'countryEn' : 'countryAr';
    return (
      <form className="rtl" onSubmit={handleSubmit( userActions.addParent({ method: 'post', url: '/Users/Add'}) )}>
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
      {/* <Field name={countryField}
              label={trans("users.signUpParent.fields.countryId")}
              suggestions={countriesSuggestions}
              completeMethod={this.doAutoComplete}
              onChange={this.onAutocomplete}
              options={ { field: countryField, dropdown: true } }
              component={renderAutoComplete} /> */}
      {/* <Field name="countryId"
              type="autocomplete"
              label={trans("users.signUpParent.fields.countryId")}
              component={renderInput} /> */}
      {/* idType */}
      <Field name="idType"
              type="radio"
              options={idTypeOptions}
              labelClassName="active"
              itemsClassName="validate check-options"
              label={trans("users.signUpParent.fields.idType")}
              component={renderCheck} />
      {/* parentId */}
      <Field name="parentId"
              label={trans("users.signUpParent.fields.parentId")}
              component={renderInput} />
      {/* idExpireDate */}
      <Field name="idExpireDate"
              label={trans("users.signUpParent.fields.idExpireDate")}
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
              component={renderInput} />
      {/* password */}
      <Field name="password"
              type="password"
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

  componentDidUpdate(prevState) {
    const { countriesOptions } = this.state;
    const { dispatch } = this.props;
    if(this.initAutoComplete) {
      // init the autocomplete materialize control
      initAutoComplete({
        'countryId': {
          data: countriesOptions,
          onAutocomplete: (selectedCountry) => {
            const selectedCountryId = this.state.countriesOptions[selectedCountry];
            dispatch(change('signUpParent', 'countryId', selectedCountryId ));
          }
        }
      });
      this.initAutoComplete = false;
    }
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
  "trans": getTranslate(state.localize),
  "language": getActiveLanguage(state.localize).code
});

export default connect(mapStateToProps)(_SignUpParent);