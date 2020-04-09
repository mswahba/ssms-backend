import React from 'react'
import { Switch, Route } from 'react-router-dom'

import { useTranslation } from 'react-i18next'
import { ToastContainer } from 'react-toastify'
import '../node_modules/react-toastify/dist/ReactToastify.min.css'

import styled from 'styled-components'

import LMSLayout from './lms-ui/LMSLayout'
import MediaLayout from './media-ui/MediaLayout'

const AppWrapper = styled.div`
	direction: ${ ({ lang }) => lang === 'ar' ? 'rtl' : 'ltr' };
`

function App() {
	const { t, i18n } = useTranslation(['AppRoot'])
	return (
		<AppWrapper lang={i18n.language}>
			<p>
				<button onClick={ _ => void i18n.changeLanguage( i18n.language === 'ar' ? 'en' : 'ar') }>
					{t('AppRoot:changeLanguage', 'Missing Key')}
				</button>
			</p>
			<Switch>
				{/* LMS Site */}
				<Route path="/lms" component={LMSLayout} />
				{/* Media Site */}
				<Route path="/" component={MediaLayout} />
			</Switch>
			<ToastContainer autoClose={5000} pauseOnFocusLoss={true} />
		</AppWrapper>
	)
}

export default App
