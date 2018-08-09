// React
import React from 'react'
import { BrowserRouter } from "react-router-dom";
import App from "./App";
// Redux And React-Redux
import { createStore, combineReducers, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import promise from 'redux-promise-middleware';
// App Reducers
import user from './users/usersReducer';
import shared from './shared/sharedReducer';
import eduAssets from './basic/eduAssetsReducer';

const rootReducer = combineReducers({
  user,
  shared,
  eduAssets
})

const middleware = applyMiddleware(promise())

export const store = createStore(rootReducer, middleware)

export default () => (
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>
)
