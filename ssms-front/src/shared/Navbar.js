import React from 'react'
import { Link, NavLink } from 'react-router-dom'
import { initSidenav, initDropdown } from '../helpers'

const renderNavLinks = (id, className, navLinks, activeLink, setActiveLink) => {
  return (
    <ul id={id} className={className}>
      {navLinks.map((link, i) => (
        <li key={i + 1} className={activeLink.includes(link.path) ? 'active' : ''}>
          {(link.path)
            ? <NavLink to={link.path} onClick={() => setActiveLink(link.path)} >
                <i className={`${link.icon} right`}></i>
                {link.text}
              </NavLink>
            : <a data-target={ (id === 'main-nav')? link.id+'-main' : link.id+'-mobile' } className="dropdown-trigger">
                <i className={`${link.icon} right`}></i>
                {link.text}
                <i className="material-icons left">arrow_drop_down</i>
              </a>
          }
        </li>
      ))}
    </ul>
  )
}

const renderNavSubLinks = (navLinks) => {
  const linksWithChildren = navLinks.filter( link => link.children && Array.isArray(link.children) )
  return linksWithChildren.map((link, index) => (
    <div key={index + 1} className="dropdown-contents">
      <ul id={`${link.id}-main`} className="dropdown-content">
        {link.children.map((item, i) => (
          <li key={i + 1}>
            <NavLink to={item.path}>
              <i className={`${item.icon || 'fas fa-file-alt'} right`}></i>
              {item.text}
            </NavLink>
          </li>
        ))}
      </ul>
      <ul id={`${link.id}-mobile`} className="dropdown-content">
        {link.children.map((item, i) => (
          <li key={i + 1}>
            <NavLink to={item.path}>
              <i className={`${item.icon || 'fas fa-file-alt'} right`}></i>
              {item.text}
            </NavLink>
          </li>
        ))}
      </ul>
    </div>
  ))
}

export default function Navbar({ navTitle, navLinks, lang }) {
  const [activeLink, setActiveLink] = React.useState(window.location.pathname)
  // after component mounted
  React.useEffect(() => {
    initSidenav({ edge: (lang === 'ar')? 'right' : 'left' });
    initDropdown();
  }, []);
  // render
  return (
    <>
      <div className="navbar-fixed">
        <nav>
          <div className="nav-wrapper">
            <Link to={navTitle.path} className="brand-logo">{navTitle.text}</Link>
            <a data-target="mobile-nav" className="sidenav-trigger hide-on-large-only"><i className="material-icons">menu</i></a>
            {renderNavLinks("main-nav", "hide-on-med-and-down left", navLinks, activeLink, setActiveLink)}
          </div>
        </nav>
      </div>
      {renderNavLinks("mobile-nav", "sidenav", navLinks, activeLink, setActiveLink)}
      {renderNavSubLinks(navLinks)}
    </>
  )
}
