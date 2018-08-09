const initialState = {
  users: [],
  loggedUser: {},
  loading: false,
  error: ""
}

const methods = {
  SIGN_IN_PENDING: (state, payload) => ({
    ...state,
    loading: true
  }),
  SIGN_IN_FULFILLED: (state, payload) => ({
    ...state,
    loading: false,
    loggedUser: payload
  }),
  SIGN_IN_REJECTED: (state, payload) => ({
    ...state,
    loading: false,
    error: payload
  }),
  GET_USERS_PENDING: (state, payload) => ({
    ...state,
    loading: true
  }),
  GET_USERS_FULFILLED: (state, payload) => ({
    ...state,
    loading: false,
    users: payload
  }),
  GET_USERS_REJECTED: (state, payload) => ({
    ...state,
    loading: false,
    error: payload
  }),
}

export const actionTypes = {
  SIGN_IN: "SIGN_IN",
  SIGN_IN_PENDING: "SIGN_IN_PENDING",
  SIGN_IN_FULFILLED: "SIGN_IN_FULFILLED",
  SIGN_IN_REJECTED: "SIGN_IN_REJECTED",
  GET_USERS: "GET_USERS",
  GET_USERS_PENDING: "GET_USERS_PENDING",
  GET_USERS_FULFILLED: "GET_USERS_FULFILLED",
  GET_USERS_REJECTED: "GET_USERS_REJECTED"
}

// userReducer
export default (state = initialState, { type, payload }) => {
  // instead of one big switch statement
  // call a function based on actionType [from the methods object]
  // that called function will return the new state
  // if there is no matching function based on actionType, return the same state
  return (Object.keys(methods).includes(type))
    ? methods[type](state,payload)
    : state;
}