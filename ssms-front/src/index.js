import React from "react";
import { render } from "react-dom";
import AppStore from "./AppStore";
import registerServiceWorker from "./registerServiceWorker";
import M from "materialize-css";
import axios from "axios";
// for primereact css styles
import "primereact/resources/primereact.min.css";
import "primereact/resources/themes/omega/theme.css";

axios.defaults.baseURL = "http://localhost:5000";
M.AutoInit();
render( <AppStore /> , document.getElementById("root") );
registerServiceWorker();