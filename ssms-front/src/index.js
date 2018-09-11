// for react
import React from "react";
import { render } from "react-dom";
import AppStore from "./AppStore";
// others
import registerServiceWorker from "./registerServiceWorker";
import M from "materialize-css";
import addExtensions from './addExtensions';
// for primereact css styles
import "primereact/resources/primereact.min.css";
import "primereact/resources/themes/omega/theme.css";
// app styles
import "./app.css";

// AutoInit the Materialize component [which needs AutoInit]
M.AutoInit();
// add extension functions to the js base Types
addExtensions();
// render the react App
render( <AppStore /> , document.getElementById("root") );
// register service worker
registerServiceWorker();