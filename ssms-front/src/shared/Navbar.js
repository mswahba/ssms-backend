import React from 'react'
import { Link, NavLink } from 'react-router-dom'
import styled from 'styled-components'

import { initSidenav, initDropdown } from '../helpers'

const NavDropdown = styled.ul`
  min-width: 30% !important;
`
const NavDropdownItem = styled.li`
  margin: ${({ lang }) => lang === 'ar' ? "0 -1rem 0 0" : "0 0 0 -1rem"};
`

const renderNavLinks = (id, className, navLinks, activeLink, setActiveLink) => {
  return (
    <ul id={id} className={className}>
      {navLinks.map((link, i) => (
        <li key={i + 1} className={activeLink.includes(link.path) ? 'active' : ''}>
          {(link.component)
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

const renderDropdown = (link, id, activeLink, setActiveLink, lang) => {
  return (
    <NavDropdown id={`${link.id}-${id}`} className="dropdown-content">
      {link.children.map((item, i) => (
        <NavDropdownItem
          key={i + 1}
          lang={lang}
          className={activeLink.includes(item.path) ? 'active' : ''}>
          <NavLink to={item.path} onClick={() => setActiveLink(item.path)}>
            <i className={`${item.icon || 'fas fa-file-alt'} right`}></i>
            {item.text}
          </NavLink>
        </NavDropdownItem>
      ))}
    </NavDropdown>
  )
}

const renderNavSubLinks = (lang, navLinks, activeLink, setActiveLink) => {
  const linksWithChildren = navLinks.filter( link => link.children && Array.isArray(link.children) )
  return linksWithChildren.map((link, index) => (
    <div key={index + 1} className="dropdown-contents">
      { renderDropdown(link, 'main', activeLink, setActiveLink, lang) }
      { renderDropdown(link, 'mobile', activeLink, setActiveLink, lang) }
    </div>
  ))
}

function Navbar({ navTitle, navLinks, lang, defaultPath }) {
  const [activeLink, setActiveLink] = React.useState(defaultPath)
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
      {renderNavSubLinks(lang, navLinks, activeLink, setActiveLink)}
    </>
  )
}

export default Navbar
