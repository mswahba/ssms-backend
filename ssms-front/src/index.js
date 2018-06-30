import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import M from 'materialize-css';
import axios from 'axios';

axios.defaults.baseURL = "http://localhost:5000"

M.AutoInit();

ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();
