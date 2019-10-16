import React from 'react'
import { TwitterTimelineEmbed, TwitterFollowButton } from 'react-twitter-embed'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'

import { Field, reduxForm } from 'redux-form'
import { renderInput, Button } from '../../shared/FormInputs'

import { store } from '../../AppStore'

function ContactUsForm({ className, trans, handleSubmit, pristine, submitting }) {
  return (
    <form className={`rtl ${className}`} onSubmit={handleSubmit(console.log)}>
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

// form validation
const validate = ({ }) => {
  const trans = getTranslate(store.getState().localize);
  const errors = {};

  return errors;
}

// define the redux form
const ContactUs = reduxForm({
  form: 'contactUs',
  enableReinitialize: true,
  validate
})(ContactUsForm)

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
