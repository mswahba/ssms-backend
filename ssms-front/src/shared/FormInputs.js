import React from 'react'
// form Inputs
export const renderInput = (field) => {
  return (
    <div className="input-field">
      <i className="material-icons prefix">{field.icon || 'edit'}</i>
      <input id={field.input.name} type={field.type || 'text'} {...field.input} />
      <label className={field.input.value? 'active': ''} htmlFor={field.input.name}>{ field.label }</label>
      {
        (field.meta.touched && field.meta.error)
        ? <div className="red-text text-darken-4 valign-wrapper">
            <i class="material-icons">error_outline</i>
            {field.error}
          </div>
        : null
      }
    </div>
  )
}

export const renderDatepicker = (field) => {
  return (
    <div className="input-field">
      <i className="material-icons prefix">{field.icon || 'edit'}</i>
      <input id={field.input.name} type='text' className={field.type} {...field.input} />
      <label className={field.input.value? 'active': ''} htmlFor={field.input.name}>{ field.label }</label>
      {
        (field.meta.touched && field.meta.error)
        ? <div className="red-text text-darken-4 valign-wrapper">
            <i class="material-icons">error_outline</i>
            {field.error}
          </div>
        : null
      }
    </div>
  )
}