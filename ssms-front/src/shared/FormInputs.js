import React from 'react'
import HGDatePicker from '../shared/HGDatePicker'
import { AutoComplete } from 'primereact/autocomplete'

// #region show validations messages
const showError = ( { error, touched } ) => (
  (touched && error)
  ? <div className="red-text text-darken-4 valign-wrapper validate">
      <i className="material-icons">error_outline</i>
      {error}
    </div>
  : null
)
// #endregion

// #region Action Button
export const Button = ({ name, hidden, disabled, classes, icon, label }) => {
  let btnClasses = `btn waves-effect waves-light ${classes} `;
  if(hidden)
    btnClasses += 'hidden';
  return (
    <button id={name}
            name={name}
            className={btnClasses}
            disabled={disabled}
    >
      <i className="material-icons left">{ icon || 'send' }</i>
      { label }
    </button>
  )
}
// #endregion

// #region Inputs and Textarea
export const renderInput = ({ input, icon, type, label, meta, uiState: {hidden, disabled} = {} }) => {
  return (
    <div className="input-field" hidden={hidden}>
      <i className="material-icons prefix">{icon || 'edit'}</i>
      { (type === 'textarea')
          ? <textarea
              id={input.name}
              className="materialize-textarea"
              disabled={disabled}
              {...input}
            />
          : <input
              id={input.name}
              type={type === 'autocomplete'? 'text' : type}
              className={type === 'autocomplete'? 'autocomplete' : ''}
              disabled={disabled}
              {...input}
            />
      }
      <label className={input.value? 'active': ''} htmlFor={input.name}>{ label }</label>
      { showError(meta) }
    </div>
  )
}
// #endregion

// #region date and time pickers
export const renderDatepicker = ({ input, icon, type, label, meta, uiState: {hidden, disabled} = {} }) => {
  return (
    <div className="input-field" hidden={hidden}>
      <i className="material-icons prefix">{icon || 'edit'}</i>
      <input id={input.name} type='text' className={type} disabled={disabled} {...input} />
      <label className={input.value? 'active': ''} htmlFor={input.name}>{ label }</label>
      { showError(meta) }
    </div>
  )
}
// #endregion

// #region Switch
export const renderSwitch = ({ input, meta, icon, label, on, off, uiState: {hidden, disabled} = {} }) => (
  <div className="input-field" hidden={hidden}>
    <i className="material-icons prefix">{icon || 'edit'}</i>
    <label className="active">{label}</label>
    <div className="switch">
      <label>
        {off && <span>{off}</span>}
        <input id="isActive"
              type="checkbox"
              disabled={disabled}
              checked={input.value}
              {...input}
        />
        <span className="lever" />
        {on && <span>{on}</span>}
      </label>
    </div>
    { showError(meta) }
  </div>
)
// #endregion

// #region Select [Dropdown list]
export const renderSelect = ({ meta, input, label, options, icon = 'input', uiState: {hidden, disabled} = {} }) => (
  <div className="input-field" hidden={hidden}>
  <i className="material-icons prefix">{icon}</i>
  <select id={input.name}
          disabled={disabled}
          {...input}
  >
    <option value=''>{label || input.name}</option>
    {options.map(opt => <option key={opt.value} value={opt.value}>{opt.text}</option>)}
  </select>
  <label htmlFor={input.name}>{label || input.name}</label>
  { showError(meta) }
</div>
)
// #endregion

// #region Radios and Checkboxes
export const renderCheck = ({ meta, input, label, options, type = 'radio', icon = 'edit', labelClassName= '', itemsClassName = '', itemClassName = '', inputClassName= '', uiState: {hidden, disabled} = {} }) => (
  <div className="input-field" hidden={hidden}>
    <i className="material-icons prefix">{icon}</i>
    <label className={labelClassName} htmlFor={input.name}>{ label || input.name}</label>
    <div className={itemsClassName}>
      {options.map(opt => (
        <label key={opt.value} htmlFor={opt.value} className={itemClassName}>
          <input type={type}
                  id={opt.value}
                  className={inputClassName}
                  disabled={disabled}
                  {...input}
        />
          <span>{opt.text}</span>
        </label>
      ))}
    </div>
    { showError(meta) }
  </div>
)
// #endregion

// #region HGDatepicker
export const renderHGDatepicker = ({ meta, input, label, HLabel, GLabel, HKey, GKey, icon = 'edit', HDate = null, GDate = new Date(), onSelect, uiState: {hidden, disabled} = {} }) => (
  <div className="input-field" hidden={hidden}>
    <i className="material-icons prefix hg-icon">{icon}</i>
    <HGDatePicker
        label={label}
        HLabel={HLabel}
        GLabel={GLabel}
        HKey={HKey}
        GKey={GKey}
        HDate={HDate}
        GDate={GDate}
        getDates={onSelect}
        {...input}
    />
    { showError(meta) }
  </div>
)
// #endregion

// #region primereact AutoComplete
export const renderAutoComplete = ({ meta, input, label, onChange, completeMethod, options = {}, icon = 'edit', uiState: {hidden, disabled} = {} }) => (
  <div className="input-field" hidden={hidden}>
    <i className="material-icons prefix">{icon}</i>
    <AutoComplete
        className="validate"
        label={label}
        disabled={disabled}
        completeMethod={completeMethod}
        {...options}
        {...input}
        onChange={onChange}
    />
    { showError(meta) }
  </div>
)
// #endregion