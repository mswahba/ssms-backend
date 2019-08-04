import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled from 'styled-components'

import { useFetch } from '../../customHooks'
import { time } from '../../helpers'

import Loading from '../../shared/Loading'

const key = 'supervisor_message'
const endpoint = '/abouts/6'

const CEOImg = styled.img`
  width: 180px !important;
  height: 180px !important;
  border-radius: 100% !important;
`

function CEOMessageWrapper({ isSection, children }) {
  return (
    (isSection)
      ? <section>{children}</section>
      : <>{children}</>
  )
}

function CEOMessage({ trans, lang, aboutTitleAr, aboutTitleEn, aboutTextAr, aboutTextEn, photoURL }) {
  return (
    <div className="card">
      <div className="card-image flex-center">
        <CEOImg src={photoURL} />
      </div>
      <div className="card-content center-align">
        <span className="card-title">{lang === 'ar' ? aboutTitleAr : aboutTitleEn}</span>
        <p className='content-text'>{lang === 'ar' ? aboutTextAr : aboutTextEn}</p>
      </div>
    </div>
  )
}

function SupervisorMessage({ trans, lang, isSection }) {
  // get Supervisor Message from LS OR Server
  const { loading, error, data } = useFetch({
    requestId: key,
    request: ['get', endpoint],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.day
  })

  return (
    <CEOMessageWrapper isSection={isSection}>
      { (loading)
        ? <Loading />
        : (error)
          ? <div className='card-panel red lighten-4'>{error}</div>
          : (data)
            ? <CEOMessage trans={trans} lang={lang} {...data} />
            : <div className='card-panel red lighten-4'>{trans("home.news.emptyNews")}</div>
      }
    </CEOMessageWrapper>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(SupervisorMessage)
