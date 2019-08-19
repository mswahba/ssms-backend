import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled from 'styled-components'

import { useFetch } from '../../customHooks'
import { time } from '../../helpers'

import Loading from '../../shared/Loading'

const key = 'fees'
const endpoint = '/abouts/26'

function FeesInner({ lang, aboutTitleAr, aboutTitleEn, aboutTextAr, aboutTextEn }) {
  return (
    <>
      <h2 className='center-align'>{lang === 'ar' ? aboutTitleAr : aboutTitleEn}</h2>
      <div className='content-text' dangerouslySetInnerHTML={{__html: lang === 'ar' ? aboutTextAr : aboutTextEn}}></div>
    </>
  )
}

function Fees({ lang, trans }) {
    // get Fees from LS OR Server
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
            ? <FeesInner lang={lang} {...data} />
            : <div className='card-panel red lighten-4'>{trans("home.emptyData")}</div>
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
export default connect(mapStateToProps)(Fees)
