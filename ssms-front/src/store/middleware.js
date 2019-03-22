import logger from "redux-logger";
import axios from "axios";
import axiosCancel from "axios-cancel";
import { toast } from 'react-toastify';
import LS from '../shared/localStorage';

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
    // build the ajax request promise
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
    // dispatch({type: action.type + '_PENDING'});
    requestPromise
      .then(res => {
        if(res) {
          // if localStorage key exists then save res.data to LS with that key
          if(action.payload.localStorage)
            LS.set(action.payload.localStorage, res.data);
          // dispatch action only when res in not null or undefined
          dispatch({ type: action.type.replace('_PENDING', '_FULFILLED') , payload: res });
          if(action.payload.fulfilledToast && action.payload.fulfilledToast.length)
            toast[action.payload.fulfilledToast[0]](action.payload.fulfilledToast[1]);
          if ( action.payload.afterFulfilled && action.payload.afterFulfilled.length )
            action.payload.afterFulfilled.forEach(action => dispatch(action));
        }
      })
      .catch(error => {
        // The request was made and the server responded with a status code that falls out of the range of 2xx
        // error.response.data - error.response.status - error.response.headers
        if (error.response) {
          dispatch({ type: action.type.replace('_PENDING', '_REJECTED'), payload: error.response.data || error.response.status });
          if(action.payload.errorToast && action.payload.errorToast.length)
            toast[action.payload.errorToast[0]](action.payload.errorToast[1]);
        }
        // The request was made but no response was received
        // `error.request` is an instance of XMLHttpRequest in the browser and an instance of http.ClientRequest in node.js
        else if (error.request)
          dispatch({ type: action.type.replace('_PENDING', '_REJECTED'), payload: error.request });
        // Something happened in setting up the request that triggered an Error
        // else
        console.log(error);
      });
  }
  next(action);
};

export const middleware = [logger, ajax];