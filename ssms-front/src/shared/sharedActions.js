import { store } from '../AppStore'
import { actionTypes } from './sharedReducer'

export const getSharedLookUp = (payload) => {
  store.dispatch({
    type: actionTypes.GET_SHARED_LOOK_UP,
    payload
  })
}