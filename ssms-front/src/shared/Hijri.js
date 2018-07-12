import React, { Component, Fragment } from 'react'
import HijriDatePicker from 'hijri-date-picker';
import '../../node_modules/hijri-date-picker/build/css/index.css';

export default class Hijri extends Component {
  render() {
    return (
      <Fragment>
        <HijriDatePicker
        inputName="hijri_date"
        className="form-control"
        selectedDate="1439/08/02"
        />
      </Fragment>
    )
  }
}
