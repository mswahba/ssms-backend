import React, { Component } from "react";
import { Consumer } from "../AppStore";
import M from "materialize-css";

export default class SchoolsForm extends Component {

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

  setupFormType = () => {
    const { match: { params: { id } }, match: { url } } = this.props;
    if (url.includes('edit') && id)
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
    this.initDatePicker();
    this.setupFormType();
  }

  addSchool = () => {
    console.log(this.state);
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
      <Consumer>
        {({eduAssets, getSchool}) => {
          return (
            <form>
              {/* form title */}
              <h3 className="orange-text">{title}</h3>
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
                        }}
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
        }}
      </Consumer>
    )
  }
}
