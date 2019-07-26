import React from 'react'
import Navbar from '../shared/Navbar'

function Header({ navTitle, navLinks, lang, defaultPath }) {
  return (
    <header>
      <Navbar navTitle={navTitle} navLinks={navLinks} lang={lang} defaultPath={defaultPath} />
    </header>
  )
}

export default Header
