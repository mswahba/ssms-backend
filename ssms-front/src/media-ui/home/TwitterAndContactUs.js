import React from 'react'
import { TwitterTimelineEmbed, TwitterFollowButton } from 'react-twitter-embed'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'

import { Field, reduxForm } from 'redux-form'
import { renderInput, Button } from '../../shared/FormInputs'

import { store } from '../../AppStore'

import { useFetch } from '../../customHooks'
import { time } from '../../helpers'

import isEmail from 'validator/lib/isEmail'
import isLength from 'validator/lib/isLength'
import isNumeric from 'validator/lib/isNumeric'

const key = 'contactUs_message_added'
const endpoint = '/contactUsMessages/add'

const doSubmit = setMessage => values => {
  console.log("TCL: doSubmit => values: ", values)
  setMessage(values)
}

function ContactUsForm({ className, trans, handleSubmit, pristine, submitting }) {
  const [message, setMessage] = React.useState(null);
  // Add contactUsMessage to Server
  const { loading, error, data } = useFetch({
    requestId: key,
    request: ['post', endpoint, message],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.day,
    deps: [message]
  })
  console.log("TCL: ContactUsForm -> data", data)
  console.log("TCL: ContactUsForm -> error", error)
  return (
    <form className={`rtl ${className}`} onSubmit={handleSubmit(doSubmit(setMessage))}>
      {/* form title */}
      <h4 className="orange-text">{ trans("home.contactUs.title") }</h4>
      <div className="divider orange" />
      {/* senderName */}
      <Field name="senderName"
        label={trans("home.contactUs.fields.senderName")}
        component={renderInput} />
      {/* email */}
      <Field name="email"
        type="email"
        label={trans("home.contactUs.fields.email")}
        component={renderInput} />
      {/* mobile */}
      <Field name="mobile"
        label={trans("home.contactUs.fields.mobile")}
        component={renderInput} />
      {/* messageTitle */}
      <Field name="messageTitle"
        label={trans("home.contactUs.fields.messageTitle")}
        component={renderInput} />
      {/* messageText */}
      <Field name="messageText"
        type='textarea'
        label={trans("home.contactUs.fields.messageText")}
        component={renderInput} />
      {/* Action Button */}
      <Button classes="primary darken-3"
        name="send"
        icon="send"
        label={ trans("home.contactUs.fields.sendBtn") }
        disabled={pristine || submitting}
      />
    </form>
  )
}

//#region form validation
// senderName
const validateSenderName = (trans, senderName) => {
  if (!senderName)
    return trans("home.contactUs.validations.senderName.required")
  else if (!senderName.alpha('ar') && !senderName.alpha('en'))
    return trans("home.contactUs.validations.senderName.alpha")
  else if ( !isLength(senderName, { min: 5, max: 50 }) )
    return trans("home.contactUs.validations.senderName.length")
}
// email
const validateEmail = (trans, email, mobile) => {
  if (!email && !mobile)
    return trans("home.contactUs.validations.email.required")
  else if (email && !isEmail(email) )
    return trans("home.contactUs.validations.email.isEmail")
}
// mobile
const validateMobile = (trans, mobile, email) => {
  if (!mobile && !email)
    return trans("home.contactUs.validations.mobile.required")
  else if ( mobile && !isNumeric(mobile, { no_symbols: true }) )
    return trans("home.contactUs.validations.mobile.isNumeric")
  else if ( mobile && !isLength(mobile, { min: 10, max: 10 }) )
    return trans("home.contactUs.validations.mobile.length")
}
// messageTitle
const validateMessageTitle = (trans, messageTitle) => {
  if (!messageTitle)
    return trans("home.contactUs.validations.messageTitle.required")
  else if ( !isLength(messageTitle, { min: 3, max: 75 }) )
    return trans("home.contactUs.validations.messageTitle.length")
}
// messageText
const validateMessageText = (trans, messageText) => {
  if (!messageText)
    return trans("home.contactUs.validations.messageText.required")
  else if ( !isLength(messageText, { min: 10, max: 1500 }) )
    return trans("home.contactUs.validations.messageText.length")
}
const validate = ({ senderName, email, mobile, messageTitle, messageText }) => {
  const trans = getTranslate(store.getState().localize);
  const errors = {};
  errors.senderName = validateSenderName(trans, senderName)
  errors.email = validateEmail(trans, email, mobile)
  errors.mobile = validateMobile(trans, mobile, email)
  errors.messageTitle = validateMessageTitle(trans, messageTitle)
  errors.messageText = validateMessageText(trans, messageText)
  return errors;
}
//#endregion

//#region define the redux form
const ContactUs = reduxForm({
  form: 'contactUs',
  enableReinitialize: true,
  validate
})(ContactUsForm)
//#endregion

function TwitterEmbed({ className, width, height, theme, accountName, sourceType, lang, buttonSize  }) {
  return (
    <div className={className}>
      {/* Assadarah Twitter Timeline Embed */}
      <TwitterTimelineEmbed
        screenName={accountName}
        sourceType={sourceType}
        lang={lang}
        options={{ width, height, theme }}
      />
      {/* Assadarah Twitter Follow Button */}
      <TwitterFollowButton screenName={accountName} options={{ size: buttonSize }} />
    </div>
  )
}

function TwitterAndContactUs({ trans, lang }) {
  return (
    <div className='row'>
      <TwitterEmbed
        className='col l6 s12'
        accountName='Assadarah'
        sourceType='profile'
        theme='light'
        buttonSize='large'
        lang={lang}
        width={400}
        height={400}
      />
      <ContactUs className='col l6 s12' trans={trans} />
    </div>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = state => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(TwitterAndContactUs);
