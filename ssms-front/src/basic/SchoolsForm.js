import React, { Component } from "react";
import { connect } from "react-redux";
import { lookupActions } from "../store/lookup";
import { initDatePicker } from '../helpers';
import { Link } from 'react-router-dom';

class SchoolsForm extends Component {

  placeholder = {};

  state = {
    title: "Add New School",
    schoolId: {
      hidden: false,
      disabled: true,
      value: 0
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
      value: new Date()
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

  getFormValues = () => {
    return Object.entries(this.state).reduce( (acc,item) => {
      if( ["title","btnAdd","btnUpdate","btnDelete"].includes(item[0]) )
        return acc;
      acc[item[0]] = item[1].value;
      return acc;
    }, {});
  }

  componentDidMount() {
    // extract id, url from routes props
    const { match: { params: { id } }, match: { url } } = this.props;
    // add empty placeholder on each input on edit OR details
    if(url.includes('/edit') || url.includes('/details'))
      this.placeholder = { placeholder: "" }
    // init Materialize datePicker
    const currentYear = (new Date()).getFullYear();
    initDatePicker({
      format: 'dd/mm/yyyy',
      yearRange: [currentYear-70,currentYear+30],
      defaultDate: this.state.startDate.value.toLocaleDateString('en-gb'),
      onSelect: (selectedDate) => this.setFieldValue('startDate',selectedDate)
    });
    // handle the 3 Form Conditions based on routes props
    this.setupFormType(id, url);
    // set the selected table which will be used in ADD,UPDATE,DELETE Actions
    lookupActions.setSelectedTable({ name: 'schools', key: 'schoolId'});
  }

  componentWillReceiveProps(newProps) {
    // extract id, url from routes props
    const { match: { url } } = this.props;
    // when the Form in new state then return immediatly
    if (url.includes('/new'))
      return;
    // when receive schools but lookupEntity is empty - then fill it
    if( newProps.schools.length && newProps.lookupEntity && Object.keys(newProps.lookupEntity).length === 0) {
      lookupActions.setLookupEntity({
        lookupTable: 'schools',
        lookupKey: 'schoolId',
        id: newProps.match.params.id
      })
    }
    // when lookupEntity is filled - pass its values to the form State values
    if(newProps.lookupEntity && Object.keys(newProps.lookupEntity).length) {
      Object.entries(newProps.lookupEntity)
            .filter(([key,val]) => key !== 'branches')
            .forEach(([key,val]) => this.setFieldValue(key,(key === 'startDate')? new Date(val) : val) );
    }
  }

  addSchool = () => {
    lookupActions.addLookupEntity( { req: ['post','/schools/add?autoId=ok', this.getFormValues()]} );
    this.props.history.push("/schools/list");
  }
  updateSchool = () => {
    lookupActions.updateLookupEntity( { req: ['put','/schools/update', this.getFormValues()]} );
    this.props.history.push("/schools/list");
  }
  deleteSchool = () => {
    lookupActions.deleteLookupEntity( { req: ['post',`/schools/delete?deleteType=physical`, this.getFormValues() ]} );
    this.props.history.push("/schools/list");
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

    return (
      <form>
        {/* form title */}
        <h4 className="orange-text">{title}</h4>
        <div className="divider orange" />
        <Link to='/schools/list'>Back To List</Link>
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
                  }}
                  {...this.placeholder}
          />
          <label htmlFor="schoolId">School Number</label>
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
                }}
                {...this.placeholder}
          />
          <label htmlFor="schoolName">School Name [Arabic] </label>
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
                }}
                {...this.placeholder}
          />
          <label htmlFor="schoolNameEn">School Name [English] </label>
        </div>
        {/* startDate */}
        <div className="input-field" hidden={startDate.hidden}>
          <i className="material-icons prefix">date_range</i>
          <input disabled={startDate.disabled}
                id="startDate"
                type="text"
                className="datepicker"
          />
          <label htmlFor="startDate">Start Date </label>
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
                  }}
                  {...this.placeholder}
          />
          <label htmlFor="address">Address </label>
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
                }}
                {...this.placeholder}
          />
          <label htmlFor="comNum">Commercial Number</label>
        </div>
        {/* isActive */}
        <div className="input-field switch" hidden={isActive.hidden}>
          <i className="material-icons prefix">school</i>
          <div id="isActive">
            <label>
              Activate School? No
              <input disabled={isActive.disabled}
                    type="checkbox"
                    checked={isActive.value}
                    onChange={(e)=> {
                      this.setFieldValue('isActive',e.target.checked);
                    }}
                    {...this.placeholder}
              />
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
                hidden={btnUpdate.hidden}
                onClick={this.updateSchool}
        >
            <i className="material-icons left">edit</i>
            Update School
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
            Delete School
        </button>
        </div>
      </form>
    )
  }
}

const mapStateToProps = (state) => ({
  ...state.lookup
})


export default connect(mapStateToProps)(SchoolsForm)