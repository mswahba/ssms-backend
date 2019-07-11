import React from 'react'
import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'

import { navLinks, routes } from './routes'

import Header from './Header'
import MediaRoutes from './MediaRoutes'
import Footer from './Footer'
import './media-ui.css'

function MediaLayout ({ trans, lang }) {
  const defaultPath = '/home'
  const navTitle = { path: '/home', text: trans("home.title") }

  return (
    <div className='rtl'>
      <Header navTitle={navTitle} navLinks={navLinks(trans)} lang={lang} defaultPath={defaultPath} />
      <MediaRoutes navLinks={routes(trans)} defaultPath={defaultPath} />
      <Footer />
    </div>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(MediaLayout);
