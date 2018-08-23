import { store } from '../AppStore'

const actionTypes = {
  SIGN_IN: "SIGN_IN",
  SIGN_IN_PENDING: "SIGN_IN_PENDING",
  SIGN_IN_FULFILLED: "SIGN_IN_FULFILLED",
  SIGN_IN_REJECTED: "SIGN_IN_REJECTED",
  GET_USERS: "GET_USERS",
  GET_USERS_PENDING: "GET_USERS_PENDING",
  GET_USERS_FULFILLED: "GET_USERS_FULFILLED",
  GET_USERS_REJECTED: "GET_USERS_REJECTED",
  ADD_PARENT: "ADD_PARENT",
  ADD_PARENT_PENDING: "ADD_PARENT_PENDING",
  ADD_PARENT_FULFILLED: "ADD_PARENT_FULFILLED",
  ADD_PARENT_REJECTED: "ADD_PARENT_REJECTED"
}

const initialState = {
  users: [],
  loggedUser: {},
  currentParent: {},
  loading: false,
  error: ''
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
    error: payload.response.data
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
    error: payload.response.data
  }),
  [actionTypes.ADD_PARENT_PENDING]: (state, payload) => ({
    ...state,
    loading: true
  }),
  [actionTypes.ADD_PARENT_FULFILLED]: (state, payload) => ({
    ...state,
    loading: false,
    currentParent: payload.data
  }),
  [actionTypes.ADD_PARENT_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload.response.data
  }),
}

const userActions = {
  signIn:(payload) => {
    store.dispatch({
      type: actionTypes.SIGN_IN,
      payload
    })
  },
  addParent: (payload) => (entity) => {
    // mapping
    const parent = {
      userId: entity.parentId,
      userPassword: entity.password,
      userTypeId: 3,
      _parent: {
        parentId: entity.parentId,
        fName: entity.fName,
        mName: entity.mName,
        gName: entity.gName,
        lName: entity.lName,
        idType: entity.idType,
        idExpireDateG: entity.idExpireDateG,
        mobile1: entity.mobile,
        email: entity.email,
        countryId: entity.countryId
      }
    };
    // dispatch
    store.dispatch({
      type: actionTypes.ADD_PARENT,
      // payload: axiosOne(payload.method,payload.url, parent)
      payload: { req: [payload.method,payload.url, parent] }
    })
  },
  getUsers:(payload) => {
    // dispath only when users is empty
    const {user: {users}} = store.getState();
    if(!users.length) {
        store.dispatch({
        type: actionTypes.GET_USERS,
        payload
      })
    }
  }
}

const stateKey = 'user';

// userReducer
const reducer = (state = initialState, { type, payload }) => {
  // instead of one big switch statement
  // call a function based on actionType [from the updater object]
  // that called function will return the new state
  // if there is no matching function based on actionType, return the same state
  return (Object.keys(updater).includes(type))
    ? updater[type](state,payload)
    : state;
}

export {
  userActions,
  stateKey,
  reducer as default
}