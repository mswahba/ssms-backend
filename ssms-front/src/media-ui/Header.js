import React from 'react'
import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import Navbar from '../shared/Navbar'

function Header({ trans, lang }) {
  const navTitle = { path: '/home', text: trans("home.title") }
  const navLinks = [
    { path: '/home', text: trans("home.nav.home"), icon: 'fas fa-home' },
    {
      id: 'about-dropdown',
      icon: 'fas fa-info-circle',
      text: trans("home.nav.about"),
      children: [
        { path: '/about/visionMission', text: trans("home.nav.visionMission") },
        { path: '/about/visionMission', text: trans("home.nav.supervisorMessage") },
        { path: '/about/visionMission', text: trans("home.nav.schoolHistory") },
        { path: '/about/visionMission', text: trans("home.nav.organizationalStructure") },
      ]
    },
    { path: '/sections', text: trans("home.nav.sections"), icon: 'fas fa-landmark' },
    { path: '/facilities', text: trans("home.nav.facilities"), icon: 'fas fa-flask' },
    { path: '/admission', text: trans("home.nav.admission"), icon: 'fas fa-check-circle' },
  ]
  return (
    <div className="rtl">
      <Navbar navTitle={navTitle} navLinks={navLinks} lang={lang} />
    </div>
  )
}
// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(Header);
