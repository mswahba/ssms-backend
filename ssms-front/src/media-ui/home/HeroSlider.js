import React from 'react'
import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import { initSlider, getSlider } from '../../helpers'
// the heroSlider materialize-css instance
let heroSlider
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
// the slides data
const _slides = [
  {
    photoURL: 'https://lorempixel.com/580/250/nature/1',
    captionAlign: 'left-align',
    title: 'Left Aligned Caption',
    description: `Here's our small slogan.`
  },
  {
    photoURL: 'https://lorempixel.com/580/250/nature/2',
    captionAlign: 'center-align',
    title: 'This is our big Tagline!',
    description: `Here's our big slogan.`
  },
  {
    photoURL: 'https://lorempixel.com/580/250/nature/3',
    captionAlign: 'center-align',
    title: 'This is our small Tagline!',
    description: `Here's our small slogan.`
  },
  {
    photoURL: 'https://lorempixel.com/580/250/nature/4',
    captionAlign: 'right-align',
    title: 'Right Aligned Caption',
    description: `Here's our small slogan.`
  }
]
// render the slides data
const renderSlides = (slides) => {
  return slides.map( (slide, i) => (
    <li key={i+1}>
      <img src={slide.photoURL} />
      <div class={`caption ${slide.captionAlign}`}>
        <h3>{slide.title}</h3>
        <h5 class='light grey-text text-lighten-3'>{slide.description}</h5>
      </div>
    </li>
  ))
}
// HeroSlider component
function HeroSlider ({ trans, lang }) {
  const [slides, setSlides] = React.useState(_slides)
  React.useEffect(() => {
    initSlider()
    heroSlider = getSlider('hero-slider')
  }, [])
  return (
    <div id='hero-slider' class='slider'>
      <ul class='slides'>
        {renderSlides(slides)}
      </ul>
      <div className='slider-buttons'>
        <i class='material-icons forward'   onClick={moveSlider(lang, 'forward')}>arrow_forward_ios</i>
        <i class='material-icons backward'  onClick={moveSlider(lang, 'backward')}>arrow_back_ios</i>
      </div>
    </div>
  )
}
// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(HeroSlider);
