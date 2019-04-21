import React from "react"
import { connect } from "react-redux"
import { getTranslate } from 'react-localize-redux'
import { Field, reduxForm } from 'redux-form'
import { store } from '../AppStore'
import { renderInput, Button } from '../shared/FormInputs'
import { userActions } from "../store/user"
import isNumeric from 'validator/lib/isNumeric'
import isLength from 'validator/lib/isLength'

let SignIn = (props) => {
  const { trans, handleSubmit, pristine, submitting } = props;
  const doSignIn = (values) => userActions.signIn({
    req: ["post", "/Users/sign-in", values],
    fulfilledToast: ["success", trans('users.signIn.success')],
    errorToast: ["error", trans('users.signIn.error')],
    localStorage: 'loggedUser'
  });
  return (
    <form className="rtl" onSubmit={handleSubmit(doSignIn)}>
      {/* form title */}
      <h4 className="orange-text">{ trans("users.signIn.title") }</h4>
      <div className="divider orange" />
      {/* userId */}
      <Field name="userId"
              label={trans("users.signIn.fields.userId")}
              component={renderInput} />
      {/* userPassword */}
      <Field name="userPassword"
              type="password"
              label={trans("users.signIn.fields.userPassword")}
              component={renderInput} />
      {/* Action Button */}
      <Button classes="primary darken-3"
                name="signIn"
                icon="send"
                label={ trans("users.signIn.fields.btn") }
                disabled={pristine || submitting}
      />
    </form>
  );
}
// userId validation
const validateUserId = (trans, userId, errors) => {
  if (!userId)
    errors.userId = trans("users.signIn.validations.userId.required");
  else if ( !isNumeric(userId, { no_symbols: true }) )
    errors.userId = trans("users.signIn.validations.userId.numeric");
  else if ( !isLength(userId, { min: 10, max: 10 }) )
    errors.userId = trans("users.signIn.validations.userId.length");
}
// userPassword validation
const validateUserPassword = (trans, userPassword, errors) => {
  if (!userPassword)
    errors.userPassword = trans("users.signIn.validations.userPassword.required");
  else if ( !isLength(userPassword, { min: 6, max: 25 }) )
    errors.userPassword = trans("users.signIn.validations.userPassword.length");
}

// form validation
const validate = ({ userId, userPassword }) => {
  const trans = getTranslate(store.getState().localize);
  const errors = {};
  // userId
  validateUserId(trans, userId, errors);
  // userPassword
  validateUserPassword(trans, userPassword, errors);
  return errors;
}
// define the redux form
SignIn = reduxForm({
  form: 'signIn',
  enableReinitialize: true,
  validate
})(SignIn);

// get props from redux state
const mapStateToProps = state => ({
  ...state.user,
  "trans": getTranslate(state.localize)
});

export default connect(mapStateToProps)(SignIn);
