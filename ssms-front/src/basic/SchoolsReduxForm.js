import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { connect } from 'react-redux'
import { getTranslate } from 'react-localize-redux'
import { Field, reduxForm, change } from 'redux-form'
import isAlpha from 'validator/lib/isAlpha'
import isLength from 'validator/lib/isLength'
import isBefore from 'validator/lib/isBefore'
import isNumeric from 'validator/lib/isNumeric'
import moment from 'moment'
import { store } from '../AppStore'
import { renderInput, renderDatepicker, renderSwitch, Button } from '../shared/FormInputs'
import { lookupActions } from '../store/lookup'
import { initDatePicker, formatDate } from '../helpers'

class _SchoolsReduxForm extends Component {

  constructor(props) {
    super(props);
    // setting the detfault date
    this.defaultDate = new Date();
    // setting the formCase [new - edit - details]
    this.formCase = (props.match.url.includes('new'))
                      ? 'new'
                      : (props.match.url.includes('edit'))
                        ? 'edit'
                        : (props.match.url.includes('details'))
                          ? 'details'
                          : '';
    // define the form state
    this.state = {
      title: '',
      schoolId: {
        hidden: false,
        disabled: true
      },
      schoolName: {
        hidden: false,
        disabled: false
      },
      schoolNameEn: {
        hidden: false,
        disabled: false
      },
      startDate: {
        hidden: false,
        disabled: false
      },
      address: {
        hidden: false,
        disabled: false
      },
      comNum: {
        hidden: false,
        disabled: false
      },
      isActive: {
        hidden: false,
        disabled: false
      },
      btnAdd: {
        hidden: false,
        disabled: false
      },
      btnUpdate: {
        hidden: false,
        disabled: false
      },
      btnDelete: {
        hidden: false,
        disabled: false
      }
    }
  }
  // change form inputs [disable-hidden] state based on form Case [new, edit, details]
  setupFormCase = () => {
    const { trans } = this.props;
    if (this.formCase === 'new')
      this.setState({
        title: trans("schools.actions.new"),
        schoolId: {
          hidden: true,
          disabled: true
        },
        btnUpdate: {
          hidden: true,
          disabled: true
        },
        btnDelete: {
          hidden: true,
          disabled: true
        }
      });
    else if (this.formCase === 'edit') {
      this.setState({
        title: trans("schools.actions.update"),
        schoolId: {
          hidden: false,
          disabled: true
        },
        btnAdd: {
          hidden: true,
          disabled: true
        },
        btnDelete: {
          hidden: true,
          disabled: true
        }
      });
    }
    else if (this.formCase === 'details')
      this.setState({
        title: trans("schools.actions.detailsTitle"),
        schoolId: {
          hidden: false,
          disabled: true
        },
        schoolName: {
          hidden: false,
          disabled: true
        },
        schoolNameEn: {
          hidden: false,
          disabled: true
        },
        startDate: {
          hidden: false,
          disabled: true
        },
        address: {
          hidden: false,
          disabled: true
        },
        comNum: {
          hidden: false,
          disabled: true
        },
        isActive: {
          hidden: false,
          disabled: true
        },
        btnAdd: {
          hidden: true,
          disabled: true
        },
        btnUpdate: {
          hidden: true,
          disabled: true
        },
      });
  };

  componentWillMount() {
    // handle the 3 Form Cases based on route url
    this.setupFormCase();
  }

