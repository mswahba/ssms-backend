import { store } from '../AppStore'

const actionTypes = {
  SIGN_IN: "SIGN_IN",
  SIGN_IN_PENDING: "SIGN_IN_PENDING",
  SIGN_IN_FULFILLED: "SIGN_IN_FULFILLED",
  SIGN_IN_REJECTED: "SIGN_IN_REJECTED",
  GET_USERS: "GET_USERS",
  GET_USERS_PENDING: "GET_USERS_PENDING",
  GET_USERS_FULFILLED: "GET_USERS_FULFILLED",
  GET_USERS_REJECTED: "GET_USERS_REJECTED"
}

const initialState = {
  users: [],
  loggedUser: {},
  loading: false,
  error: ""
}

const updater = {
  [actionTypes.SIGN_IN_PENDING]: (state, payload) => ({
    ...state,
    loading: true
  }),
  [actionTypes.SIGN_IN_FULFILLED]: (state, payload) => ({
    ...state,
    loading: false,
    loggedUser: payload.data
  }),
  [actionTypes.SIGN_IN_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload
  }),
  [actionTypes.GET_USERS_PENDING]: (state, payload) => ({
    ...state,
    loading: true
  }),
  [actionTypes.GET_USERS_FULFILLED]: (state, payload) => ({
    ...state,
    loading: false,
    users: payload.data
  }),
  [actionTypes.GET_USERS_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload
  }),
}

export const userActions = {
  signIn:(payload) => {
    store.dispatch({
      type: actionTypes.SIGN_IN,
      payload
    })
  },
  getUsers:(payload) => {
    store.dispatch({
      type: actionTypes.GET_USERS,
      payload
    })
  }
}

// userReducer
export const userReducer = (state = initialState, { type, payload }) => {
  // instead of one big switch statement
  // call a function based on actionType [from the updater object]
  // that called function will return the new state
  // if there is no matching function based on actionType, return the same state
  return (Object.keys(updater).includes(type))
    ? updater[type](state,payload)
    : state;
}