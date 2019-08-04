import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled from 'styled-components'

import { useFetch } from '../../customHooks'
import { time } from '../../helpers'

import Loading from '../../shared/Loading'

const key = 'organizational_structure'
const endpoint = '/abouts/22'

function OSContent ({ lang, aboutTitleAr, aboutTitleEn, aboutTextAr, aboutTextEn }) {
  return (
    <>
      <h3 className='center-align'>{lang === 'ar' ? aboutTitleAr : aboutTitleEn}</h3>
      <img
        className='responsive-img'
        src={lang === 'ar' ? aboutTextAr : aboutTextEn}
        alt={lang === 'ar' ? aboutTitleAr : aboutTitleEn}
      />
    </>
  )
}

function OrganizationalStructure({ trans, lang }) {
  // get Organizational Structure from LS OR Server
  const { loading, error, data } = useFetch({
    requestId: key,
    request: ['get', endpoint],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.day
  })
  return (
    <>
      { (loading)
        ? <Loading />
        : (error)
          ? <div className='card-panel red lighten-4'>{error}</div>
          : (data)
            ? <OSContent lang={lang} {...data} />
            : <div className='card-panel red lighten-4'>{trans("home.news.emptyNews")}</div>
      }
    </>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(OrganizationalStructure)
