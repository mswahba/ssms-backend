import React from 'react'

import HeroSlider from './HeroSlider'
import NewsSection from './NewsSection'
import WelcomeSection from './WelcomeSection'
import VisionSection from './VisionSection'
import SupervisorMessage from '../about/SupervisorMessage'
import TwitterAndContactUs from './TwitterAndContactUs'
import SchoolMap from './SchoolMap'

export default function Home ({}) {
  return (
    <>
      {/* HeroSlider */}
      <HeroSlider />
      {/* NewsSection [4 cards] */}
      <NewsSection />
      {/* Welcome Section  */}
      <WelcomeSection />
      {/* Vision Section  */}
      <VisionSection />
      {/* Supervisor Message  */}
      <SupervisorMessage isSection={true} />
      {/* Twitter And ContactUs */}
      <TwitterAndContactUs />
      {/* school on google maps */}
      <SchoolMap />
    </>
  )
}
