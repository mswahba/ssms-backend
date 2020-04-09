import React from 'react'
import { render } from 'react-dom'
import { BrowserRouter } from 'react-router-dom'

import App from './App'
import './index.css'

import './i18nSetup'

render(
	<React.StrictMode>
		<BrowserRouter>
			<React.Suspense fallback={null}>
				<App />
			</React.Suspense>
		</BrowserRouter>
	</React.StrictMode>,
	document.getElementById('root')
)
