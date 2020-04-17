import Home from './pages/home/Home'
import Sections from './pages/Sections'
import Facilities from './pages/Facilities'
import Albums from './pages/Albums'
import AdmissionPolicy from './pages/admission/AdmissionPolicy'
import AdmissionProcedures from './pages/admission/AdmissionProcedures'
import Fees from './pages/admission/Fees'
import VisionMissionObjectives from './pages/about/VisionMissionObjectives'
import SupervisorMessage from './pages/about/SupervisorMessage'
import SchoolHistory from './pages/about/SchoolHistory'
import OrganizationalStructure from './pages/about/OrganizationalStructure'

export const navLinks = (trans) => ([
  { path: '/home', text: trans('MediaHome:nav.home'), icon: 'fas fa-home', component: Home },
  { path: '/sections', text: trans('MediaHome:nav.sections'), icon: 'fas fa-landmark', component: Sections },
  { path: '/facilities', text: trans('MediaHome:nav.facilities'), icon: 'fas fa-flask', component: Facilities },
  { path: '/albums', text: trans('MediaHome:nav.albums'), icon: 'fas fa-images', component: Albums },
  {
    id: 'admission-dropdown',
    path: '/admission',
    icon: 'fas fa-check-circle',
    text: trans('MediaHome:nav.admission'),
    children: [
      { path: '/admission/policy', text: trans("MediaHome:nav.policy"), component: AdmissionPolicy },
      { path: '/admission/procedures', text: trans("MediaHome:nav.procedures"), component: AdmissionProcedures },
      { path: '/admission/fees', text: trans("MediaHome:nav.fees"), component: Fees },
    ]
  },
  {
    id: 'about-dropdown',
    path: '/about',
    icon: 'fas fa-info-circle',
    text: trans('MediaHome:nav.about'),
    children: [
      { path: '/about/vision-mission', text: trans("MediaHome:nav.visionMission"), component: VisionMissionObjectives },
      { path: '/about/supervisor-message', text: trans("MediaHome:nav.supervisorMessage"), component: SupervisorMessage },
      { path: '/about/school-history', text: trans("MediaHome:nav.schoolHistory"), component: SchoolHistory },
      { path: '/about/organizational-structure', text: trans("MediaHome:nav.organizationalStructure"), component: OrganizationalStructure },
    ]
  },
])

export const otherLinks = (trans) => ([

])

export const routesList = (trans) => ([
  ...navLinks(trans),
  ...otherLinks(trans)
])
