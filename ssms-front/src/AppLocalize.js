import React, { Component, Fragment } from 'react'
import { renderToStaticMarkup } from 'react-dom/server'
import { BrowserRouter } from 'react-router-dom'
import { withLocalize } from 'react-localize-redux'
import AppRoutes from './AppRoutes'

class AppLocalize extends Component {
  constructor(props) {
    super(props);
    // import all translation files dynamically from './translations' dir
    // and concat them into one global translation object [globalTrans]
    const importAll = (r) => r.keys().map(r);
    const globalTrans = importAll(require.context('./translations', false, /\.json$/))
                          .reduce( (acc, _module) => {
                            acc = {...acc, ..._module};
                            return acc;
                          },{});
    // initialize localize
    props.initialize({
      languages: [
        { name: "English", code: "en" },
        { name: "Arabic",  code: "ar" }
      ],
      translation: globalTrans, //{...schoolsTrans, ...usersTrans},
      options: { renderInnerHtml: true, renderToStaticMarkup }
    });
    // set active language manually
    props.setActiveLanguage('ar');
  }
  render() {
    return (
      <Fragment>
        {/* <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-rc.2/css/materialize.min.css' /> */}
        <link rel="stylesheet" href='/materialize.rtl.min.css' />
        <BrowserRouter>
          {/* header */}
          {/* sidebar */}
          <AppRoutes />
          {/* footer */}
        </BrowserRouter>
      </Fragment>
    )
  }
}

export default withLocalize(AppLocalize);