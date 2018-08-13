import { store } from '../AppStore'

const lookup = ['docTypes','countries','jobs','departments'];

const lookupState = lookup.reduce((acc,key) => {
  acc[key] = []
  return acc;
} ,{})

const initialState = {
  loading: false,
  error: "",
  resKeys: [],
  ...lookupState
}

const actionTypes = {
  GET_SHARED_LOOK_UP: "GET_SHARED_LOOK_UP",
  GET_SHARED_LOOK_UP_PENDING: "GET_SHARED_LOOK_UP_PENDING",
  GET_SHARED_LOOK_UP_FULFILLED: "GET_SHARED_LOOK_UP_FULFILLED",
  GET_SHARED_LOOK_UP_REJECTED: "GET_SHARED_LOOK_UP_REJECTED",
  SET_RES_KEYS: "SET_RES_KEYS",
}

const updater = {
  [actionTypes.GET_SHARED_LOOK_UP_PENDING]: (state) => ({
    ...state,
    loading: true
  }),
  [actionTypes.GET_SHARED_LOOK_UP_FULFILLED]: (state, payload) => {
    const lookupNewState = state.resKeys.reduce((acc,key, i) => {
      acc[key] = payload[i].data
      return acc;
    } ,{})
    return {
      ...state,
      ...lookupNewState,
      loading: false
    }
  },
  [actionTypes.GET_SHARED_LOOK_UP_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload.response.data
  }),
  [actionTypes.SET_RES_KEYS]: (state,payload) => ({
    ...state,
    resKeys: payload
  })
}

const sharedActions = {
  getSharedLookUp: (payload) => {
    store.dispatch({
      type: actionTypes.GET_SHARED_LOOK_UP,
      payload
    })
  },
  setResKeys: (payload) => {
    store.dispatch({
      type: actionTypes.SET_RES_KEYS,
      payload
    })
  }
}

const stateKey = 'shared'

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
  sharedActions,
  stateKey,
  reducer as default
}