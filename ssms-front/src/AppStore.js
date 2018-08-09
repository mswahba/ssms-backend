// React
import React from 'react'
import { BrowserRouter } from "react-router-dom";
import AppRoutes from "./AppRoutes";
// Redux And React-Redux
import { createStore, combineReducers, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import promise from 'redux-promise-middleware';
import { composeWithDevTools } from 'redux-devtools-extension'
// App Reducers
import user from './users/userReducer';
import shared from './shared/sharedReducer';
import eduAssets from './basic/eduAssetsReducer';

// combine multiple reducers
const rootReducer = combineReducers({
  user,
  shared,
  eduAssets
})
// applying middleware chain functions
const middleware = applyMiddleware(promise())
// define enhancers
const enhancers = composeWithDevTools(
  middleware
  // other store enhancers if any
);
// create the Redux Store
export const store = createStore(rootReducer, enhancers)
// create the AppStore Component
export default () => (
  <Provider store={store}>
    <BrowserRouter>
      <AppRoutes />
    </BrowserRouter>
  </Provider>
)
