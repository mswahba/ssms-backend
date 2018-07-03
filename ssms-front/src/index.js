import React from 'react';
import {render} from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import M from 'materialize-css';
import axios from 'axios';

axios.defaults.baseURL = "http://localhost:5000"

M.AutoInit();

render(<App />, document.getElementById('root'));

registerServiceWorker();
