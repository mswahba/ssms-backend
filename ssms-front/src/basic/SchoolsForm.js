import React, { Component } from "react";
import M from "materialize-css";

export default class SchoolsForm extends Component {

  state = {};

  initDatePicker = () => {
    document.addEventListener("DOMContentLoaded", function() {
      var elems = document.querySelector(".datepicker");
      M.Datepicker.init(elems, { format: "dd/mm/yyyy" });
    });
  };

  componentDidMount() {
    this.initDatePicker();
  }

  render() {
    return (
      <form>
        <h3 className="orange-text">Add New School</h3>
        <div className="divider orange" />
        <div className="input-field ">
          <i className="material-icons prefix">edit</i>
          <input id="schoolId" type="text" className="validate" />
          <label htmlFor="schoolId">School Number</label>
        </div>
        <div className="input-field">
          <i className="material-icons prefix">edit</i>
          <input id="schoolName" type="text" className="validate" />
          <label htmlFor="schoolName">School Name [Arabic] </label>
        </div>
        <div className="input-field">
          <i className="material-icons prefix">edit</i>
          <input id="schoolNameEn" type="text" className="validate" />
          <label htmlFor="schoolNameEn">School Name [English] </label>
        </div>
        <div className="input-field">
          <i className="material-icons prefix">date_range</i>
          <input id="startDate" type="text" className="datepicker" />
          <label htmlFor="startDate">Start Date </label>
        </div>
        <div className="input-field">
          <i className="material-icons prefix">home</i>
          <textarea
            id="address"
            type="text"
            className="materialize-textarea validate"
          />
          <label htmlFor="address">Address </label>
        </div>
        <div className="input-field switch">
          <i className="material-icons prefix">school</i>
          <div id="isActive">
            <label>
              Activate School? No
              <input type="checkbox" />
              <span class="lever" />
              Yes
            </label>
          </div>
        </div>
        <div className="input-field">
          <i className="material-icons prefix">home</i>
          <input
            id="upload"
            type="file"
            className="materialize-textarea validate"
          />
          <label htmlFor="address">Address </label>
        </div>
        <div className="input-field center">
          <button
            class="btn waves-effect waves-light orange darken-3"
            type="submit"
            name="action"
          >
            Save New School
            <i class="material-icons right">send</i>
          </button>
        </div>
      </form>
    );
  }
}
