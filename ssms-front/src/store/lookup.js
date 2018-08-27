import { store } from '../AppStore'

const lookupTables = [
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

const lookupState = lookupTables.reduce((acc,key) => {
  acc[key] = []
  return acc;
} ,{})

const initialState = {
  loading: false,
  error: '',
  selectedTables: [],
  selectedTable: {
    name: '',
    key: ''
  },
  lookupEntity: {},
  ...lookupState
}

const actionTypes = {
  //
  SET_SELECTED_TABLES: "SET_SELECTED_TABLES",
  //
  SET_SELECTED_TABLE: "SET_SELECTED_TABLE",
  //
  SET_LOOKUP_ENTITY: "SET_LOOKUP_ENTITY",
  //
  GET_LOOKUP_DATA_PENDING: "GET_LOOKUP_DATA_PENDING",
  GET_LOOKUP_DATA_FULFILLED: "GET_LOOKUP_DATA_FULFILLED",
  GET_LOOKUP_DATA_REJECTED: "GET_LOOKUP_DATA_REJECTED",
  //
  ADD_LOOKUP_ENTITY_PENDING: "ADD_LOOKUP_ENTITY_PENDING",
  ADD_LOOKUP_ENTITY_FULFILLED: "ADD_LOOKUP_ENTITY_FULFILLED",
  ADD_LOOKUP_ENTITY_REJECTED: "ADD_LOOKUP_ENTITY_REJECTED",
  //
  UPDATE_LOOKUP_ENTITY_PENDING: "UPDATE_LOOKUP_ENTITY_PENDING",
  UPDATE_LOOKUP_ENTITY_FULFILLED: "UPDATE_LOOKUP_ENTITY_FULFILLED",
  UPDATE_LOOKUP_ENTITY_REJECTED: "UPDATE_LOOKUP_ENTITY_REJECTED",
  //
  DELETE_LOOKUP_ENTITY_PENDING: "DELETE_LOOKUP_ENTITY_PENDING",
  DELETE_LOOKUP_ENTITY_FULFILLED: "DELETE_LOOKUP_ENTITY_FULFILLED",
  DELETE_LOOKUP_ENTITY_REJECTED: "DELETE_LOOKUP_ENTITY_REJECTED"
}

const updater = {
  [actionTypes.SET_SELECTED_TABLES]: (state,payload) => ({
    ...state,
    selectedTables: payload
  }),
  [actionTypes.SET_LOOKUP_ENTITY]: (state, payload) => {
    const entity = state[payload.lookupTable].find(item => item[payload.lookupKey] == payload.id)
    return {
      ...state,
      lookupEntity: entity
    }
  },
  [actionTypes.SET_SELECTED_TABLE]: (state,payload) => ({
    ...state,
    selectedTable: payload
  }),
  [actionTypes.GET_LOOKUP_DATA_PENDING]: (state) => ({
    ...state,
    loading: true,
    error: null
  }),
  [actionTypes.GET_LOOKUP_DATA_FULFILLED]: (state, payload) => {
    const lookupNewState = state.selectedTables.reduce((acc,key,i) => {
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
  [actionTypes.ADD_LOOKUP_ENTITY_PENDING]: (state) => ({
    ...state,
    loading: true,
    error: null
  }),
  [actionTypes.ADD_LOOKUP_ENTITY_FULFILLED]: (state, payload) => ({
    ...state,
    [state.selectedTable.name]: [...state[state.selectedTable.name],payload],
    loading: false,
    error: null,
  }),
  [actionTypes.GET_LOOKUP_DATA_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload.response.data
  }),
  [actionTypes.UPDATE_LOOKUP_ENTITY_PENDING]: (state) => ({
    ...state,
    loading: true,
    error: null
  }),
  [actionTypes.UPDATE_LOOKUP_ENTITY_FULFILLED]: (state, payload) => ({
    ...state,
    [state.selectedTable.name]: state[state.selectedTable.name].map(item => {
      if(item[state.selectedTable.key] == payload.data[state.selectedTable.key])
        return payload.data;
      return item;
    }),
    loading: false,
    error: null,
  }),
  [actionTypes.UPDATE_LOOKUP_ENTITY_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload.response.data
  }),
  [actionTypes.DELETE_LOOKUP_ENTITY_PENDING]: (state) => ({
    ...state,
    loading: true,
    error: null
  }),
  [actionTypes.DELETE_LOOKUP_ENTITY_FULFILLED]: (state, payload) => ({
    ...state,
    [state.selectedTable.name]: state[state.selectedTable.name].filter(item => item[state.selectedTable.key] != payload.data[state.selectedTable.key] ),
    loading: false,
    error: null,
  }),
  [actionTypes.DELETE_LOOKUP_ENTITY_REJECTED]: (state, payload) => ({
    ...state,
    loading: false,
    error: payload.response.data
  }),
}

const lookupActions = {
  setSelectedTables: (payload) => {
    store.dispatch({
      type: actionTypes.SET_SELECTED_TABLES,
      payload
    })
  },
  setSelectedTable: (payload) => {
    store.dispatch({
      type: actionTypes.SET_SELECTED_TABLE,
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
  },
  addLookupEntity: (payload) => {
    store.dispatch({
      type: actionTypes.ADD_LOOKUP_ENTITY_PENDING,
      payload
    })
  },
  updateLookupEntity: (payload) => {
    store.dispatch({
      type: actionTypes.UPDATE_LOOKUP_ENTITY_PENDING,
      payload
    })
  },
  deleteLookupEntity: (payload) => {
    store.dispatch({
      type: actionTypes.DELETE_LOOKUP_ENTITY_PENDING,
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