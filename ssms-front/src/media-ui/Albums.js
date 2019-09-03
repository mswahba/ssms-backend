import React from 'react'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'
import { Link } from 'react-router-dom'
import styled from 'styled-components'

import { useFetch, getData, INITIAL_STATE } from '../customHooks'
import { time } from '../helpers'

import Loading from '../shared/Loading'

const albumsKey = 'albums'
const photosKey = 'photos'
const albumsEndpoint = '/albums?filters=approved|=|1,enabled|=|1,albumId|>|1'
const photosEndpoint = '/photos?filters=approved|=|1,enabled|=|1,albumId|=|'

function Album({ lang, albumId, albumTitleAr, albumTitleEn, descriptionAr, descriptionEn, albumDate, mainPhoto }) {
  return (
    <div className="col s12 m6 l4">
      <div className="card">
        <div className="card-image">
          <Link to={`/album-photos/${albumId}`}>
            <img src={mainPhoto && mainPhoto.thumbURL} />
          </Link>
        </div>
        <div className="card-content">
          <Link to={`/album-photos/${albumId}`}>
            <span className="card-title">{ (lang === 'ar')? albumTitleAr : albumTitleEn }</span>
            { (lang === 'ar' && descriptionAr)
                ? <p>{descriptionAr.truncate(100)}</p>
                : (lang === 'en' && descriptionEn)
                  ? <p>{descriptionEn.truncate(100)}</p>
                  : null
            }
          </Link>
        </div>
        <div className="card-action">
          <div>{new Date(albumDate).toLocaleString('en-gb')}</div>
        </div>
      </div>
    </div>
  )
}

function Albums({ trans, lang }) {
  // get Albums from LS OR Server
  const { loading, error, data } = useFetch({
    requestId: albumsKey,
    request: ['get', albumsEndpoint],
    localStorageKey: albumsKey,
    errorToast: ['error', 'something went wrong'],
    timeout: time.day
  })
  // page state
  const [photosDTO, setPhotosDTO] = React.useState({ ...INITIAL_STATE })
  const [albums, setAlbums] = React.useState([])
  // when albums data arrive then get each albums photos
  React.useEffect(
    () => {
      if(data && data.length) {
        let requests = data.map(item => ['get', `${photosEndpoint}${item.albumId}`])
        getData({
          requestId: photosKey,
          request: requests,
          localStorageKey: photosKey,
          errorToast: ['error', 'something went wrong'],
          timeout: time.day,
          setState: setPhotosDTO
        })
      }
    },
    [data]
  )
  // when photos arrive then fill the albums array
  React.useEffect(
    () => {
      if(photosDTO.data && photosDTO.data.length) {
        let _albums = data.map( (album, i) => {
          album.mainPhoto = {
            photoURL: photosDTO.data[i][0].photoURL,
            thumbURL: photosDTO.data[i][0].thumbURL
          }
          return album
        })
        setAlbums(_albums)
      }
    },
    [photosDTO.data]
  )

  return (
    <>
      <h2>{trans("home.nav.albums")}</h2>
      { (loading)
        ? <Loading />
        : (error)
          ? <div className='card-panel red lighten-4'>{error}</div>
          : (data && data.length && albums && albums.length)
            ? <div className='row'>
                {albums.map(item => <Album key={item.albumId} lang={lang} {...item} /> )}
              </div>
            : <div className='card-panel red lighten-4'>{trans("home.emptyData")}</div>
      }
    </>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(Albums)
