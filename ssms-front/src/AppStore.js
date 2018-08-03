import React, { Component } from 'react'
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import { getState, getActions } from './centralStore';

const { Provider, Consumer } = React.createContext();
class AppStore extends Component {
  // constructor(props) {
  //   super(props);
  //   console.log(this.getValue());
  //   console.log( ...Object.entries(getActions(this)).map(item => item[1]) )
  // }
  state = getState();
  getValue = () => ({
    ...this.state,
    ...getActions(this)
  });
  render() {
    return (
      <Provider value={ this.getValue() }>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </Provider>
    )
  }
}

export {
  Consumer,
  AppStore as default
};