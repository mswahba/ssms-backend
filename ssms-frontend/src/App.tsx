import React from 'react'
import { Switch, Route } from 'react-router-dom'

import { ToastContainer } from 'react-toastify'
import '../node_modules/react-toastify/dist/ReactToastify.min.css'

import LMSLayout from './lms-ui/LMSLayout'
import MediaLayout from './media-ui/MediaLayout'

function App() {
	return (
		<>
			<Switch>
				{/* LMS Site */}
				<Route path="/lms" component={LMSLayout} />
				{/* Media Site */}
				<Route path="/" component={MediaLayout} />
			</Switch>
			<ToastContainer autoClose={5000} pauseOnFocusLoss={true} />
		</>
	)
}

export default App
