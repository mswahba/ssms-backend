import axios from "axios";
// set axios baseURL to server API URL
axios.defaults.baseURL = "http://localhost:5000";
// the default axios method
export const axiosOne = (method, url, payload) => axios[method](url,payload)
// the axios all method
export const axiosAll = (requests) => axios.all(requests)