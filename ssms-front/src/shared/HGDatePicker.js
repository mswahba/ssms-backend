import React, { Component, Fragment } from 'react'
import M from 'materialize-css'
import HijriDatePicker from 'hijri-date-picker'
import '../../node_modules/hijri-date-picker/build/css/index.css'
import moment from 'moment-hijri'

export default class HGDatePicker extends Component {

  // init Gdate picker [materialize-css]
  initGDatePicker = ({ GKey, GDate }) => {
    const now = new Date();
    const currentYear = +now.getFullYear();
    const options = {
      format: 'dd/mm/yyyy',
      yearRange: [currentYear-70,currentYear+30],
      firstDay: 6,
      defaultDate: GDate,
      setDefaultDate: true,
      onSelect: (selectedDate) => {
        // add 3 hours to utc date
        selectedDate.setHours(selectedDate.getHours()+3);
        const Gdate = selectedDate;
        // convert Gdate to Hdate using built-in Date function
        const Hdate = selectedDate.toLocaleDateString('ar-SA');
        console.log(Hdate.replace('هـ','').trim(), Gdate);
      }
    }
    // get the input el
    const el = document.querySelector(`#${GKey}`);
    // init the datepicker materialize component
    M.Datepicker.init(el, options);
  }
  // get the selected Hdate value
  HdateOnChange = ({ HKey }) => {
    // the container div
    const container = document.querySelector(`#${HKey}`);
    // the date input
    const input = document.querySelector(`input[name=${HKey}]`);
    // add click handler to the container div
    container.addEventListener('click', (e) => {
      // work only if the target is a button [the day in the hijri Calender]
      if(e.target.nodeName === "BUTTON") {
        // wait till the selected date is written in the text input
        setTimeout(() => {
          // convert the date string to Hijri date object using 'moment-hijri'
          const Hdate = moment(input.value, 'iYYYY/iMM/iDD');
          // convert the Hdate to Gdate using 'moment-hijri'
          const Gdate = Hdate.format('YYYY/MM/DD');
          console.log(Hdate, Gdate);
        }, 0)
      }
    })
  }

  componentDidMount() {
    // call the initGdatePicker and HdateOnchange
    this.initGDatePicker(this.props);
    this.HdateOnChange(this.props);
  }

  render() {
    // get the wanted values from the component props
    const { label, HKey, GKey, HDate } = this.props;
    // return the component UI using:
    // [materialize-datepicker]
    // [hijri-date-picker]
    return (
      <Fragment>
        <label htmlFor={GKey}>{label}</label>
        <div className="input-field">
          <i className="material-icons prefix">date_range</i>
          <input type="text"
                className="datepicker"
                id={GKey}
                name={GKey}
          />
        </div>
        <div id={HKey} className="input-field">
          <i className="material-icons prefix">date_range</i>
          <HijriDatePicker
              className="input-field"
              inputName={HKey}
              selectedDate={HDate}
          />
        </div>
      </Fragment>
    )
  }
}
