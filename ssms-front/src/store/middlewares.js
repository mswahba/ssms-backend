import logger from "redux-logger";
import axios from "axios";
import axiosCancel from "axios-cancel";

// set axios baseURL to server API URL
axios.defaults.baseURL = "http://localhost:5000";
// adds cancel method to the axios prototype
axiosCancel(axios);

const ajax = ({ dispatch }) => next => action => {
  let allPromises = [],
    requestPromise = null,
    request = null;
  if (action.payload && Array.isArray(action.payload.req)) {
    request = action.payload.req;
    // build the ajax requset promise
    if ( Array.isArray(request) && Array.isArray(request[0]) ) {
      allPromises = request.map(request => {
        const [ method, url, body = null ] = request;
        return axios[method](url, body);
      });
      requestPromise = axios.all(allPromises, { requestId: action.type });
    } else if ( Array.isArray(request) && typeof request[0] === 'string' ) {
      const [ method, url, body = {} ] = request;
      body.requestId = action.type;
      requestPromise = axios[method](url, body);
    }
    // send pending to store
    dispatch({type: action.type + '_PENDING'});
    if (!action.payload.afterFulfilled)
      requestPromise
        .then(res => {
          console.log('​---');
          console.log('​', res);
          console.log('​---');
          dispatch({ type: action.type + "_FULFILLED", payload: res });
        })
        .catch(res => {
          dispatch({ type: action.type + "_REJECTED", payload: res });
        });
    else
      requestPromise
        .then(res => {
          dispatch({ type: action.type + "_FULFILLED", payload: res });
          if ( action.payload.afterFulfilled && action.payload.afterFulfilled.length )
            action.payload.afterFulfilled.forEach(action => dispatch(action));
        })
        .catch(res => {
          dispatch({ type: action.type + "_REJECTED", payload: res });
        });
  }
  else
    next(action);
};

export const middlewares = [logger, ajax];