import React from 'react'
import { Link, NavLink } from 'react-router-dom'
import { initSidenav } from '../helpers'

export default function Header({}) {
  React.useEffect(() => {
    initSidenav();
  }, []);
  return (
    <>
      <div className="rtl navbar-fixed">
        <nav>
          <div className="nav-wrapper">
            <Link to="/home" className="brand-logo left">Logo</Link>
            <Link to="#!" data-target="mobile-nav" className="sidenav-trigger hide-on-large-only">
              <i className="material-icons">menu</i>
            </Link>
            <ul id="nav-mobile" className="hide-on-med-and-down">
              <li><NavLink to="/home">Home</NavLink></li>
              <li><NavLink to="/about">About</NavLink></li>
              <li><NavLink to="/sections">Sections</NavLink></li>
              <li><NavLink to="/facilities">Facilities</NavLink></li>
              <li><NavLink to="/admission">Admission</NavLink></li>
            </ul>
          </div>
        </nav>
      </div>
      <ul class="sidenav" id="mobile-nav">
        <li><NavLink to="/home">Home</NavLink></li>
        <li><NavLink to="/about">About</NavLink></li>
        <li><NavLink to="/sections">Sections</NavLink></li>
        <li><NavLink to="/facilities">Facilities</NavLink></li>
        <li><NavLink to="/admission">Admission</NavLink></li>
      </ul>
    </>
  )
}
