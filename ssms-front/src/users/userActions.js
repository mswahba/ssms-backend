import { store } from '../AppStore'
import { actionTypes } from './userReducer'

export const signIn = (payload) => {
  store.dispatch({
    type: actionTypes.SIGN_IN,
    payload
  })
}

export const getUsers = (payload) => {
  store.dispatch({
    type: actionTypes.GET_USERS,
    payload
  })
}