// React
import React from 'react'
import { BrowserRouter } from "react-router-dom";
// Redux And React-Redux
import { createStore, combineReducers, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import promise from 'redux-promise-middleware';
import { composeWithDevTools } from 'redux-devtools-extension'
// App Reducers
import { userReducer } from './store/user';
import { sharedReducer } from './store/shared';
import { eduAssetsReducer } from './store/eduAssets';
// App Routes Component
import AppRoutes from "./AppRoutes";
// combine multiple reducers
const rootReducer = combineReducers({
  user: userReducer,
  shared: sharedReducer,
  eduAssets: eduAssetsReducer
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
