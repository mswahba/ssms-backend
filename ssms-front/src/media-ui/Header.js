import React from 'react'
import { Link, NavLink } from 'react-router-dom'
import { connect } from 'react-redux'
import { getTranslate } from 'react-localize-redux'
import { initSidenav, initDropdown } from '../helpers'

function Header({ trans }) {
  // after component mounted
  React.useEffect(() => {
    initSidenav();
    initDropdown();
  }, []);
  // render
  return (
    <div className="rtl">
      <div className="navbar-fixed">
        <nav>
          <div className="nav-wrapper">
            <Link to="/home" className="brand-logo">{trans("home.title")}</Link>
            <Link to="#!" data-target="mobile-nav" className="sidenav-trigger hide-on-large-only">
              <i className="material-icons">menu</i>
            </Link>
            <ul id="main-nav" className="hide-on-med-and-down left">
              <li><NavLink to="/home">{trans("home.nav.home")}</NavLink></li>
              <li>
                <a className="dropdown-trigger" data-target="about-dropdown">
                  <i className="material-icons left">arrow_drop_down</i>
                  {trans("home.nav.about")}
                </a>
              </li>
              <li><NavLink to="/sections">{trans("home.nav.sections")}</NavLink></li>
              <li><NavLink to="/facilities">{trans("home.nav.facilities")}</NavLink></li>
              <li><NavLink to="/admission">{trans("home.nav.admission")}</NavLink></li>
            </ul>
          </div>
        </nav>
      </div>
      <ul id="mobile-nav" className="sidenav">
        <li><NavLink to="/home">Home</NavLink></li>
        <li>
          <a className="dropdown-trigger" data-target="about-dropdown1">
            <i className="material-icons left">arrow_drop_down</i>
            {trans("home.nav.about")}
          </a>
        </li>
        <li><NavLink to="/sections">Sections</NavLink></li>
        <li><NavLink to="/facilities">Facilities</NavLink></li>
        <li><NavLink to="/admission">Admission</NavLink></li>
      </ul>
      <ul id="about-dropdown" className="dropdown-content">
        <li><NavLink to="#!">{trans("home.nav.visionMission")}</NavLink></li>
        <li className="divider"></li>
        <li><NavLink to="#!">{trans("home.nav.supervisorMessage")}</NavLink></li>
        <li className="divider"></li>
        <li><NavLink to="#!">{trans("home.nav.schoolHistory")}</NavLink></li>
        <li className="divider"></li>
        <li><NavLink to="#!">{trans("home.nav.organizationalStructure")}</NavLink></li>
        <li className="divider"></li>
      </ul>
      <ul id="about-dropdown1" className="dropdown-content">
        <li><NavLink to="#!">{trans("home.nav.visionMission")}</NavLink></li>
        <li className="divider"></li>
        <li><NavLink to="#!">{trans("home.nav.supervisorMessage")}</NavLink></li>
        <li className="divider"></li>
        <li><NavLink to="#!">{trans("home.nav.schoolHistory")}</NavLink></li>
        <li className="divider"></li>
        <li><NavLink to="#!">{trans("home.nav.organizationalStructure")}</NavLink></li>
      </ul>
    </div>
  )
}
// select the values needed form redux state
// get the translate function from localize
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize)
})
// connect the form with the redux state
export default connect(mapStateToProps)(Header);