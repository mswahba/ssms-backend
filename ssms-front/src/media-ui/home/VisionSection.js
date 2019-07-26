import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled, { css } from 'styled-components'

import { useFetch } from '../../customHooks'
import { time } from '../../helpers'

import Loading from '../../shared/Loading'

const key = 'vision_section'
const endpoint = '/abouts/find/2,3'

const Section = styled.section`
  padding: 0 2rem;
`

const CardContainer = styled.div`
  position: relative;
  @media (max-width: 992px) {
    margin-bottom: 1rem;
  }
`

const transform = ({ dir }) =>
  dir === 'start'
    ? css`skewX(15deg)`
    : css`skewX(-15deg)`

const BackCard = styled.div`
  width: 95%;
  height: 10rem;
  background-color: #0044ff;
  position: absolute;
  transform: ${transform};
`
const FrontCard = styled.div`
  width: 85%;
  padding: 0.5rem;
  background-color: #b8e1ff !important;
  position: absolute;
  top: -2rem;
  left: ${({ dir }) => dir === "start" ? "auto" : "auto" };
  right: ${({ dir }) => dir === "start" ? "1.3rem" : "3.3rem" };
  transform: ${transform};
`
const CardIcon = styled.i`
  background-color: #b8e1ff;
  font-size: 3rem !important;
  color: #ff9900;
  border-radius: 100%;
  padding: 1rem;
  width: 5rem;
  height: 5rem;
  text-align: center;
  position: absolute;
  top: 45%;
  right: ${({ dir }) => dir === "start" ? "auto" : "-1.5rem" };
  left: ${({ dir }) => dir === "start" ? "-1.5rem" : "auto" };
  transform: translateY(-50%);
  z-index: 99;
`

function VisionMission({ trans, lang, vision, mission }) {
  return (
    <>
      <CardContainer className='col l5 m12'>
        <CardIcon dir='start' className='far fa-lightbulb' />
        <BackCard dir='start' />
        <FrontCard dir='start' className='card'>
          <span className='card-title'>
            {lang === 'ar' ? vision.aboutTitleAr : vision.aboutTitleEn}
          </span>
          <p style={{ lineHeight: '2.2rem' }}>{lang === 'ar' ? vision.aboutTextAr : vision.aboutTextEn}</p>
        </FrontCard>
      </CardContainer>
      <CardContainer className='col l2 m12'></CardContainer>
      <CardContainer className='col l5 m12'>
        <CardIcon dir='end' className='fas fa-chart-line' />
        <BackCard dir='end' />
        <FrontCard dir='end' className='card'>
          <span className='card-title'>
            {lang === 'ar' ? mission.aboutTitleAr : mission.aboutTitleEn}
          </span>
          <p style={{ lineHeight: '2.2rem' }}>{lang === 'ar' ? mission.aboutTextAr : mission.aboutTextEn}</p>
        </FrontCard>
      </CardContainer>
    </>
  )
}

function VisionSection({ trans, lang }) {
  // get Vision from LS OR Server
  const { loading, error, data } = useFetch({
    requestId: key,
    request: ['get', endpoint],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.day
  })

  return (
    <Section className="row">
      { (loading)
        ? <Loading />
        : (error)
          ? <div className='card-panel red lighten-4'>{error}</div>
          : (data && data.length)
            ? <VisionMission trans={trans} lang={lang} vision={data[0]} mission={data[1]} />
            : <div className='card-panel red lighten-4'>{trans("home.news.emptyNews")}</div>
      }
    </Section>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(VisionSection)
