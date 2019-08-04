import React from 'react'
import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import styled from 'styled-components'

import { useFetch } from '../customHooks'
import { time } from '../helpers'

import Loading from '../shared/Loading'

const key = 'contact_useful_social'
const contactEndpoint = '/abouts?filters=schoolId|=|1,categoryId|=|9'
const usefulEndpoint = '/abouts?filters=schoolId|=|1,categoryId|=|10'
const socialEndpoint = '/abouts?filters=schoolId|=|1,categoryId|=|7'

// const _socialColors = {
//   'Facebook': '#002a82',
//   'Youtube': '#b31217',
//   'Instagram': '#003789',
//   'Twitter': '#55acee',
//   'Snapchat': '#fffc00'
// }

const FooterWrapper = styled.footer`
  margin-bottom: 0 !important;
  background-color: var(--main-bg-color);
  color: #fff;
`
const Collection = styled.ul`
  border: none !important;
`
const SocialCollection = styled(Collection)`
  display: flex;
  flex-direction: column;
  align-items: center;
`
const CollectionItem = styled.li`
  background-color: transparent !important;
`
const SectionItem = styled(CollectionItem)`
  border-bottom: none !important;
`
const FooterIcon = styled.i`
  width: 2.5rem;
  font-size: 1.5rem;
  text-align: center;
`
const SocialWrapper = styled.div`
  margin-top: 1rem;
  width: 70%;
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
`
// color: ${({ title }) => `${_socialColors[title]} !important`};
const SocialIcon = styled.i`
  font-size: 3.5rem;
  margin: 0 0.5rem 1rem;
  color: #eaeaea !important;
  transition: transform 0.2s ease-out;
  &:hover {
    transform: scale(1.3);
  }
`
const ContactField = styled.span`
  margin-left: 0.5rem;
  font-size: 1.1rem;
  font-weight: 600;
  color: #fff9a5;
`
const SectionLink = styled.a`
  font-weight: 600;
  color: #fff9a5 !important;
  &:hover {
    color: #ffff00 !important;
    text-decoration: underline;
  }
`

const getSectionTitle = (id, trans) => {
  switch (id) {
    case 9:
      return trans("home.footer.contact")
    case 10:
      return trans("home.footer.useful")
    case 7:
      return trans("home.footer.social")
    default:
      return '';
  }
}

const getItemIcon = (title) => {
  switch (title) {
    case 'Address':
      return 'fas fa-map-marker-alt'
    case 'Phone':
      return 'fas fa-phone'
    case 'Email':
      return 'fas fa-at'
    case 'Fax':
      return 'fas fa-fax'
    case 'Postal Code':
      return 'fas fa-envelope'
    case 'Working Hours':
      return 'fas fa-clock'
    case 'Ministry Of Education':
    case 'Noor Portal':
    case 'School Admin Site':
    case 'School Books':
      return 'fas fa-link'
    case 'Phone':
      return 'fas fa-mobile-alt'
    case 'Twitter':
      return 'fab fa-twitter-square'
    case 'Youtube':
      return 'fab fa-youtube'
    case 'Facebook':
      return 'fab fa-facebook-square'
    case 'Instagram':
      return 'fab fa-instagram'
    case 'Snapchat':
      return 'fab fa-snapchat-square'
    default:
      return '';
  }
}

function SectionHeader ({ trans, categoryId }) {
  return (
    <CollectionItem className="collection-header w-75">
      <h6>{getSectionTitle(categoryId,trans)}</h6>
    </CollectionItem>
  )
}

function SectionContent ({ lang, item, id }) {
  switch (id) {
    case 9:
      return (
        <>
          <FooterIcon className={getItemIcon(item.aboutTitleEn)}></FooterIcon>
          <ContactField>{lang === 'ar' ? item.aboutTitleAr : item.aboutTitleEn}:</ContactField>
          <span>{lang === 'ar' ? item.aboutTextAr : item.aboutTextEn}</span>
        </>
      )
    case 10:
      return (
        <>
          <FooterIcon className={getItemIcon(item.aboutTitleEn)}></FooterIcon>
          <SectionLink href={item.aboutTextEn}>
            {lang === 'ar' ? item.aboutTitleAr : item.aboutTitleEn}
          </SectionLink>
        </>
      )
    case 7:
      return (
        <a href={item.aboutTextEn} className="flex-center">
          <SocialIcon title={item.aboutTitleEn} className={getItemIcon(item.aboutTitleEn)}></SocialIcon>
        </a>
      )
    default:
      return null;
  }
}

function FooterSection({ className = '', trans, lang, data  }) {
  if(data[0].categoryId === 7)
    return (
      <SocialCollection className={`collection with-header ${className}`}>
        <SectionHeader trans={trans} categoryId={data[0].categoryId} />
        <SocialWrapper>
          {data.map(item => (
            <SectionContent key={item.aboutId} lang={lang} item={item} id={item.categoryId} />
          ))}
        </SocialWrapper>
      </SocialCollection>
    )
  return (
    <Collection className={`collection with-header ${className}`}>
      <SectionHeader trans={trans} categoryId={data[0].categoryId} />
      {data.map(item => (
        <SectionItem key={item.aboutId} className='collection-item flex'>
          <SectionContent lang={lang} item={item} id={item.categoryId} />
        </SectionItem>
      ))}
    </Collection>
  )
}

function Footer({ trans, lang }) {
  // get data from LS OR Server
  const { loading, error, data } = useFetch({
    requestId: key,
    request: [
      ['get', contactEndpoint],
      ['get', usefulEndpoint],
      ['get', socialEndpoint]
    ],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.day
  })

  return (
    <FooterWrapper className="row">
    { (loading)
      ? <Loading />
      : (error)
        ? <div className='card-panel red lighten-4'>{JSON.stringify(error)}</div>
        : (data && data.length)
          ? <>
              <FooterSection className='col l5 m12' trans={trans} lang={lang} data={data[0]} />
              <FooterSection  className='col l4 m12' trans={trans} lang={lang} data={data[1]} />
              <FooterSection  className='col l3 m12' trans={trans} lang={lang} data={data[2]} />
            </>
          : <div className='card-panel red lighten-4'>{trans("home.emptyData")}</div>
    }
    </FooterWrapper>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(Footer)
