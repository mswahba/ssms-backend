import React from 'react'
import { useTranslation } from 'react-i18next'

import { navLinks, routesList } from '../routesList'

import Header from './Header'
import MediaRoutes from './MediaRoutes'
import Footer from './Footer'

const defaultPath = '/home'

function MediaLayout() {
  const { t: trans, i18n } = useTranslation(['MediaHome'])
  return (
    <>
      <Header defaultPath={defaultPath} lang={i18n.language} trans={trans} navLinks={navLinks} />
      <MediaRoutes routesList={routesList(trans)} defaultPath={defaultPath} />
      <Footer />
    </>
  )
}

export default MediaLayout
