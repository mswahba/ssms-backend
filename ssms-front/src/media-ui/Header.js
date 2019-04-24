import React from 'react'
import { Link, NavLink } from 'react-router-dom'
import { initSidenav, initDropdown } from '../helpers'

export default function Header({}) {
  React.useEffect(() => {
    initSidenav();
    initDropdown();
  }, []);
  return (
    <div className="rtl">
      <div className="navbar-fixed">
        <nav>
          <div className="nav-wrapper">
            <Link to="/home" className="brand-logo left">Logo</Link>
            <Link to="#!" data-target="mobile-nav" className="sidenav-trigger hide-on-large-only">
              <i className="material-icons">menu</i>
            </Link>
            <ul id="nav-mobile" className="hide-on-med-and-down">
              <li><NavLink to="/home">Home</NavLink></li>
              <li>
                <a class="dropdown-trigger" data-target="about-dropdown">
                  About
                  <i class="material-icons right">arrow_drop_down</i>
                </a>
              </li>
              <li><NavLink to="/sections">Sections</NavLink></li>
              <li><NavLink to="/facilities">Facilities</NavLink></li>
              <li><NavLink to="/admission">Admission</NavLink></li>
            </ul>
          </div>
        </nav>
      </div>
      <ul class="sidenav" id="mobile-nav">
        <li><NavLink to="/home">Home</NavLink></li>
        <li>
          <a class="dropdown-trigger" data-target="about-dropdown1">
            About
            <i class="material-icons right">arrow_drop_down</i>
          </a>
        </li>
        <li><NavLink to="/sections">Sections</NavLink></li>
        <li><NavLink to="/facilities">Facilities</NavLink></li>
        <li><NavLink to="/admission">Admission</NavLink></li>
      </ul>
      <ul id="about-dropdown" class="dropdown-content">
        <li><a href="#!">Vision & Mission</a></li>
        <li class="divider"></li>
        <li><a href="#!">General Supervisor's Message</a></li>
        <li class="divider"></li>
        <li><a href="#!">Our School's History</a></li>
        <li class="divider"></li>
        <li><a href="#!">Organizational Structure</a></li>
        <li class="divider"></li>
      </ul>
      <ul id="about-dropdown1" class="dropdown-content">
        <li><a href="#!">Vision & Mission</a></li>
        <li class="divider"></li>
        <li><a href="#!">General Supervisor's Message</a></li>
        <li class="divider"></li>
        <li><a href="#!">Our School's History</a></li>
        <li class="divider"></li>
        <li><a href="#!">Organizational Structure</a></li>
        <li class="divider"></li>
      </ul>      
    </div>
  )
}
