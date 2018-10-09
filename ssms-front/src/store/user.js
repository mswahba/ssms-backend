import { store } from '../AppStore'

const actionTypes = {
  SIGN_IN_PENDING: "SIGN_IN_PENDING",
  SIGN_IN_FULFILLED: "SIGN_IN_FULFILLED",
  SIGN_IN_REJECTED: "SIGN_IN_REJECTED",
  GET_USERS_PENDING: "GET_USERS_PENDING",
  GET_USERS_FULFILLED: "GET_USERS_FULFILLED",
  GET_USERS_REJECTED: "GET_USERS_REJECTED",
  ADD_PARENT_PENDING: "ADD_PARENT_PENDING",
  ADD_PARENT_FULFILLED: "ADD_PARENT_FULFILLED",
  ADD_PARENT_REJECTED: "ADD_PARENT_REJECTED"
}

const initialState = {
  users: [],
  loggedUser: {},
  currentParent: {},
  loading: false,
  error: null
}

const updater = {
  [actionTypes.SIGN_IN_PENDING]: (state) => ({
    ...state,
    loading: true,
    error: null
  }),
  [actionTypes.SIGN_IN_FULFILLED]: (state, payload) => ({
    ...state,
    loading: false,
    error: null,
    loggedUser: payload.data
  }),
  [actionTypes.SIGN_IN_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload
  }),
  [actionTypes.GET_USERS_PENDING]: (state) => ({
    ...state,
    loading: true,
    error: null
  }),
  [actionTypes.GET_USERS_FULFILLED]: (state, payload) => ({
    ...state,
    loading: false,
    error: null,
    users: payload.data
  }),
  [actionTypes.GET_USERS_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload
  }),
  [actionTypes.ADD_PARENT_PENDING]: (state) => ({
    ...state,
    loading: true,
    error: null
  }),
  [actionTypes.ADD_PARENT_FULFILLED]: (state, payload) => ({
    ...state,
    loading: false,
    error: null,
    currentParent: payload.data
  }),
  [actionTypes.ADD_PARENT_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload
  }),
}

const userActions = {
  signIn:(payload) => {
    store.dispatch({
      type: actionTypes.SIGN_IN_PENDING,
      payload
    })
  },
  addParent: (payload) => (entity) => {
    console.log(entity);
    // mapping
    const parent = {
      userId: entity.parentId,
      userPassword: entity.password,
      userTypeId: 3, // Parent User Type
      _parent: {
        parentId: entity.parentId,
        fName: entity.fName,
        mName: entity.mName,
        gName: entity.gName,
        lName: entity.lName,
        idType: entity.idType,
        idExpireDateG: (entity.idExpireDate)? entity.idExpireDate.idExpireDateG: '',
        idExpireDateH: (entity.idExpireDate)? entity.idExpireDate.idExpireDateH: '',
        mobile1: entity.mobile,
        email: entity.email,
        countryId: entity.countryId
      }
    };
    // dispatch
    store.dispatch({
      type: actionTypes.ADD_PARENT_PENDING,
      payload: { req: [payload.method,payload.url, parent] }
    })
  },
  getUsers:(payload) => {
    // dispath only when users is empty
    const {user: {users}} = store.getState();
    if(!users.length) {
        store.dispatch({
        type: actionTypes.GET_USERS_PENDING,
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