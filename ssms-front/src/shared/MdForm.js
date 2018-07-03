import React, { Component } from 'react'
import M from 'materialize-css';
import './MdForm.css';

export default class MdForm extends Component {
  // hold the needed dom element catched in component DidMount
  domElements = {};
  // hold the Form fields props
  inputs  = Object.keys(this.props)
                  .map(key => ({ fieldName: key, ...this.props[key] } ));
  // holds the Form state
  state = this.inputs
              .filter(input => !['submit','button','className'].includes(input.fieldName) )
              .reduce( (obj, input) => {
                obj[input.fieldName] = {
                  value: input.value || '',
                  invalid: false,
                  touched: false,
                  errors: (input.validators)
                          ? Object.keys(input.validators)
                                  .reduce( (obj, validator) => {
                                    obj[validator] = null;
                                    return obj;
                                  }, {})
                          : {}
                };
                return obj;
              }, {invalid: false, touched: false});

  // set errors
  getErrors = (value, validatorKeys, validators, prevErrors) => {
    for (let i = 0; i < validatorKeys.length; i++) {
      const err = validators[validatorKeys[i]](value);
      if(err)
        return {
          ...prevErrors,
          [validatorKeys[i]] : err
        }
    }
    return {
      ...prevErrors
    }
  }
  // handle validation [set errors]
  setErrors = (key, input, value) => {
    this.setState((prevState) => ({
        [key]: {
          ...prevState[key],
          errors: this.getErrors(value,Object.keys(input.validators),input.validators,prevState[key].errors),
          value: value,
          touched: true
        }
      })
    );
  }
  // handle validation [set field invalid state]
  setFieldInvalid = (key) => {
    this.setState((prevState) => ({
        [key]: {
          ...prevState[key],
          invalid: Object.keys(prevState[key].errors)
                        .some( (err) => prevState[key].errors[err] !== null)
        }
      })
    );
  }
  // handle validation [set Form invalid state]
  setFormInvalid = (key) => {
    this.setState((prevState) => ({
        [key]: {
          ...prevState[key],
          invalid: Object.keys(prevState)
                        .filter( key => !['invalid','touched'].includes(key) )
                        .some( key => prevState[key].invalid === true )
        }
      })
    );
  }
  // handle validation [all]
  checkValidation = (key, input, value) => {
      this.setErrors(key, input, value);
      this.setFieldInvalid(key);
      this.setFormInvalid(key);
  }
  // handle Changed Value
  setValue = (key, input, value) => {
    if (input.validators)
      this.checkValidation(key, input, value);
    else
      this.setState( (prevState) => ({
          [key]: {
            ...prevState[key],
            value: value,
            touched: true
          }
        })
      )
  }
  // build the Form fields [logic and UI] from the fields props
  formFields = this.inputs
    .filter(input => !['className'].includes(input.fieldName) )
    .map( input => {
      let key = input.fieldName;
      switch (input.type) {
        case 'checkbox':
        case 'radio':
          return (
            <div key={key} className="input-field">
              <i className="material-icons prefix">{input.icon || 'input'}</i>
              <label className="radio-check-label" htmlFor={key}>{input.label || input.placeholder || key}</label>
              <div className="radio-check-items">
                {input.options.map(opt => (
                  <label key={opt.value} className="radio-check-item">
                    <input type={input.type}
                            className={input.className || ''}
                            id={opt.value}
                            name={key}
                            value={this.state.key}
                            onChange={ (e) => {
                              let value = (input.type === 'checkbox')
                                          ? input.options.reduce( (str, opt) => {
                                            if(this.domElements[key][opt.value].checked)
                                              str += opt.value + ' ';
                                            return str;
                                          }, '' ).trim()
                                          : opt.value;
                              this.setValue(key,input,value);
                            } }
                            onBlur={ (e) => this.setState( (prevState) =>  {
                              return {
                                [key]: {
                                  ...prevState[key],
                                  touched: true
                                }
                              }
                            }) } />
                    <span>{opt.text}</span>
                  </label>
                ))}
              </div>
            </div>
          )
        case 'switch':
          return (
            <div key={key} className="input-field">
              <i className="material-icons prefix">{input.icon || 'input'}</i>
              <div className="switch">
                  <label className="switch-label">
                    <input type="checkbox"
                          id={key}
                          name={key}
                          value={this.state.key}
                          onChange={ (e) => {
                            let value = this.domElements[key].checked;
                            this.setValue(key,input,value);
                          } }
                          onBlur={ (e) => this.setState( (prevState) =>  {
                            return {
                              [key]: {
                                ...prevState[key],
                                touched: true
                              }
                            }
                          }) } />
                    <span className="lever"></span>
                  </label>
                  <label className="input-label" htmlFor={key}>{input.label || input.placeholder || key}</label>
              </div>
            </div>
          )
        case 'range':
          return (
            <div key={key} className="input-field">
              <i className="material-icons prefix">{input.icon || 'input'}</i>
              <label className="range-label" htmlFor={key}>{input.label || input.placeholder || key}</label>
              <input className="range-input"
                    type="range"
                    id={key}
                    name={key}
                    min={input.min || 0}
                    max={input.max || 100}
                    value={this.state.key}
                    onChange={ (e) => {
                      let value = this.domElements[key].value;
                      this.setValue(key,input,value);
                    } }
                    onBlur={ (e) => this.setState( (prevState) =>  {
                      return {
                        [key]: {
                          ...prevState[key],
                          touched: true
                        }
                      }
                    }) } />
            </div>
          )
        case 'textarea':
          return (
            <div key={key} className="input-field">
              <i className="material-icons prefix">{input.icon || 'input'}</i>
              <textarea className="materialize-textarea"
                        id={key}
                        name={key}
                        value={this.state.key}
                        onChange={ (e) => {
                          let value = this.domElements[key].value;
                          this.setValue(key,input,value);
                        } }
                        onBlur={ (e) => this.setState( (prevState) =>  {
                          return {
                            [key]: {
                              ...prevState[key],
                              touched: true
                            }
                          }
                        }) }>
              </textarea>
              <label htmlFor={key}>{input.label || input.placeholder || input.name}</label>
            </div>
          )
        case 'datepicker':
        case 'timepicker':
          const className = (input.type === 'datepicker')? input.type + ' no-autoinit' : input.type;
          return (
            <div key={key} className="input-field">
              <i className="material-icons prefix">{input.icon || 'input'}</i>
              <input type="text"
                    id={key}
                    name={key}
                    className={className}
                    value={this.state.key}
                    onBlur={ (e) => {
                      let value = this.domElements[key].value;
                      this.setValue(key,input,value);
                    } } />
              <label htmlFor={key}>{input.label || input.placeholder || key}</label>
            </div>
          )
        case 'select':
          return (
            <div key={input.key} className="input-field">
              <i className="material-icons prefix">{input.icon || 'input'}</i>
              <select id={key}
                      name={key}
                      value={this.state.key}
                      onChange={ (e) => {
                        let value = this.domElements[key].value;
                        this.setValue(key,input,value);
                      } }
                      onBlur={ (e) => this.setState( (prevState) =>  {
                        return {
                          [key]: {
                            ...prevState[key],
                            touched: true
                          }
                        }
                      }) }>
                <option value=''>Choose {input.label || input.placeholder || key}</option>
                {input.options.map(opt => <option key={opt.value} value={opt.value}>{opt.text}</option>)}
              </select>
              <label htmlFor={key}>{input.label || input.placeholder || key}</label>
            </div>
          )
        case 'submit':
        case 'button':
          return (
            <div key={input.label} className="input-field">
              <button className={"btn waves-effect waves-light "+input.className}
                    id={input.key}
                    name={input.key}
                    type={input.type}
                    onClick={()=> {
                        console.log(this.state);
                      }}>
                {input.label}
              <i className="material-icons right">{input.icon || 'send'}</i>
              </button>
            </div>
          )
        default:
          return (
            <div key={key} className="input-field">
              <i className="material-icons prefix">{input.icon || 'input'}</i>
              <input id={key}
                    name={key}
                    type={input.type || 'text'}
                    value={this.state.key}
                    onChange={ (e) => {
                      let value = this.domElements[key].value;
                      this.setValue(key,input,value);
                    } }
                    onBlur={ (e) => this.setState( (prevState) =>  {
                      return {
                        [key]: {
                          ...prevState[key],
                          touched: true
                        }
                      }
                    }) } />
              <label htmlFor={key}>{input.label || input.placeholder || key}</label>
            </div>
          )
      }
    });
  // init date picker
  initDatePickers = () => {
    const currentYear = +(new Date()).getFullYear();
    const pickers = document.querySelectorAll('.datepicker');
    pickers.forEach(picker => {
      const options = {
        format: 'dd/mm/yyyy',
        yearRange: [currentYear-70,currentYear],
        firstDay: 6,
        onSelect: (selectedDate) => {
          this.setState({ [picker.id]: { value: selectedDate } });
        }
      }
      M.Datepicker.init(picker, options);
    });
  }

  initSelectLists = () => {
    const selectLists = document.querySelectorAll('select');
    M.FormSelect.init(selectLists, {});
  }

  componentDidMount () {
    // init the datepicker with options
    this.initDatePickers();
    //init the Form Select Lists
    this.initSelectLists();
    // get all the needed dom element to be used element events
    this.domElements = this.inputs
        .filter(input => !['submit','button'].includes(input.fieldName) )
        .reduce( (obj, input) => {
          if (input.type === 'checkbox' || input.type === 'radio')
            obj[input.fieldName] = input.options.reduce( (obj, opt) => {
              obj[opt.value] = document.getElementById(opt.value);
              return obj;
            }, {});
          else
            obj[input.fieldName] = document.getElementById(input.fieldName);
          return obj;
        }, {});
  }

  render() {
    return (
      <form className={this.props.className}>
        {this.formFields}
      </form>
    )
  }
}