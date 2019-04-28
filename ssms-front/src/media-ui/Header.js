import React from 'react'
import Navbar from '../shared/Navbar'

function Header({ navTitle, navLinks, lang, defaultPath }) {
  return (
    <Navbar navTitle={navTitle} navLinks={navLinks} lang={lang} defaultPath={defaultPath} />
  )
}

export default Header
