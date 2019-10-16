import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled from 'styled-components'

import { useFetch } from '../../customHooks'
import { time } from '../../helpers'

import Loading from '../../shared/Loading'

const key = 'welcome_section'
const endpoint = '/abouts/1'

const WelcomeWrapper = styled.section`
  height: 300px;
`
const WelcomeCol = styled.section`
  padding: 0;
  height: 100%;
`
const WelcomeCard = styled.section`
  height: 100%;
  overflow: auto;
  margin: 0 !important;
`

function Welcome({ lang, aboutTitleAr, aboutTitleEn, aboutTextAr, aboutTextEn  }) {
  return (
    <>
      <WelcomeCol className='col l6 s12'>
        <WelcomeCard className='card scroll'>
          <div className='card-content'>
            <span className='card-title content-title'>{lang === 'ar' ? aboutTitleAr : aboutTitleEn}</span>
            <p className='content-text-sm'>{lang === 'ar' ? aboutTextAr : aboutTextEn}</p>
          </div>
        </WelcomeCard>
      </WelcomeCol>
      <div className='col l6 s12'>
        <iframe
          width='100%'
          height='300'
          frameBorder='0'
          src='https://www.youtube.com/embed/ZoNgUKLW4TQ'
          allow='accelerometer;autoplay;encrypted-media;gyroscope;picture-in-picture'
          allowFullScreen
        />
      </div>
    </>
  )
}

function WelcomeSection({ trans, lang }) {
  // get welcome from LS OR Server
  const { loading, error, data: welcome } = useFetch({
    requestId: key,
    request: ['get', endpoint],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.day
  })

  return (
    <WelcomeWrapper className="row">
      { (loading)
        ? <Loading />
        : (error)
          ? <div className='card-panel red lighten-4'>{error}</div>
          : (welcome)
            ? <Welcome lang={lang} {...welcome} />
            : <div className='card-panel red lighten-4'>{trans("home.news.emptyNews")}</div>
      }
    </WelcomeWrapper>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(WelcomeSection)