  componentWillReceiveProps(nextProps) {
    // when the Form in new state then set form initialValues
    if ( !nextProps.match.params.id ) {
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

  doSubmit = (values) => {
    const { reset, history, trans } = this.props;
    // reformate the date string to be suitable to SQL Server [month/day/year]
    values = {...values, startDate: moment(values.startDate).format('DD/MM/YYYY')};
    if (this.formCase === 'new') {
      lookupActions.addLookupEntity( {
        req: ['post','/schools/add?autoId=ok', values ],
        fulfilledToast: ["success","new school added successfully ..."]
      });
      reset();
    }
    else if (this.formCase === 'edit') {
      lookupActions.updateLookupEntity( {
        req: ['put','/schools/update', values ],
        fulfilledToast: ["success","this school updated successfully ..."]
      });
      history.push("/schools/list");
    }
    else if (this.formCase === 'details') {
      if( window.confirm( trans('schools.actions.deleteConfirm') ) ) {
        lookupActions.deleteLookupEntity( {
          req: ['post',`/schools/delete?deleteType=physical`, values ],
          fulfilledToast: ["info","this school deleted successfully ..."]
        });
        history.push("/schools/list");
      }
    }
  }

  render() {
    const { trans, handleSubmit, pristine, submitting } = this.props;
    const {
      title,
      schoolId,
      schoolName,
      schoolNameEn,
      startDate,
      address,
      comNum,
      isActive,
      btnAdd,
      btnUpdate,
      btnDelete
    } = this.state;
    return (
      <form className="rtl" onSubmit={handleSubmit(this.doSubmit)}>
        {/* form title */}
        <h4 className="orange-text">{ title }</h4>
        <Link to='/schools/list'>{ trans("schools.backLink") }</Link>
        <div className="divider orange" />
        {/* schoolId */}
        <Field name="schoolId"
                uiState={schoolId}
                label={trans("schools.fields.schoolId")}
                component={renderInput} />
        {/* schoolName */}
        <Field name="schoolName"
                uiState={schoolName}
                label={trans("schools.fields.schoolNameAr")}
                component={renderInput} />
        {/* schoolNameEn */}
        <Field name="schoolNameEn"
                uiState={schoolNameEn}
                label={trans("schools.fields.schoolNameEn")}
                component={renderInput} />
        {/* startDate */}
        <Field name="startDate"
                uiState={startDate}
                type="datepicker"
                label={trans("schools.fields.startDate")}
                icon="date_range"
                component={renderDatepicker} />
        {/* address */}
        <Field name="address"
                uiState={address}
                type="textarea"
                label={trans("schools.fields.address")}
                component={renderInput} />
        {/* comNum */}
          <Field name="comNum"
                uiState={comNum}
                label={trans("schools.fields.comNum")}
                component={renderInput} />
        {/* isActive */}
        <Field name="isActive"
                uiState={isActive}
                label={trans("schools.fields.isActive")}
                component={renderSwitch} />
        {/* Action Buttons */}
        <div className="input-field center">
          <Button classes="primary darken-3"
                  name="btnAdd"
                  icon="add"
                  label={ trans("schools.actions.new") }
                  hidden={btnAdd.hidden}
                  disabled={btnAdd.disabled || pristine || submitting}
          />
          <Button classes="orange darken-3"
                  name="btnUpdate"
                  icon="edit"
                  label={ trans("schools.actions.update") }
                  hidden={btnUpdate.hidden}
                  disabled={btnUpdate.disabled || pristine || submitting}
          />
          <Button classes="red darken-3"
                  name="btnDelete"
                  icon="close"
                  label={ trans("schools.actions.remove") }
                  hidden={btnDelete.hidden}
                  disabled={btnDelete.disabled}
          />
        </div>
      </form>
    )
  }

  componentDidMount() {
    const { dispatch } = this.props;
    // init Materialize datePicker
    const currentYear = (new Date()).getFullYear();
    initDatePicker({
      format: 'dd/mm/yyyy',
      yearRange: [currentYear-70,currentYear+30],
      defaultDate: this.defaultDate,
      onSelect: (selectedDate) => {
        // set the value individually by calling change action creator from reduxForm
        dispatch(change('schools', 'startDate', selectedDate.toLocaleDateString('en-gb') ));
      }
    });
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
  // startDate with reformate the date string to be suitable to date Validation [month/day/year]
  if( startDate && !isBefore(moment(startDate).format('DD/MM/YYYY'), moment().add(1, 'day').format('MM/DD/YYYY') ) )
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