import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled from 'styled-components'

import { initSlider, getSlider } from '../../helpers'
import { useFetch } from '../../customHooks'
import Loading from '../../shared/Loading';

//#region styled components
const Slides = styled.ul`
  height: 100% !important;
`
const SlideCaption = styled.div`
  background-color: rgba(0,0,0,0.3);
  width: auto !important;
  padding: 1rem 2rem;
`
const CaptionTitle = styled.h3`
  margin: 0 0 0.5rem 0;
`
const SliderArrows = styled.div`
  z-index: 100;
  width: 100%;
  display: flex;
  justify-content: space-between;
  padding: 0 1.5rem;
  position: absolute;
  top: 50%;
  transform: translate(0, -80%);
  direction: ltr;
`
const SliderArrow = styled.i`
  font-size: 3.5rem !important;
  color: #fff !important;
  cursor: pointer !important;
`
//#endregion

//#region local variables heroSlider materialize-css instance
let heroSlider
const captionAligns = [
  'left-align',
  'center-align',
  'right-align'
]
//#endregion

//#region to move slides based on [lang, direction] using heroSlider instance [next(), prev()]
const moveSlider = (lang, dir) => (e) => {
  if (dir === 'backward')
    (lang === 'en')
      ? heroSlider.prev()
      : heroSlider.next()
  else if (dir === 'forward')
    (lang === 'ar')
      ? heroSlider.prev()
      : heroSlider.next()
}
//#endregion

//#region render the slides data
const renderSlides = (lang, slides) => {
  return slides.map( (slide, i) => (
    <li key={i+1}>
      <img src={slide.photoURL} />
      <SlideCaption className={`caption ${captionAligns[Number.between(0,2)]}`}>
        <CaptionTitle>
          {(lang === 'ar')? slide.photoTitleAr : slide.photoTitleEn}
        </CaptionTitle>
        <h5 className='light grey-text text-lighten-3'>
          {(lang === 'ar')? slide.descriptionAr : slide.descriptionEn}
        </h5>
      </SlideCaption>
    </li>
  ))
}
//#endregion

//#region HeroSlider component
function HeroSlider ({ trans, lang }) {
  // get slides from LS OR Server
  const { loading, error, data: slides } = useFetch({
    requestId: 'hero_slider',
    request: ['get', '/photos?filters=approved|=|1,enabled|=|1,albumId|=|1'],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: 'hero_slides'
  })

  React.useEffect(() => {
    if(slides && slides.length) {
      initSlider()
      heroSlider = getSlider('hero-slider');
    }
  }, [slides])

  if(loading)
    return <Loading />

  else if (error)
    return <div className="card-panel red lighten-4">{error}</div>

  else if (slides)
    return (
      <div id='hero-slider' className='slider'>
        <Slides className='slides'>
          {renderSlides(lang, slides)}
        </Slides>
        <SliderArrows>
          <SliderArrow className='material-icons backward' onClick={moveSlider(lang, 'backward')}>
            arrow_back_ios
          </SliderArrow>
          <SliderArrow className='material-icons forward' onClick={moveSlider(lang, 'forward')}>
            arrow_forward_ios
          </SliderArrow>
        </SliderArrows>
      </div>
    )

  return null;
}
//#endregion

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(HeroSlider);
