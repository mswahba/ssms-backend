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

const methods = {
  GET_EDUASSETS_LOOK_UP_PENDING: (state) => ({
    ...state,
    loading: true
  }),
  GET_EDUASSETS_LOOK_UP_FULFILLED: (state, payload) => {
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
  GET_EDUASSETS_LOOK_UP_REJECTED: (state, payload) => ({
    ...state,
    error: payload,
    loading: false
  })
}

export const actionTypes = {
  GET_EDUASSETS_LOOK_UP: "GET_EDUASSETS_LOOK_UP",
  GET_EDUASSETS_LOOK_UP_PENDING: "GET_EDUASSETS_LOOK_UP_PENDING",
  GET_EDUASSETS_LOOK_UP_FULFILLED: "GET_EDUASSETS_LOOK_UP_FULFILLED",
  GET_EDUASSETS_LOOK_UP_REJECTED: "GET_EDUASSETS_LOOK_UP_REJECTED"
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
