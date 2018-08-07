import React from 'react'
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import { createStore, combineReducers } from 'redux';
import { Provider } from 'react-redux';
import userReducer from './users/usersReducer';

const rootReducer = combineReducers({
  user: userReducer
})

const store = createStore(rootReducer)

export default () => (
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>
)
