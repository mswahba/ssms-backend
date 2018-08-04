import React, { Component } from "react";
import M from "materialize-css";

export default class SchoolsForm extends Component {

  state = {
    title: "Add New School",
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
  };

  initDatePicker = () => {
    var elems = document.querySelector(".datepicker");
    M.Datepicker.init(elems, { format: "dd/mm/yyyy" });
  };

  setupFormType() {
    const { match: { params: { id } }, match: { url } } = this.props;
    if (url.includes('edit') && id)
      this.setState({
        title: "Edit this School",
        schoolId: {
          hidden: false,
          disabled: true
        },
        btnAdd: {
          hidden: true,
          disabled: true
        }
      });
    else if (url.includes('new'))
      this.setState({
        title: "Add New School",
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
    else if (url.includes('details'))
      this.setState({
        title: "view School Details",
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

  componentDidMount() {
    this.initDatePicker();
    this.setupFormType();
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
        <h3 className="orange-text">{title}</h3>
        <div className="divider orange" />
        {/* schoolId */}
        <div className="input-field" hidden={schoolId.hidden}>
          <i className="material-icons prefix">edit</i>
          <input disabled={schoolId.disabled} id="schoolId" type="text" className="validate" />
          <label htmlFor="schoolId">School Number</label>
        </div>
        {/* schoolName */}
        <div className="input-field" hidden={schoolName.hidden}>
          <i className="material-icons prefix">edit</i>
          <input disabled={schoolName.disabled}
                id="schoolName"
                type="text"
                className="validate"
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
          />
          <label htmlFor="comNum">Commercial Number</label>
        </div>
        {/* isActive */}
        <div className="input-field switch" hidden={isActive.hidden}>
          <i className="material-icons prefix">school</i>
          <div id="isActive">
            <label>
              Activate School? No
              <input disabled={isActive.disabled} type="checkbox" />
              <span class="lever" />
              Yes
            </label>
          </div>
        </div>
        {/* Action Buttons */}
        <div className="input-field center">
        <button class="btn waves-effect waves-light primary darken-3"
                id="btnAdd"
                name="btnAdd"
                disabled={btnAdd.disabled}
                hidden={btnAdd.hidden}>
            <i class="material-icons left">add</i>
            Add New School
        </button>
        <button class="btn waves-effect waves-light orange darken-3"
                id="btnUpdate"
                name="btnUpdate"
                disabled={btnUpdate.disabled}
                hidden={btnUpdate.hidden}>
            <i class="material-icons left">edit</i>
            Update School
        </button>
        <button class="btn waves-effect waves-light red darken-3"
                id="btnDelete"
                name="btnDelete"
                disabled={btnDelete.disabled}
                hidden={btnDelete.hidden}>
            <i class="material-icons left">close</i>
            Delete School
        </button>
        </div>
      </form>
    )
  }
}
