import React from 'react'
import HeroSlider from './HeroSlider'
import NewsSection from './NewsSection'
import WelcomeSection from './WelcomeSection';
import VisionSection from './VisionSection';
import SupervisorMessage from '../about/SupervisorMessage';

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
      <SupervisorMessage />
      {/* Map */}
      {/* ContactUs */}
    </>
  )
}
