import React from 'react'
import { Link, NavLink } from 'react-router-dom'
import styled from 'styled-components'
import { withLocalize } from 'react-localize-redux'

import { initSidenav, initDropdown } from '../helpers'
import { useFetch } from '../customHooks'
import { time } from '../helpers'

import Loading from '../shared/Loading'

const key = 'social_links'
const socialEndpoint = '/abouts?filters=schoolId|=|1,categoryId|=|7'

const getLinkIcon = (title) => {
  switch(title) {
    case 'Twitter':
      return 'fab fa-twitter-square'
    case 'Youtube':
      return 'fab fa-youtube'
    case 'Facebook':
      return 'fab fa-facebook-square'
    case 'Instagram':
      return 'fab fa-instagram'
    case 'Snapchat':
      return 'fab fa-snapchat-square'
    default:
      return '';
  }
}

//#region styled components
const NavWrapper = styled.nav`
  height: 100px;
  line-height: 50px;
`
const LogoImg = styled.img`
  display: block;
  margin: 0 15%;
  width: 70%;
`
const LogoText = styled.span`
  font-size: 1.8rem;
  position: relative;
  top: -1rem;
`
const NavLinksContainer = styled.div( ({ lang }) => ({
  width: '80%',
  position: 'absolute',
  [lang === 'ar' ? 'left' : 'right']: 0,
}))

const NavItemsWrapper = styled.ul`
  height: 50%;
`
const NavDropdown = styled.ul`
  min-width: 30% !important;
`
const NavDropdownItem = styled.li`
  margin: ${({ lang }) => lang === 'ar' ? "0 -1rem 0 0" : "0 0 0 -1rem"};
`
const NavLinkIcon = styled.i`
  line-height: 50px !important;
`
const SocialIcon = styled.i`
  height: auto !important;
  line-height: inherit !important;
  font-size: 2rem;
  color: #eaeaea !important;
  transition: transform 0.2s ease-out;
  &:hover {
    transform: scale(1.3);
  }
`
//#endregion

function SocialLink({ lang, aboutTitleAr, aboutTitleEn, aboutTextEn }) {
  return (
    <li className='h-100 flex-center'>
      <a className='h-100 flex-center' href={aboutTextEn} target='_blank'>
        <SocialIcon
          title={lang === 'ar' ? aboutTitleAr : aboutTitleEn}
          className={getLinkIcon(aboutTitleEn)}
        />
      </a>
    </li>
  )
}

function TopNavLinks ({ lang, setActiveLanguage }) {
  // get social links from LS OR Server
  const { loading, error, data } = useFetch({
    requestId: key,
    request: ['get', socialEndpoint],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.day
  })
  return (
    <li className='w-100 h-100 flex-between'>
      <ul className='flex-b-25 h-100'>
        <li className='h-100 flex-center'
          onClick={ _ => void setActiveLanguage( lang === 'ar' ? 'en' : 'ar') }
        >
          <a className='h-100 flex-center'>
            <i className={`flag-icon flag-icon-${lang === 'ar' ? 'sa' : 'us'}`}></i>
            <span className={lang === 'ar' ? 'mr-1' : 'ml-1'}>
              {lang === 'ar' ? 'العربية' : 'English'}
            </span>
          </a>
        </li>
      </ul>
      <ul className='flex-b-70'>
        { (loading)
            ? <Loading />
            : (data)
              ? data.map(link => <SocialLink key={link.aboutId} lang={lang} {...link} />)
              : null
        }
      </ul>
    </li>
  )
}

function NavLinks ({ id, className, lang, navLinks, activeLink, setActiveLink, setActiveLanguage }) {
  return (
    <NavLinksContainer className='h-100' lang={lang}>
      <NavItemsWrapper id={id} className={className}>
        <TopNavLinks lang={lang} setActiveLanguage={setActiveLanguage} />
        {navLinks.map((link, i) => (
          <li key={i + 1} className={`h-100 ${activeLink.includes(link.path) ? 'active' : ''}`}>
            {(link.component)
              ? <NavLink to={link.path} onClick={() => setActiveLink(link.path)} >
                  <NavLinkIcon className={`${link.icon} right`}></NavLinkIcon>
                  {link.text}
                </NavLink>
              : <a data-target={ (id === 'main-nav')? link.id+'-main' : link.id+'-mobile' } className="dropdown-trigger">
                  <NavLinkIcon className={`${link.icon} right`}></NavLinkIcon>
                  {link.text}
                  <NavLinkIcon className="material-icons left">arrow_drop_down</NavLinkIcon>
                </a>
            }
          </li>
        ))}
      </NavItemsWrapper>
    </NavLinksContainer>
  )
}

function NavLinkDropdown ({ id, lang, link, activeLink, setActiveLink }) {
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

function NavSubLinks ({ lang, navLinks, activeLink, setActiveLink }) {
  const linksWithChildren = navLinks.filter( link => link.children && Array.isArray(link.children) )
  return linksWithChildren.map((link, index) => (
    <div key={index + 1} className="dropdown-contents">
      <NavLinkDropdown id='main' lang={lang} link={link} activeLink={activeLink} setActiveLink={setActiveLink} />
      <NavLinkDropdown id='mobile' lang={lang} link={link} activeLink={activeLink} setActiveLink={setActiveLink} />
    </div>
  ))
}

function Navbar({ navTitle, navLinks, lang, defaultPath, setActiveLanguage }) {
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
        <NavWrapper>
          <div className="nav-wrapper">
            <Link to={navTitle.path} className='brand-logo flex-column-center h-100'>
              <LogoImg src='/images/assadara_logo.png' alt={navTitle.text} />
              <LogoText>{navTitle.text}</LogoText>
            </Link>
            <a data-target="mobile-nav" className="sidenav-trigger hide-on-large-only"><i className="material-icons">menu</i></a>
            <NavLinks id="main-nav" className="hide-on-med-and-down left" lang={lang} navLinks={navLinks} activeLink={activeLink} setActiveLink={setActiveLink} setActiveLanguage={setActiveLanguage} />
          </div>
        </NavWrapper>
      </div>
      <NavLinks id="mobile-nav" className="sidenav" lang={lang} navLinks={navLinks} activeLink={activeLink} setActiveLink={setActiveLink} setActiveLanguage={setActiveLanguage} />
      <NavSubLinks lang={lang} navLinks={navLinks} activeLink={activeLink} setActiveLink={setActiveLink} />
    </>
  )
}

export default withLocalize(Navbar)
