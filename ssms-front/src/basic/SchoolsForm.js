import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Link } from 'react-router-dom'
import { getTranslate } from 'react-localize-redux'
import isAlpha from 'validator/lib/isAlpha'
import isLength from 'validator/lib/isLength'
import isBefore from 'validator/lib/isBefore'
import isNumeric from 'validator/lib/isNumeric'
import moment from 'moment'
import { lookupActions } from '../store/lookup'
import { initDatePicker } from '../helpers'
class SchoolsForm extends Component {

  constructor(props) {
    super(props);
    const { trans } = props;
    // hold form fields values
    this.initValues = {
      'schoolId': 0,
      'schoolName': '',
      'schoolNameEn': '',
      'startDate': new Date(),
      'address': '',
      'comNum': '',
      'isActive': false
    };
    // hold the form fields keys
    this.fieldsKeys = Object.keys(this.initValues);
    // the form state
    this.state = {
      title: "",
      formInvalid: true,
      formSubmitted: false,
      activeLable: '', // to render a label with or without 'active' class
      schoolId: {
        hidden: false,
        disabled: true,
        value: this.initValues['schoolId']
      },
      schoolName: {
        hidden: false,
        disabled: false,
        value: this.initValues['schoolName'],
        touched: false,
        invalid: true,
        error: '',
        validtor: (value) => {
          if(!value)
            return trans("schools.validations.schoolNameAr.required");
          else if(!isAlpha(value, 'ar'))
            return trans("schools.validations.schoolNameAr.alpha");
        }
      },
      schoolNameEn: {
        hidden: false,
        disabled: false,
        value: this.initValues['schoolNameEn'],
        touched: false,
        invalid: false,
        error: '',
        validtor: (value) => {
          if(!value)
            return trans("schools.validations.schoolNameEn.required");
          else if(!isAlpha(value))
            return trans("schools.validations.schoolNameEn.alpha");
        }
      },
      startDate: {
        hidden: false,
        disabled: false,
        value: this.initValues['startDate'],
        touched: false,
        invalid: false,
        error: '',
        validtor: (value) => {
          if(value && !isBefore(moment(value).format('DD/MM/YYYY'), moment().add(1, 'day').format('DD/MM/YYYY') ) )
            return trans("schools.validations.startDate.before");
        }
      },
      address: {
        hidden: false,
        disabled: false,
        value: this.initValues['address'],
        touched: false,
        invalid: false,
        error: '',
        validtor: (value) => {
          if(value && !isLength(value, { min:0, max: 250}))
            return trans("schools.validations.address.length");
        }
      },
      comNum: {
        hidden: false,
        disabled: false,
        value: this.initValues['comNum'],
        touched: false,
        invalid: false,
        error: '',
        validtor: (value) => {
          if(value) {
            if(!isNumeric(value, { no_symbols: true }))
              return trans("schools.validations.comNum.numeric");
            else if( !isLength(value, { min: 0, max: 6 }) )
              return trans("schools.validations.comNum.length");
          }
        }
      },
      isActive: {
        hidden: false,
        disabled: false,
        value: this.initValues['isActive']
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
    };
  }
  // change form inputs [disable-hidden] state based on the form type
  // that comes form form url [new, edit, details]
  setupFormType = (id, url) => {
    const { trans } = this.props;
    if (url.includes('new'))
      this.setState((prevState) => ({
        title: trans("schools.actions.new"),
        activeLabel: '',
        schoolId: {
          ...prevState.schoolId,
          hidden: true,
          disabled: true
        },
        startDate: {
          ...prevState.startDate,
          value: null
        },
        btnUpdate: {
          hidden: true,
          disabled: true
        },
        btnDelete: {
          hidden: true,
          disabled: true
        }
      }));
    else if (url.includes('edit') && id) {
      this.setState((prevState) => ({
        title: trans("schools.actions.update"),
        activeLable: 'active',
        schoolId: {
          ...prevState.schoolId,
          hidden: false,
          disabled: true
        },
        btnAdd: {
          hidden: true,
          disabled: true
        }
      }));
    }
    else if (url.includes('details') && id)
      this.setState((prevState) => ({
        title: trans("schools.actions.detailsTitle"),
        activeLable: 'active',
        schoolId: {
          ...prevState.schoolId,
          hidden: false,
          disabled: true
        },
        schoolName: {
          ...prevState.schoolName,
          hidden: false,
          disabled: true
        },
        schoolNameEn: {
          ...prevState.schoolNameEn,
          hidden: false,
          disabled: true
        },
        startDate: {
          ...prevState.startDate,
          hidden: false,
          disabled: true
        },
        address: {
          ...prevState.address,
          hidden: false,
          disabled: true
        },
        comNum: {
          ...prevState.comNum,
          hidden: false,
          disabled: true
        },
        isActive: {
          ...prevState.isActive,
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
      }));
  };
  // set each form field [value] state
  setFieldValue = (key,value) => {
    this.setState((prevState) => ({
      [key]: {
        ...prevState[key],
        value: value
      }
    }));
  };
  // set each form field [touched] state
  setFieldTouched = (field) => {
    this.setState((prevState) => ({
      [field]: {
        ...prevState[field],
        touched: true
      }
    }));
  };
  // set each form field [touched] state
  setFormSubmitted = () => {
    this.setState({
      formSubmitted: true
    });
  };
  // get the form values from the form state
  getFormValues = () => {
    return this.fieldsKeys.reduce( (acc,item) => {
      acc[item] = this.state[item].value;
      return acc;
    }, {});
  };
  // validate each form input using the validator function exists in [this.state.field]
  validateForm = () => {
    // [flag to show if form has any error]
    let formInvalid = false;
    this.fieldsKeys.forEach(key => {
      const field = this.state[key];
      // do validation
      if(field.validtor) {
        const error = field.validtor(field.value);
        // if any error then set formInvalid => false
        if(error)
          formInvalid = true;
        this.setState( (prevState) => ({
          // set each field (invalid, error)
          [key]: {
            ...prevState[key],
            invalid: !!error,
            error,
          },
          // set formInvalid
          formInvalid
        }) );
      }
    })
  };
  // display the error message
  showError = (field) => {
    return ( (field.touched || this.state.formSubmitted) && field.invalid )
      ? <div className="red-text text-darken-4 valign-wrapper">
          <i class="material-icons">error_outline</i>
          {field.error}
        </div>
      : null
  };
  // reset form state
  resetForm = () => {
    this.fieldsKeys.forEach(key => this.setFieldValue(key,this.initValues[key]) );
    console.log(this.state);
  };
  // map props to form state
  mapPropsToState = (props) => {
    // when the Form in new state then return immediatly
    if (props.match.url.includes('/new'))
      return;
    // when receive schools change lookupEntity based on route id
    if ( props.schoolsCount ) {
      lookupActions.setLookupEntity({
        lookupTable: 'schools',
        lookupKey: 'schoolId',
        id: props.match.params.id
      });
    }
    // when lookupEntity is filled - pass its values to the form State values
    if (props.lookupEntity && Object.keys(props.lookupEntity).length) {
      Object.entries(props.lookupEntity)
        .filter(([key, val]) => key !== 'branches')
        .forEach(([key, val]) => this.setFieldValue(key, (key === 'startDate') ? new Date(val) : val));
    }
  };
  // componentDidMount
  componentDidMount() {
    // extract id, url from routes props
    const { match: { params: { id } }, match: { url } } = this.props;
    // init Materialize datePicker
    const currentYear = (new Date()).getFullYear();
    initDatePicker({
      format: 'dd/mm/yyyy',
      yearRange: [currentYear-70,currentYear+30],
      defaultDate: this.state.startDate.value.toLocaleDateString('en-gb'),
      onSelect: (selectedDate) => {
        this.setFieldValue('startDate',selectedDate);
        this.validateForm();
      }
    });
    // handle the 3 Form Conditions based on routes props
    this.setupFormType(id, url);
    // map the from fields values from props to state
    this.mapPropsToState(this.props);
  }
  // componentWillReceiveProps
  componentWillReceiveProps(nextProps) {
    // extract id, url from routes props
    const { match: { params: { id } }, match: { url } } = nextProps;
    // handle the 3 Form Conditions based on routes props
    this.setupFormType(id, url);
    // map the from fields values from props to state
    this.mapPropsToState(nextProps);
  }
  // addSchool
  addSchool = () => {
    this.setFormSubmitted();
    if(this.state.formInvalid)
      return;
    lookupActions.addLookupEntity( {
      req: ['post','/schools/add?autoId=ok', this.getFormValues()],
      fulfilledToast: ["success","new school added successfully ..."]
    });
    this.resetForm();
  }
  // updateSchool
  updateSchool = () => {
    this.setFormSubmitted();
    if(this.state.formInvalid)
      return;
    lookupActions.updateLookupEntity( {
      req: ['put','/schools/update', this.getFormValues()],
      fulfilledToast: ["success","this school updated successfully ..."]
    });
    this.props.history.push("/schools/list");
  }
  // deleteSchool
  deleteSchool = () => {
    lookupActions.deleteLookupEntity( {
      req: ['post',`/schools/delete?deleteType=physical`, this.getFormValues() ],
      fulfilledToast: ["info","this school deleted successfully ..."]
    });
    this.props.history.push("/schools/list");
  }

  render() {
    const {
      title,
      activeLable,
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
    const { trans } = this.props;
    return (
      <form className="rtl">
        {/* form title */}
        <h4 className="orange-text">{ title }</h4>
        <Link to='/schools/list'>{ trans("schools.backLink") }</Link>
        <div className="divider orange" />
        {/* schoolId */}
        <div className="input-field" hidden={schoolId.hidden}>
          <i className="material-icons prefix">edit</i>
          <input disabled={schoolId.disabled}
                  id="schoolId"
                  type="text"
                  className="validate"
                  value={schoolId.value}
                  onChange={(e)=> {
                    this.setFieldValue('schoolId',e.target.value);
                    this.validateForm();
                  }}
                  onBlur = { () => {
                    this.setFieldTouched('schoolId');
                    this.validateForm();
                  } }
          />
          <label className={activeLable} htmlFor="schoolId">{ trans("schools.fields.schoolId") }</label>
          { this.showError(schoolId) }
        </div>
        {/* schoolName */}
        <div className="input-field" hidden={schoolName.hidden}>
          <i className="material-icons prefix">edit</i>
          <input disabled={schoolName.disabled}
                id="schoolName"
                type="text"
                className="validate"
                value={schoolName.value}
                onChange={(e)=> {
                  this.setFieldValue('schoolName',e.target.value);
                  this.validateForm();
                }}
                onBlur = { () => {
                  this.setFieldTouched('schoolName');
                  this.validateForm();
                } }
          />
          <label className={activeLable} htmlFor="schoolName">{ trans("schools.fields.schoolNameAr") }</label>
          { this.showError(schoolName) }
        </div>
        {/* schoolNameEn */}
        <div className="input-field" hidden={schoolNameEn.hidden}>
          <i className="material-icons prefix">edit</i>
          <input disabled={schoolNameEn.disabled}
                id="schoolNameEn"
                type="text"
                className="validate"
                value={schoolNameEn.value}
                onChange={(e)=> {
                  this.setFieldValue('schoolNameEn',e.target.value);
                  this.validateForm();
                } }
                onBlur = { () => {
                  this.setFieldTouched('schoolNameEn');
                  this.validateForm();
                } }
          />
          <label className={activeLable} htmlFor="schoolNameEn">{ trans("schools.fields.schoolNameEn") }</label>
          { this.showError(schoolNameEn) }
        </div>
        {/* startDate */}
        <div className="input-field" hidden={startDate.hidden}>
          <i className="material-icons prefix">date_range</i>
          <input disabled={startDate.disabled}
                id="startDate"
                type="text"
                className="datepicker"
                value={startDate.value? startDate.value.toLocaleDateString('en-gb') : ''}
                onBlur = { () => {
                  this.setFieldTouched('startDate');
                  this.validateForm();
                } }
          />
          <label className={activeLable} htmlFor="startDate">{ trans("schools.fields.startDate") }</label>
          { this.showError(startDate) }
        </div>
        {/* address */}
        <div className="input-field" hidden={address.hidden}>
          <i className="material-icons prefix">home</i>
          <textarea disabled={address.disabled}
                  id="address"
                  type="text"
                  className="materialize-textarea validate"
                  value={address.value}
                  onChange={(e)=> {
                    this.setFieldValue('address',e.target.value);
                    this.validateForm();
                  }}
                  onBlur = { () => {
                    this.setFieldTouched('address');
                    this.validateForm();
                  } }
          />
          <label className={activeLable} htmlFor="address">{ trans("schools.fields.address") }</label>
          { this.showError(address) }
        </div>
        {/* comNum */}
        <div className="input-field" hidden={comNum.hidden}>
          <i className="material-icons prefix">edit</i>
          <input disabled={comNum.disabled}
                id="comNum"
                type="text"
                className="validate"
                value={comNum.value}
                onChange={(e)=> {
                    this.setFieldValue('comNum',e.target.value);
                    this.validateForm();
                }}
                onBlur = { () => {
                  this.setFieldTouched('comNum');
                  this.validateForm();
                } }
          />
          <label className={activeLable} htmlFor="comNum">{ trans("schools.fields.comNum") }</label>
          { this.showError(comNum) }
        </div>
        {/* isActive */}
        <div className="input-field switch" hidden={isActive.hidden}>
          <i className="material-icons prefix">school</i>
          <div>
            <label className={activeLable}>
              { `${trans("schools.fields.isActive")} ? ${trans("schools.fields.no")}` }
              <input id="isActive"
                    disabled={isActive.disabled}
                    type="checkbox"
                    checked={isActive.value}
                    onChange={(e)=> {
                      this.setFieldValue('isActive',e.target.checked);
                      this.validateForm();
                    }}
                    onBlur = { () => {
                      this.setFieldTouched('isActive');
                      this.validateForm();
                    } }
              />
              <span className="lever" />
              {trans("schools.fields.yes")}
            </label>
          </div>
          { this.showError(isActive) }
        </div>
        {/* Action Buttons */}
        <div className="input-field center">
        <button className="btn waves-effect waves-light primary darken-3"
                type="button"
                id="btnAdd"
                name="btnAdd"
                disabled={btnAdd.disabled}
                hidden={btnAdd.hidden}
                onClick={this.addSchool}
        >
            <i className="material-icons left">add</i>
            { trans("schools.actions.new") }
        </button>
        <button className="btn waves-effect waves-light orange darken-3"
                type="button"
                id="btnUpdate"
                name="btnUpdate"
                disabled={btnUpdate.disabled}
                hidden={btnUpdate.hidden}
                onClick={this.updateSchool}
        >
            <i className="material-icons left">edit</i>
            { trans("schools.actions.update") }
        </button>
        <button className="btn waves-effect waves-light red darken-3"
                type="button"
                id="btnDelete"
                name="btnDelete"
                disabled={btnDelete.disabled}
                hidden={btnDelete.hidden}
                onClick={this.deleteSchool}
        >
            <i className="material-icons left">close</i>
            { trans("schools.actions.remove") }
        </button>
        </div>
      </form>
    )
  }
}
// select the values needed form redux state
const mapStateToProps = (state) => ({
  "schools": state.lookup.schools,
  "schoolsCount": state.lookup.schools.length,
  "lookupEntity": state.lookup.lookupEntity,
  "trans": getTranslate(state.localize)
})
// connect the form with the redux state
export default connect(mapStateToProps)(SchoolsForm);