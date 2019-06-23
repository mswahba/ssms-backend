import React from 'react'
import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import { initSlider, getSlider } from '../../helpers'
import { useFetch } from '../../customHooks'

// the heroSlider materialize-css instance
let heroSlider
const captionAligns = [
  'left-align',
  'center-align',
  'right-align'
]
// the slides data
// const _slides = [
//   {
//     photoURL: 'https://lorempixel.com/580/250/nature/1',
//     captionAlign: 'left-align',
//     title: 'Left Aligned Caption',
//     description: `Here's our small slogan.`
//   },
//   {
//     photoURL: 'https://lorempixel.com/580/250/nature/2',
//     captionAlign: 'center-align',
//     title: 'This is our big Tagline!',
//     description: `Here's our big slogan.`
//   },
//   {
//     photoURL: 'https://lorempixel.com/580/250/nature/3',
//     captionAlign: 'center-align',
//     title: 'This is our small Tagline!',
//     description: `Here's our small slogan.`
//   },
//   {
//     photoURL: 'https://lorempixel.com/580/250/nature/4',
//     captionAlign: 'right-align',
//     title: 'Right Aligned Caption',
//     description: `Here's our small slogan.`
//   }
// ]

// to move slides based on [lang, direction] using heroSlider instance [next(), prev()]
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
// render the slides data
const renderSlides = (lang, slides) => {
  return slides.map( (slide, i) => (
    <li key={i+1}>
      <img src={slide.photoURL} />
      <div className={`caption ${captionAligns[Number.between(0,2)]}`}>
        <h3>
          {(lang === 'ar')? slide.photoTitleAr : slide.photoTitleEn}
        </h3>
        <h5 className='light grey-text text-lighten-3'>
          {(lang === 'ar')? slide.descriptionAr : slide.descriptionEn}
        </h5>
      </div>
    </li>
  ))
}
// HeroSlider component
function HeroSlider ({ trans, lang }) {
  // const [slides, setSlides] = React.useState(_slides)
  const { loading, error, data: slides } = useFetch({
    requestId: 'hero_slider',
    request: ['get', '/photos?filters=approved|=|1,enabled|=|1,albumId|=|1'],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: 'hero_slides'
  })

  React.useEffect(() => {
    if(slides) {
      initSlider()
      heroSlider = getSlider('hero-slider');
    }
  }, [slides])

  if(loading)
    return (
      <div className="preloader-wrapper big active">
        <div className="spinner-layer spinner-blue">
          <div className="circle-clipper left">
            <div className="circle"></div>
          </div><div className="gap-patch">
            <div className="circle"></div>
          </div><div className="circle-clipper right">
            <div className="circle"></div>
          </div>
        </div>
      </div>
    )

  else if (error)
    return <div className="card-panel red lighten-4">{error}</div>

  else if (slides)
    return (
      <div id='hero-slider' className='slider'>
        <ul className='slides'>
          {renderSlides(lang, slides)}
        </ul>
        <div className='slider-buttons'>
          <i className='material-icons forward'   onClick={moveSlider(lang, 'forward')}>arrow_forward_ios</i>
          <i className='material-icons backward'  onClick={moveSlider(lang, 'backward')}>arrow_back_ios</i>
        </div>
      </div>
    )

  return null;
}
// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(HeroSlider);
