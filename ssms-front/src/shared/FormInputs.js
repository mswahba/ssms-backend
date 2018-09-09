import React from 'react'

const showError = ( { error, touched } ) => (
  (touched && error)
  ? <div className="red-text text-darken-4 valign-wrapper">
      <i class="material-icons">error_outline</i>
      {error}
    </div>
  : null
)

// form Inputs
export const renderInput = ({ input, icon, type, label, meta }) => {
  return (
    <div className="input-field">
      <i className="material-icons prefix">{icon || 'edit'}</i>
      { (type === 'textarea')
          ? <textarea id={input.name} {...input} className="materialize-textarea" />
          : <input id={input.name} type={type || 'text'} {...input} />
      }
      <label className={input.value? 'active': ''} htmlFor={input.name}>{ label }</label>
      { showError(meta) }
    </div>
  )
}

export const renderDatepicker = ({ input, icon, type, label, meta }) => {
  return (
    <div className="input-field">
      <i className="material-icons prefix">{icon || 'edit'}</i>
      <input id={input.name} type='text' className={type} {...input} />
      <label className={input.value? 'active': ''} htmlFor={input.name}>{ label }</label>
      { showError(meta) }
    </div>
  )
}

export const renderSwitch = ({ input, meta, icon, label, on, off, hidden, disabled }) => (
  <div className="input-field switch" hidden={hidden}>
    <i className="material-icons prefix">{icon}</i>
    <div>
      <label className={input.value? 'active': ''} >
        <span>{label}</span>
        {off && <span>{off}</span>}
        <input id="isActive"
              disabled={disabled}
              type="checkbox"
              {...input}
        />
        <span className="lever" />
        {on && <span>{on}</span>}
      </label>
    </div>
    { showError(meta) }
  </div>
)