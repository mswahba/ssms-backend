import React from 'react'
import { Link } from 'react-router-dom'

import { connect } from 'react-redux'
import { getTranslate, getActiveLanguage } from 'react-localize-redux'

import { time } from '../../helpers'
import { useFetch } from '../../customHooks'
import Loading from '../../shared/Loading'

const key = 'news_section'
const endpoint =
  "/db/query/SELECT TOP (4) * FROM [dbo].[articles] WHERE categoryIds like '%1%' ORDER BY articleId DESC"

function NewsCard ({
  lang,
  trans,
  articleId,
  articleDate,
  mainPhotoURL,
  articleTitleAr,
  articleTitleEn,
  articleTextAr,
  articleTextEn,
  authorNameAr,
  authorNameEn
}) {
  return (
    <div className="col s12 m6 l3">
      <div className="card">
        <div className="card-image">
          <Link to={`/news-details/${articleId}`}>
            <img src={mainPhotoURL} />
          </Link>
        </div>
        <div className="card-content">
          <Link to={`/news-details/${articleId}`}>
            <span className="card-title">{ (lang === 'ar')? articleTitleAr : articleTitleEn }</span>
            <p>{ (lang === 'ar')? articleTextAr.truncate(100) : articleTextEn.truncate(100) }</p>
          </Link>
        </div>
        <div className="card-action">
          <div>{ `${trans("home.news.Date")}: ${(new Date(articleDate)).toLocaleString('en-gb')}` }</div>
          <div>{ `${trans("home.news.Author")}: ${(lang === 'ar')? authorNameAr : authorNameEn}` }</div>
        </div>
      </div>
    </div>
  )
}

function NewsSection ({ trans, lang }) {
  // get slides from LS OR Server
  const { loading, error, data: news } = useFetch({
    requestId: key,
    request: ['get', endpoint],
    errorToast: ['error', 'something went wrong'],
    localStorageKey: key,
    timeout: time.hour
  })

  console.log("TCL: NewsSection -> news", news)

  return (
    <section className='news-section red lighten-1'>
      <div className='flex-between p-1'>
        <h3 className="m-0">{trans("home.news.title")}</h3>
        <Link to='/news-list'>{trans("home.news.newsListLink")}</Link>
      </div>
      { (loading)
        ? <Loading />
        : (error)
          ? <div className='card-panel red lighten-4'>{error}</div>
          : (news)
            ? <div className="row">
                {news.map(item => (
                  <NewsCard key={item.articleId} lang={lang} trans={trans} {...item} />
                ))}
              </div>
            : <div className='card-panel red lighten-4'>{trans("home.news.emptyNews")}</div>
      }
    </section>
  )
}

// select the values needed form redux state [get the translate function from localize]
const mapStateToProps = (state) => ({
  "trans": getTranslate(state.localize),
  "lang": getActiveLanguage(state.localize).code
})
// connect the form with the redux state
export default connect(mapStateToProps)(NewsSection);