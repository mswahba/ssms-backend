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
  top: 1.1rem !important;
`
const CEOSection = styled.section`
  background-color: var(--third-bg-color) !important;
`
const CEOCard = styled.div`
  background-color: transparent !important;
  color: ${ ({ isSection }) => isSection ? 'var(--third-fr-color)' : 'inherit' };
`
const CEOTitle = styled.span`
  color: ${ ({ isSection }) => isSection ? 'var(--third-fr-color)' : 'var(--main-bg-color)' };
  font-weight: 600 !important;
`

function CEOMessageWrapper({ isSection, children }) {
  return (
    (isSection)
      ? <CEOSection>{children}</CEOSection>
      : <>{children}</>
  )
}

function CEOMessage({ isSection, lang, aboutTitleAr, aboutTitleEn, aboutTextAr, aboutTextEn, photoURL }) {
  return (
    <CEOCard isSection={isSection} className="card">
      <div className="card-image flex-center">
        <CEOImg src={photoURL} />
      </div>
      <div className="card-content center-align">
        <CEOTitle isSection={isSection} className="card-title">{lang === 'ar' ? aboutTitleAr : aboutTitleEn}</CEOTitle>
        <p className='content-text'>{lang === 'ar' ? aboutTextAr : aboutTextEn}</p>
      </div>
    </CEOCard>
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
            ? <CEOMessage lang={lang} isSection={isSection} {...data} />
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
