
import { store } from '../AppStore'

const lookup = [
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

const lookupState = lookup.reduce((acc,key) => {
  acc[key] = []
  return acc;
} ,{})

const initialState = {
  loading: false,
  error: '',
  ...lookupState
}

const actionTypes = {
  GET_EDUASSETS_LOOK_UP: "GET_EDUASSETS_LOOK_UP",
  GET_EDUASSETS_LOOK_UP_PENDING: "GET_EDUASSETS_LOOK_UP_PENDING",
  GET_EDUASSETS_LOOK_UP_FULFILLED: "GET_EDUASSETS_LOOK_UP_FULFILLED",
  GET_EDUASSETS_LOOK_UP_REJECTED: "GET_EDUASSETS_LOOK_UP_REJECTED"
}

const updater = {
  [actionTypes.GET_EDUASSETS_LOOK_UP_PENDING]: (state) => ({
    ...state,
    loading: true
  }),
  [actionTypes.GET_EDUASSETS_LOOK_UP_FULFILLED]: (state, payload) => {
    const lookupNewState = lookup.reduce((acc,key) => {
      if(payload[key])
        acc[key] = payload[key]
      return acc;
    } ,{})
    return {
      ...state,
      ...lookupNewState,
      loading: false
    }
  },
  [actionTypes.GET_EDUASSETS_LOOK_UP_REJECTED]: (state, payload) => ({
    ...state,
    error: payload.response.data,
    loading: false
  })
}

const eduAssetsActions = {
  getEduAssetsLookUp: (payload) => {
    store.dispatch({
      type: actionTypes.GET_EDUASSETS_LOOK_UP,
      payload
    })
  }
}

const stateKey = 'eduAssets';

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
  eduAssetsActions,
  stateKey,
  reducer as default
}