import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled from 'styled-components'

import { useFetch } from '../../customHooks'
import { time } from '../../helpers'

import Loading from '../../shared/Loading'

const key = 'vision_mission_objectives'
const endpoint = '/abouts/find/2,3,4'

const itemIcons = {
  Vision: 'far fa-lightbulb',
  Mission: 'fas fa-chart-line',
  Objectives: 'fas fa-bullseye'
}
const itemColors = {
  Vision: '#3949ab',
  Mission: '#283593',
  Objectives: '#1a237e'
}

const CollectionItem = styled.li`
  background-color: ${ ({ title }) => itemColors[title] } !important;
  color: #fff !important;
`
const ItemIcon = styled.i`
  font-size: 2.4rem !important;
  background-color: #fff !important;
  color: ${ ({ title }) => itemColors[title] } !important;
`
const ItemTitle = styled.span`
  font-size: 1.5rem;
  font-weight: 600;
  color: #fffc00;
`
const ItemText = styled.p`
  font-size: 1.2rem;
  line-height: 2.2rem;
`

function VMOItem({ lang, aboutTitleAr, aboutTitleEn, aboutTextAr, aboutTextEn }) {
  return (
    <CollectionItem title={aboutTitleEn} className='collection-item avatar flex'>
      <ItemIcon title={aboutTitleEn} className={`${itemIcons[aboutTitleEn]} circle`}></ItemIcon>
      <div>
        <ItemTitle>{lang === 'ar' ? aboutTitleAr : aboutTitleEn}</ItemTitle>
        <ItemText>{lang === 'ar' ? aboutTextAr : aboutTextEn}</ItemText>
      </div>
    </CollectionItem>
  )
}

function VisionMissionObjectives({ trans, lang }) {
  // get vision_mission_objectives from LS OR Server
  const { loading, error, data } = useFetch({
    requestId: key,
    request: ['get', endpoint],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.day
  })
  return (
    <div className='row'>
      <h3 className='center-align head-color'>{trans("home.visionMissionObjectives.title")}</h3>
      { (loading)
        ? <Loading />
        : (error)
          ? <div className='card-panel red lighten-4'>{error}</div>
          : (data && data.length)
            ? <ul className={`collection b-0 col m10 ${lang === 'ar' ? 'pull' : 'push'}-m1`}>
                {data.map(item => <VMOItem key={item.aboutId} lang={lang} {...item} />)}
              </ul>
            : <div className='card-panel red lighten-4'>{trans("home.emptyData")}</div>
      }
    </div>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(VisionMissionObjectives)
