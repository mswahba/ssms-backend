import React from 'react'

const showError = ( { error, touched } ) => (
  (touched && error)
  ? <div className="red-text text-darken-4 valign-wrapper">
      <i class="material-icons">error_outline</i>
      {error}
    </div>
  : null
)
// Action Button
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

// Inputs and Textarea
export const renderInput = ({ input, icon, type, label, meta, uiState: {hidden, disabled} }) => {
  return (
    <div className="input-field" hidden={hidden}>
      <i className="material-icons prefix">{icon || 'edit'}</i>
      { (type === 'textarea')
          ? <textarea id={input.name} className="materialize-textarea" disabled={disabled} {...input} />
          : <input    id={input.name} type={type || 'text'} disabled={disabled} {...input} />
      }
      <label className={input.value? 'active': ''} htmlFor={input.name}>{ label }</label>
      { showError(meta) }
    </div>
  )
}
// date and time pickers
export const renderDatepicker = ({ input, icon, type, label, meta, uiState: {hidden, disabled} }) => {
  return (
    <div className="input-field" hidden={hidden}>
      <i className="material-icons prefix">{icon || 'edit'}</i>
      <input id={input.name} type='text' className={type} disabled={disabled} {...input} />
      <label className={input.value? 'active': ''} htmlFor={input.name}>{ label }</label>
      { showError(meta) }
    </div>
  )
}
// Switch
export const renderSwitch = ({ input, meta, icon, label, on, off, uiState: {hidden, disabled} }) => (
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