import React, { Component } from "react";
import { connect } from "react-redux";
import { lookupActions, lookupActionTypes } from "../store/lookup";
import { axiosOne } from '../axios';
import M from "materialize-css";

class SchoolsForm extends Component {

  state = {
    title: "Add New School",
    schoolId: {
      hidden: false,
      disabled: true,
      value: ''
    },
    schoolName: {
      hidden: false,
      disabled: false,
      value: ''
    },
    schoolNameEn: {
      hidden: false,
      disabled: false,
      value: ''
    },
    startDate: {
      hidden: false,
      disabled: false,
      value: ''
    },
    address: {
      hidden: false,
      disabled: false,
      value: ''
    },
    comNum: {
      hidden: false,
      disabled: false,
      value: ''
    },
    isActive: {
      hidden: false,
      disabled: false,
      value: false
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

  initDatePicker = () => {
    const currentYear = (new Date()).getFullYear();
    const pickers = document.querySelector(".datepicker");
    const options = {
      format: 'dd/mm/yyyy',
      yearRange: [currentYear-70,currentYear],
      onSelect: (selectedDate) => {
        this.setFieldValue('startDate',selectedDate);
      }
    }
    M.Datepicker.init(pickers, options);
  };

  setupFormType = (id, url) => {
    if (url.includes('edit') && id) {
      this.setState((prevState) => ({
        title: "Edit this School",
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
    else if (url.includes('new'))
      this.setState((prevState) => ({
        title: "Add New School",
        schoolId: {
          ...prevState.schoolId,
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
      }));
    else if (url.includes('details'))
      this.setState((prevState) => ({
        title: "view School Details",
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

  setFieldValue = (field,value) => {
    this.setState((prevState) => ({
      [field]: {
        ...prevState[field],
        value: value
      }
    }));
  };

  componentDidMount() {
    // extract id, url from routes props
    const { match: { params: { id } }, match: { url } } = this.props;
    // init Materialize datePicker
    this.initDatePicker();
    // handle the 3 Form Conditions based on routes props
    this.setupFormType(id, url);
  }

  addSchool = () => {
    console.log(this.state);
  }

  getFormInputs = (input) => {
    const { match: { url } } = this.props;
    if (input[0] === 'address') {
      return (url.includes('/edit') || url.includes('/details'))
        ? <textarea disabled={input[1].disabled}
              id={input[0]}
              type="text"
              className="materialize-textarea validate"
              placeholder=""
              value={input[2]}
              onChange={(e)=> {
                this.setFieldValue(input[0],e.target.value);
              }}
          />
        : <textarea disabled={input[1].disabled}
              id={input[0]}
              type="text"
              className="materialize-textarea validate"
              value={input[2]}
              onChange={(e)=> {
                this.setFieldValue(input[0],e.target.value);
              }}
          />     
    } else if (input[0] === 'isActive') {
      return (url.includes('/edit') || url.includes('/details')) 
        ? <input disabled={input[1].disabled}
              id={input[0]}
              type="text"
              className="validate"
              placeholder=""
              checked={input[2]}
              onChange={(e)=> {
                this.setFieldValue(input[0],e.target.value);
              }}
          />
        : <input disabled={input[1].disabled}
              id={input[0]}
              type="text"
              className="validate"
              checked={input[2]}
              onChange={(e)=> {
                this.setFieldValue(input[0],e.target.value);
              }}
          /> 
    }
    return (url.includes('/edit') || url.includes('/details'))
      ? <input disabled={input[1].disabled}
            id={input[0]}
            type="text"
            className="validate"
            placeholder=""
            value={input[2]}
            onChange={(e) => {
              this.setFieldValue(input[0], e.target.value);
            }}
      />
      : <input disabled={input[1].disabled}
            id={input[0]}
            type="text"
            className="validate"
            value={input[2]}
            onChange={(e) => {
              this.setFieldValue(input[0], e.target.value);
            }}
      />
  }

  render() {
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

    const {
      schoolId: _schoolId,
      schoolName: _schoolName,
      schoolNameEn: _schoolNameEn,
      startDate: _startDate,
      address: _address,
      comNum: _comNum,
      isActive: _isActive
    } = this.props.lookupEntity;

    return (
      <form>
        {/* form title */}
        <h3 className="orange-text">{title}</h3>
        <div className="divider orange" />
        {/* schoolId */}
        <div className="input-field" hidden={schoolId.hidden}>
          <i className="material-icons prefix">edit</i>
          { this.getFormInputs(["schoolId", schoolId , _schoolId]) }
          <label htmlFor="schoolId">School Number</label>
        </div>
        {/* schoolName */}
        <div className="input-field" hidden={schoolName.hidden}>
          <i className="material-icons prefix">edit</i>
          { this.getFormInputs(["schoolName", schoolName , _schoolName]) }
          <label htmlFor="schoolName">School Name [Arabic] </label>
        </div>
        {/* schoolNameEn */}
        <div className="input-field" hidden={schoolNameEn.hidden}>
          <i className="material-icons prefix">edit</i>
          { this.getFormInputs(["schoolNameEn", schoolNameEn , _schoolNameEn]) }
          <label htmlFor="schoolNameEn">School Name [English] </label>
        </div>
        {/* startDate */}
        <div className="input-field" hidden={startDate.hidden}>
          <i className="material-icons prefix">date_range</i>
          <input disabled={startDate.disabled}
                id="startDate"
                type="text"
                className="datepicker"
                value={new Date(_startDate).toLocaleDateString('en-gb')}
          />
          <label htmlFor="startDate">Start Date </label>
        </div>
        {/* address */}
        <div className="input-field" hidden={address.hidden}>
          <i className="material-icons prefix">home</i>
          { this.getFormInputs(["address", address , _address]) }
          <label htmlFor="address">Address </label>
        </div>
        {/* comNum */}
        <div className="input-field" hidden={comNum.hidden}>
          <i className="material-icons prefix">edit</i>
          { this.getFormInputs(["comNum", comNum , _comNum]) }
          <label htmlFor="comNum">Commercial Number</label>
        </div>
        {/* isActive */}
        <div className="input-field switch" hidden={isActive.hidden}>
          <i className="material-icons prefix">school</i>
          <div id="isActive">
            <label>
              Activate School? No
              { this.getFormInputs(["isActive", isActive , _isActive]) }
              <span className="lever" />
              Yes
            </label>
          </div>
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
            Add New School
        </button>
        <button className="btn waves-effect waves-light orange darken-3"
                type="button"
                id="btnUpdate"
                name="btnUpdate"
                disabled={btnUpdate.disabled}
                hidden={btnUpdate.hidden}>
            <i className="material-icons left">edit</i>
            Update School
        </button>
        <button className="btn waves-effect waves-light red darken-3"
                type="button"
                id="btnDelete"
                name="btnDelete"
                disabled={btnDelete.disabled}
                hidden={btnDelete.hidden}>
            <i className="material-icons left">close</i>
            Delete School
        </button>
        </div>
      </form>
    )
  }
}

const mapStateToProps = (state, ownProps) => {
  if( ownProps &&
      state.lookup.schools.length &&
      Object.keys(state.lookup.lookupEntity).length === 0) {
    lookupActions.setLookupEntity({
      lookupTable: 'schools',
      lookupKey: 'schoolId',
      id: ownProps.match.params.id
    })
  }
  return {
    ...state.lookup
  }
}

export default connect(mapStateToProps)(SchoolsForm)