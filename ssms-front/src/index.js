import React from "react";
import { render } from "react-dom";
import AppStore from "./AppStore";
import registerServiceWorker from "./registerServiceWorker";
import M from "materialize-css";
import axios from "axios";
import addExtensions from './addExtensions';
// for primereact css styles
import "primereact/resources/primereact.min.css";
import "primereact/resources/themes/omega/theme.css";

// set axios baseURL to server API URL
axios.defaults.baseURL = "http://localhost:5000";
// AutoInit the Materialize component [which needs AutoInit]
M.AutoInit();
// add extension functions to the js base Types
addExtensions();
// render the react App
render( <AppStore /> , document.getElementById("root") );
// register service worker
registerServiceWorker();