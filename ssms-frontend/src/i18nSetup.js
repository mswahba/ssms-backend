import i18n from 'i18next'
import Backend from 'i18next-xhr-backend'
import { initReactI18next } from 'react-i18next'

i18n
	.use(Backend)
	.use(initReactI18next)
	.init({
		debug: true,
		lng: 'ar',
		fallbackLng: 'en',
		whitelist: ['ar', 'en'],
		backend: {
			loadPath: '/locales/{{lng}}/{{ns}}.json'
		}
  })

export default i18n
