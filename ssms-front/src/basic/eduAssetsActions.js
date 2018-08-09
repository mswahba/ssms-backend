import { store } from '../AppStore'
import { actionTypes } from './eduAssetsReducer'

export const getEduAssetsLookUp = (payload) => {
  store.dispatch({
    type: actionTypes.GET_EDUASSETS_LOOK_UP,
    payload
  })
}