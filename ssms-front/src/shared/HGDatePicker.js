import React, { Component, Fragment } from 'react'
import M from 'materialize-css'
import HijriDatePicker from 'hijri-date-picker'
import '../../node_modules/hijri-date-picker/build/css/index.css'
import moment from 'moment-hijri'

function toHDate(GDate) {
  return GDate
          .toLocaleDateString('ar-SA')
          .replace('هـ', '')
          .trim();
}

function toGDate(HDate) {
  // convert the date string to Hijri date object using 'moment-hijri'
  return moment(HDate, 'iYYYY/iMM/iDD')
  // convert the Hdate to Gdate using 'moment-hijri'
    .format('YYYY/MM/DD');
}

export default class HGDatePicker extends Component {
  // the initial state
  state = {
    inputDate: null,
    GDateValue: null,
    HDateValue: null
  }
  // get the converted date from props
  setInitialDates = () => {
    let { GDate, HDate, GKey, HKey } = this.props;
    let selectedInput = GKey;
    if(GDate) {
      // convert Gdate to Hdate using built-in Date function
      HDate = toHDate(GDate);
    } else if (HDate) {
      // convert the Hdate to Gdate using 'moment-hijri'
      GDate = toGDate(HDate);
      selectedInput = HKey;
    } else {
      GDate = new Date();
      HDate = toHDate(GDate);
    }
    this.setState({
      inputDate: selectedInput,
      GDateValue: GDate,
      HDateValue: HDate
    })
  }
  // handle selected date radio input
  onRadioChecked = (e) => {
    this.setState( { inputDate: e.target.value } );
  }

  // init Gdate picker [materialize-css]
  initGDatePicker = ({ HKey, GKey, GDate, getDates }) => {
    const now = new Date();
    const currentYear = +now.getFullYear();
    const options = {
      format: 'dd/mm/yyyy',
      yearRange: [currentYear-70,currentYear+30],
      firstDay: 6,
      defaultDate: new Date(this.state.GDateValue),
      setDefaultDate: true,
      onSelect: (selectedDate) => {
        // add 3 hours to utc date
        selectedDate.setHours(selectedDate.getHours()+3);
        const Gdate = selectedDate;
        // convert Gdate to Hdate using built-in Date function
        const Hdate = toHDate(selectedDate);
        // set the converted G date to its state
        this.setState({
          HDateValue: Hdate
        });
        // console.log(Hdate, Gdate);
        getDates({
          [HKey]: Hdate,
          [GKey]: Gdate
        });
      }
    }
    // get the input el
    const el = document.querySelector(`#${GKey}`);
    // init the datepicker materialize component
    M.Datepicker.init(el, options);
  }
  // get the selected Hdate value
  HdateOnChange = ({ HKey, GKey, getDates }) => {
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
          // convert the Hdate to Gdate using 'moment-hijri'
          const Gdate = toGDate(input.value);
          // set the converted G date to its state
          this.setState({
            GDateValue: Gdate
          });
          // console.log(Hdate, Gdate);
          getDates({
            [HKey]: input.value,
            [GKey]: Gdate
          });
        }, 0)
      }
    })
  }

  componentWillMount() {
    // call the setIntialDates to set the GDate and HDate values from props
    this.setInitialDates();
  }

  componentDidMount() {
    // call the initGdatePicker and HdateOnchange
    this.initGDatePicker(this.props);
    this.HdateOnChange(this.props);
  }

  render() {
    // get the wanted values from the component props
    const { label, HLabel, GLabel, HKey, GKey, HDate } = this.props;
    // return the component UI using:
    // [materialize-datepicker]
    // [hijri-date-picker]
    return (
      <div className="hg-datepicker validate">
        {/* Main field label */}
        <label className="main-label" htmlFor={GKey}>{label}</label>
        {/* Gregorian Label [Gregorian radio button]  */}
        <label className="g-label">
          <input type="radio"
                name={label}
                value={GKey}
                onChange={this.onRadioChecked}
                checked={this.state.inputDate === GKey} />
          <span>{GLabel}</span>
        </label>
        {/* materialize datepicker input to pick a Gregorian date */}
        <div className="input-field g-input" hidden={this.state.inputDate !== GKey}>
          <i className="material-icons prefix">date_range</i>
          <input type="text"
                className="datepicker"
                id={GKey}
                name={GKey}
          />
        </div>
        {/* text input to display the resulted Gregorian date from hijri date */}
        <div className="input-field g-input" hidden={this.state.inputDate === GKey}>
          <i className="material-icons prefix">edit</i>
          <input type="text"
                id={GKey}
                placeholder={GKey}
                value={this.state.GDateValue.toLocaleDateString('en-gb')}
                disabled />
        </div>
        {/* Hijri Label [Hijri radio button]  */}
        <label className="h-label">
          <input type="radio"
                name={label}
                value={HKey}
                checked={this.state.inputDate === HKey}
                onChange={this.onRadioChecked} />
          <span>{HLabel}</span>
        </label>
        {/* HijriDatePicker component to pick a hijri date */}
        <div id={HKey} className="input-field h-input" hidden={this.state.inputDate !== HKey}>
          <i className="material-icons prefix">date_range</i>
          <HijriDatePicker
              className="input-field"
              inputName={HKey}
              selectedDate={this.state.HDateValue}
          />
        </div>
        {/* text input to display the resulted hijri date from Gregorian date */}
        <div className="input-field h-input" hidden={this.state.inputDate === HKey}>
          <i className="material-icons prefix">edit</i>
          <input type="text"
                id={HDate}
                placeholder={HDate}
                value={this.state.HDateValue}
                disabled />
        </div>
      </div>
    )
  }
}