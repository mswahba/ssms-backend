import logger from 'redux-logger'

const promise = ({ dispatch }) => (next) => (action) => {
  if (action.payload instanceof Promise) {
    dispatch({type: action.type + '_PENDING'});
    action.payload
      .then(res => {
        dispatch({type: action.type + '_FULFILLED', payload: res });
        if(action.afterFulfilled && action.afterFulfilled.length)
          action.afterFulfilled.forEach(action => dispatch(action) );
      })
      .catch(res => {
        dispatch({type: action.type + '_REJECTED', payload: res });
      })
  }
  next(action);
}

export const middlewares = [
  logger,
  promise
]