import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled, { css } from 'styled-components'

import { useFetch } from '../../customHooks'
import { time } from '../../helpers'

import Loading from '../../shared/Loading'

const key = 'vision_section'
const endpoint = '/abouts/find/2,3'

// #region styled components
const Section = styled.section`
  padding: 4rem 2rem 1rem;
  background-color: var(--third-bg-color);
`
const CardContainer = styled.div`
  position: relative;
  @media (max-width: 992px) {
    margin-bottom: 1rem;
  }
`
const transform = ({ dir }) => dir === 'start' ? css`skewX(15deg)` : css`skewX(-15deg)`

const BackCard = styled.div`
  width: 95%;
  height: 10rem;
  background-color: var(--second-bg-color);
  position: absolute;
  transform: ${transform};
`
const FrontCard = styled.div`
  width: 85%;
  height: 155px;
  padding: 0.8rem;
  text-align: justify;
  background-color: var(--third-fr-color) !important;
  color: var(--second-bg-color) !important;
  position: absolute;
  top: -2rem;
  left: ${({ dir, lang }) =>
    lang === 'ar'
      ? "auto"
      : dir === 'start'
        ? "0"
        : "4rem"
  };
  right: ${({ dir, lang }) =>
    dir === 'start'
      ? lang === 'ar'
        ? "1.3rem"
        : "auto"
      : lang === 'ar'
        ? "3.3rem"
        : "auto"
  };
  transform: ${transform};
`
const FrontCardText = styled.p`
  margin: 0;
  line-height: 1.5rem;
`
const CardIcon = styled.i`
  background-color: var(--third-bg-color);
  font-size: 3rem !important;
  color: var(--second-bg-color);
  border-radius: 100%;
  padding: 1rem;
  width: 5rem;
  height: 5rem;
  text-align: center;
  position: absolute;
  top: 45%;
  right: ${({ dir, lang }) => dir === 'start' && lang === 'ar' ? "auto" : "-1.5rem"
  };
  left: ${({ dir, lang }) =>
  dir === 'start'
    ? lang === 'ar'
      ? "-1.5rem"
      : "auto"
    : lang === 'ar'
      ? "auto"
      : "-1.5rem"
  };
  transform: translateY(-50%);
  z-index: 99;
`
//#endregion

function VisionMission({ lang, vision, mission }) {
  return (
    <>
      <CardContainer className='col l5 m12'>
        <CardIcon dir='start' lang={lang} className='far fa-lightbulb' />
        <BackCard dir='start' />
        <FrontCard dir='start' lang={lang} className='card'>
          <span className='card-title orange-text font-b-500 mb-1'>
            {lang === 'ar' ? vision.aboutTitleAr : vision.aboutTitleEn}
          </span>
          <FrontCardText>{lang === 'ar' ? vision.aboutTextAr : vision.aboutTextEn}</FrontCardText>
        </FrontCard>
      </CardContainer>
      <CardContainer className='col l2 m12'></CardContainer>
      <CardContainer className='col l5 m12'>
        <CardIcon dir='end' className='fas fa-chart-line' />
        <BackCard dir='end' />
        <FrontCard dir='end' lang={lang} className='card'>
          <span className='card-title orange-text font-b-500 mb-1'>
            {lang === 'ar' ? mission.aboutTitleAr : mission.aboutTitleEn}
          </span>
          <FrontCardText>{lang === 'ar' ? mission.aboutTextAr : mission.aboutTextEn}</FrontCardText>
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
