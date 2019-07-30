import { useState, useEffect } from 'react'
import axios from 'axios'
import axiosCancel from 'axios-cancel'
import { toast } from 'react-toastify'
import LS from './localStorage'
import { time } from './helpers'

// set axios baseURL to server API URL
axios.defaults.baseURL = "http://localhost:5000";
// adds cancel method to the axios prototype
axiosCancel(axios);

// build request and send it to the server and return the data OR error
// and display the needed toast messages
async function _request(requestId, request, successToast, errorToast) {
  let allPromises = [],
    requestPromise = null;
  // build the ajax request promise
  if ( Array.isArray(request) && Array.isArray(request[0]) ) {
    allPromises = request.map(request => {
      const [ method, url, body = null ] = request;
      return axios[method](url, body);
    });
    requestPromise = axios.all(allPromises, { requestId });
  } else if ( Array.isArray(request) && typeof request[0] === 'string' ) {
    const [ method, url, body = {} ] = request;
    body.requestId = requestId;
    requestPromise = axios[method](url, body);
  }
  // send request
  try {
    const res = await requestPromise
    console.log("TCL: function_request -> res", res)
    if(res) {
      if(successToast && successToast.length)
        toast[successToast[0]](successToast[1]);
    }
    return { status: 'success', response: res }
  } catch(err) {
    if(errorToast && errorToast.length)
      toast[errorToast[0]](errorToast[1]);
    // The request was made and the server responded with a status code that falls out of the range of 2xx
    // error.response.data - error.response.status - error.response.headers
    if (err.response)
      return { status: 'error', response: err.response.data || err.response.status }
    // The request was made but no response was received
    // `error.request` is an instance of XMLHttpRequest in the browser and an instance of http.ClientRequest in node.js
    else if (err.request && Object.keys(err.request).length)
      return { status: 'error', response: err.request }
    // Something happened in setting up the request that triggered an Error
    else {
      let error = JSON.parse(JSON.stringify(err))
      return { status: 'error', response: error.message || 'Something went wrong!' }
    }
  }
}

async function getData({ requestId, request, localStorageKey, successToast, errorToast, timeout, setState }) {
  let data = null
  // setState to loading_state
  setState({ loading: true, error: null, data: null });
  // try get data from local storage
  data = LS.get(localStorageKey);
  // if there is stored data then check its timestamp
  // if the timestamp in the given timeout [not expired]
  // then setState to data_state
  if(data && (Date.now() - data.timestamp) < timeout )
    setState({ loading: false, error: null, data: data.data });
  else {
    // if there isn't stored data then request data from API
    const { status, response } = await _request(requestId, request, successToast, errorToast);
    // if the result has error then setState to error_state
    if (status === 'error')
      setState({ loading: false, error: response, data: null });
    // if the result has success
    else if (status === 'success') {
      // handle if sending multiple requests [response is Array]
      data = (Array.isArray(response))
        ? response.map(item => item.data)
        : response.data
      // store it in local storage
      if (localStorageKey)
        LS.set(localStorageKey, { data, timestamp: Date.now() });
      // setState to data_state
      setState({ loading: false, error: null, data });
    }
  }
};

export function useFetch({ requestId, request, localStorageKey, successToast = null, errorToast = null, timeout = time.day, deps = [] }) {
  const [state, setState] = useState({ loading: true, error: null, data: null });
  useEffect( () => {
    getData({ requestId, request, localStorageKey, successToast, errorToast, timeout, setState });
  }, deps);
  return state;
}
