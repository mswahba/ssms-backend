// React
import React from 'react'
// Redux And React-Redux
import { createStore, combineReducers, applyMiddleware } from 'redux'
import { composeWithDevTools } from 'redux-devtools-extension'
import { Provider } from 'react-redux'
import { middleware } from './store/middleware'
// i18n
import { LocalizeProvider, localizeReducer } from 'react-localize-redux'
// redux form reducer
import { reducer as formReducer } from 'redux-form'
import AppLocalize from './AppLocalize';

// #region import All Redux Reducers
// import all store reducers dynamically from './store' dir
const importAll = (r) => r.keys().map(r);
const allModules = importAll(require.context('./store', false, /\.js$/));
const allReducers = allModules
      .filter(_module => _module.middleware === undefined)
      .reduce( (reducers, _module) => {
        reducers[_module.stateKey] = _module.default;
        return reducers;
      },{});
// add the localize reducer
allReducers.localize = localizeReducer;
// add the redux form reducer
allReducers.form = formReducer;
// #endregion

// #region Configure Redux Store
// combine multiple reducers
const rootReducer = combineReducers(allReducers);
// applying middleware chain functions
const allMiddleware = applyMiddleware(...middleware);
// define enhancers
const enhancers = composeWithDevTools(allMiddleware);
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