import Home from './home/Home'
import Sections from './Sections'
import Facilities from './Facilities'
import Admission from './Admission'
import VisionMissionObjectives from './about/VisionMissionObjectives'
import SupervisorMessage from './about/SupervisorMessage'
import SchoolHistory from './about/SchoolHistory'
import OrganizationalStructure from './about/OrganizationalStructure'

export const navLinks = (trans) => ([
  { path: '/home', text: trans('home.nav.home'), icon: 'fas fa-home', component: Home },
  { path: '/sections', text: trans('home.nav.sections'), icon: 'fas fa-landmark', component: Sections },
  { path: '/facilities', text: trans('home.nav.facilities'), icon: 'fas fa-flask', component: Facilities },
  { path: '/admission', text: trans('home.nav.admission'), icon: 'fas fa-check-circle', component: Admission },
  {
    id: 'about-dropdown',
    icon: 'fas fa-info-circle',
    text: trans('home.nav.about'),
    path: '/about',
    children: [
      { path: '/about/vision-mission', text: trans("home.nav.visionMission"), component: VisionMissionObjectives },
      { path: '/about/supervisor-message', text: trans("home.nav.supervisorMessage"), component: SupervisorMessage },
      { path: '/about/school-history', text: trans("home.nav.schoolHistory"), component: SchoolHistory },
      { path: '/about/organizational-structure', text: trans("home.nav.organizationalStructure"), component: OrganizationalStructure },
    ]
  },
])

export const links = (trans) => ([

])

export const routes = (trans) => ([
  ...navLinks(trans),
  ...links(trans)
])
