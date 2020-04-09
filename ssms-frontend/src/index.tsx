import React from 'react'
import { render } from 'react-dom'
import { BrowserRouter } from 'react-router-dom'

import { StylesProvider, ThemeProvider, jssPreset } from '@material-ui/styles'
import { createMuiTheme } from '@material-ui/core/styles'
import { create } from 'jss'
import rtl from 'jss-rtl'

import App from './App'
import './index.css'

import './i18nSetup'

const jss = create({ plugins: [...jssPreset().plugins, rtl()] })
const theme = createMuiTheme({ direction: 'rtl' })

render(
	<React.StrictMode>
		<BrowserRouter>
			<StylesProvider jss={jss}>
				<ThemeProvider theme={theme}>
					<React.Suspense fallback={null}>
						<App />
					</React.Suspense>
				</ThemeProvider>
			</StylesProvider>
		</BrowserRouter>
	</React.StrictMode>,
	document.getElementById('root')
)
