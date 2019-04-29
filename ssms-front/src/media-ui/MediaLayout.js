import React from 'react'
import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import Header from './Header'
import MediaRoutes from './MediaRoutes'
import Home from './home/Home'
import Sections from './Sections'
import Facilities from './Facilities'
import Admission from './Admission'
import VisionMission from './about/VisionMission'
import SupervisorMessage from './about/SupervisorMessage'
import SchoolHistory from './about/SchoolHistory'
import OrganizationalStructure from './about/OrganizationalStructure'
import Footer from './Footer'
import './media-ui.css'

function MediaLayout ({ trans, lang }) {
  const defaultPath = '/home'
  const navTitle = { path: '/home', text: trans("home.title") }
  const navLinks = [
    { path: '/home', text: trans('home.nav.home'), icon: 'fas fa-home', component: Home },
    { path: '/sections', text: trans('home.nav.sections'), icon: 'fas fa-landmark', component: Sections },
    { path: '/facilities', text: trans('home.nav.facilities'), icon: 'fas fa-flask', component: Facilities },
    { path: '/admission', text: trans('home.nav.admission'), icon: 'fas fa-check-circle', component: Admission },
    {
      id: 'about-dropdown',
      icon: 'fas fa-info-circle',
      text: trans('home.nav.about'),
      path: '/about',
      children: [
        { path: '/about/vision-mission', text: trans("home.nav.visionMission"), component: VisionMission },
        { path: '/about/supervisor-message', text: trans("home.nav.supervisorMessage"), component: SupervisorMessage },
        { path: '/about/school-history', text: trans("home.nav.schoolHistory"), component: SchoolHistory },
        { path: '/about/organizational-structure', text: trans("home.nav.organizationalStructure"), component: OrganizationalStructure },
      ]
    },
  ]
  return (
    <div className='rtl'>
      <Header navTitle={navTitle} navLinks={navLinks} lang={lang} defaultPath={defaultPath} />
      <MediaRoutes navLinks={navLinks} defaultPath={defaultPath} />
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
