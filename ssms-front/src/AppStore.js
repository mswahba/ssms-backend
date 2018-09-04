// React
import React from 'react'
// Redux And React-Redux
import { createStore, combineReducers, applyMiddleware } from 'redux'
import { composeWithDevTools } from 'redux-devtools-extension'
import { Provider } from 'react-redux'
import { middlewares } from './store/middlewares'
// i18n
import { LocalizeProvider, localizeReducer } from 'react-localize-redux'
import AppLocalize from './AppLocalize';

// #region import All Redux Reducers
// import all store reducers dynamically from './store' dir
const importAll = (r) => r.keys().map(r);
const allModules = importAll(require.context('./store', false, /\.js$/));
const allReducers = allModules
      .filter(_module => _module.middlewares === undefined)
      .reduce( (reducers, _module) => {
        reducers[_module.stateKey] = _module.default;
        return reducers;
      },{});
// add the loclize reducer
allReducers.localize = localizeReducer;
// #endregion

// #region Configure Redux Store
// combine multiple reducers
const rootReducer = combineReducers(allReducers);
// applying middleware chain functions
const middleware = applyMiddleware(...middlewares);
// define enhancers
const enhancers = composeWithDevTools(middleware);
// create the Redux Store
export const store = createStore(rootReducer, enhancers);
// #endregion

// create the AppStore Component
export default () => (
  <Provider store={store}>
    <LocalizeProvider store={store}>
      <AppLocalize />
    </LocalizeProvider>
  </Provider>
)