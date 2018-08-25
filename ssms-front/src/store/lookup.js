import { store } from '../AppStore'

const allLookupKeys = [
  'docTypes',
  'countries',
  'jobs',
  'departments',
  'schools',
  'branches',
  'stages',
  'grades',
  'classrooms',
  'periods',
  'schoolDayEvents',
  'academicYears',
  'academicSemesters',
  'academicWeeks',
  'majors',
  'subjects',
  'gradesSubjects'
];

const lookupState = allLookupKeys.reduce((acc,key) => {
  acc[key] = []
  return acc;
} ,{})

const initialState = {
  loading: false,
  error: '',
  lookupKeys: [],
  lookupEntity: {},
  ...lookupState
}

const actionTypes = {
  SET_LOOKUP_KEYS: "SET_LOOKUP_KEYS",
  GET_LOOKUP_DATA_PENDING: "GET_LOOKUP_DATA_PENDING",
  GET_LOOKUP_DATA_FULFILLED: "GET_LOOKUP_DATA_FULFILLED",
  GET_LOOKUP_DATA_REJECTED: "GET_LOOKUP_DATA_REJECTED",
  SET_LOOKUP_ENTITY: "SET_LOOKUP_ENTITY"
}

const updater = {
  [actionTypes.SET_LOOKUP_KEYS]: (state,payload) => ({
    ...state,
    lookupKeys: payload
  }),
  [actionTypes.GET_LOOKUP_DATA_PENDING]: (state) => ({
    ...state,
    loading: true
  }),
  [actionTypes.GET_LOOKUP_DATA_FULFILLED]: (state, payload) => {
    const lookupNewState = state.lookupKeys.reduce((acc,key,i) => {
      (Array.isArray(payload))
        ? acc[key] = payload[i].data
        : acc[key] = payload.data;
      return acc;
    } ,{})
    return {
      ...state,
      ...lookupNewState,
      loading: false,
      error: null,
    }
  },
  [actionTypes.GET_LOOKUP_DATA_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload.response.data
  }),
  [actionTypes.SET_LOOKUP_ENTITY]: (state, payload) => {
    const entity = state[payload.lookupTable].find(item => item[payload.lookupKey] == payload.id)
    return {
      ...state,
      lookupEntity: entity
    }
  }
}

const lookupActions = {
  setLookupKeys: (payload) => {
    store.dispatch({
      type: actionTypes.SET_LOOKUP_KEYS,
      payload
    })
  },
  getLookupData: (payload) => {
    store.dispatch({
      type: actionTypes.GET_LOOKUP_DATA_PENDING,
      payload
    })
  },
  setLookupEntity: (payload) => {
    store.dispatch({
      type: actionTypes.SET_LOOKUP_ENTITY,
      payload
    })
  }
}

const stateKey = 'lookup'

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
  actionTypes as lookupActionTypes,
  lookupActions,
  stateKey,
  reducer as default
}