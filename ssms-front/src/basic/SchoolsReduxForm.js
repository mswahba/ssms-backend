import React, { Component } from 'react'
import { connect } from 'react-redux'
import { getTranslate } from 'react-localize-redux'
import { Field, reduxForm } from 'redux-form'
import isAlpha from 'validator/lib/isAlpha'
import isLength from 'validator/lib/isLength'
import isBefore from 'validator/lib/isBefore'
import isNumeric from 'validator/lib/isNumeric'
import moment from 'moment'
import { store } from '../AppStore'
import { renderInput, renderDatepicker, renderSwitch } from '../shared/FormInputs'
import { lookupActions } from '../store/lookup'
import { initDatePicker, formatDate } from '../helpers'

class _SchoolsReduxForm extends Component {
  constructor(props) {
    super(props);
    this.defaultDate = (new Date()).toLocaleDateString('en-gb');
  }

  componentWillReceiveProps(nextProps) {
    // when the Form in new state then set form initialValues
    if ( !Object.keys(nextProps.match.params).includes('id') ) {
      // dispatch set lookup entity to fill it with form defaut values
      lookupActions.setLookupEntity({
        'schoolId': 0,
        'schoolName': '',
        'schoolNameEn': '',
        'startDate': this.defaultDate,
        'address': '',
        'comNum': '',
        'isActive': false
      });
    }
    // when receive schools change lookupEntity based on route id
    else if (
        ( nextProps.schoolsCount && !nextProps.initialValues.schoolId ) ||
        ( nextProps.schoolsCount && nextProps.initialValues.schoolId != nextProps.match.params.id )
       ) {
      lookupActions.setLookupEntity({
        lookupTable: 'schools',
        lookupKey: 'schoolId',
        id: nextProps.match.params.id
      });
    }
  }

  componentDidMount() {
    // init Materialize datePicker
    const currentYear = (new Date()).getFullYear();
    initDatePicker({
      format: 'dd/mm/yyyy',
      yearRange: [currentYear-70,currentYear+30],
      defaultDate: this.defaultDate,
      onSelect: (selectedDate) => {
        console.log(selectedDate);
        console.log(selectedDate.toLocaleDateString('en-us'));
        this.setFieldValue('startDate',selectedDate);
      }
    });
  }

  render() {
    const { handleSubmit, trans } = this.props;
    return (
      <form className="rtl" onSubmit={handleSubmit(console.log)}>
        <div>
          <Field name="schoolId"
                label={trans("schools.fields.schoolId")}
                component={renderInput} />
        </div>
        <div>
          <Field name="schoolName"
                label={trans("schools.fields.schoolNameAr")}
                component={renderInput} />
        </div>
        <div>
          <Field name="schoolNameEn"
                label={trans("schools.fields.schoolNameEn")}
                component={renderInput} />
        </div>
        <div>
          <Field name="startDate"
                type="datepicker"
                label={trans("schools.fields.startDate")}
                icon="date_range"
                component={renderDatepicker} />
        </div>
        <div>
          <Field name="address"
                type="textarea"
                label={trans("schools.fields.address")}
                component={renderInput} />
        </div>
        <div>
          <Field name="comNum"
                label={trans("schools.fields.comNum")}
                component={renderInput} />
        </div>
        <div>
          <Field name="isActive"
                label={trans("schools.fields.isActive")}
                component={renderSwitch} />
        </div>
        <button type="submit">Submit</button>
      </form>
    )
  }
}

const validate = ({ schoolName, schoolNameEn, startDate, address, comNum }) => {
  const trans = getTranslate(store.getState().localize);
  const errors = {};
  // schoolName
  if (!schoolName)
    errors.schoolName = trans("schools.validations.schoolNameAr.required");
  else if (!isAlpha(schoolName, 'ar'))
    errors.schoolName = trans("schools.validations.schoolNameAr.alpha");
  // schoolNameEn
  if (!schoolNameEn)
    errors.schoolNameEn = trans("schools.validations.schoolNameEn.required");
  else if (!isAlpha(schoolNameEn))
    errors.schoolNameEn = trans("schools.validations.schoolNameEn.alpha");
  // startDate
  if( startDate && !isBefore(moment(startDate).format('MM/DD/YYYY'), moment().add(1, 'day').format('MM/DD/YYYY') ) )
    errors.startDate = trans("schools.validations.startDate.before");
  // address
  if(address && !isLength(address, { min:0, max: 250}))
    errors.address = trans("schools.validations.address.length");
  // comNum
  if(comNum) {
    if(!isNumeric(comNum, { no_symbols: true }))
      errors.comNum = trans("schools.validations.comNum.numeric");
    else if( !isLength(comNum, { min: 0, max: 6 }) )
      errors.comNum = trans("schools.validations.comNum.length");
  }
  return errors;
}
// define the redux form
const SchoolsReduxForm = reduxForm({
  form: 'schools',
  enableReinitialize: true,
  validate
})(_SchoolsReduxForm);
// select the values needed form redux state
const mapStateToProps = (state) => ({
  "schools": state.lookup.schools,
  "schoolsCount": state.lookup.schools.length,
  "initialValues": formatDate('startDate')(state.lookup.lookupEntity),
  "trans": getTranslate(state.localize)
})
// connect the form with the redux state
export default connect(mapStateToProps)(SchoolsReduxForm);