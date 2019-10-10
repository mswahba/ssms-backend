import React from 'react'
import Navbar from '../shared/Navbar'

function Header({ navTitle, navLinks, lang, trans, defaultPath }) {
  return (
    <header>
      <Navbar navTitle={navTitle} navLinks={navLinks} lang={lang} trans={trans} defaultPath={defaultPath} />
    </header>
  )
}

export default Header
