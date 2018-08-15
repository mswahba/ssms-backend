import logger from 'redux-logger'

const promise = ({ dispatch }) => (next) => (action) => {
  if(action.payload &&
      ( action.payload instanceof Promise || action.payload.promise instanceof Promise )
    ) {
    dispatch({type: action.type + '_PENDING'});
    if(action.payload instanceof Promise)
      action.payload
            .then(res => {
              dispatch({type: action.type + '_FULFILLED', payload: res });
            })
            .catch(res => {
              dispatch({type: action.type + '_REJECTED', payload: res });
            })
    else
      action.payload.promise
            .then(res => {
              dispatch({type: action.type + '_FULFILLED', payload: res });
              if(action.payload.afterFulfilled && action.payload.afterFulfilled.length)
                action.payload.afterFulfilled.forEach(action => dispatch(action) );
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