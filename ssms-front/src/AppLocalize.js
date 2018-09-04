import React, { Component } from 'react'
import { renderToStaticMarkup } from 'react-dom/server'
import { BrowserRouter } from 'react-router-dom'
import { withLocalize } from 'react-localize-redux'
import AppRoutes from './AppRoutes'
import globalTranslations from './translations/global.json'

class AppLocalize extends Component {
  constructor(props) {
    super(props);
    // initialize localize
    props.initialize({
      languages: [
        { name: "English", code: "en" },
        { name: "Arabic",  code: "ar" }
      ],
      translation: globalTranslations,
      options: { renderInnerHtml: true, renderToStaticMarkup }
    });
    // set active language manually
    props.setActiveLanguage('ar');
  }
  render() {
    return (
      <BrowserRouter>
        <AppRoutes />
      </BrowserRouter>
    )
  }
}

export default withLocalize(AppLocalize);